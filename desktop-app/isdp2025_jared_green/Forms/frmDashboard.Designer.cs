namespace idsp2025_jared_green
{
    partial class frmDashboard
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDashboard));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            picBullseyeLogo = new PictureBox();
            label1 = new Label();
            lblUser = new Label();
            label3 = new Label();
            lblLocation = new Label();
            btnSignOut = new Button();
            btnRefresh = new Button();
            imgLstNotification = new ImageList(components);
            bsEmployeesForPermissions = new BindingSource(components);
            bsItems = new BindingSource(components);
            bsEmployees = new BindingSource(components);
            bsInventory = new BindingSource(components);
            bsLocations = new BindingSource(components);
            bsOrders = new BindingSource(components);
            nfIconOrderSubmitted = new NotifyIcon(components);
            bsSuppliers = new BindingSource(components);
            bsTransactionHistory = new BindingSource(components);
            tabCustomerOrders = new TabPage();
            btnMarkCustPickup = new Button();
            cboOnlineOrderStore = new ComboBox();
            btnPrepareOrder = new Button();
            dgvCustomerOrders = new DataGridView();
            label15 = new Label();
            tabTransactions = new TabPage();
            btnEditTxn = new Button();
            btnCancelTxn = new Button();
            dgvTransactions = new DataGridView();
            label14 = new Label();
            tabSuppliers = new TabPage();
            btnPlaceSupplierOrder = new Button();
            btnEditSupplier = new Button();
            btnAddSupplier = new Button();
            dgvSuppliers = new DataGridView();
            label11 = new Label();
            tabOrders = new TabPage();
            btnPickUpOrder = new Button();
            btnDeliverStoreOrder = new Button();
            btnCheckOrderSubmissions = new Button();
            btnBackOrder = new Button();
            btnCreateEmergencyOrder = new Button();
            btnCreateStandardOrder = new Button();
            btnAllocateInventory = new Button();
            btnFulfillOrder = new Button();
            cboOrderLocation = new ComboBox();
            label13 = new Label();
            btnReceiveOrder = new Button();
            label10 = new Label();
            label9 = new Label();
            cboOrderStatus = new ComboBox();
            cboOrderType = new ComboBox();
            label8 = new Label();
            dgvOrders = new DataGridView();
            tabLocations = new TabPage();
            btnRemoveLocation = new Button();
            btnUpdateLocation = new Button();
            btnAddLocation = new Button();
            label7 = new Label();
            dgvLocations = new DataGridView();
            tabInventory = new TabPage();
            btnReturn = new Button();
            btnLossOrDamage = new Button();
            label12 = new Label();
            comboBox1 = new ComboBox();
            txtSearchInventory = new TextBox();
            lblSearchBar = new Label();
            btnUpdateInventory = new Button();
            label6 = new Label();
            dgvInventory = new DataGridView();
            tabPermissions = new TabPage();
            label2 = new Label();
            lstRoles = new ListBox();
            btnSetRoles = new Button();
            dgvPermissions = new DataGridView();
            tabEmployees = new TabPage();
            btnRemoveEmployee = new Button();
            btnEditEmployee = new Button();
            btnAddNewEmployee = new Button();
            label5 = new Label();
            dgvEmployees = new DataGridView();
            tabDashboard = new TabControl();
            tabItems = new TabPage();
            btnAddNewItem = new Button();
            label4 = new Label();
            btnUpdateItem = new Button();
            dgvItems = new DataGridView();
            bsCustomerOrders = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)picBullseyeLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsEmployeesForPermissions).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsEmployees).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsInventory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsLocations).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsSuppliers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsTransactionHistory).BeginInit();
            tabCustomerOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerOrders).BeginInit();
            tabTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            tabSuppliers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).BeginInit();
            tabOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            tabLocations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLocations).BeginInit();
            tabInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            tabPermissions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPermissions).BeginInit();
            tabEmployees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            tabDashboard.SuspendLayout();
            tabItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bsCustomerOrders).BeginInit();
            SuspendLayout();
            // 
            // picBullseyeLogo
            // 
            picBullseyeLogo.Image = Properties.Resources.bullseye;
            picBullseyeLogo.Location = new Point(55, 24);
            picBullseyeLogo.Name = "picBullseyeLogo";
            picBullseyeLogo.Size = new Size(161, 151);
            picBullseyeLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picBullseyeLogo.TabIndex = 0;
            picBullseyeLogo.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(271, 65);
            label1.Name = "label1";
            label1.Size = new Size(87, 38);
            label1.TabIndex = 1;
            label1.Text = "User: ";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUser
            // 
            lblUser.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUser.Location = new Point(350, 66);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(224, 38);
            lblUser.TabIndex = 2;
            lblUser.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(1331, 74);
            label3.Name = "label3";
            label3.Size = new Size(135, 38);
            label3.TabIndex = 3;
            label3.Text = "Location: ";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLocation
            // 
            lblLocation.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLocation.Location = new Point(1457, 73);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(267, 38);
            lblLocation.TabIndex = 4;
            lblLocation.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnSignOut
            // 
            btnSignOut.Location = new Point(1730, 76);
            btnSignOut.Name = "btnSignOut";
            btnSignOut.Size = new Size(112, 34);
            btnSignOut.TabIndex = 5;
            btnSignOut.Text = "&Sign Out";
            btnSignOut.UseVisualStyleBackColor = true;
            btnSignOut.Click += btnSignOut_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(1701, 946);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(137, 34);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "&Load / Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // imgLstNotification
            // 
            imgLstNotification.ColorDepth = ColorDepth.Depth32Bit;
            imgLstNotification.ImageStream = (ImageListStreamer)resources.GetObject("imgLstNotification.ImageStream");
            imgLstNotification.TransparentColor = Color.Transparent;
            imgLstNotification.Images.SetKeyName(0, "notifications_active_16dp_FF0000_FILL0_wght400_GRAD0_opsz20.png");
            // 
            // nfIconOrderSubmitted
            // 
            nfIconOrderSubmitted.BalloonTipIcon = ToolTipIcon.Info;
            nfIconOrderSubmitted.BalloonTipText = "\"An order requires your attention. Please visit the orders tab to receive the new order.";
            nfIconOrderSubmitted.BalloonTipTitle = "\"Order Submitted\"";
            nfIconOrderSubmitted.Icon = (Icon)resources.GetObject("nfIconOrderSubmitted.Icon");
            nfIconOrderSubmitted.Text = "Order Submitted By Store\r\n";
            nfIconOrderSubmitted.Visible = true;
            // 
            // tabCustomerOrders
            // 
            tabCustomerOrders.BackColor = Color.Gainsboro;
            tabCustomerOrders.Controls.Add(btnMarkCustPickup);
            tabCustomerOrders.Controls.Add(cboOnlineOrderStore);
            tabCustomerOrders.Controls.Add(btnPrepareOrder);
            tabCustomerOrders.Controls.Add(dgvCustomerOrders);
            tabCustomerOrders.Controls.Add(label15);
            tabCustomerOrders.Location = new Point(4, 34);
            tabCustomerOrders.Name = "tabCustomerOrders";
            tabCustomerOrders.Size = new Size(1779, 682);
            tabCustomerOrders.TabIndex = 8;
            tabCustomerOrders.Text = "Customer Orders";
            // 
            // btnMarkCustPickup
            // 
            btnMarkCustPickup.Location = new Point(33, 629);
            btnMarkCustPickup.Name = "btnMarkCustPickup";
            btnMarkCustPickup.Size = new Size(213, 34);
            btnMarkCustPickup.TabIndex = 4;
            btnMarkCustPickup.Text = "Picked Up By Customer";
            btnMarkCustPickup.UseVisualStyleBackColor = true;
            btnMarkCustPickup.Click += btnMarkCustPickup_Click;
            // 
            // cboOnlineOrderStore
            // 
            cboOnlineOrderStore.FormattingEnabled = true;
            cboOnlineOrderStore.Location = new Point(1471, 10);
            cboOnlineOrderStore.Name = "cboOnlineOrderStore";
            cboOnlineOrderStore.Size = new Size(275, 33);
            cboOnlineOrderStore.TabIndex = 3;
            cboOnlineOrderStore.Visible = false;
            cboOnlineOrderStore.SelectedIndexChanged += cboOnlineOrderStore_SelectedIndexChanged;
            // 
            // btnPrepareOrder
            // 
            btnPrepareOrder.Location = new Point(1553, 629);
            btnPrepareOrder.Name = "btnPrepareOrder";
            btnPrepareOrder.Size = new Size(192, 34);
            btnPrepareOrder.TabIndex = 2;
            btnPrepareOrder.Text = "Prepare Online Order";
            btnPrepareOrder.UseVisualStyleBackColor = true;
            btnPrepareOrder.Click += btnPrepareOrder_Click;
            // 
            // dgvCustomerOrders
            // 
            dgvCustomerOrders.AllowUserToAddRows = false;
            dgvCustomerOrders.AllowUserToDeleteRows = false;
            dgvCustomerOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomerOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomerOrders.Location = new Point(33, 51);
            dgvCustomerOrders.MultiSelect = false;
            dgvCustomerOrders.Name = "dgvCustomerOrders";
            dgvCustomerOrders.RowHeadersVisible = false;
            dgvCustomerOrders.RowHeadersWidth = 62;
            dgvCustomerOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomerOrders.Size = new Size(1713, 556);
            dgvCustomerOrders.TabIndex = 1;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.Location = new Point(22, 2);
            label15.Name = "label15";
            label15.Size = new Size(299, 48);
            label15.TabIndex = 0;
            label15.Text = "Customer Orders:";
            // 
            // tabTransactions
            // 
            tabTransactions.BackColor = Color.Gainsboro;
            tabTransactions.Controls.Add(btnEditTxn);
            tabTransactions.Controls.Add(btnCancelTxn);
            tabTransactions.Controls.Add(dgvTransactions);
            tabTransactions.Controls.Add(label14);
            tabTransactions.Location = new Point(4, 34);
            tabTransactions.Name = "tabTransactions";
            tabTransactions.Padding = new Padding(3);
            tabTransactions.Size = new Size(1779, 682);
            tabTransactions.TabIndex = 7;
            tabTransactions.Text = "Company Transactions";
            // 
            // btnEditTxn
            // 
            btnEditTxn.Location = new Point(1633, 635);
            btnEditTxn.Name = "btnEditTxn";
            btnEditTxn.Size = new Size(112, 34);
            btnEditTxn.TabIndex = 10;
            btnEditTxn.Text = "&Edit";
            btnEditTxn.UseVisualStyleBackColor = true;
            btnEditTxn.Visible = false;
            btnEditTxn.Click += btnEditTxn_Click;
            // 
            // btnCancelTxn
            // 
            btnCancelTxn.Location = new Point(1491, 635);
            btnCancelTxn.Name = "btnCancelTxn";
            btnCancelTxn.Size = new Size(112, 34);
            btnCancelTxn.TabIndex = 9;
            btnCancelTxn.Text = "&Cancel";
            btnCancelTxn.UseVisualStyleBackColor = true;
            btnCancelTxn.Visible = false;
            btnCancelTxn.Click += btnCancelTxn_Click;
            // 
            // dgvTransactions
            // 
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AllowUserToDeleteRows = false;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Location = new Point(33, 54);
            dgvTransactions.MultiSelect = false;
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.ReadOnly = true;
            dgvTransactions.RowHeadersVisible = false;
            dgvTransactions.RowHeadersWidth = 62;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.Size = new Size(1712, 566);
            dgvTransactions.TabIndex = 8;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(23, 3);
            label14.Name = "label14";
            label14.Size = new Size(469, 48);
            label14.TabIndex = 0;
            label14.Text = "Bullseye Transaction History:";
            // 
            // tabSuppliers
            // 
            tabSuppliers.BackColor = Color.Gainsboro;
            tabSuppliers.Controls.Add(btnPlaceSupplierOrder);
            tabSuppliers.Controls.Add(btnEditSupplier);
            tabSuppliers.Controls.Add(btnAddSupplier);
            tabSuppliers.Controls.Add(dgvSuppliers);
            tabSuppliers.Controls.Add(label11);
            tabSuppliers.Location = new Point(4, 34);
            tabSuppliers.Name = "tabSuppliers";
            tabSuppliers.Padding = new Padding(3);
            tabSuppliers.Size = new Size(1779, 682);
            tabSuppliers.TabIndex = 6;
            tabSuppliers.Text = "Suppliers";
            // 
            // btnPlaceSupplierOrder
            // 
            btnPlaceSupplierOrder.Location = new Point(19, 635);
            btnPlaceSupplierOrder.Name = "btnPlaceSupplierOrder";
            btnPlaceSupplierOrder.Size = new Size(191, 34);
            btnPlaceSupplierOrder.TabIndex = 11;
            btnPlaceSupplierOrder.Text = "Place Supplier Order";
            btnPlaceSupplierOrder.UseVisualStyleBackColor = true;
            btnPlaceSupplierOrder.Visible = false;
            btnPlaceSupplierOrder.Click += btnPlaceSupplierOrder_Click;
            // 
            // btnEditSupplier
            // 
            btnEditSupplier.Location = new Point(1505, 635);
            btnEditSupplier.Name = "btnEditSupplier";
            btnEditSupplier.Size = new Size(112, 34);
            btnEditSupplier.TabIndex = 10;
            btnEditSupplier.Text = "&Edit";
            btnEditSupplier.UseVisualStyleBackColor = true;
            btnEditSupplier.Visible = false;
            btnEditSupplier.Click += btnEditSupplier_Click;
            // 
            // btnAddSupplier
            // 
            btnAddSupplier.Location = new Point(1637, 635);
            btnAddSupplier.Name = "btnAddSupplier";
            btnAddSupplier.Size = new Size(112, 34);
            btnAddSupplier.TabIndex = 9;
            btnAddSupplier.Text = "&Add";
            btnAddSupplier.UseVisualStyleBackColor = true;
            btnAddSupplier.Visible = false;
            btnAddSupplier.Click += btnAddSupplier_Click;
            // 
            // dgvSuppliers
            // 
            dgvSuppliers.AllowUserToAddRows = false;
            dgvSuppliers.AllowUserToDeleteRows = false;
            dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSuppliers.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvSuppliers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSuppliers.Location = new Point(19, 54);
            dgvSuppliers.MultiSelect = false;
            dgvSuppliers.Name = "dgvSuppliers";
            dgvSuppliers.ReadOnly = true;
            dgvSuppliers.RowHeadersVisible = false;
            dgvSuppliers.RowHeadersWidth = 62;
            dgvSuppliers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSuppliers.Size = new Size(1730, 570);
            dgvSuppliers.TabIndex = 8;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(19, 3);
            label11.Name = "label11";
            label11.Size = new Size(310, 48);
            label11.TabIndex = 0;
            label11.Text = "Supplier Manager:";
            // 
            // tabOrders
            // 
            tabOrders.BackColor = Color.Gainsboro;
            tabOrders.Controls.Add(btnPickUpOrder);
            tabOrders.Controls.Add(btnDeliverStoreOrder);
            tabOrders.Controls.Add(btnCheckOrderSubmissions);
            tabOrders.Controls.Add(btnBackOrder);
            tabOrders.Controls.Add(btnCreateEmergencyOrder);
            tabOrders.Controls.Add(btnCreateStandardOrder);
            tabOrders.Controls.Add(btnAllocateInventory);
            tabOrders.Controls.Add(btnFulfillOrder);
            tabOrders.Controls.Add(cboOrderLocation);
            tabOrders.Controls.Add(label13);
            tabOrders.Controls.Add(btnReceiveOrder);
            tabOrders.Controls.Add(label10);
            tabOrders.Controls.Add(label9);
            tabOrders.Controls.Add(cboOrderStatus);
            tabOrders.Controls.Add(cboOrderType);
            tabOrders.Controls.Add(label8);
            tabOrders.Controls.Add(dgvOrders);
            tabOrders.Location = new Point(4, 34);
            tabOrders.Name = "tabOrders";
            tabOrders.Padding = new Padding(3);
            tabOrders.Size = new Size(1779, 682);
            tabOrders.TabIndex = 5;
            tabOrders.Text = "Orders";
            // 
            // btnPickUpOrder
            // 
            btnPickUpOrder.Location = new Point(1014, 629);
            btnPickUpOrder.Name = "btnPickUpOrder";
            btnPickUpOrder.Size = new Size(134, 34);
            btnPickUpOrder.TabIndex = 19;
            btnPickUpOrder.Text = "Driver Pickup";
            btnPickUpOrder.UseVisualStyleBackColor = true;
            btnPickUpOrder.Visible = false;
            btnPickUpOrder.Click += btnPickUpOrder_Click;
            // 
            // btnDeliverStoreOrder
            // 
            btnDeliverStoreOrder.Location = new Point(838, 629);
            btnDeliverStoreOrder.Name = "btnDeliverStoreOrder";
            btnDeliverStoreOrder.Size = new Size(165, 34);
            btnDeliverStoreOrder.TabIndex = 17;
            btnDeliverStoreOrder.Text = "Manage Delivery";
            btnDeliverStoreOrder.UseVisualStyleBackColor = true;
            btnDeliverStoreOrder.Visible = false;
            btnDeliverStoreOrder.Click += btnDeliverStoreOrder_Click;
            // 
            // btnCheckOrderSubmissions
            // 
            btnCheckOrderSubmissions.Location = new Point(645, 629);
            btnCheckOrderSubmissions.Name = "btnCheckOrderSubmissions";
            btnCheckOrderSubmissions.Size = new Size(177, 34);
            btnCheckOrderSubmissions.TabIndex = 16;
            btnCheckOrderSubmissions.Text = "Check Submissions";
            btnCheckOrderSubmissions.UseVisualStyleBackColor = true;
            btnCheckOrderSubmissions.Visible = false;
            btnCheckOrderSubmissions.Click += btnCheckOrderSubmissions_Click;
            // 
            // btnBackOrder
            // 
            btnBackOrder.Location = new Point(499, 629);
            btnBackOrder.Name = "btnBackOrder";
            btnBackOrder.Size = new Size(130, 34);
            btnBackOrder.TabIndex = 15;
            btnBackOrder.Text = "&Back Order";
            btnBackOrder.UseVisualStyleBackColor = true;
            btnBackOrder.Visible = false;
            btnBackOrder.Click += btnBackOrder_Click;
            // 
            // btnCreateEmergencyOrder
            // 
            btnCreateEmergencyOrder.Location = new Point(317, 629);
            btnCreateEmergencyOrder.Name = "btnCreateEmergencyOrder";
            btnCreateEmergencyOrder.Size = new Size(166, 34);
            btnCreateEmergencyOrder.TabIndex = 14;
            btnCreateEmergencyOrder.Text = "&Emergency Order";
            btnCreateEmergencyOrder.UseVisualStyleBackColor = true;
            btnCreateEmergencyOrder.Visible = false;
            btnCreateEmergencyOrder.Click += btnCreateEmergencyOrder_Click;
            // 
            // btnCreateStandardOrder
            // 
            btnCreateStandardOrder.Location = new Point(149, 629);
            btnCreateStandardOrder.Name = "btnCreateStandardOrder";
            btnCreateStandardOrder.Size = new Size(152, 34);
            btnCreateStandardOrder.TabIndex = 13;
            btnCreateStandardOrder.Text = "&Standard Order";
            btnCreateStandardOrder.UseVisualStyleBackColor = true;
            btnCreateStandardOrder.Visible = false;
            btnCreateStandardOrder.Click += btnCreateStandardOrder_Click;
            // 
            // btnAllocateInventory
            // 
            btnAllocateInventory.Location = new Point(1411, 629);
            btnAllocateInventory.Name = "btnAllocateInventory";
            btnAllocateInventory.Size = new Size(181, 34);
            btnAllocateInventory.TabIndex = 12;
            btnAllocateInventory.Text = "&Allocate Inventory";
            btnAllocateInventory.UseVisualStyleBackColor = true;
            btnAllocateInventory.Visible = false;
            btnAllocateInventory.Click += btnAllocateInventory_Click;
            // 
            // btnFulfillOrder
            // 
            btnFulfillOrder.Location = new Point(19, 629);
            btnFulfillOrder.Name = "btnFulfillOrder";
            btnFulfillOrder.Size = new Size(114, 34);
            btnFulfillOrder.TabIndex = 11;
            btnFulfillOrder.Text = "&Fulfill Order";
            btnFulfillOrder.UseVisualStyleBackColor = true;
            btnFulfillOrder.Visible = false;
            btnFulfillOrder.Click += btnFulfillOrder_Click;
            // 
            // cboOrderLocation
            // 
            cboOrderLocation.Enabled = false;
            cboOrderLocation.FormattingEnabled = true;
            cboOrderLocation.Location = new Point(983, 10);
            cboOrderLocation.Name = "cboOrderLocation";
            cboOrderLocation.Size = new Size(272, 33);
            cboOrderLocation.TabIndex = 10;
            cboOrderLocation.SelectedIndexChanged += cboOrderLocation_SelectedIndexChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(894, 14);
            label13.Name = "label13";
            label13.Size = new Size(83, 25);
            label13.TabIndex = 9;
            label13.Text = "Location:";
            // 
            // btnReceiveOrder
            // 
            btnReceiveOrder.Location = new Point(1607, 629);
            btnReceiveOrder.Name = "btnReceiveOrder";
            btnReceiveOrder.Size = new Size(141, 34);
            btnReceiveOrder.TabIndex = 8;
            btnReceiveOrder.Text = "&Receive Order";
            btnReceiveOrder.UseVisualStyleBackColor = true;
            btnReceiveOrder.Visible = false;
            btnReceiveOrder.Click += btnReceiveOrder_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(1537, 13);
            label10.Name = "label10";
            label10.Size = new Size(64, 25);
            label10.TabIndex = 6;
            label10.Text = "Status:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(1261, 14);
            label9.Name = "label9";
            label9.Size = new Size(104, 25);
            label9.TabIndex = 5;
            label9.Text = "Order Type:";
            // 
            // cboOrderStatus
            // 
            cboOrderStatus.Enabled = false;
            cboOrderStatus.FormattingEnabled = true;
            cboOrderStatus.Items.AddRange(new object[] { "NEW", "SUBMITTED", "ASSEMBLING", "ASSEMBLED", "IN TRANSIT", "DELIVERED", "COMPLETE", "REJECTED ", "CANCELLED", "ACTIVE", "ALL" });
            cboOrderStatus.Location = new Point(1607, 10);
            cboOrderStatus.Name = "cboOrderStatus";
            cboOrderStatus.Size = new Size(141, 33);
            cboOrderStatus.TabIndex = 3;
            cboOrderStatus.SelectedIndexChanged += cboOrderStatus_SelectedIndexChanged;
            // 
            // cboOrderType
            // 
            cboOrderType.Enabled = false;
            cboOrderType.FormattingEnabled = true;
            cboOrderType.Items.AddRange(new object[] { "Store Order", "Emergency Order", "Back Order", "All" });
            cboOrderType.Location = new Point(1371, 10);
            cboOrderType.Name = "cboOrderType";
            cboOrderType.Size = new Size(159, 33);
            cboOrderType.TabIndex = 2;
            cboOrderType.SelectedIndexChanged += cboOrderType_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(19, 3);
            label8.Name = "label8";
            label8.Size = new Size(315, 48);
            label8.TabIndex = 1;
            label8.Text = "View Store Orders:";
            // 
            // dgvOrders
            // 
            dgvOrders.AllowUserToAddRows = false;
            dgvOrders.AllowUserToDeleteRows = false;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Location = new Point(19, 54);
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.ReadOnly = true;
            dgvOrders.RowHeadersVisible = false;
            dgvOrders.RowHeadersWidth = 62;
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(1729, 561);
            dgvOrders.TabIndex = 0;
            // 
            // tabLocations
            // 
            tabLocations.BackColor = Color.Gainsboro;
            tabLocations.Controls.Add(btnRemoveLocation);
            tabLocations.Controls.Add(btnUpdateLocation);
            tabLocations.Controls.Add(btnAddLocation);
            tabLocations.Controls.Add(label7);
            tabLocations.Controls.Add(dgvLocations);
            tabLocations.Location = new Point(4, 34);
            tabLocations.Name = "tabLocations";
            tabLocations.Padding = new Padding(3);
            tabLocations.Size = new Size(1779, 682);
            tabLocations.TabIndex = 4;
            tabLocations.Text = "Locations";
            // 
            // btnRemoveLocation
            // 
            btnRemoveLocation.Location = new Point(1365, 631);
            btnRemoveLocation.Name = "btnRemoveLocation";
            btnRemoveLocation.Size = new Size(112, 34);
            btnRemoveLocation.TabIndex = 14;
            btnRemoveLocation.Text = "&Remove";
            btnRemoveLocation.UseVisualStyleBackColor = true;
            btnRemoveLocation.Visible = false;
            // 
            // btnUpdateLocation
            // 
            btnUpdateLocation.Location = new Point(1500, 631);
            btnUpdateLocation.Name = "btnUpdateLocation";
            btnUpdateLocation.Size = new Size(112, 34);
            btnUpdateLocation.TabIndex = 13;
            btnUpdateLocation.Text = "&Edit";
            btnUpdateLocation.UseVisualStyleBackColor = true;
            btnUpdateLocation.Visible = false;
            btnUpdateLocation.Click += btnUpdateLocation_Click;
            // 
            // btnAddLocation
            // 
            btnAddLocation.Location = new Point(1633, 631);
            btnAddLocation.Name = "btnAddLocation";
            btnAddLocation.Size = new Size(112, 34);
            btnAddLocation.TabIndex = 12;
            btnAddLocation.Text = "&Add";
            btnAddLocation.UseVisualStyleBackColor = true;
            btnAddLocation.Visible = false;
            btnAddLocation.Click += btnAddLocation_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(22, 3);
            label7.Name = "label7";
            label7.Size = new Size(314, 48);
            label7.TabIndex = 11;
            label7.Text = "Location Manager:";
            // 
            // dgvLocations
            // 
            dgvLocations.AllowUserToAddRows = false;
            dgvLocations.AllowUserToDeleteRows = false;
            dgvLocations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLocations.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvLocations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLocations.Location = new Point(22, 54);
            dgvLocations.MultiSelect = false;
            dgvLocations.Name = "dgvLocations";
            dgvLocations.ReadOnly = true;
            dgvLocations.RowHeadersVisible = false;
            dgvLocations.RowHeadersWidth = 62;
            dgvLocations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLocations.Size = new Size(1723, 558);
            dgvLocations.TabIndex = 0;
            dgvLocations.TabStop = false;
            // 
            // tabInventory
            // 
            tabInventory.BackColor = Color.Gainsboro;
            tabInventory.Controls.Add(btnReturn);
            tabInventory.Controls.Add(btnLossOrDamage);
            tabInventory.Controls.Add(label12);
            tabInventory.Controls.Add(comboBox1);
            tabInventory.Controls.Add(txtSearchInventory);
            tabInventory.Controls.Add(lblSearchBar);
            tabInventory.Controls.Add(btnUpdateInventory);
            tabInventory.Controls.Add(label6);
            tabInventory.Controls.Add(dgvInventory);
            tabInventory.Location = new Point(4, 34);
            tabInventory.Name = "tabInventory";
            tabInventory.Padding = new Padding(3);
            tabInventory.Size = new Size(1779, 682);
            tabInventory.TabIndex = 3;
            tabInventory.Text = "Inventory";
            // 
            // btnReturn
            // 
            btnReturn.Location = new Point(181, 631);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(144, 34);
            btnReturn.TabIndex = 17;
            btnReturn.Text = "Process Return";
            btnReturn.UseVisualStyleBackColor = true;
            btnReturn.Visible = false;
            btnReturn.Click += btnReturn_Click;
            // 
            // btnLossOrDamage
            // 
            btnLossOrDamage.Location = new Point(22, 631);
            btnLossOrDamage.Name = "btnLossOrDamage";
            btnLossOrDamage.Size = new Size(140, 34);
            btnLossOrDamage.TabIndex = 16;
            btnLossOrDamage.Text = "Record Loss";
            btnLossOrDamage.UseVisualStyleBackColor = true;
            btnLossOrDamage.Visible = false;
            btnLossOrDamage.Click += btnLossOrDamage_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(681, 15);
            label12.Name = "label12";
            label12.Size = new Size(83, 25);
            label12.TabIndex = 15;
            label12.Text = "Location:";
            label12.Visible = false;
            // 
            // comboBox1
            // 
            comboBox1.Enabled = false;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(770, 11);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(182, 33);
            comboBox1.TabIndex = 14;
            comboBox1.Visible = false;
            // 
            // txtSearchInventory
            // 
            txtSearchInventory.Enabled = false;
            txtSearchInventory.Location = new Point(1037, 13);
            txtSearchInventory.Name = "txtSearchInventory";
            txtSearchInventory.Size = new Size(716, 31);
            txtSearchInventory.TabIndex = 13;
            txtSearchInventory.Visible = false;
            txtSearchInventory.TextChanged += txtSearchInventory_TextChanged;
            // 
            // lblSearchBar
            // 
            lblSearchBar.AutoSize = true;
            lblSearchBar.Location = new Point(967, 14);
            lblSearchBar.Name = "lblSearchBar";
            lblSearchBar.Size = new Size(68, 25);
            lblSearchBar.TabIndex = 12;
            lblSearchBar.Text = "Search:";
            lblSearchBar.Visible = false;
            // 
            // btnUpdateInventory
            // 
            btnUpdateInventory.Location = new Point(1641, 631);
            btnUpdateInventory.Name = "btnUpdateInventory";
            btnUpdateInventory.Size = new Size(112, 34);
            btnUpdateInventory.TabIndex = 11;
            btnUpdateInventory.Text = "&Edit";
            btnUpdateInventory.UseVisualStyleBackColor = true;
            btnUpdateInventory.Visible = false;
            btnUpdateInventory.Click += btnUpdateInventory_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(22, 3);
            label6.Name = "label6";
            label6.Size = new Size(328, 48);
            label6.TabIndex = 10;
            label6.Text = "Inventory Manager:";
            // 
            // dgvInventory
            // 
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.AllowUserToDeleteRows = false;
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventory.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventory.Location = new Point(22, 54);
            dgvInventory.MultiSelect = false;
            dgvInventory.Name = "dgvInventory";
            dgvInventory.RowHeadersVisible = false;
            dgvInventory.RowHeadersWidth = 62;
            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.Size = new Size(1731, 561);
            dgvInventory.TabIndex = 0;
            // 
            // tabPermissions
            // 
            tabPermissions.BackColor = Color.Gainsboro;
            tabPermissions.Controls.Add(label2);
            tabPermissions.Controls.Add(lstRoles);
            tabPermissions.Controls.Add(btnSetRoles);
            tabPermissions.Controls.Add(dgvPermissions);
            tabPermissions.Location = new Point(4, 34);
            tabPermissions.Name = "tabPermissions";
            tabPermissions.Padding = new Padding(3);
            tabPermissions.Size = new Size(1779, 682);
            tabPermissions.TabIndex = 1;
            tabPermissions.Text = "Permissions";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(22, 5);
            label2.Name = "label2";
            label2.Size = new Size(515, 48);
            label2.TabIndex = 9;
            label2.Text = "Employee Permission Manager:";
            // 
            // lstRoles
            // 
            lstRoles.BackColor = SystemColors.ControlDark;
            lstRoles.DrawMode = DrawMode.OwnerDrawFixed;
            lstRoles.FormattingEnabled = true;
            lstRoles.ItemHeight = 40;
            lstRoles.Location = new Point(1564, 58);
            lstRoles.Name = "lstRoles";
            lstRoles.SelectionMode = SelectionMode.MultiSimple;
            lstRoles.Size = new Size(192, 524);
            lstRoles.TabIndex = 8;
            lstRoles.TabStop = false;
            lstRoles.DrawItem += lstRoles_DrawItem;
            // 
            // btnSetRoles
            // 
            btnSetRoles.Location = new Point(1610, 604);
            btnSetRoles.Name = "btnSetRoles";
            btnSetRoles.Size = new Size(110, 34);
            btnSetRoles.TabIndex = 1;
            btnSetRoles.Text = "&Set Roles";
            btnSetRoles.TextAlign = ContentAlignment.TopCenter;
            btnSetRoles.UseVisualStyleBackColor = true;
            btnSetRoles.Click += btnSetRoles_Click;
            // 
            // dgvPermissions
            // 
            dgvPermissions.AllowUserToAddRows = false;
            dgvPermissions.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(224, 224, 224);
            dgvPermissions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvPermissions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPermissions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvPermissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPermissions.Location = new Point(22, 56);
            dgvPermissions.MultiSelect = false;
            dgvPermissions.Name = "dgvPermissions";
            dgvPermissions.ReadOnly = true;
            dgvPermissions.RowHeadersVisible = false;
            dgvPermissions.RowHeadersWidth = 62;
            dgvPermissions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPermissions.Size = new Size(1517, 597);
            dgvPermissions.TabIndex = 0;
            dgvPermissions.TabStop = false;
            dgvPermissions.SelectionChanged += dgvPermissions_SelectionChanged;
            // 
            // tabEmployees
            // 
            tabEmployees.BackColor = Color.Gainsboro;
            tabEmployees.Controls.Add(btnRemoveEmployee);
            tabEmployees.Controls.Add(btnEditEmployee);
            tabEmployees.Controls.Add(btnAddNewEmployee);
            tabEmployees.Controls.Add(label5);
            tabEmployees.Controls.Add(dgvEmployees);
            tabEmployees.Location = new Point(4, 34);
            tabEmployees.Name = "tabEmployees";
            tabEmployees.Padding = new Padding(3);
            tabEmployees.Size = new Size(1779, 682);
            tabEmployees.TabIndex = 0;
            tabEmployees.Text = "Employees";
            // 
            // btnRemoveEmployee
            // 
            btnRemoveEmployee.Location = new Point(1356, 618);
            btnRemoveEmployee.Name = "btnRemoveEmployee";
            btnRemoveEmployee.Size = new Size(112, 34);
            btnRemoveEmployee.TabIndex = 4;
            btnRemoveEmployee.Text = "&Remove";
            btnRemoveEmployee.UseVisualStyleBackColor = true;
            btnRemoveEmployee.Click += btnRemoveEmployee_Click;
            // 
            // btnEditEmployee
            // 
            btnEditEmployee.Location = new Point(1488, 618);
            btnEditEmployee.Name = "btnEditEmployee";
            btnEditEmployee.Size = new Size(112, 34);
            btnEditEmployee.TabIndex = 3;
            btnEditEmployee.Text = "&Edit";
            btnEditEmployee.UseVisualStyleBackColor = true;
            btnEditEmployee.Click += btnEditEmployee_Click;
            // 
            // btnAddNewEmployee
            // 
            btnAddNewEmployee.Location = new Point(1621, 618);
            btnAddNewEmployee.Name = "btnAddNewEmployee";
            btnAddNewEmployee.Size = new Size(112, 34);
            btnAddNewEmployee.TabIndex = 2;
            btnAddNewEmployee.Text = "Add New";
            btnAddNewEmployee.UseVisualStyleBackColor = true;
            btnAddNewEmployee.Click += btnAddNewEmployee_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(22, 5);
            label5.Name = "label5";
            label5.Size = new Size(334, 48);
            label5.TabIndex = 1;
            label5.Text = "Employee Manager:";
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(224, 224, 224);
            dgvEmployees.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(21, 57);
            dgvEmployees.MultiSelect = false;
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.RowHeadersWidth = 62;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(1731, 531);
            dgvEmployees.TabIndex = 0;
            dgvEmployees.TabStop = false;
            dgvEmployees.SelectionChanged += dgvEmployees_SelectionChanged;
            // 
            // tabDashboard
            // 
            tabDashboard.Controls.Add(tabItems);
            tabDashboard.Controls.Add(tabEmployees);
            tabDashboard.Controls.Add(tabPermissions);
            tabDashboard.Controls.Add(tabInventory);
            tabDashboard.Controls.Add(tabLocations);
            tabDashboard.Controls.Add(tabOrders);
            tabDashboard.Controls.Add(tabSuppliers);
            tabDashboard.Controls.Add(tabTransactions);
            tabDashboard.Controls.Add(tabCustomerOrders);
            tabDashboard.ImageList = imgLstNotification;
            tabDashboard.Location = new Point(55, 191);
            tabDashboard.Name = "tabDashboard";
            tabDashboard.SelectedIndex = 0;
            tabDashboard.Size = new Size(1787, 720);
            tabDashboard.TabIndex = 7;
            tabDashboard.TabStop = false;
            tabDashboard.DrawItem += tabDashboard_DrawItem;
            tabDashboard.SelectedIndexChanged += tabDashboard_SelectedIndexChanged;
            // 
            // tabItems
            // 
            tabItems.BackColor = Color.Gainsboro;
            tabItems.Controls.Add(btnAddNewItem);
            tabItems.Controls.Add(label4);
            tabItems.Controls.Add(btnUpdateItem);
            tabItems.Controls.Add(dgvItems);
            tabItems.Location = new Point(4, 34);
            tabItems.Name = "tabItems";
            tabItems.Size = new Size(1779, 682);
            tabItems.TabIndex = 2;
            tabItems.Text = "Items";
            // 
            // btnAddNewItem
            // 
            btnAddNewItem.Location = new Point(23, 616);
            btnAddNewItem.Name = "btnAddNewItem";
            btnAddNewItem.Size = new Size(204, 34);
            btnAddNewItem.TabIndex = 10;
            btnAddNewItem.Text = "Add Item to Catalogue";
            btnAddNewItem.UseVisualStyleBackColor = true;
            btnAddNewItem.Visible = false;
            btnAddNewItem.Click += btnAddNewItem_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(23, 4);
            label4.Name = "label4";
            label4.Size = new Size(0, 48);
            label4.TabIndex = 9;
            // 
            // btnUpdateItem
            // 
            btnUpdateItem.Location = new Point(1621, 616);
            btnUpdateItem.Name = "btnUpdateItem";
            btnUpdateItem.Size = new Size(112, 34);
            btnUpdateItem.TabIndex = 8;
            btnUpdateItem.Text = "&Edit";
            btnUpdateItem.UseVisualStyleBackColor = true;
            btnUpdateItem.Visible = false;
            btnUpdateItem.Click += btnUpdateItem_Click;
            // 
            // dgvItems
            // 
            dgvItems.AllowUserToAddRows = false;
            dgvItems.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = Color.Silver;
            dgvItems.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvItems.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.MenuHighlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItems.Location = new Point(21, 57);
            dgvItems.MultiSelect = false;
            dgvItems.Name = "dgvItems";
            dgvItems.ReadOnly = true;
            dgvItems.RowHeadersVisible = false;
            dgvItems.RowHeadersWidth = 62;
            dgvItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItems.Size = new Size(1731, 531);
            dgvItems.TabIndex = 0;
            dgvItems.TabStop = false;
            dgvItems.SelectionChanged += dgvItems_SelectionChanged;
            // 
            // frmDashboard
            // 
            AcceptButton = btnRefresh;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnSignOut;
            ClientSize = new Size(1898, 1024);
            Controls.Add(tabDashboard);
            Controls.Add(btnRefresh);
            Controls.Add(btnSignOut);
            Controls.Add(lblLocation);
            Controls.Add(label3);
            Controls.Add(lblUser);
            Controls.Add(label1);
            Controls.Add(picBullseyeLogo);
            HelpButton = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bullseye Inventory Management System - Dashboard";
            Load += FrmDashboard_Load;
            HelpRequested += frmDashboard_HelpRequested;
            ((System.ComponentModel.ISupportInitialize)picBullseyeLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsEmployeesForPermissions).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsEmployees).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsInventory).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsLocations).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsSuppliers).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsTransactionHistory).EndInit();
            tabCustomerOrders.ResumeLayout(false);
            tabCustomerOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomerOrders).EndInit();
            tabTransactions.ResumeLayout(false);
            tabTransactions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            tabSuppliers.ResumeLayout(false);
            tabSuppliers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSuppliers).EndInit();
            tabOrders.ResumeLayout(false);
            tabOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            tabLocations.ResumeLayout(false);
            tabLocations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLocations).EndInit();
            tabInventory.ResumeLayout(false);
            tabInventory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            tabPermissions.ResumeLayout(false);
            tabPermissions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPermissions).EndInit();
            tabEmployees.ResumeLayout(false);
            tabEmployees.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            tabDashboard.ResumeLayout(false);
            tabItems.ResumeLayout(false);
            tabItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)bsCustomerOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picBullseyeLogo;
        private Label label1;
        private Label lblUser;
        private Label label3;
        private Label lblLocation;
        private Button btnSignOut;
        private Button btnRefresh;
        private BindingSource bsEmployeesForPermissions;
        private BindingSource bsItems;
        private BindingSource bsEmployees;
        private BindingSource bsInventory;
        private BindingSource bsLocations;
        private BindingSource bsOrders;
        private NotifyIcon nfIconOrderSubmitted;
        private ImageList imgLstNotification;
        private BindingSource bsSuppliers;
        private BindingSource bsTransactionHistory;
        private TabPage tabCustomerOrders;
        private DataGridView dgvCustomerOrders;
        private Label label15;
        private TabPage tabTransactions;
        private Button btnEditTxn;
        private Button btnCancelTxn;
        private DataGridView dgvTransactions;
        private Label label14;
        private TabPage tabSuppliers;
        private Button btnEditSupplier;
        private Button btnAddSupplier;
        private DataGridView dgvSuppliers;
        private Label label11;
        private TabPage tabOrders;
        private Button btnPickUpOrder;
        private Button btnDeliverStoreOrder;
        private Button btnCheckOrderSubmissions;
        private Button btnBackOrder;
        private Button btnCreateEmergencyOrder;
        private Button btnCreateStandardOrder;
        private Button btnAllocateInventory;
        private Button btnFulfillOrder;
        private ComboBox cboOrderLocation;
        private Label label13;
        private Button btnReceiveOrder;
        private Label label10;
        private Label label9;
        private ComboBox cboOrderStatus;
        private ComboBox cboOrderType;
        private Label label8;
        private DataGridView dgvOrders;
        private TabPage tabLocations;
        private Button btnRemoveLocation;
        private Button btnUpdateLocation;
        private Button btnAddLocation;
        private Label label7;
        private DataGridView dgvLocations;
        private TabPage tabInventory;
        private Label label12;
        private ComboBox comboBox1;
        private TextBox txtSearchInventory;
        private Label lblSearchBar;
        private Button btnUpdateInventory;
        private Label label6;
        private DataGridView dgvInventory;
        private TabPage tabPermissions;
        private Label label2;
        private ListBox lstRoles;
        private Button btnSetRoles;
        private DataGridView dgvPermissions;
        private TabPage tabEmployees;
        private Button btnRemoveEmployee;
        private Button btnEditEmployee;
        private Button btnAddNewEmployee;
        private Label label5;
        private DataGridView dgvEmployees;
        private TabControl tabDashboard;
        private TabPage tabItems;
        private Label label4;
        private Button btnUpdateItem;
        private DataGridView dgvItems;
        private BindingSource bsCustomerOrders;
        private Button btnPrepareOrder;
        private ComboBox cboOnlineOrderStore;
        private Button btnMarkCustPickup;
        private Button btnLossOrDamage;
        private Button btnReturn;
        private Button btnAddNewItem;
        private Button btnPlaceSupplierOrder;
    }
}
