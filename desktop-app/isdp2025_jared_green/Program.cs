using idsp2025_jared_green.Controllers;
using idsp2025_jared_green.Cron;
using idsp2025_jared_green.Entities;
using idsp2025_jared_green.Factories;
using idsp2025_jared_green.Forms;
using idsp2025_jared_green.Interfaces.Controllers;
using idsp2025_jared_green.Interfaces.Services;
using idsp2025_jared_green.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using NLog.Extensions.Logging;
using Quartz;
using System;
namespace idsp2025_jared_green
{
    internal static class Program
    {
        public static IServiceProvider _serviceProvider { get; private set; }

        private static readonly IConfigurationRoot configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        static Logger logger = LogManager.Setup().LoadConfigurationFromSection(configuration).GetCurrentClassLogger();

        //string connectionString = configuration.GetConnectionString("BullseyeDB");

        //var 

        static IHostBuilder CreateHostBuilder()
        {

            return Host.CreateDefaultBuilder().ConfigureServices((context, services) =>
            {
                // Add interfaces and services.
                // services.AddTransient<TService, TImplementation>():
                // Registers the service with a transient lifetime,
                // meaning a new instance is created each time the service is requested.

                // services.AddDbContext<BullseyeContext>(options => options.UseInMemoryDatabase("TestingDb"));

                services.AddQuartz(q =>
                {
                JobKey jobKey = new JobKey("OrderSubmit");
                q.AddJob<OrderSubmit>(opt => opt.WithIdentity(jobKey));

                // Execute Every Wednesday at 11:59:59 pm
                q.AddTrigger(opt => opt.ForJob(jobKey)
                    .WithIdentity("OrderSubmitTrigger")
                    .StartNow()
                    .WithCronSchedule("59 59 12 ? * WED"));

                });

                services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

                // Register the DbContext to allow dependency injection
                string connectionString = configuration.GetConnectionString("BullseyeDB");
                var serverVersion = new MySqlServerVersion(new Version(9, 1, 0));
                services.AddDbContext<BullseyeContext>(options => options.UseMySql(connectionString, serverVersion), ServiceLifetime.Scoped);

                // Register Factories
                services.AddScoped<DbContextFactory>();


                // Cron Job
                services.AddTransient<OrderSubmit>();

                // Register Interfaces and Services
                services.AddTransient<IAuthentication, AuthenticationService>();
                services.AddTransient<IAuthorization, AuthorizationService>();
                services.AddTransient<IPermissions, PermissionService>();
                services.AddTransient<IJsonWebToken, JsonWebTokenService>();
                services.AddTransient<IEncryption, EncryptionService>();
                services.AddScoped<ISessionManager, SessionController>();
                services.AddTransient<IEmployees, EmployeeService>();
                services.AddTransient<IItems, ItemService>();
                services.AddTransient<ILocations, LocationsService>();
                services.AddTransient<IInventory, InventoryService>();
                services.AddTransient<IUserLoginAttempt, LoginAttemptService>();
                services.AddTransient<ITransaction, TransactionService>();
                services.AddTransient<ISupplier, SupplierService>();

                // Register Controllers 
                services.AddTransient<IAuthenticationController, AuthenticationController>();
                services.AddTransient<IAuthorizationController, AuthorizationController>();
                services.AddTransient<IPermissionController, PermissionController>();
                services.AddTransient<IEmployeeController, EmployeeController>();
                services.AddTransient<ILocationController, LocationController>();
                services.AddTransient<IDashboardController, DashboardController>();
                services.AddTransient<IItemController, ItemController>();
                services.AddTransient<ILocationController, LocationController>();
                services.AddTransient<IInventoryController, InventoryController>();
                services.AddTransient<ITransactionController, TransactionController>();
                services.AddTransient<ISupplierController, SupplierController>();


                // This code specifies that a new login form should be created each time that it is needed. Other methods that can 
                // be used include .AddScoped() and .AddSingleton()

                // Register Forms
                // Add transient has multiple overloads.
                services.AddTransient<frmLogin>();
                services.AddTransient<frmResetPassword>();
                services.AddTransient<frmDashboard>();
                services.AddTransient<frmAddEmployee>();
                services.AddTransient<frmUpdateEmployee>();
                services.AddTransient<frmUpdateItem>();
                services.AddTransient<frmAddSupplier>();
                services.AddTransient<frmEditSupplier>();
                services.AddTransient<frmEditLocation>();
                services.AddTransient<frmAddLocation>();
                services.AddTransient<frmConfirmUserDelete>();
                services.AddTransient<frmModifyOrder>();
                services.AddTransient<frmEditLocation>();
                services.AddTransient<frmAddSupplierProduct>();
                services.AddTransient<frmItemInfo>();


                // Forms with Runtime Parameters
                    // Register functions to prepare the forms.
                services.AddTransient<Func<int, frmModifyTxnRecord>>(sp => (employeeID) =>
                {
                    return ActivatorUtilities.CreateInstance<frmModifyTxnRecord>(sp, employeeID);
                });
                services.AddTransient<Func<Inventory, frmEditInventory>>(sp => (inventory) =>
                {
                    return ActivatorUtilities.CreateInstance<frmEditInventory>(sp, inventory);
                });
                services.AddTransient<Func<int, int, frmAssignInventory>>(sp => (orderID, employeeID) =>
                {
                    return ActivatorUtilities.CreateInstance<frmAssignInventory>(sp, orderID, employeeID);
                });
                services.AddTransient<Func<int,frmFulfillOrder>> (sp => (employeeID) =>
                {
                    return ActivatorUtilities.CreateInstance<frmFulfillOrder>(sp, employeeID);
                });
                services.AddTransient<Func<int, frmSupplierOrder>>(sp => (employeeID) =>
                {
                    return ActivatorUtilities.CreateInstance<frmSupplierOrder>(sp, employeeID);
                });
                services.AddTransient<Func<Employee, frmAcceptStoreOrder>>(sp => (Employee) =>
                {
                    return ActivatorUtilities.CreateInstance<frmAcceptStoreOrder>(sp, Employee);
                });
                services.AddTransient<Func<Employee, frmPickupStoreOrder>>(sp => (Employee) =>
                {
                    return ActivatorUtilities.CreateInstance<frmPickupStoreOrder>(sp, Employee);
                });
                services.AddTransient<Func<Employee, frmSignForOrder>>(sp => (Employee) =>
                {
                    return ActivatorUtilities.CreateInstance<frmSignForOrder>(sp, Employee);
                });
                services.AddTransient<Func<Employee, List<string>, frmReturn>>(sp => (Employee, Roles) =>
                {
                    return ActivatorUtilities.CreateInstance<frmReturn>(sp, Employee, Roles);
                });
                services.AddTransient<Func<Employee, List<string>, frmLoss>>(sp => (Employee, Roles) =>
                {
                    return ActivatorUtilities.CreateInstance<frmLoss>(sp, Employee, Roles);
                });
                services.AddTransient<Func<Employee, List<string>, frmReturn>>(sp => (Employee, Roles) =>
                {
                    return ActivatorUtilities.CreateInstance<frmReturn>(sp, Employee, Roles);
                });
                services.AddTransient<Func<Employee, frmPrepareOnlineOrder>>(sp => (Employee) =>
                {
                    return ActivatorUtilities.CreateInstance<frmPrepareOnlineOrder>(sp, Employee);
                });
                services.AddTransient<Func<Employee, frmSupplierOrder>>(sp => (Employee) =>
                {
                    return ActivatorUtilities.CreateInstance<frmSupplierOrder>(sp, Employee);
                });
                services.AddTransient<Func<string, frmSelectItem>>(sp => (lossOrReturn) =>
                {
                    return ActivatorUtilities.CreateInstance<frmSelectItem>(sp, lossOrReturn);
                });
            });
        }

        [STAThread]
        static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            var host = CreateHostBuilder().Build();

            _serviceProvider = host.Services;

            // Get the scheduler factory and the scheduler.
            var schedulerFactory = _serviceProvider.GetRequiredService<ISchedulerFactory>();
            var scheduler = await schedulerFactory.GetScheduler();
            Console.WriteLine("Starting Quartz Scheduler...");
            await scheduler.Start();
            Console.WriteLine("Scheduler started successfully!");
            ApplicationConfiguration.Initialize();
            Application.Run(_serviceProvider.GetRequiredService<frmLogin>());
        }
    }
}