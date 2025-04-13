using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using idsp2025_jared_green.Controllers;
using idsp2025_jared_green.Cron;
using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Entities.dto;
using idsp2025_jared_green.Forms;
using idsp2025_jared_green.Helpers;
using idsp2025_jared_green.Interfaces.Controllers;
using idsp2025_jared_green.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Quartz.Impl.AdoJobStore;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Timers;
using System.Transactions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Site = idsp2025_jared_green.Entities.Site;

namespace idsp2025_jared_green
{
    public partial class frmDashboard : Form
    {

        private readonly IDashboardController _dashboardController;
        private readonly ISessionManager _sessionManager;
        private readonly IPermissionController _permissionController;
        private readonly Dictionary<string, Delegate> _dataRetrievalFunctions;
        private readonly ILocationController _locationController;
        private readonly ITransactionController _transactionController;
        private readonly IInventoryController _inventoryController;
        private readonly IServiceProvider _serviceProvider;
        private readonly ISupplierController _supplierController;
        private System.Timers.Timer _orderSubmissionNotificationTimer;
        // To prevent Db Connection Pool Conflicts
        private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);
        private Dictionary<string, string> activeOrderFilters = new Dictionary<string, string>();

        //private readonly IAuthentication _authenticationService;
        private bool _permissionsLoaded = false;

        private IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

        //public frmDashboard(IDashboardController dashboardController, ISessionManager sessionManager, IPermissionController permissionController, IAuthentication authenticationService)
        public frmDashboard(IDashboardController dashboardController, IServiceProvider serviceProvider, ISessionManager sessionManager, IPermissionController permissionController, ILocationController locationController, ITransactionController transactionController, IInventoryController inventoryController, ISupplierController supplierController)
        {
            _dashboardController = dashboardController;
            _sessionManager = sessionManager;
            _permissionController = permissionController;
            _locationController = locationController;
            //_authenticationService = authenticationService;
            _transactionController = transactionController;
            _inventoryController = inventoryController;
            _supplierController = supplierController;
            _serviceProvider = serviceProvider;
            _dataRetrievalFunctions = new Dictionary<string, Delegate>
            {
                {"tabItems", async () => await GetItems()},
                {"tabEmployees", async () => await GetEmployees()},
                {"tabPermissions", async () => await GetPositions()},
                {"tabInventory", async () => await GetInventory()},
                {"tabLocations", async () => await GetLocations() },
                {"tabOrders", async () => await GetOrders() },
                {"tabSuppliers", async () => await GetSuppliers() },
                {"tabTransactions", async () => await GetTransactions() },
                {"tabCustomerOrders", async () => await GetOnlineOrders() }
            };
            InitializeOrderNotificationTimer();
            InitializeComponent();
        }

        private void InitializeOrderNotificationTimer()
        {
            _orderSubmissionNotificationTimer = new System.Timers.Timer();
            _orderSubmissionNotificationTimer.Interval = 300000;
            _orderSubmissionNotificationTimer.Elapsed += SetOrderSubmissionNotification;
            _orderSubmissionNotificationTimer.AutoReset = true;
            _orderSubmissionNotificationTimer.Start();
        }

