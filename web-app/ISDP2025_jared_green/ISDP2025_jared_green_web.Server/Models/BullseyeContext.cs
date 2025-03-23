using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace ISDP2025_jared_green_web.Server.Models;

public partial class BullseyeContext : DbContext
{
    public BullseyeContext()
    {
    }

    public BullseyeContext(DbContextOptions<BullseyeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Delivery> Deliveries { get; set; }

    public virtual DbSet<Deliverymethod> Deliverymethods { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Employeerole> Employeeroles { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Posn> Posns { get; set; }

    public virtual DbSet<Province> Provinces { get; set; }

    public virtual DbSet<Site> Sites { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Txn> Txns { get; set; }

    public virtual DbSet<Txnaudit> Txnaudits { get; set; }

    public virtual DbSet<Txnitem> Txnitems { get; set; }

    public virtual DbSet<Txnstatus> Txnstatuses { get; set; }

    public virtual DbSet<Txntype> Txntypes { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<Employeeloginattempt> Userloginattempt { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<ImagePath> ImagePaths { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseMySql("server=localhost;database=bullseyedb2025;user=jared;password=jared", Microsoft.EntityFrameworkCore.ServerVersion.Parse("9.1.0-mysql"));
        var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        string connectionString = configuration.GetConnectionString("BullseyeDB");
        optionsBuilder.UseMySql(connectionString, ServerVersion.Parse("9.1.0"));
        optionsBuilder.EnableSensitiveDataLogging();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryName).HasName("PRIMARY");

            entity.ToTable("category");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(32)
                .HasColumnName("categoryName");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("'1'")
                .HasColumnName("active");
        });

        modelBuilder.Entity<Delivery>(entity =>
        {
            entity.HasKey(e => e.DeliveryId).HasName("PRIMARY");

            entity.ToTable("delivery");

            entity.HasIndex(e => e.VehicleType, "vehicleType");

            entity.Property(e => e.DeliveryId).HasColumnName("deliveryID");
            entity.Property(e => e.DeliveryDate)
                .HasColumnType("datetime")
                .HasColumnName("deliveryDate");
            entity.Property(e => e.DistanceCost)
                .HasPrecision(10, 2)
                .HasColumnName("distanceCost");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .HasColumnName("notes");
            entity.Property(e => e.VehicleType)
                .HasMaxLength(20)
                .HasColumnName("vehicleType");

            entity.HasOne(d => d.VehicleTypeNavigation).WithMany(p => p.Deliveries)
                .HasForeignKey(d => d.VehicleType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("delivery_ibfk_1");
        });

        modelBuilder.Entity<Deliverymethod>(entity =>
        {
            entity.HasKey(e => e.DeliveryMethodId).HasName("PRIMARY");

            entity.ToTable("deliverymethod");

            entity.HasIndex(e => e.ProvinceId, "provinceID");

            entity.Property(e => e.DeliveryMethodId).HasColumnName("deliveryMethodID");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("'1'")
                .HasColumnName("active");
            entity.Property(e => e.Address1)
                .HasMaxLength(50)
                .HasColumnName("address1");
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .HasColumnName("address2");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Contact)
                .HasMaxLength(100)
                .HasColumnName("contact");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .HasColumnName("notes");
            entity.Property(e => e.Phone)
                .HasMaxLength(14)
                .HasColumnName("phone");
            entity.Property(e => e.Postalcode)
                .HasMaxLength(11)
                .HasColumnName("postalcode");
            entity.Property(e => e.ProvinceId)
                .HasMaxLength(2)
                .HasColumnName("provinceID");

            entity.HasOne(d => d.Province).WithMany(p => p.Deliverymethods)
                .HasForeignKey(d => d.ProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("deliverymethod_ibfk_1");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PRIMARY");

            entity.ToTable("employee");

            entity.HasIndex(e => e.PositionId, "PositionID");

            entity.HasIndex(e => e.SiteId, "siteID");

            entity.HasIndex(e => e.Username, "username").IsUnique();

            entity.Property(e => e.EmployeeId).HasColumnName("employeeID");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("'1'")
                .HasColumnName("active");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(20);
            entity.Property(e => e.LastName).HasMaxLength(20);
            entity.Property(e => e.Locked)
                .HasDefaultValueSql("'0'")
                .HasColumnName("locked");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .HasColumnName("notes");
            entity.Property(e => e.Password).HasMaxLength(32);
            entity.Property(e => e.PositionId).HasColumnName("PositionID");
            entity.Property(e => e.SiteId).HasColumnName("siteID");
            entity.Property(e => e.Username).HasColumnName("username");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee_ibfk_1");

            entity.HasOne(d => d.Site).WithMany(p => p.Employees)
                .HasForeignKey(d => d.SiteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employee_ibfk_2");
        });

        modelBuilder.Entity<Employeerole>(entity =>
        {
            entity.HasKey(e => e.EmployeeRoleId).HasName("PRIMARY");

            entity.ToTable("employeerole");

            entity.HasIndex(e => e.EmployeeId, "employeeID");

            entity.HasIndex(e => e.PositionId, "positionID");

            entity.Property(e => e.EmployeeRoleId).HasColumnName("employeeRoleID").ValueGeneratedOnAdd();
            entity.Property(e => e.Active)
                .HasDefaultValueSql("'1'")
                .HasColumnName("active");
            entity.Property(e => e.EmployeeId).HasColumnName("employeeID");
            entity.Property(e => e.PositionId).HasColumnName("positionID");

            entity.HasOne(d => d.Employee).WithMany(p => p.Employeeroles)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employeerole_ibfk_1");

            entity.HasOne(d => d.Position).WithMany(p => p.Employeeroles)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("employeerole_ibfk_2");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => new { e.ItemId, e.SiteId, e.ItemLocation })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0, 0 });

            entity.ToTable("inventory");

            entity.HasIndex(e => e.SiteId, "siteID");

            entity.Property(e => e.ItemId).HasColumnName("itemID");
            entity.Property(e => e.SiteId).HasColumnName("siteID");
            entity.Property(e => e.ItemLocation)
                .HasMaxLength(9)
                .HasDefaultValueSql("'Stock'")
                .HasColumnName("itemLocation");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .HasColumnName("notes");
            entity.Property(e => e.OptimumThreshold).HasColumnName("optimumThreshold");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.ReorderThreshold).HasColumnName("reorderThreshold");

            entity.HasOne(d => d.Item).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inventory_ibfk_1");

            entity.HasOne(d => d.Site).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.SiteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inventory_ibfk_2");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PRIMARY");

            entity.ToTable("item");

            entity.HasIndex(e => e.Category, "category");

            entity.HasIndex(e => e.SupplierId, "supplierID");

            entity.Property(e => e.ItemId).HasColumnName("itemID");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("'1'")
                .HasColumnName("active");
            entity.Property(e => e.ImageLocation).HasMaxLength(255).HasColumnName("imageLocation");
            entity.Property(e => e.CaseSize).HasColumnName("caseSize");
            entity.Property(e => e.Category)
                .HasMaxLength(32)
                .HasColumnName("category");
            entity.Property(e => e.CostPrice)
                .HasPrecision(10, 2)
                .HasColumnName("costPrice");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .HasColumnName("notes");
            entity.Property(e => e.RetailPrice)
                .HasPrecision(10, 2)
                .HasColumnName("retailPrice");
            entity.Property(e => e.Sku)
                .HasMaxLength(20)
                .HasColumnName("sku");
            entity.Property(e => e.SupplierId).HasColumnName("supplierID");
            entity.Property(e => e.Weight)
                .HasPrecision(10, 2)
                .HasColumnName("weight");

            entity.HasOne(d => d.CategoryNavigation).WithMany(p => p.Items)
                .HasForeignKey(d => d.Category)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("item_ibfk_2");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Items)
                .HasForeignKey(d => d.SupplierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("item_ibfk_1");
        });

        modelBuilder.Entity<Posn>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PRIMARY");

            entity.ToTable("posn");

            entity.Property(e => e.PositionId).HasColumnName("positionID");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("'1'")
                .HasColumnName("active");
            entity.Property(e => e.PermissionLevel)
                .HasMaxLength(20)
                .HasColumnName("permissionLevel");
        });

        modelBuilder.Entity<Province>(entity =>
        {
            entity.HasKey(e => e.ProvinceId).HasName("PRIMARY");

            entity.ToTable("province");

            entity.Property(e => e.ProvinceId)
                .HasMaxLength(2)
                .HasColumnName("provinceID");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("'1'")
                .HasColumnName("active");
            entity.Property(e => e.CountryCode)
                .HasMaxLength(50)
                .HasColumnName("countryCode");
            entity.Property(e => e.ProvinceName)
                .HasMaxLength(20)
                .HasColumnName("provinceName");
        });

        modelBuilder.Entity<Site>(entity =>
        {
            entity.HasKey(e => e.SiteId).HasName("PRIMARY");

            entity.ToTable("site");

            entity.HasIndex(e => e.ProvinceId, "provinceID");

            entity.Property(e => e.SiteId).HasColumnName("siteID");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("'1'")
                .HasColumnName("active");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .HasColumnName("address");
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .HasColumnName("address2");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.DayOfWeek)
                .HasMaxLength(50)
                .HasColumnName("dayOfWeek");
            entity.Property(e => e.DistanceFromWh).HasColumnName("distanceFromWH");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .HasColumnName("notes");
            entity.Property(e => e.Phone)
                .HasMaxLength(14)
                .HasColumnName("phone");
            entity.Property(e => e.PostalCode)
                .HasMaxLength(14)
                .HasColumnName("postalCode");
            entity.Property(e => e.ProvinceId)
                .HasMaxLength(2)
                .HasColumnName("provinceID");
            entity.Property(e => e.SiteName)
                .HasMaxLength(50)
                .HasColumnName("siteName");
            entity.Property(e => e.locationType)
                .HasMaxLength(50)
                .HasColumnName("locationType");

            entity.HasOne(d => d.Province).WithMany(p => p.Sites)
                .HasForeignKey(d => d.ProvinceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("site_ibfk_1");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PRIMARY");

            entity.ToTable("supplier");

            entity.HasIndex(e => e.Province, "province");

            entity.Property(e => e.SupplierId).HasColumnName("supplierID");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("'1'")
                .HasColumnName("active");
            entity.Property(e => e.Address1)
                .HasMaxLength(50)
                .HasColumnName("address1");
            entity.Property(e => e.Address2)
                .HasMaxLength(50)
                .HasColumnName("address2");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Contact)
                .HasMaxLength(100)
                .HasColumnName("contact");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .HasColumnName("notes");
            entity.Property(e => e.Phone)
                .HasMaxLength(14)
                .HasColumnName("phone");
            entity.Property(e => e.Postalcode)
                .HasMaxLength(11)
                .HasColumnName("postalcode");
            entity.Property(e => e.Province)
                .HasMaxLength(2)
                .HasColumnName("province");

            entity.HasOne(d => d.ProvinceNavigation).WithMany(p => p.Suppliers)
                .HasForeignKey(d => d.Province)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("supplier_ibfk_1");
        });

        modelBuilder.Entity<Txn>(entity =>
        {
            entity.HasKey(e => e.TxnId).HasName("PRIMARY");

            entity.ToTable("txn");

            entity.HasIndex(e => e.DeliveryId, "deliveryID");

            entity.HasIndex(e => e.EmployeeId, "employeeID");

            entity.HasIndex(e => e.SiteIdfrom, "siteIDFrom");

            entity.HasIndex(e => e.SiteIdto, "siteIDTo");

            entity.HasIndex(e => e.TxnStatus, "txnStatus");

            entity.HasIndex(e => e.TxnType, "txnType");

            entity.Property(e => e.TxnId).HasColumnName("txnID");
            entity.Property(e => e.BarCode)
                .HasMaxLength(50)
                .HasColumnName("barCode");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.DeliveryId).HasColumnName("deliveryID");
            entity.Property(e => e.EmergencyDelivery).HasColumnName("emergencyDelivery");
            entity.Property(e => e.EmployeeId).HasColumnName("employeeID");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .HasColumnName("notes");
            entity.Property(e => e.ShipDate)
                .HasColumnType("datetime")
                .HasColumnName("shipDate");
            entity.Property(e => e.SiteIdfrom).HasColumnName("siteIDFrom");
            entity.Property(e => e.SiteIdto).HasColumnName("siteIDTo");
            entity.Property(e => e.TxnStatus)
                .HasMaxLength(20)
                .HasColumnName("txnStatus");
            entity.Property(e => e.TxnType)
                .HasMaxLength(20)
                .HasColumnName("txnType");
            entity.Property(e => e.CustFirstName)
                .HasMaxLength(20)
                .HasColumnName("custFirstName");
            entity.Property(e => e.CustLastName)
                .HasMaxLength(20)
                .HasColumnName("custLastName");
            entity.Property(e => e.CustEmail)
                .HasMaxLength(100)
                .HasColumnName("custEmail");
            entity.Property(e => e.CustPhone)
                .HasMaxLength(14)
                .HasColumnName("custPhone");

            entity.HasOne(d => d.Delivery).WithMany(p => p.Txns)
                .HasForeignKey(d => d.DeliveryId)
                .HasConstraintName("txn_ibfk_6");

            entity.HasOne(d => d.Employee).WithMany(p => p.Txns)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("txn_ibfk_1");

            entity.HasOne(d => d.SiteIdfromNavigation).WithMany(p => p.TxnSiteIdfromNavigations)
                .HasForeignKey(d => d.SiteIdfrom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("txn_ibfk_3");

            entity.HasOne(d => d.SiteIdtoNavigation).WithMany(p => p.TxnSiteIdtoNavigations)
                .HasForeignKey(d => d.SiteIdto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("txn_ibfk_2");

            entity.HasOne(d => d.TxnStatusNavigation).WithMany(p => p.Txns)
                .HasForeignKey(d => d.TxnStatus)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("txn_ibfk_4");

            entity.HasOne(d => d.TxnTypeNavigation).WithMany(p => p.Txns)
                .HasForeignKey(d => d.TxnType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("txn_ibfk_5");
        });

        modelBuilder.Entity<Txnaudit>(entity =>
        {
            entity.HasKey(e => e.TxnAuditId).HasName("PRIMARY");

            entity.ToTable("txnaudit");

            entity.HasIndex(e => e.SiteId, "SiteID");

            entity.HasIndex(e => e.DeliveryId, "deliveryID");

            entity.HasIndex(e => e.EmployeeId, "employeeID");

            entity.HasIndex(e => e.TxnType, "txnType");

            entity.Property(e => e.TxnAuditId).HasColumnName("txnAuditID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.DeliveryId).HasColumnName("deliveryID");
            entity.Property(e => e.EmployeeId).HasColumnName("employeeID");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .HasColumnName("notes");
            entity.Property(e => e.SiteId).HasColumnName("SiteID");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.TxnDate)
                .HasColumnType("datetime")
                .HasColumnName("txnDate");
            entity.Property(e => e.TxnId).HasColumnName("txnID");
            entity.Property(e => e.TxnType)
                .HasMaxLength(20)
                .HasColumnName("txnType");

            entity.HasOne(d => d.Delivery).WithMany(p => p.Txnaudits)
                .HasForeignKey(d => d.DeliveryId)
                .HasConstraintName("txnaudit_ibfk_4");

            entity.HasOne(d => d.Employee).WithMany(p => p.Txnaudits)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("txnaudit_ibfk_1");

            entity.HasOne(d => d.Site).WithMany(p => p.Txnaudits)
                .HasForeignKey(d => d.SiteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("txnaudit_ibfk_3");

            entity.HasOne(d => d.TxnTypeNavigation).WithMany(p => p.Txnaudits)
                .HasForeignKey(d => d.TxnType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("txnaudit_ibfk_2");
        });

        modelBuilder.Entity<Txnitem>(entity =>
        {
            entity.HasKey(e => new { e.TxnId, e.ItemId })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("txnitems");

            entity.HasIndex(e => e.ItemId, "ItemID");

            entity.Property(e => e.TxnId).HasColumnName("txnID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .HasColumnName("notes");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Item).WithMany(p => p.Txnitems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("txnitems_ibfk_2");

            entity.HasOne(d => d.Txn).WithMany(p => p.Txnitems)
                .HasForeignKey(d => d.TxnId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("txnitems_ibfk_1");
        });

        modelBuilder.Entity<Txnstatus>(entity =>
        {
            entity.HasKey(e => e.StatusName).HasName("PRIMARY");

            entity.ToTable("txnstatus");

            entity.Property(e => e.StatusName)
                .HasMaxLength(20)
                .HasColumnName("statusName");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("'1'")
                .HasColumnName("active");
            entity.Property(e => e.StatusDescription)
                .HasMaxLength(100)
                .HasColumnName("statusDescription");
        });

        modelBuilder.Entity<Txntype>(entity =>
        {
            entity.HasKey(e => e.TxnType1).HasName("PRIMARY");

            entity.ToTable("txntype");

            entity.Property(e => e.TxnType1)
                .HasMaxLength(20)
                .HasColumnName("txnType");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("'1'")
                .HasColumnName("active");
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VehicleType).HasName("PRIMARY");

            entity.ToTable("vehicle");

            entity.Property(e => e.VehicleType)
                .HasMaxLength(20)
                .HasColumnName("vehicleType");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("'1'")
                .HasColumnName("active");
            entity.Property(e => e.CostPerKm)
                .HasPrecision(10, 2)
                .HasColumnName("costPerKm");
            entity.Property(e => e.HourlyTruckCost).HasPrecision(10, 2);
            entity.Property(e => e.MaxWeight)
                .HasPrecision(10)
                .HasColumnName("maxWeight");
            entity.Property(e => e.Notes)
                .HasMaxLength(255)
                .HasColumnName("notes");
        });

        // Added the Fluent API data for the new user login attempt table:
        modelBuilder.Entity<Employeeloginattempt>(entity =>
        {
            entity.HasKey(e => e.EmployeeID)
                .HasName("PRIMARY");
            entity.ToTable("employeeLoginAttempts");
            entity.Property(e => e.SubsequentFailedAttempt)
                .HasColumnName("failedAttempts").HasColumnType("int");
            entity.Property(e => e.LastFailedAttempt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("lastFailedAttempt");
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.HasKey(e => e.ImageID).HasName("PRIMARY");
            entity.ToTable("image");
            entity.Property(e => e.ImageID).HasColumnName("imageID").ValueGeneratedOnAdd();
            entity.Property(e => e.ImagePath).HasColumnName("imagePath");
            entity.Property(e => e.ImageName).HasColumnName("imageName");
        });

        modelBuilder.Entity<ImagePath>(entity =>
        {
            entity.HasKey(e => e.ItemImagePathID).HasName("PRIMARY");
            entity.ToTable("imagePaths");

            entity.HasIndex(e => e.ItemID);
            entity.HasIndex(e => e.ImageID);

            entity.Property(e => e.ItemImagePathID).HasColumnName("itemImagePathID").ValueGeneratedOnAdd();
            entity.Property(e => e.ItemID).HasColumnName("itemID").HasColumnType("int");
            entity.Property(e => e.ImageID).HasColumnName("imageID").HasColumnType("int");

            entity.HasOne(d => d.Image).WithMany(p => p.ImagePaths)
            .HasForeignKey(d => d.ImageID)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("imagepaths_ibfk_1");

            entity.HasOne(d => d.Item).WithMany(p => p.ImagePaths)
                .HasForeignKey(d => d.ItemID)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("imagepaths_ibfk_2");

        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