        private async void SetOrderSubmissionNotification(object? sender, ElapsedEventArgs e)
        {


            if (this.InvokeRequired)
            {
                bool hasFocus = false;
                this.Invoke((MethodInvoker)(() => { hasFocus = this.ContainsFocus; }));
                if (!hasFocus) return;
            }
            else
            {
                if (!this.ContainsFocus) return;
            }


            // Make sure that this does not execute while any other operations are going on.
            await _semaphoreSlim.WaitAsync();
            try
            {
                // List<string> permissions = new List<string>()
                List<string> permissions = _sessionManager.GetPermissionsFromToken();

                // permissions.Add("Administrator");
                // permissions.Add("Warehouse Manager");
                if (await _transactionController.CheckForOrderSubmission((int)_orderSubmissionNotificationTimer.Interval) && (permissions.Contains("Administrator") || permissions.Contains("Warehouse Manager")) && tabDashboard.TabPages.Contains(tabOrders))
                // if (true)
                {
                    this.Invoke(delegate { nfIconOrderSubmitted.ShowBalloonTip(5000); });
                    this.Invoke(delegate { tabDashboard.TabPages["tabOrders"]!.ImageIndex = 0; });
                }
            }
            catch (SecurityTokenException stEx)
            {
                MessageBox.Show("There was a problem extracting your employee permissions from the session data. Please try logging in again.", "Permission Error");
                this.Close();
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        private void SessionManagerSessionExpired(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => SessionManagerSessionExpired(sender, e)));
            }
            else
            {
                // Handle session expired
                MessageBox.Show("Session expired. Please log in again.");
                this.Close();
            }
        }

        private void TrackUserActivity(Object sender, EventArgs e)
        {
            _sessionManager.ResetInactivityTimer();
        }

        public async Task<bool> GenerateKeyAndIV(string username)
        {
            try
            {
                var keyVaultUri = configuration["KeyVault:Uri"];

                // SecretClient is a class used to interact with Azure Key Vault secrets. It provides methods for storing,
                // retrieving and managing secrets.
                // DefaultAzureCredential is a class that provides a mechanism for authenticating to Azure Services.
                var client = new SecretClient(new Uri(keyVaultUri), new DefaultAzureCredential());

                byte[] key = GenerateRandomCryptographicKey(256);
                byte[] IV = GenerateRandomCryptographicKey(128);

                string keyString = Convert.ToBase64String(key);
                string IVString = Convert.ToBase64String(IV);
                string secretValueString = $"{keyString}:{IVString}";

                // Generate Secret Value Based on the Username Logged In.
                var secretName = username;

                await client.SetSecretAsync(secretName, secretValueString);

                // MessageBox.Show($"Secret '{secretName}' stored successfully.");
                return true;
            }
            catch (Exception ex)
            {
                // Need to add exception logging...
                return false;
            }
        }

        private async void FrmDashboard_Load(object sender, EventArgs e)
        {

            try
            {
                List<string> permissions = _sessionManager.GetPermissionsFromToken();

                //List<string> permissions = new List<string>();
                //permissions.Add("Administrator");
                // permissions.Add("Store Manager");
                // permissions.Add("Warehouse Manager");
                // permissions.Add("Warehouse Worker");
                //permissions.Add("Store");
                ApplyPermissions(permissions);

                // Set the labels
                List<string> usernameAndLocation = _sessionManager.ExtractUsernameAndLocation();
                lblUser.Text = usernameAndLocation[0];
                lblLocation.Text = usernameAndLocation[1];

                DisableButton(btnUpdateItem);
                // Employee tab
                DisableButton(btnEditEmployee);
                DisableButton(btnRemoveEmployee);
                DisableButton(btnAddNewEmployee);
                // Employee Permissions tab
                DisableButton(btnSetRoles);

            }
            catch (SecurityTokenException stEx)
            {
                MessageBox.Show("There was a problem extracting your employee permissions from the session data. Please try logging in again.", "Permission Error");
                this.Close();
            }
        }

        /*---  Set Labels based on the user that is logged in  ---*/

        private void SetUserLabel(string username)
        {
            lblUser.Text = username;
        }

        private void SetLocationLabel(string location)
        {
            lblLocation.Text = location;
        }

        /*---  Clear and Add Tabs  ---*/

        private void ClearTabs()
        {
            tabDashboard.TabPages.Clear();
        }

        // Pass a list of tab names based on the enum
        private void AddTabs(List<string> tabNames)
        {
            foreach (string name in tabNames)
            {
                TabPage tabPage = tabDashboard.TabPages[name];
                AddTab(tabPage);
            }

        }

        private void AddTab(TabPage tp)
        {
            tabDashboard.TabPages.Add(tp);
        }

        /*---  Refresh the Data Views for the Tabs  ---*/

        private void RefreshDGV(DataGridView dgv, BindingSource bs)
        {
            dgv.DataSource = bs;
        }

        private void ResetDGV(DataGridView dgv)
        {
            dgv.Refresh();
        }

        private void SetBindingSourceDataSource<T>(BindingSource bs, BindingList<T> bl)
        {
            bs.DataSource = bl;
        }

        private void SetDataGridViewDataSource<T>(DataGridView dgv, BindingSource bs)
        {
            dgv.DataSource = bs;
        }

        private void RefreshBindingSource(BindingSource bs)
        {
            bs.ResetBindings(true);
        }

        private void ReassignDataSource(DataGridView dgv)
        {
            var dataSource = dgv.DataSource;
            dgv.DataSource = null;
            dgv.DataSource = dataSource;
        }

        /*---  Events Related to Button Presses  ---*/

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            _sessionManager.Logout();
            this.Close();
        }

        public void RenameColumns(DataGridView dgv, List<string> columnNames, List<string> desiredColumnHeaders)
        {
            Console.WriteLine("Existing DataGridView Columns:");
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                Debug.WriteLine($"Column Name: {col.Name}");
            }


            for (int i = 0; i < columnNames.Count(); i++)
            {
                // Output debugging information
                Console.WriteLine($"Checking column: {columnNames[i]}");

                // Check if the column exists in the DataGridView
                if (dgv.Columns[columnNames[i]] != null)
                {
                    dgv.Columns[columnNames[i]].HeaderText = desiredColumnHeaders[i];
                    Console.WriteLine($"Set header text for column: {columnNames[i]}");
                }
                else
                {
                    // Output debugging information if the column is not found
                    Console.WriteLine($"Column '{columnNames[i]}' does not exist in the DataGridView.");
                    MessageBox.Show($"Column '{columnNames[i]}' does not exist in the DataGridView.", "Column Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void RemoveColumns(DataGridView dgv, List<string> columnNamesToRemove)
        {
            foreach (string column in columnNamesToRemove)
            {
                dgv.Columns.Remove(column);
            }
        }

        public void HideColumns(DataGridView dgv, List<string> columnNamesToHide)
        {
            foreach (string column in columnNamesToHide)
            {
                dgv.Columns[column].Visible = false;
            }
        }

        public void ReorderColumns(DataGridView dgv, List<string> columnOrder)
        {
            if (dgv.Columns != null)
            {
                for (int i = 0; i < columnOrder.Count; i++)
                {
                    dgv.Columns[columnOrder[i]].DisplayIndex = i;
                }
            }
        }

        public void SetColumnWidth(DataGridView dgv, List<int> columnWidths)
        {
            if (dgv.Columns != null)
            {
                for (int i = 0; i < columnWidths.Count; i++)
                {
                    dgv.Columns[i].Width = columnWidths[i];
                }
            }
        }

        public void SanitizeDGV(DataGridView dgv, List<string> columnsToRemove, List<string> columnNames, List<string> desiredColumns, List<string> columnOrder)
        {
            // RemoveColumns(dgv, columnsToRemove);
            HideColumns(dgv, columnsToRemove);
            RenameColumns(dgv, columnNames, desiredColumns);
            ReorderColumns(dgv, columnOrder);
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            TabPage? selectedTp = DetermineWhichTabIsSelected();

            if (selectedTp != null)
            {
                if (selectedTp.Name == "tabEmployees")
                {
                    await RefreshEmployeesTab(selectedTp);
                }
                else if (selectedTp.Name == "tabItems")
                {
                    await RefreshItemsTab(selectedTp);
                }
                else if (selectedTp.Name == "tabPermissions")
                {
                    await RefreshPermissionsTab(selectedTp);
                }
                else if (selectedTp.Name == "tabInventory")
                {
                    await RefreshInventoryTab(selectedTp);
                }
                else if (selectedTp.Name == "tabLocations")
                {
                    await RefreshLocationsTab(selectedTp);
                }
                else if (selectedTp.Name == "tabOrders")
                {
                    await RefreshOrdersTab(selectedTp);
                }
                else if (selectedTp.Name == "tabSuppliers")
                {
                    await RefreshSuppliersTab(selectedTp);
                }
                else if (selectedTp.Name == "tabTransactions")
                {
                    await RefreshTransactionsTab(selectedTp);
                }
                else if (selectedTp.Name == "tabCustomerOrders")
                {
                    await RefreshOnlineOrdersTab(selectedTp);
                }
            }
        }

        private async Task RefreshPermissionsTab(TabPage selectedTp)
        {
            var permissions = await DetermineWhichDataFunctionToExecute<Posn>(selectedTp);
            var func = _dataRetrievalFunctions["tabEmployees"] as Func<Task<BindingList<Employee>>>;
            if (func != null)
            {
                var employees = await func();
                SetBindingSourceDataSource<Employee>(bsEmployeesForPermissions, employees);
                SetDataGridViewDataSource<Employee>(dgvPermissions, bsEmployeesForPermissions);

                // Lists for Sanitizing the DataGridView
                List<string> columnsToRemove = new List<string>(["PositionID", "password", "Txnaudits", "Txns", "SiteId", "Email", "Notes", "Active", "Locked", "Employeeroles"]);
                List<string> columnNames = new List<string>(["EmployeeId", "FirstName", "LastName", "Username", "Position", "Site"]);
                List<string> desiredColumns = new List<string>(["Employee ID", "First Name", "Last Name", "Username", "Position", "Location"]);
                List<string> columnOrder = new List<string>(["EmployeeId", "FirstName", "LastName", "Username", "Position", "Site"]);

                if (!dgvPermissions.Columns.Contains("Roles"))
                {
                    var rolesCol = new DataGridViewTextBoxColumn
                    {
                        Name = "Roles",
                        HeaderText = "Employee Roles",
                        DataPropertyName = "Roles"
                    };
                    dgvPermissions.Columns.Add(rolesCol);
                }

                SanitizeDGV(dgvPermissions, columnsToRemove, columnNames, desiredColumns, columnOrder);
                EnableButton(btnSetRoles);

                foreach (DataGridViewRow row in dgvPermissions.Rows)
                {
                    Employee emp = row.DataBoundItem as Employee;
                    if (emp != null)
                    {
                        // Concatenate the role names
                        string employeeRoles = string.Join(", ", emp.Employeeroles.Where(er => er.Active == 1).Select(er => er.Position.PermissionLevel));

                        // Set the value of the Roles column for the current row
                        row.Cells["Roles"].Value = employeeRoles;
                    }
                }
            }
            lstRoles.Items.Clear();
            foreach (var role in permissions)
            {
                lstRoles.Items.Add(role);
            }
            _permissionsLoaded = true;
            SetListboxSelection();
        }

        private async Task RefreshItemsTab(TabPage selectedTp)
        {
            var items = await DetermineWhichDataFunctionToExecute<Item>(selectedTp);
            SetBindingSourceDataSource<Item>(bsItems, items);
            SetDataGridViewDataSource<Item>(dgvItems, bsItems);

            // Lists for Sanitizing the DataGridView
            List<string> columnsToRemove = new List<string>(["CategoryNavigation", "Inventories", "SupplierId", "Txnitems", "ImageLocation", "ImagePaths", "isSelected"]);
            List<string> columnNames = new List<string>(["ItemId", "Name", "Sku", "Description", "Category", "Weight", "CaseSize", "CostPrice", "RetailPrice", "Notes", "Active", "Supplier"]);
            List<string> desiredColumns = new List<string>(["Item ID", "Name", "SKU", "Description", "Category", "Weight", "Case Size", "Unit Price", "Retail Price", "Notes", "Active", "Supplier"]);
            List<string> columnOrder = new List<string>(["ItemId", "Name", "Sku", "Description", "Category", "Supplier", "Weight", "CaseSize", "CostPrice", "RetailPrice", "Notes", "Active"]);

            SanitizeDGV(dgvItems, columnsToRemove, columnNames, desiredColumns, columnOrder);
            EnableButton(btnUpdateItem);
        }

        private async Task RefreshEmployeesTab(TabPage selectedTp)
        {
            var employees = await DetermineWhichDataFunctionToExecute<Employee>(selectedTp);
            SetBindingSourceDataSource<Employee>(bsEmployees, employees);
            SetDataGridViewDataSource<Employee>(dgvEmployees, bsEmployees);

            // Lists for Sanitizing the DataGridView
            List<string> columnsToRemove = new List<string>(["PositionID", "password", "Txnaudits", "Txns", "SiteId", "Employeeroles"]);
            List<string> columnNames = new List<string>(["EmployeeId", "FirstName", "LastName", "Email", "Username", "Notes", "Locked", "Active", "Position", "Site"]);
            List<string> desiredColumns = new List<string>(["Employee ID", "First Name", "Last Name", "Email", "Username", "Notes", "Locked", "Active", "Position", "Location"]);
            List<string> columnOrder = new List<string>(["EmployeeId", "FirstName", "LastName", "Username", "Email", "Position", "Site", "Notes", "Active", "Locked"]);

            EnableButton(btnAddNewEmployee);
            SanitizeDGV(dgvEmployees, columnsToRemove, columnNames, desiredColumns, columnOrder);
        }

        private async Task RefreshLocationsTab(TabPage selectedTp)
        {
            var locations = await DetermineWhichDataFunctionToExecute<Site>(selectedTp);
            SetBindingSourceDataSource<Site>(bsLocations, locations);
            SetDataGridViewDataSource<Site>(dgvLocations, bsLocations);

            // Lists for Sanitizing the DataGridView
            List<string> columnsToRemove = new List<string>(["Employees", "Address2", "Inventories", "Province", "TxnSiteIdfromNavigations", "TxnSiteIdtoNavigations", "Txnaudits"]);
            List<string> columnNames = new List<string>(["SiteId", "SiteName", "Address", "City", "ProvinceId", "Country", "PostalCode", "Phone", "DayOfWeek", "DistanceFromWh", "Notes", "Active", "locationType"]);
            List<string> desiredColumns = new List<string>(["Site ID", "Location", "Address", "City", "Province", "Country", "Postal Code", "Phone", "Delivery Day", "Distance from Wh", "Notes", "Active", "Site Type"]);
            List<string> columnOrder = new List<string>(["SiteId", "SiteName", "Address", "City", "ProvinceId", "Country", "PostalCode", "Phone", "DayOfWeek", "DistanceFromWh", "Notes", "Active", "locationType"]);

            SanitizeDGV(dgvLocations, columnsToRemove, columnNames, desiredColumns, columnOrder);
            dgvLocations.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private async Task RefreshInventoryTab(TabPage selectedTp)
        {
            var inventory = await DetermineWhichDataFunctionToExecute<Inventory>(selectedTp);
            DataTable dt = DataTableConverter.ConvertToDataTable(inventory);
            bsInventory.DataSource = dt;
            dgvInventory.DataSource = dt;

            // Lists for Sanitizing the DataGridView

            //List<string> columnsToRemove = new List<string>(["SiteId", "ItemLocation", "Notes", "Site"]);
            List<string> columnsToRemove = new List<string>(["ItemLocation", "Notes", "Site"]);
            List<string> columnNames = new List<string>(["ItemId", "Quantity", "ReorderThreshold", "OptimumThreshold", "Item", "siteId"]);
            List<string> desiredColumns = new List<string>(["Item ID", "Quantity", "Reorder Threshold", "Optimum Threshold", "Description", "Site ID"]);
            List<string> columnOrder = new List<string>(["ItemId", "Item", "siteId", "Quantity", "ReorderThreshold", "OptimumThreshold"]);

            SanitizeDGV(dgvInventory, columnsToRemove, columnNames, desiredColumns, columnOrder);
            dgvInventory.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private async Task RefreshSuppliersTab(TabPage selectedTp)
        {
            var suppliers = await DetermineWhichDataFunctionToExecute<Supplier>(selectedTp);
            DataTable dt = DataTableConverter.ConvertToDataTable(suppliers);
            bsSuppliers.DataSource = dt;
            dgvSuppliers.DataSource = dt;

            // Lists for Sanitizing the DataGridView

            List<string> columnsToHide = new List<string>(["Address2", "Items", "ProvinceNavigation"]);
            List<string> columnNames = new List<string>(["SupplierID", "Name", "Address1", "City", "Country", "Province", "Postalcode", "Phone", "Contact", "Notes", "Active"]);
            List<string> desiredColumns = new List<string>(["Supplier ID", "Name", "Address", "City", "Country", "Province", "Postal Code", "Phone", "Contact", "Notes", "Active"]);
            List<string> columnOrder = new List<string>(["SupplierID", "Name", "Address1", "City", "Country", "Province", "Postalcode", "Phone", "Contact", "Notes", "Active"]);

            SanitizeDGV(dgvSuppliers, columnsToHide, columnNames, desiredColumns, columnOrder);
            dgvSuppliers.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private async Task RefreshTransactionsTab(TabPage selectedTp)
        {
            var transactions = await DetermineWhichDataFunctionToExecute<Txn>(selectedTp);
            DataTable dt = DataTableConverter.ConvertToDataTable(transactions);
            bsTransactionHistory.DataSource = dt;
            dgvTransactions.DataSource = dt;

            // Lists for Sanitizing the DataGridView

            List<string> columnsToHide = new List<string>(["Delivery", "Employee", "SiteIdFromNavigation", "SiteIdToNavigation", "TxnStatusNavigation", "TxnTypeNavigation", "TxnItems"]);
            List<string> columnNames = new List<string>(["TxnID", "EmployeeID", "SiteIDFrom", "SiteIDTo", "TxnStatus", "shipDate", "txnType", "Barcode", "createdDate", "DeliveryID", "emergencyDelivery", "notes"]);
            List<string> desiredColumns = new List<string>(["TransactionID", "Last Associated Employee", "Site From", "Site To", "Transaction Status", "Ship Date", "Transaction Type", "Barcode", "Created Date", "Delivery ID", "Emergency Delivery", "Notes"]);
            List<string> columnOrder = new List<string>(["TxnID", "EmployeeID", "SiteIDFrom", "SiteIDTo", "TxnStatus", "shipDate", "txnType", "Barcode", "createdDate", "DeliveryID", "emergencyDelivery", "notes"]);

            SanitizeDGV(dgvTransactions, columnsToHide, columnNames, desiredColumns, columnOrder);
            dgvTransactions.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private async Task RefreshOnlineOrdersTab(TabPage selectedTp)
        {
            var onlineOrders = await DetermineWhichDataFunctionToExecute<Txn>(selectedTp);
            DataTable dt = DataTableConverter.ConvertToDataTable(onlineOrders);
            DataView view = new DataView(dt);
            //view.RowFilter = "TxnStatus = 'NEW' AND TxnType = 'Online'";
            DataTable filtered = view.ToTable();

            bsCustomerOrders.DataSource = filtered;
            dgvCustomerOrders.DataSource = filtered;


            //// Lists for Sanitizing the DataGridView

            List<string> columnsToHide = new List<string>(["EmployeeId", "SiteIdfrom", "ShipDate", "EmergencyDelivery", "Notes", "Delivery", "Employee", "SiteIdFromNavigation", "SiteIdfromNavigation", "SiteIdtoNavigation", "TxnStatusNavigation", "TxnTypeNavigation", "TxnItems"]);
            List<string> columnNames = new List<string>([]);
            List<string> desiredColumns = new List<string>([]);
            List<string> columnOrder = new List<string>([]);

            SanitizeDGV(dgvCustomerOrders, columnsToHide, columnNames, desiredColumns, columnOrder);
            dgvTransactions.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private async Task RefreshOrdersTab(TabPage selectedTp)
        {
            var orders = await DetermineWhichDataFunctionToExecute<dtoOrders>(selectedTp);
            DataTable dt = DataTableConverter.ConvertToDataTable(orders);
            bsOrders.DataSource = dt;
            dgvOrders.DataSource = bsOrders;

            //SetBindingSourceDataSource<dtoOrders>(bsOrders, orders);
            //SetDataGridViewDataSource<dtoOrders>(dgvOrders, bsOrders);

            //Modify the columns
            //Lists for Sanitizing the DataGridView
            List<string> columnsToRemove = new List<string>(["DeliveryDateDisplay"]);
            List<string> columnNames = new List<string>(["txnID", "siteName", "txnType", "txnStatus", "itemCount", "totalWeight", "deliveryDate"]);
            List<string> desiredColumns = new List<string>(["OrderID", "Location", "Type", "Status", "Items", "Weight", "Delivery Date"]);
            List<string> columnOrder = new List<string>(["txnID", "txnType", "siteName", "txnStatus", "itemCount", "totalWeight", "deliveryDate"]);

            SanitizeDGV(dgvOrders, columnsToRemove, columnNames, desiredColumns, columnOrder);

            cboOrderLocation.Items.Clear();

            if (dt.Rows.Count > 0)
            {
                BindingList<Site> sites = await _locationController.GetBullseyeLocations();
                foreach (Site site in sites)
                {
                    cboOrderLocation.Items.Add(site.ToString());
                }
                cboOrderLocation.Items.Add("ALL");

                cboOrderLocation.Enabled = true;
                cboOrderStatus.Enabled = true;
                cboOrderType.Enabled = true;

                int indexMemoryType = cboOrderType.SelectedIndex == -1 ? -1 : cboOrderType.SelectedIndex;
                int indexMemoryStatus = cboOrderStatus.SelectedIndex == -1 ? -1 : cboOrderStatus.SelectedIndex;
                int indexMemoryLocation = cboOrderLocation.SelectedIndex == -1 ? -1 : cboOrderLocation.SelectedIndex;

                cboOrderType.SelectedIndex = -1;
                if (indexMemoryType == -1)
                {
                    cboOrderType.SelectedItem = "All";
                }
                else
                {
                    cboOrderType.SelectedIndex = indexMemoryType;
                }

                cboOrderStatus.SelectedIndex = -1;
                if (indexMemoryStatus == -1)
                {
                    cboOrderStatus.SelectedItem = "ACTIVE";
                }
                else
                {
                    cboOrderStatus.SelectedIndex = indexMemoryStatus;
                }

                cboOrderLocation.SelectedIndex = -1;
                if (indexMemoryLocation == -1)
                {
                    //Check if the user is an admin
                    List<string> roles = _sessionManager.GetPermissionsFromToken();
                    // List<string> roles = new List<string>();
                    // roles.Add("Administrator");
                    // roles.Add("Warehouse Manager");
                    if (roles.Contains("Administrator") || roles.Contains("Warehouse Manager") || roles.Contains("Warehouse Worker"))
                    {
                        cboOrderLocation.SelectedItem = "ALL";
                    }
                    else
                    {
                        if (lblUser.Text.Length > 0)
                        //if (lblUser.Text.Length == 0)
                        {
                            Site site = await _locationController.GetEmployeeLocation(lblUser.Text);
                            // Site site = await _locationController.GetEmployeeLocation("jperez");

                            if (site != null)
                            {
                                cboOrderLocation.SelectedItem = site.SiteName;
                            }
                        }
                    }
                }
                else
                {
                    cboOrderLocation.SelectedIndex = indexMemoryLocation;
                }
            }
        }

        private void ApplyMultipleFilters()
        {
            // Base filter (existing filters)

            // If no filters are applied, clear the filter
            if (activeOrderFilters.Count == 0)
            {
                bsOrders.RemoveFilter();
                return;
            }


            List<string> filters = new List<string>();

            foreach (var filter in activeOrderFilters.Values)
            {
                if (!string.IsNullOrEmpty(filter))
                {
                    filters.Add(filter);
                }
            }


            // Only apply filter if there is at least one valid filter
            if (filters.Count > 0)
            {
                bsOrders.Filter = string.Join(" AND ", filters);
            }
            else
            {
                bsOrders.RemoveFilter();
            }
        }

        /*---  Items Tab ---*/

        private async void btnUpdateItem_Click(object sender, EventArgs e)
        {
            if (ValidateInput.ItemInDGVSelected(dgvItems))
            {
                //frmUpdateItem frmUpdateItem = new frmUpdateItem(dgvItems.SelectedRows[0]);
                Item item = dgvItems.SelectedRows[0].DataBoundItem as Item;
                IItemController itemController = Program._serviceProvider.GetService<IItemController>();
                ISupplierController supplierController = Program._serviceProvider.GetService<ISupplierController>();
                frmUpdateItem frmUpdateItem = new frmUpdateItem(item, itemController, supplierController);
                frmUpdateItem.ShowDialog();
                await RefreshItemsTab(tabItems);
            }
        }

        /*---  Employees Tab  ---*/

        private async void btnAddNewEmployee_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.DataSource != null)
            {
                frmAddEmployee frmAddEmployee = Program._serviceProvider.GetRequiredService<frmAddEmployee>();
                frmAddEmployee.ShowDialog();
                await RefreshEmployeesTab(tabEmployees);
            }
        }

        private async void btnEditEmployee_Click(object sender, EventArgs e)
        {
            if (ValidateInput.ItemInDGVSelected(dgvEmployees))
            {
                Employee employee = dgvEmployees.SelectedRows[0].DataBoundItem as Employee;
                IEmployeeController employeeController = Program._serviceProvider.GetRequiredService<IEmployeeController>();
                IPermissionController permissionController = Program._serviceProvider.GetRequiredService<IPermissionController>();
                ILocationController locationController = Program._serviceProvider.GetRequiredService<ILocationController>();
                IAuthenticationController authenticationController = Program._serviceProvider.GetRequiredService<IAuthenticationController>();
                frmUpdateEmployee frmUpdateEmployee = new frmUpdateEmployee(employee, employeeController, permissionController, locationController, authenticationController);
                frmUpdateEmployee.ShowDialog();
                await RefreshEmployeesTab(tabEmployees);
            }

        }

        private async void btnRemoveEmployee_Click(object sender, EventArgs e)
        {
            if (ValidateInput.ItemInDGVSelected(dgvEmployees))
            {
                Employee? selectedEmployee = dgvEmployees.SelectedRows[0].DataBoundItem as Employee;
                if (selectedEmployee != null)
                {
                    frmConfirmUserDelete frmConfirmUserDelete = new frmConfirmUserDelete();

                    if (frmConfirmUserDelete.ShowDialog() == DialogResult.OK)
                    {
                        if (await _dashboardController.DeleteEmployee(selectedEmployee))
                        {
                            ReassignDataSource(dgvEmployees);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("An employee must be selected to remove.");
            }
        }

        /*---  Permissions Tab  ---*/
        private async void btnSetRoles_Click(object sender, EventArgs e)
        {
            if (dgvPermissions.SelectedRows.Count == 1 && lstRoles.SelectedItems.Count > 0)
            {
                List<Posn> selectedPermissions = [];
                foreach (Posn permission in lstRoles.SelectedItems)
                {
                    selectedPermissions.Add(permission);
                }
                await _permissionController.SetPermissions(dgvPermissions.SelectedRows[0].DataBoundItem as Employee, selectedPermissions);

                _permissionsLoaded = false;
                await RefreshPermissionsTab(tabPermissions);
            }
            else
            {
                MessageBox.Show("An employee must have at least one permission.", "Select a permission");
            }
            //ReassignDataSource(dgvPermissions);

        }

        /*---  Enabling of Controls  ---*/
        private void ToggleButtonState(Button btn)
        {
            btn.Enabled = !btn.Enabled;
        }

        private void EnableButton(Button btn)
        {
            btn.Enabled = true;
        }

        private void DisableButton(Button btn)
        {
            btn.Enabled = false;
        }


        private async Task<BindingList<T>> DetermineWhichDataFunctionToExecute<T>(TabPage tabPage) where T : class
        {
            if (_dataRetrievalFunctions.TryGetValue(tabPage.Name, out var dataRetrievalFunction))
            {
                var typedFunction = dataRetrievalFunction as Func<Task<BindingList<T>>>;
                if (typedFunction != null)
                {
                    return await typedFunction();
                }
            }
            return new BindingList<T>();
        }

        private TabPage? DetermineWhichTabIsSelected()
        {
            TabPage tp = null;

            //1. Check which tab is focused
            if (tabDashboard.TabPages.Count > 0 && tabDashboard.SelectedTab != null)
            {
                tp = tabDashboard.SelectedTab;
            }

            return tp;
        }


        /*---  Data Collection Events  ---*/

        private async Task<BindingList<Item>> GetItems()
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                BindingList<Item> blItems = await _dashboardController.GetItems();
                return blItems;
            }
            finally
            {
                _semaphoreSlim.Release();
            }


        }

        private async Task<BindingList<Employee>> GetEmployees()
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                BindingList<Employee> blEmployees = await _dashboardController.GetEmployees();
                return blEmployees;
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        private async Task<BindingList<Posn>> GetPositions()
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                BindingList<Posn> blPermissions = await _dashboardController.GetPositions();
                return blPermissions;
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        private async Task<BindingList<Inventory>> GetInventory()
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                Site site;
                List<string> roles = _sessionManager.GetPermissionsFromToken();
                //List<string> roles = [];
                //roles.Add("Administrator");

                BindingList<Inventory> inventoryList = new BindingList<Inventory>();
                if (roles.Contains("Administrator"))
                {
                    return await _inventoryController.GetAllInventory();
                }
                else
                {
                    if (lblUser.Text != "")
                    // if (lblUser.Text != "cpatstone")
                    {
                        site = await _locationController.GetEmployeeLocation(lblUser.Text);
                        // site = await _locationController.GetEmployeeLocation("cpatstone");
                        if (site != null)
                        {
                            return await _inventoryController.GetInventoryByLocation(site);
                        }
                        else
                        {
                            MessageBox.Show("Unable to get your location data for fetching the inventory data.", "Unable to fetch inventory data");
                            return inventoryList;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unable to get your employee details for fetching your location's inventory data.", "Unable to fetch inventory data");
                        return inventoryList;
                    }
                }
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        private async Task<BindingList<dtoOrders>> GetOrders()
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                BindingList<dtoOrders> orders = await _transactionController.GetAllStoreOrders();
                return orders;
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        private async Task<BindingList<Supplier>> GetSuppliers()
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                BindingList<Supplier> suppliers = await _supplierController.GetSuppliers() as BindingList<Supplier>;
                return suppliers;
            }
            finally
            {
                _semaphoreSlim.Release();
            }

        }

        private async Task<BindingList<Txn>> GetTransactions()
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                BindingList<Txn> transactions = await _transactionController.GetAllTransactions() as BindingList<Txn>;
                return transactions;
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        private async Task<BindingList<Txn>> GetOnlineOrders()
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                BindingList<Txn> transactions = await _transactionController.GetOnlineOrdersForStores() as BindingList<Txn>;
                return transactions;
            }
            finally
            {
                _semaphoreSlim.Release();
            }

        }

        private async Task<BindingList<Site>> GetLocations()
        {
            await _semaphoreSlim.WaitAsync();
            try
            {
                BindingList<Site> locations = await _locationController.GetBullseyeLocations();
                return locations;
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        private void lstRoles_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox? listRoles = sender as ListBox;
            if (listRoles != null)
            {
                e.DrawBackground();
                bool isSelected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;
                Color backGroundColor = isSelected ? Color.LightSteelBlue : Color.LightGray;
                Color textColour = isSelected ? Color.White : Color.Black;
                Color borderColour = Color.Black;

                using (Brush brush = new SolidBrush(backGroundColor))
                using (Brush textBrush = new SolidBrush(textColour))
                {
                    e.Graphics.FillRectangle(brush, e.Bounds);
                    e.Graphics.DrawString(listRoles.Items[e.Index].ToString(), e.Font!, textBrush, e.Bounds);
                }

                using (Pen borderPen = new Pen(borderColour))
                {
                    e.Graphics.DrawRectangle(borderPen, e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1);
                }
                e.DrawFocusRectangle();
            }
            else
            {
                return;
            }
        }

        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            EnableButton(btnEditEmployee);
            EnableButton(btnRemoveEmployee);
        }

        public void ApplyPermissions(List<string> employeePositions)
        {
            // Initial setup
            tabDashboard.TabPages.Clear();

            // Buttons
            btnUpdateItem.Visible = false;
            btnRemoveEmployee.Visible = false;
            btnEditEmployee.Visible = false;
            btnAddNewEmployee.Visible = false;
            foreach (string position in employeePositions)
            {
                switch (position)
                {
                    case "Regional Manager":
                        AddTabIfNotExists(tabEmployees);
                        AddTabIfNotExists(tabItems);
                        AddTabIfNotExists(tabLocations);
                        break;

                    case "Financial Manager":
                        AddTabIfNotExists(tabEmployees);
                        AddTabIfNotExists(tabItems);
                        AddTabIfNotExists(tabLocations);
                        break;

                    case "Warehouse Manager":
                        AddTabIfNotExists(tabEmployees);
                        AddTabIfNotExists(tabItems);
                        AddTabIfNotExists(tabOrders);
                        AddTabIfNotExists(tabLocations);
                        AddTabIfNotExists(tabInventory);
                        AddTabIfNotExists(tabSuppliers);
                        btnUpdateItem.Visible = true;
                        btnUpdateInventory.Visible = true;
                        btnBackOrder.Visible = true;
                        btnFulfillOrder.Visible = true;
                        btnAllocateInventory.Visible = true;
                        btnReceiveOrder.Visible = true;
                        btnCheckOrderSubmissions.Visible = true;
                        btnAddSupplier.Visible = true;
                        btnEditSupplier.Visible = true;
                        btnAddNewItem.Visible = true;
                        btnUpdateItem.Visible = true;
                        btnLossOrDamage.Visible = true;
                        btnReturn.Visible = true;
                        break;

                    case "Store Manager":
                        AddTabIfNotExists(tabEmployees);
                        AddTabIfNotExists(tabItems);
                        AddTabIfNotExists(tabOrders);
                        AddTabIfNotExists(tabLocations);
                        AddTabIfNotExists(tabInventory);
                        AddTabIfNotExists(tabCustomerOrders);
                        btnUpdateInventory.Visible = true;
                        btnCreateStandardOrder.Visible = true;
                        btnCreateEmergencyOrder.Visible = true;
                        btnDeliverStoreOrder.Visible = true;
                        btnPrepareOrder.Visible = true;
                        btnMarkCustPickup.Visible = true;
                        btnLossOrDamage.Visible = true;
                        btnReturn.Visible = true;
                        break;

                    case "Warehouse Worker":
                        AddTabIfNotExists(tabEmployees);
                        AddTabIfNotExists(tabItems);
                        AddTabIfNotExists(tabLocations);
                        AddTabIfNotExists(tabOrders);
                        btnFulfillOrder.Visible = true;
                        break;

                    case "Delivery":
                        //AddTabIfNotExists(tabEmployees);
                        //AddTabIfNotExists(tabItems);
                        AddTabIfNotExists(tabOrders);
                        btnPickUpOrder.Visible = true;
                        btnDeliverStoreOrder.Visible= true;
                        break;


                    case "Store Worker":
                        AddTabIfNotExists(tabEmployees);
                        AddTabIfNotExists(tabItems);
                        AddTabIfNotExists(tabLocations);
                        AddTabIfNotExists(tabOrders);
                        AddTabIfNotExists(tabCustomerOrders);
                        btnDeliverStoreOrder.Visible = true;
                        btnPickUpOrder.Visible = true;
                        break;

                    case "Administrator":
                        AddTabIfNotExists(tabEmployees);
                        AddTabIfNotExists(tabItems);
                        AddTabIfNotExists(tabPermissions);
                        AddTabIfNotExists(tabOrders);
                        AddTabIfNotExists(tabInventory);
                        AddTabIfNotExists(tabLocations);
                        AddTabIfNotExists(tabSuppliers);
                        AddTabIfNotExists(tabTransactions);
                        AddTabIfNotExists(tabCustomerOrders);
                        btnRemoveEmployee.Visible = true;
                        btnEditEmployee.Visible = true;
                        btnAddNewEmployee.Visible = true;
                        btnUpdateLocation.Visible = true;
                        btnAddLocation.Visible = true;
                        btnUpdateInventory.Visible = true;
                        btnCreateStandardOrder.Visible = true;
                        btnCreateEmergencyOrder.Visible = true;
                        btnBackOrder.Visible = true;
                        btnFulfillOrder.Visible = true;
                        btnAllocateInventory.Visible = true;
                        btnReceiveOrder.Visible = true;
                        btnCheckOrderSubmissions.Visible = true;
                        btnDeliverStoreOrder.Visible = true;
                        btnPrepareOrder.Visible = true;
                        btnAddSupplier.Visible = true;
                        btnEditSupplier.Visible = true;
                        btnPickUpOrder.Visible = true;
                        btnMarkCustPickup.Visible = true;
                        btnUpdateItem.Visible = true;
                        btnCancelTxn.Visible = true;
                        btnEditTxn.Visible = true;
                        btnAddNewItem.Visible = true;
                        btnUpdateItem.Visible = true;
                        btnLossOrDamage.Visible = true;
                        btnReturn.Visible = true;
                        // cboOnlineOrderStore.Visible = true;
                        break;

                    case "Online Customer":
                        AddTabIfNotExists(tabItems);
                        break;

                    default:
                        MessageBox.Show("Error: No employee permissions detected. Returning to Login");
                        _sessionManager.Logout();
                        this.Close();
                        break;
                }
            }
        }

        private void AddTabIfNotExists(TabPage page)
        {
            if (!tabDashboard.TabPages.Contains(page))
            {
                tabDashboard.TabPages.Add(page);
            }
        }

        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dgvPermissions_SelectionChanged(object sender, EventArgs e)
        {
            SetListboxSelection();
        }

        private void SetListboxSelection()
        {
            try
            {
                if (_permissionsLoaded)
                {
                    lstRoles.SelectedIndices.Clear();
                    string roleNames = dgvPermissions.SelectedRows[0].Cells["Roles"].Value.ToString();
                    if (roleNames != null)
                    {
                        var roles = roleNames.Split(",").Select(r => r.Trim()).ToArray();
                        for (int i = 0; i < lstRoles.Items.Count; i++)
                        {
                            if (lstRoles.Items[i] != null && roles != null)
                            {
                                foreach (var roleName in roles)
                                {
                                    // MessageBox.Show(lstRoles.Items[i].ToString());
                                    if (roleName == lstRoles.Items[i].ToString())
                                    {
                                        lstRoles.SetSelected(i, true);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error
            }

        }

        public static byte[] GenerateRandomCryptographicKey(int keySizeInBits)
        {
            // Convert from bits to bytes.
            byte[] key = new byte[keySizeInBits / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
            }
            return key;
        }

        private void frmDashboard_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string helpText = "The dashboard in the main portion of this application. From here, depending on an employee's permissions, a series of tabs will be presented, allowing the user to interact with the system and perform job-related tasks. To switch between tabs click on the desired tab from the tab bar. When a tab is selected, click the 'Load / refresh' button to reload the data for the tab. To exit the application click the 'sign-out' button in the top-right corner.";
            MessageBox.Show(helpText, "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtSearchInventory_TextChanged(object sender, EventArgs e)
        {
            // Not implemented 

            // If the data source is not null, filter the search results based on the text the user has typed.
            //if (dgvInventory.DataSource != null)
            //{
            //}
        }

        private async void btnUpdateLocation_Click(object sender, EventArgs e)
        {
            // Check that there is data selected
            if (dgvLocations.DataSource != null && dgvLocations.SelectedRows.Count == 1)
            {

                Site? location = dgvLocations.SelectedRows[0].DataBoundItem as Site;

                if (location != null)
                {
                    frmEditLocation? editLocation = _serviceProvider.GetService<frmEditLocation>();
                    if (editLocation != null)
                    {
                        editLocation.Tag = location;
                    }
                    //var formFactory = _serviceProvider.GetRequiredService<Func<Site, frmEditLocation>>();
                    //var form = formFactory(location);
                    editLocation.ShowDialog();
                    await RefreshLocationsTab(tabLocations);

                }
            }
        }

        private async void btnAddLocation_Click(object sender, EventArgs e)
        {
            frmAddLocation frmAddLocation = _serviceProvider.GetRequiredService<frmAddLocation>();
            frmAddLocation.ShowDialog();
            await RefreshLocationsTab(tabLocations);
        }

        private void cboOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (dgvOrders.DataSource != null && cboOrderStatus.SelectedIndex != -1)
            {
                string filterText = cboOrderStatus.Text;

                if (string.IsNullOrEmpty(filterText) || filterText == "ALL")
                {
                    activeOrderFilters.Remove("txnStatus");
                }
                else if (filterText == "ACTIVE")
                {
                    activeOrderFilters["txnStatus"] = "txnStatus NOT IN ('CLOSED', 'CANCELLED', 'COMPLETE', 'Complete')";
                }
                else
                {
                    activeOrderFilters["txnStatus"] = $"txnStatus = '{filterText}'";
                }

                ApplyMultipleFilters();
            }
        }

        private void cboOrderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvOrders.DataSource != null && cboOrderType.SelectedIndex != -1)
            {
                string filterText = cboOrderType.Text;

                if (string.IsNullOrEmpty(filterText) || filterText == "All")
                {
                    activeOrderFilters.Remove("txnType");
                }
                else
                {
                    activeOrderFilters["txnType"] = $"txnType = '{filterText}'";
                }

                ApplyMultipleFilters();
            }
        }

        private void ResetOrdersTab()
        {
            tabOrders.Invalidate();
        }

        private void tabDashboard_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage tabPage = tabOrders;
            Rectangle tabBounds = e.Bounds;
        }

        private async void btnAllocateInventory_Click(object sender, EventArgs e)
        {
            if (dgvOrders.DataSource != null && dgvOrders.SelectedRows.Count == 1)
            {

                //if (((Txn)dgvOrders.SelectedRows[0].DataBoundItem).TxnStatus == "RECEIVED")
                if (dgvOrders.SelectedRows[0].Cells[3].Value.ToString() == "RECEIVED")
                {
                    var formFactory = _serviceProvider.GetRequiredService<Func<int, int, frmAssignInventory>>();

                    BindingList<Employee> employees = await _dashboardController.GetEmployees();
                    Employee? employee = (from emp in employees where emp.Username == lblUser.Text select emp).FirstOrDefault();
                    if (employee != null)
                    {
                        var form = formFactory(Convert.ToInt32(dgvOrders.SelectedRows[0].Cells[0].Value.ToString()), employee.EmployeeId);
                        form.ShowDialog();
                        await RefreshOrdersTab(tabOrders);
                        
                    }
                }
                else
                {
                    MessageBox.Show("No 'RECEIVED' order to allocate inventory to.", "No 'RECEIVED' orders");
                    return;
                }
            }
            else
            {
                // MessageBox.Show("No order data loaded.", "No data");
                return;
            }
        }

        private void cboOrderLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvOrders.DataSource != null && cboOrderLocation.SelectedIndex != -1)
            {
                string filterText = cboOrderLocation.Text;

                if (string.IsNullOrEmpty(filterText) || filterText == "ALL")
                {
                    activeOrderFilters.Remove("siteName");
                }
                else
                {
                    activeOrderFilters["siteName"] = $"siteName LIKE '%{filterText}%'";
                }

                ApplyMultipleFilters();
            }
        }

        private async void btnReceiveOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 1 && dgvOrders.SelectedRows[0].DataBoundItem != null)
            {
                DataRowView drv = dgvOrders.SelectedRows[0].DataBoundItem as DataRowView;
                if (drv != null)
                {
                    try
                    {
                        dtoOrders receivedOrder = new dtoOrders
                        {
                            txnID = Convert.ToInt32(drv["txnID"]),
                            siteName = drv["siteName"].ToString(),
                            txnType = drv["txnType"].ToString(),
                            txnStatus = drv["txnStatus"].ToString(),
                            itemCount = Convert.ToInt32(drv["itemCount"]),
                            totalWeight = Convert.ToInt32(drv["totalWeight"]),
                            deliveryDate = null
                        };

                        if (receivedOrder.txnStatus == "SUBMITTED")
                        {
                            List<string> roles = _sessionManager.GetPermissionsFromToken();
                            // List<string> roles = [];
                            // roles.Add("Admin");
                            if ((roles.Contains("Administrator") || roles.Contains("Warehouse Manager")) && dgvOrders.SelectedRows.Count == 1 && dgvOrders.SelectedRows[0].DataBoundItem != null)
                            {
                                BindingList<Employee> employees = await _dashboardController.GetEmployees();
                                Employee? employee = (from emp in employees where emp.Username == lblUser.Text select emp).FirstOrDefault();
                                if (employee != null)
                                {
                                    await _transactionController.UpdateTransactionStatus(receivedOrder.txnID, employee.EmployeeId, "RECEIVED");
                                }
                                string orderType = cboOrderType.Text;
                                string orderStatus = cboOrderStatus.Text;
                                string location = cboOrderLocation.Text;
                                // Refresh the view and set the selectors back to what they were.
                                await RefreshOrdersTab(tabOrders);
                                cboOrderType.SelectedItem = orderType;
                                cboOrderStatus.SelectedItem = orderStatus;
                                cboOrderLocation.SelectedItem = location;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return;
                    }
                }
            }
        }

        private async void btnUpdateInventory_Click(object sender, EventArgs e)
        {

            //List<string> columnsToRemove = new List<string>(["SiteId", "ItemLocation", "Notes", "Site"]);
            //List<string> columnNames = new List<string>(["ItemId", "Quantity", "ReorderThreshold", "OptimumThreshold", "Item"]);

            if (dgvInventory.DataSource != null && dgvInventory.SelectedRows.Count == 1)
            {
                DataRowView? drv = dgvInventory.SelectedRows[0].DataBoundItem as DataRowView;
                Inventory inv = new Inventory
                {
                    ItemId = Convert.ToInt32(drv["ItemId"]),
                    SiteId = Convert.ToInt32(drv["SiteId"]),
                    ItemLocation = drv["ItemLocation"].ToString(),
                    Notes = drv["Notes"].ToString(),
                    Quantity = Convert.ToInt32(drv["Quantity"]),
                    ReorderThreshold = Convert.ToInt32(drv["ReorderThreshold"]),
                    OptimumThreshold = Convert.ToInt32(drv["OptimumThreshold"])
                };

                BindingList<Employee> employees = await _dashboardController.GetEmployees();
                Employee? employee = (from emp in employees where emp.Username == lblUser.Text select emp).FirstOrDefault();

                if (inv != null)
                {
                    if (employee.SiteId == inv.SiteId || employee.Employeeroles.Any(e => e.PositionId == 9999))
                    {
                        var formFactory = _serviceProvider.GetRequiredService<Func<Inventory, frmEditInventory>>();
                        var form = formFactory(inv);
                        form.Tag = drv["Item"].ToString();
                        form.ShowDialog();
                        await RefreshInventoryTab(tabInventory);
                    }
                    else
                    {
                        MessageBox.Show("Non-admin can only edit inventory for their location.", "Invalid request");
                    }
                }
            }
        }

        private async void btnCreateStandardOrder_Click(object sender, EventArgs e)
        {
            BindingList<Site> locations = await _locationController.GetBullseyeLocations();
            Site? employeeWorkplace = (from loc in locations where loc.SiteName == lblLocation.Text select loc).FirstOrDefault();
            // Site? employeeWorkplace = (from loc in locations where loc.SiteName == "Saint John Retail" select loc).FirstOrDefault();
            List<string> roles = _sessionManager.GetPermissionsFromToken();
            //List<string> roles = [];
            //roles.Add("Store Manager");
            if (roles.Contains("Administrator") && cboOrderLocation.SelectedIndex != -1)
            {
                employeeWorkplace = (from loc in locations where loc.SiteName == cboOrderLocation.Text select loc).FirstOrDefault();

            }


            if (employeeWorkplace != null && employeeWorkplace.locationType == "Store")
            // if (true)
            {
                Txn order = await _transactionController.CheckForOrder(employeeWorkplace.SiteId, 0);
                // Txn order = await _transactionController.CheckForOrder(1, 0);
                if (order != null)
                {
                    // Open the existing order
                    frmModifyOrder frmModifyOrder = _serviceProvider.GetRequiredService<frmModifyOrder>();
                    frmModifyOrder.Tag = order;
                    frmModifyOrder.ShowDialog();
                }
                else
                {
                    // Create the new order
                    //order = await _transactionController.CreateOrder(employeeWorkplace.SiteId, 0);
                    BindingList<Employee> employees = await _dashboardController.GetEmployees();
                    Employee? employee = (from emp in employees where emp.Username == lblUser.Text select emp).FirstOrDefault();
                    //Employee? employee = (from emp in employees where emp.Username == "jperez" select emp).FirstOrDefault();
                    if (employee != null)
                    {
                        order = await _transactionController.CreateOrder(employee.EmployeeId, employeeWorkplace.SiteId, 0);
                    }
                    frmModifyOrder frmModifyOrder = _serviceProvider.GetRequiredService<frmModifyOrder>();
                    frmModifyOrder.Tag = order;
                    frmModifyOrder.ShowDialog();
                }

                string orderType = cboOrderType.Text;
                string orderStatus = cboOrderStatus.Text;
                string location = cboOrderLocation.Text;
                // Refresh the view and set the selectors back to what they were.
                await RefreshOrdersTab(tabOrders);
                cboOrderType.SelectedItem = orderType;
                cboOrderStatus.SelectedItem = orderStatus;
                cboOrderLocation.SelectedItem = location;
            }
        }

        private async void btnCreateEmergencyOrder_Click(object sender, EventArgs e)
        {
            BindingList<Site> locations = await _locationController.GetBullseyeLocations();
            Site? employeeWorkplace = (from loc in locations where loc.SiteName == lblLocation.Text select loc).FirstOrDefault();
            //Site? employeeWorkplace = (from loc in locations where loc.SiteName == "Saint John Retail" select loc).FirstOrDefault();
            List<string> roles = _sessionManager.GetPermissionsFromToken();
            // List<string> roles = [];
            //roles.Add("Store Manager");
            if (roles.Contains("Administrator") && cboOrderLocation.SelectedIndex != -1)
            {
                employeeWorkplace = (from loc in locations where loc.SiteName == cboOrderLocation.Text select loc).FirstOrDefault();

            }

            if (employeeWorkplace != null && employeeWorkplace.locationType == "Store")
            {
                Txn order = await _transactionController.CheckForEmergencyOrder(employeeWorkplace.SiteId, 1);
                // Txn order = await _transactionController.CheckForOrder(1, 1);
                if (order != null)
                {
                    // Open the existing order
                    frmModifyOrder frmModifyOrder = _serviceProvider.GetRequiredService<frmModifyOrder>();
                    frmModifyOrder.Tag = order;
                    frmModifyOrder.ShowDialog();
                }
                else
                {
                    BindingList<Employee> employees = await _dashboardController.GetEmployees();
                    Employee? employee = (from emp in employees where emp.Username == lblUser.Text select emp).FirstOrDefault();
                    // Employee? employee = (from emp in employees where emp.Username == "jperez" select emp).FirstOrDefault();
                    if (employee != null)
                    {
                        order = await _transactionController.CreateOrder(employee.EmployeeId, employeeWorkplace.SiteId, 1);
                    }
                    frmModifyOrder frmModifyOrder = _serviceProvider.GetRequiredService<frmModifyOrder>();
                    frmModifyOrder.Tag = order;
                    frmModifyOrder.ShowDialog();
                }

                string orderType = cboOrderType.Text;
                string orderStatus = cboOrderStatus.Text;
                string location = cboOrderLocation.Text;
                // Refresh the view and set the selectors back to what they were.
                await RefreshOrdersTab(tabOrders);
                cboOrderType.SelectedItem = orderType;
                cboOrderStatus.SelectedItem = orderStatus;
                cboOrderLocation.SelectedItem = location;
            }
        }

        private async void btnFulfillOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 1 && dgvOrders.SelectedRows[0].DataBoundItem != null)
            {
                DataRowView drv = dgvOrders.SelectedRows[0].DataBoundItem as DataRowView;
                if (drv != null)
                {
                    try
                    {
                        dtoOrders fulfilledOrder = new dtoOrders
                        {
                            txnID = Convert.ToInt32(drv["txnID"]),
                            siteName = drv["siteName"].ToString(),
                            txnType = drv["txnType"].ToString(),
                            txnStatus = drv["txnStatus"].ToString(),
                            itemCount = Convert.ToInt32(drv["itemCount"]),
                            totalWeight = Convert.ToInt32(drv["totalWeight"]),
                            deliveryDate = null
                        };

                        if (fulfilledOrder.txnStatus == "ASSEMBLING")
                        {
                            List<string> roles = _sessionManager.GetPermissionsFromToken();
                            //List<string> roles = [];
                            //roles.Add("Administrator");
                            if (roles.Contains("Administrator") || roles.Contains("Warehouse Manager") || roles.Contains("Warehouse Worker"))
                            {
                                BindingList<Employee> employees = await _dashboardController.GetEmployees();
                                Employee? employee = (from emp in employees where emp.Username == lblUser.Text select emp).FirstOrDefault();
                                //Employee? employee = (from emp in employees where emp.Username == "htrent" select emp).FirstOrDefault();
                                if (employee != null)
                                {
                                    var formFactory = _serviceProvider.GetRequiredService<Func<int, frmFulfillOrder>>();
                                    frmFulfillOrder form = formFactory(employee.EmployeeId);
                                    form.Tag = fulfilledOrder;
                                    form.ShowDialog();

                                    string orderType = cboOrderType.Text;
                                    string orderStatus = cboOrderStatus.Text;
                                    string location = cboOrderLocation.Text;
                                    // Refresh the view and set the selectors back to what they were.
                                    await RefreshOrdersTab(tabOrders);
                                    cboOrderType.SelectedItem = orderType;
                                    cboOrderStatus.SelectedItem = orderStatus;
                                    cboOrderLocation.SelectedItem = location;
                                }
                                else
                                {
                                    MessageBox.Show("Error: Unable to access your employee details. Please try logging out and logging back in.", "Unable to access employee details.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        return;
                    }
                }
            }
        }

        private async void btnBackOrder_Click(object sender, EventArgs e)
        {
            List<string> roles = _sessionManager.GetPermissionsFromToken();
            //List<string> roles = [];
            //roles.Add("Administrator");
            //roles.Add("Warehouse Manager");

            if (cboOrderLocation.SelectedIndex != -1 && (roles.Contains("Administrator") || roles.Contains("Warehouse Manager")))
            {
                //Txn order = await _transactionController.CheckForOrder(employeeWorkplace.SiteId, 0);
                BindingList<Site> site = await _locationController.GetBullseyeLocations();
                Site? selectedSite = (from st in site where st.SiteName == cboOrderLocation.SelectedItem.ToString() select st).FirstOrDefault();
                if (selectedSite != null && selectedSite.locationType == "Store")
                {
                    BindingList<Employee> employees = await _dashboardController.GetEmployees();
                    // Employee? employee = (from emp in employees where emp.Username == lblUser.Text select emp).FirstOrDefault();
                    Employee? employee = (from emp in employees where emp.Username == "admin" select emp).FirstOrDefault();
                    Txn order = await _transactionController.CheckForBackorder(selectedSite.SiteId);
                    if (order != null)
                    {
                        // Open the existing order
                        frmModifyOrder frmModifyOrder = _serviceProvider.GetRequiredService<frmModifyOrder>();
                        frmModifyOrder.Tag = order;
                        frmModifyOrder.ShowDialog();
                    }
                    else
                    {
                        // Create the new order
                        //order = await _transactionController.CreateOrder(employeeWorkplace.SiteId, 0);
                        if (employee != null)
                        {
                            order = await _transactionController.CreateBackorder(employee.EmployeeId, selectedSite.SiteId, "");
                        }
                        frmModifyOrder frmModifyOrder = _serviceProvider.GetRequiredService<frmModifyOrder>();
                        frmModifyOrder.Tag = order;
                        frmModifyOrder.ShowDialog();
                    }

                    string orderType = cboOrderType.Text;
                    string orderStatus = cboOrderStatus.Text;
                    string location = cboOrderLocation.Text;
                    // Refresh the view and set the selectors back to what they were.
                    await RefreshOrdersTab(tabOrders);
                    cboOrderType.SelectedItem = orderType;
                    cboOrderStatus.SelectedItem = orderStatus;
                    cboOrderLocation.SelectedItem = location;
                }
            }
        }

        private async void tabDashboard_SelectedIndexChanged(object sender, EventArgs e)
        {
            //await SetOnlineOrderCombobox();

            if (tabDashboard.TabPages.Contains(tabOrders))
            {
                if (tabDashboard.SelectedTab == tabOrders && tabDashboard.TabPages["tabOrders"].ImageIndex == 0)
                {
                    tabDashboard.TabPages["tabOrders"].ImageIndex = -1;
                }
            }
        }

        //private async Task SetOnlineOrderCombobox()
        //{
        //    if (tabDashboard.TabPages.Contains(tabCustomerOrders))
        //    {
        //        if (tabDashboard.SelectedTab == tabCustomerOrders)
        //        {
        //            BindingList<Site> sites = await _locationController.GetBullseyeLocations();
        //            cboOnlineOrderStore.DataSource = sites;

        //            //// Get the txn id, 
        //            //BindingList<Employee> employees = await _dashboardController.GetEmployees();
        //            //Employee? employee = (from emp in employees where emp.Username == lblUser.Text select emp).FirstOrDefault();
        //            //cboOnlineOrderStore.SelectedItem = employee.Site;

        //            //List<string> roles = _sessionManager.GetPermissionsFromToken();

        //            //if (roles.Contains("Administrator"))
        //            //{
        //            //    cboOnlineOrderStore.SelectedIndex = 3;
        //            //}
        //        }
        //    }
        //}

        private async void btnAddSupplier_Click(object sender, EventArgs e)
        {
            frmAddSupplier frmAddSupplier = _serviceProvider.GetRequiredService<frmAddSupplier>();
            frmAddSupplier.ShowDialog();
            await RefreshSuppliersTab(tabSuppliers);
        }

        private async void btnEditSupplier_Click(object sender, EventArgs e)
        {
            // Check that a row is selected
            if (dgvSuppliers.SelectedRows.Count == 1)
            {
                // Get the selected row
                if (dgvSuppliers.SelectedRows[0].DataBoundItem != null)
                {
                    DataRowView drv = dgvSuppliers.SelectedRows[0].DataBoundItem as DataRowView;

                    if (drv != null)
                    {

                        Supplier selectedSupplier = new Supplier
                        {
                            SupplierId = Convert.ToInt32(drv["SupplierId"]),
                            Name = drv["Name"].ToString(),
                            Address1 = drv["Address1"].ToString(),
                            Address2 = drv["Address2"].ToString(),
                            City = drv["City"].ToString(),
                            Country = drv["Country"].ToString(),
                            Province = drv["Province"].ToString(),
                            Postalcode = drv["Postalcode"].ToString(),
                            Phone = drv["Phone"].ToString(),
                            Contact = drv["Contact"].ToString(),
                            Notes = drv["Notes"].ToString(),
                            Active = Convert.ToSByte(drv["Active"]),
                        };


                        if (selectedSupplier != null)
                        {
                            frmEditSupplier editSupplier = _serviceProvider.GetRequiredService<frmEditSupplier>();
                            editSupplier.Tag = selectedSupplier;
                            editSupplier.ShowDialog();

                            await RefreshSuppliersTab(tabSuppliers);
                        }
                    }
                }
            }
        }

        private void btnRemoveSupplier_Click(object sender, EventArgs e)
        {
            // Not implemented yet
            return;
        }

        private async void btnEditTxn_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.DataSource != null && dgvTransactions.SelectedRows.Count == 1)
            {
                DataRowView? drv = dgvTransactions.SelectedRows[0].DataBoundItem as DataRowView;

                if (drv != null)
                {

                    Txn selectedTransaction = new Txn
                    {
                        TxnId = Convert.ToInt32(drv["TxnId"]),
                        EmployeeId = Convert.ToInt32(drv["EmployeeId"]),
                        SiteIdto = Convert.ToInt32(drv["SiteIdto"]),
                        SiteIdfrom = Convert.ToInt32(drv["SiteIdfrom"]),
                        TxnStatus = drv["TxnStatus"].ToString(),
                        ShipDate = Convert.ToDateTime(drv["ShipDate"]),
                        TxnType = drv["TxnType"].ToString(),
                        BarCode = drv["BarCode"].ToString(),
                        CreatedDate = Convert.ToDateTime(drv["CreatedDate"]),
                        DeliveryId = drv["DeliveryId"] == DBNull.Value ? (int?)null : Convert.ToInt32(drv["DeliveryId"]),
                        EmergencyDelivery = drv["EmergencyDelivery"] == DBNull.Value ? (sbyte?)null : Convert.ToSByte(drv["EmergencyDelivery"]),
                        Notes = drv["Notes"] == DBNull.Value ? null : drv["Notes"].ToString(),
                    };

                    if (selectedTransaction != null && ((selectedTransaction.TxnStatus).ToUpper() != "CANCELLED" && (selectedTransaction.TxnStatus).ToUpper() != "COMPLETE" && (selectedTransaction.TxnStatus).ToUpper() != "REJECTED" && (selectedTransaction.TxnStatus).ToUpper() != "CLOSED"))
                    {
                        BindingList<Employee> employees = await _dashboardController.GetEmployees();
                        Employee? employee = (from emp in employees where emp.Username == lblUser.Text select emp).FirstOrDefault();
                        if (employee != null)
                        {
                            var formFactory = _serviceProvider.GetRequiredService<Func<int, frmModifyTxnRecord>>();
                            var form = formFactory(employee.EmployeeId);
                            form.Tag = selectedTransaction;
                            form.ShowDialog();

                            await RefreshTransactionsTab(tabTransactions);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unable to modify closed, completed, or rejected transactions.", "Modification of Transaction Forbidden");
                    }
                }
            }
        }

        private async void btnCancelTxn_Click(object sender, EventArgs e)
        {
            if (dgvTransactions.DataSource != null && dgvTransactions.SelectedRows.Count == 1)
            {
                DataRowView? drv = dgvTransactions.SelectedRows[0].DataBoundItem as DataRowView;

                if (drv != null)
                {

                    Txn selectedTransaction = new Txn
                    {
                        TxnId = Convert.ToInt32(drv["TxnId"]),
                        EmployeeId = Convert.ToInt32(drv["EmployeeId"]),
                        SiteIdto = Convert.ToInt32(drv["SiteIdto"]),
                        SiteIdfrom = Convert.ToInt32(drv["SiteIdfrom"]),
                        TxnStatus = drv["TxnStatus"].ToString(),
                        ShipDate = Convert.ToDateTime(drv["ShipDate"]),
                        TxnType = drv["TxnType"].ToString(),
                        BarCode = drv["BarCode"].ToString(),
                        CreatedDate = Convert.ToDateTime(drv["CreatedDate"]),
                        DeliveryId = drv["DeliveryId"] == DBNull.Value ? (int?)null : Convert.ToInt32(drv["DeliveryId"]),
                        EmergencyDelivery = drv["EmergencyDelivery"] == DBNull.Value ? (sbyte?)null : Convert.ToSByte(drv["EmergencyDelivery"]),
                        Notes = drv["Notes"] == DBNull.Value ? null : drv["Notes"].ToString(),
                    };

                    if (selectedTransaction != null)
                    {
                        if (selectedTransaction.TxnStatus.ToUpper() == "CANCELLED")
                        {
                            MessageBox.Show("Unable to cancel because this transaction has already been cancelled.", "Unable to cancel transaction");
                            return;
                        }

                        if (selectedTransaction.TxnStatus.ToUpper() == "COMPLETE" || selectedTransaction.TxnStatus.ToUpper() == "REJECTED" || selectedTransaction.TxnStatus.ToUpper() == "CLOSED")
                        {
                            MessageBox.Show("Unable to cancel because this transaction has already been closed.", "Unable to cancel transaction");
                            return;
                        }

                        if (selectedTransaction.TxnStatus.ToUpper() == "IN TRANSIT" || selectedTransaction.TxnStatus.ToUpper() == "DELIVERED")
                        {
                            MessageBox.Show("Unable to cancel because this order is already on its way.", "Unable to cancel transaction");
                            return;
                        }

                        BindingList<Employee> employees = await _dashboardController.GetEmployees();
                        Employee? employee = (from emp in employees where emp.Username == lblUser.Text select emp).FirstOrDefault();
                        if (employee != null)
                        {
                            //    // Move the inventory back to where it was
                            //    foreach (Txnitem txnItem in selectedTransaction.Txnitems)
                            //    {
                            //        _inventoryController.MoveInventory(selectedTransaction.SiteIdto, selectedTransaction.SiteIdfrom, selectedTransaction.);
                            //    }
                            if (selectedTransaction.SiteIdfrom == 3)
                            {
                                // Set txn Items back to the warehouse.
                                BindingList<Site> site = await _locationController.GetBullseyeLocations();
                                Site? selectedSite = (from st in site where st.SiteId == 3 select st).FirstOrDefault();
                                BindingList<Inventory> inv = await _inventoryController.GetInventoryByLocation(selectedSite);
                                List<Inventory> inventoryForOrder = [];

                                foreach (Inventory inventory in inv)
                                {
                                    if (inventory.ItemLocation == selectedTransaction.TxnId.ToString())
                                    {
                                        await _inventoryController.MoveInventory(3, 3, inventory.Quantity, inventory.ItemId, inventory.ItemLocation, "0");
                                    }
                                }
                            }

                            if (selectedTransaction.TxnStatus.ToUpper() == "PREPARED")
                            {
                                // Set txn Items back to the warehouse.
                                BindingList<Site> site = await _locationController.GetBullseyeLocations();
                                Site? selectedSite = (from st in site where st.SiteId == selectedTransaction.SiteIdfrom select st).FirstOrDefault();
                                BindingList<Inventory> inv = await _inventoryController.GetInventoryByLocation(selectedSite);
                                List<Inventory> inventoryForOrder = [];

                                foreach (Inventory inventory in inv)
                                {
                                    if (inventory.ItemLocation == selectedTransaction.TxnId.ToString())
                                    {
                                        await _inventoryController.MoveInventory(selectedSite.SiteId, selectedSite.SiteId, inventory.Quantity, inventory.ItemId, inventory.ItemLocation, "0");
                                    }
                                }
                            }

                            bool result = await _transactionController.UpdateTransactionStatus(selectedTransaction.TxnId, employee.EmployeeId, "CANCELLED");

                            await RefreshTransactionsTab(tabTransactions);
                            if (result)
                            {
                                MessageBox.Show($"Transaction {selectedTransaction.TxnId} has been cancelled.", "Transaction Cancelled");
                            }
                            else
                            {
                                MessageBox.Show("An unexpected error occurred while attempting to cancel the transaction. Transaction update failed.", "Unable to cancel transaction");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Unable to cancel because the logged in employee's ID could not be accessed.", "Unable to cancel transaction");
                        }
                    }
                }
            }
        }

        private async void btnCheckOrderSubmissions_Click(object sender, EventArgs e)
        {
            List<string> permissions = _sessionManager.GetPermissionsFromToken();

            if (await _transactionController.CheckForOrderSubmission((int)_orderSubmissionNotificationTimer.Interval) && ((permissions.Contains("Administrator") || permissions.Contains("Warehouse Manager")) && tabDashboard.TabPages.Contains(tabOrders)))
            {
                this.Invoke(delegate { nfIconOrderSubmitted.ShowBalloonTip(5000); });
                this.Invoke(delegate { tabDashboard.TabPages["tabOrders"]!.ImageIndex = 0; });
            }
        }


        private async void btnDeliverStoreOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 1)
            {
                DataRowView drv = dgvOrders.SelectedRows[0].DataBoundItem as DataRowView;
                if (drv != null)
                {

                    dtoOrders deliveredOrder = new dtoOrders
                    {
                        txnID = Convert.ToInt32(drv["txnID"]),
                        siteName = drv["siteName"].ToString(),
                        txnType = drv["txnType"].ToString(),
                        txnStatus = drv["txnStatus"].ToString(),
                        itemCount = Convert.ToInt32(drv["itemCount"]),
                        totalWeight = Convert.ToInt32(drv["totalWeight"]),
                        deliveryDate = null
                    };

                    if (deliveredOrder != null && (deliveredOrder.txnStatus == "IN TRANSIT" || deliveredOrder.txnStatus == "DELIVERED"))
                    {
                        // Get the txn id, 
                        BindingList<Employee> employees = await _dashboardController.GetEmployees();
                        Employee? employee = (from emp in employees where emp.Username == lblUser.Text select emp).FirstOrDefault();
                        List<string> roles = _sessionManager.GetPermissionsFromToken();


                        if (employee != null && roles.Contains("Administrator") || deliveredOrder.siteName == employee.Site.SiteName || roles.Contains("Delivery"))
                        {
                            // Move the quantities of all the items in the order.
                            BindingList<Txnitem> txnItems = await _transactionController.GetTxnItemsFromOrder(deliveredOrder.txnID);

                            var formFactory = _serviceProvider.GetRequiredService<Func<Employee, frmAcceptStoreOrder>>();
                            frmAcceptStoreOrder form = formFactory(employee);
                            form.Tag = deliveredOrder;
                            form.ShowDialog();

                            await RefreshOrdersTab(tabOrders);
                        }
                        else
                        {
                            MessageBox.Show("Only administrators or store employees may accept store orders for their location.", "Unable to proceed delivery");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Can only receive store orders that have a status of 'IN TRANSIT'.", "Unable to receive delivery");
                    }
                }
            }
        }

        private async void btnPickUpOrder_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count == 1)
            {
                DataRowView drv = dgvOrders.SelectedRows[0].DataBoundItem as DataRowView;
                if (drv != null)
                {

                    dtoOrders assembledOrder = new dtoOrders
                    {
                        txnID = Convert.ToInt32(drv["txnID"]),
                        siteName = drv["siteName"].ToString(),
                        txnType = drv["txnType"].ToString(),
                        txnStatus = drv["txnStatus"].ToString(),
                        itemCount = Convert.ToInt32(drv["itemCount"]),
                        totalWeight = Convert.ToInt32(drv["totalWeight"]),
                        deliveryDate = null
                    };

                    if (assembledOrder != null && assembledOrder.txnStatus.ToUpper() == "ASSEMBLED")
                    {
                        // Get the txn id, 
                        BindingList<Employee> employees = await _dashboardController.GetEmployees();
                        Employee? employee = (from emp in employees where emp.Username == lblUser.Text select emp).FirstOrDefault();
                        List<string> roles = _sessionManager.GetPermissionsFromToken();

                        // Move the quantities of all the items in the order.
                        BindingList<Txnitem> txnItems = await _transactionController.GetTxnItemsFromOrder(assembledOrder.txnID);
                        var formFactory = _serviceProvider.GetRequiredService<Func<Employee, frmPickupStoreOrder>>();
                        frmPickupStoreOrder form = formFactory(employee);
                        form.Tag = assembledOrder;
                        form.ShowDialog();

                        string orderType = cboOrderType.Text;
                        string orderStatus = cboOrderStatus.Text;
                        string location = cboOrderLocation.Text;
                        // Refresh the view and set the selectors back to what they were.
                        await RefreshOrdersTab(tabOrders);
                        cboOrderType.SelectedItem = orderType;
                        cboOrderStatus.SelectedItem = orderStatus;
                        cboOrderLocation.SelectedItem = location;
                    }
                }
            }
        }

        private async void btnPrepareOrder_Click(object sender, EventArgs e)
        {
            if (dgvCustomerOrders.SelectedRows.Count == 1)
            {

                DataRowView drv = dgvCustomerOrders.SelectedRows[0].DataBoundItem as DataRowView;
                if (drv != null)
                {

                    dtoOrders preparedOrder = new dtoOrders
                    {
                        txnID = Convert.ToInt32(drv["txnID"]),
                        siteName = drv["SiteIdto"].ToString(),
                        txnType = drv["txnType"].ToString(),
                        txnStatus = drv["txnStatus"].ToString(),
                        itemCount = 0,
                        totalWeight = 0,
                        deliveryDate = null
                    };

                    BindingList<Site> location = await _locationController.GetBullseyeLocations();
                    Site loc = (from l in location where l.SiteId.ToString() == preparedOrder.siteName select l).FirstOrDefault();
                    preparedOrder.siteName = loc.SiteName;

                    if (preparedOrder != null && preparedOrder.txnStatus == "NEW" && preparedOrder.txnType == "Online")
                    {

                        BindingList<Employee> employees = await _dashboardController.GetEmployees();
                        Employee? employee = (from emp in employees where emp.Username == lblUser.Text select emp).FirstOrDefault();
                        List<string> roles = _sessionManager.GetPermissionsFromToken();

                        if (employee != null && roles.Contains("Administrator") || preparedOrder.siteName == employee.Site.SiteName)
                        {
                            BindingList<Txnitem> txnItems = await _transactionController.GetTxnItemsFromOrder(preparedOrder.txnID);

                            var formFactory = _serviceProvider.GetRequiredService<Func<Employee, frmPrepareOnlineOrder>>();
                            frmPrepareOnlineOrder form = formFactory(employee);
                            form.Tag = preparedOrder;
                            form.ShowDialog();

                            await RefreshOnlineOrdersTab(tabCustomerOrders);
                        }
                        else
                        {
                            MessageBox.Show("Only administrators or store managers can receive orders and store managers may only accept store orders for their location.", "Unable to receive delivery");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Can only prepare store orders that have a status of 'NEW' and a type of 'Online'.", "Unable to prepare order");
                    }
                }
            }
        }

        private async void cboOnlineOrderStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            // await RefreshOnlineOrdersTab(tabCustomerOrders);
        }

        private async void btnMarkCustPickup_Click(object sender, EventArgs e)
        {
            if (dgvCustomerOrders.SelectedRows.Count == 1)
            {

                DataRowView drv = dgvCustomerOrders.SelectedRows[0].DataBoundItem as DataRowView;
                if (drv != null)
                {

                    dtoOrders preparedOrder = new dtoOrders
                    {
                        txnID = Convert.ToInt32(drv["txnID"]),
                        siteName = drv["SiteIdto"].ToString(),
                        txnType = drv["txnType"].ToString(),
                        txnStatus = drv["txnStatus"].ToString(),
                        itemCount = 0,
                        totalWeight = 0,
                        deliveryDate = null
                    };

                    if (preparedOrder != null && preparedOrder.txnStatus == "READY" && preparedOrder.txnType == "Online")
                    {

                        BindingList<Employee> employees = await _dashboardController.GetEmployees();
                        Employee? employee = (from emp in employees where emp.Username == lblUser.Text select emp).FirstOrDefault();
                        List<string> roles = _sessionManager.GetPermissionsFromToken();

                        if (employee != null && roles.Contains("Administrator") || preparedOrder.siteName == employee.Site.SiteId.ToString())
                        {
                            BindingList<Txnitem> txnItems = await _transactionController.GetTxnItemsFromOrder(preparedOrder.txnID);

                            // Return the delegate
                            var formFactory = _serviceProvider.GetRequiredService<Func<Employee, frmSignForOrder>>();
                            // Create the form
                            frmSignForOrder form = formFactory(employee);
                            form.Tag = preparedOrder;
                            form.ShowDialog();

                            await RefreshOnlineOrdersTab(tabCustomerOrders);
                        }
                        else
                        {
                            MessageBox.Show("Only administrators or store managers can receive orders and store managers may only accept store orders for their location.", "Unable to receive delivery");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Can only prepare store orders that have a status of 'READY' and a type of 'Online'.", "Unable to prepare order");
                    }
                }
            }
        }

        private async void btnLossOrDamage_Click(object sender, EventArgs e)
        {
            BindingList<Employee> employees = await _dashboardController.GetEmployees();
            Employee? employee = (from emp in employees where emp.Username == lblUser.Text select emp).FirstOrDefault();
            List<string> roles = _sessionManager.GetPermissionsFromToken();

            // Pass types to the delegate.
            var formFactory = _serviceProvider.GetRequiredService<Func<Employee, List<string>, frmLoss>>();
            frmLoss lossForm = formFactory(employee, roles);
            lossForm.ShowDialog();
            await RefreshInventoryTab(tabInventory);
        }

        private async void btnReturn_Click(object sender, EventArgs e)
        {
            BindingList<Employee> employees = await _dashboardController.GetEmployees();
            Employee? employee = (from emp in employees where emp.Username == lblUser.Text select emp).FirstOrDefault();
            List<string> roles = _sessionManager.GetPermissionsFromToken();

            var formFactory = _serviceProvider.GetRequiredService<Func<Employee, List<string>, frmReturn>>();
            frmReturn returnForm = formFactory(employee, roles);
            returnForm.ShowDialog();
            await RefreshInventoryTab(tabInventory);
        }

        private async void btnAddNewItem_Click(object sender, EventArgs e)
        {
            frmAddSupplierProduct addProductForm = _serviceProvider.GetRequiredService<frmAddSupplierProduct>();
            addProductForm.ShowDialog();
            await RefreshItemsTab(tabItems);
        }

        private void btnPlaceSupplierOrder_Click(object sender, EventArgs e)
        {
            frmSupplierOrder supplierOrderForm = _serviceProvider.GetRequiredService<frmSupplierOrder>();
            supplierOrderForm.ShowDialog();

        }
    }
}

