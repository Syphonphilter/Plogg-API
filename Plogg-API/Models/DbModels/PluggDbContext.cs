using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Plogg_API.Models.DbModels;

public partial class PluggDbContext : DbContext
{
    public PluggDbContext()
    {
    }

    public PluggDbContext(DbContextOptions<PluggDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appeal> Appeals { get; set; }

    public virtual DbSet<AppealReason> AppealReasons { get; set; }

    public virtual DbSet<CancelationReason> CancelationReasons { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<PaymentMode> PaymentModes { get; set; }

    public virtual DbSet<Rate> Rates { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<ServiceCategory> ServiceCategories { get; set; }

    public virtual DbSet<ServiceSubCategory> ServiceSubCategories { get; set; }

    public virtual DbSet<ServiceType> ServiceTypes { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<Tip> Tips { get; set; }

    public virtual DbSet<Token> Tokens { get; set; }

    public virtual DbSet<Tool> Tools { get; set; }

    public virtual DbSet<ToolBank> ToolBanks { get; set; }

    public virtual DbSet<ToolCategory> ToolCategories { get; set; }

    public virtual DbSet<ToolInventory> ToolInventories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAccountType> UserAccountTypes { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-CE92CDI\\SQLEXPRESS;Database=PluggDB;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appeal>(entity =>
        {
            entity.Property(e => e.AppealId)
                .ValueGeneratedNever()
                .HasColumnName("AppealID");
            entity.Property(e => e.AppealDescription).IsUnicode(false);
            entity.Property(e => e.AppealReasonId).HasColumnName("AppealReasonID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateResolved).HasColumnType("datetime");
            entity.Property(e => e.TaskId).HasColumnName("TaskID");

            entity.HasOne(d => d.AppealForNavigation).WithMany(p => p.AppealAppealForNavigations)
                .HasForeignKey(d => d.AppealFor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appeals_Users");

            entity.HasOne(d => d.AppealReason).WithMany(p => p.Appeals)
                .HasForeignKey(d => d.AppealReasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appeals_AppealReasons");

            entity.HasOne(d => d.AppealedByNavigation).WithMany(p => p.AppealAppealedByNavigations)
                .HasForeignKey(d => d.AppealedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appeals_Users1");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AppealCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appeals_Users2");

            entity.HasOne(d => d.Task).WithMany(p => p.Appeals)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Appeals_Tasks");
        });

        modelBuilder.Entity<AppealReason>(entity =>
        {
            entity.Property(e => e.AppealReasonId)
                .ValueGeneratedNever()
                .HasColumnName("AppealReasonID");
            entity.Property(e => e.AppealReason1)
                .IsUnicode(false)
                .HasColumnName("AppealReason");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AppealReasons)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppealReasons_Users");
        });

        modelBuilder.Entity<CancelationReason>(entity =>
        {
            entity.Property(e => e.CancelationReasonId)
                .ValueGeneratedNever()
                .HasColumnName("CancelationReasonID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.Reason).IsUnicode(false);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.Property(e => e.LocationId)
                .ValueGeneratedNever()
                .HasColumnName("LocationID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.LocationLatLong).IsUnicode(false);

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.LocationCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Locations_Users");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.LocationModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Locations_Users1");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.Property(e => e.PaymentId)
                .ValueGeneratedNever()
                .HasColumnName("PaymentID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.PaymentModeId).HasColumnName("PaymentModeID");
            entity.Property(e => e.PaymentRef).IsUnicode(false);
            entity.Property(e => e.PaymentStatus).IsUnicode(false);
            entity.Property(e => e.TaskId).HasColumnName("TaskID");

            entity.HasOne(d => d.PaymentMode).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PaymentModeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payments_PaymentModes");

            entity.HasOne(d => d.Task).WithMany(p => p.Payments)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Payments_Tasks");
        });

        modelBuilder.Entity<PaymentMode>(entity =>
        {
            entity.Property(e => e.PaymentModeId)
                .ValueGeneratedNever()
                .HasColumnName("PaymentModeID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.PaymentMode1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PaymentMode");
        });

        modelBuilder.Entity<Rate>(entity =>
        {
            entity.Property(e => e.RateId)
                .ValueGeneratedNever()
                .HasColumnName("RateID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.HourlyRate).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.RateCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rates_Users");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.RateModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rates_Users1");

            entity.HasOne(d => d.Service).WithMany(p => p.Rates)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Rates_Services");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.Property(e => e.RatingId)
                .ValueGeneratedNever()
                .HasColumnName("RatingID");
            entity.Property(e => e.Rating1).HasColumnName("Rating");
            entity.Property(e => e.RatingDescription).IsUnicode(false);
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.Property(e => e.RequestId)
                .ValueGeneratedNever()
                .HasColumnName("RequestID");
            entity.Property(e => e.DateAccepted).HasColumnType("datetime");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateRequestCompleted).HasColumnType("datetime");
            entity.Property(e => e.DateVendorAccepted).HasColumnType("datetime");
            entity.Property(e => e.ServiceSubCategoryId).HasColumnName("ServiceSubCategoryID");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.VendorId).HasColumnName("VendorID");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.Property(e => e.ServiceId)
                .ValueGeneratedNever()
                .HasColumnName("ServiceID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.ServiceCategoryId).HasColumnName("ServiceCategoryID");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ServiceTypeId).HasColumnName("ServiceTypeID");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ServiceCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Services_Users1");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ServiceModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Services_Users");

            entity.HasOne(d => d.ServiceCategory).WithMany(p => p.Services)
                .HasForeignKey(d => d.ServiceCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Services_ServiceCategories");

            entity.HasOne(d => d.ServiceType).WithMany(p => p.Services)
                .HasForeignKey(d => d.ServiceTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Services_ServiceTypes");
        });

        modelBuilder.Entity<ServiceCategory>(entity =>
        {
            entity.Property(e => e.ServiceCategoryId)
                .ValueGeneratedNever()
                .HasColumnName("ServiceCategoryID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.ServiceCategory1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ServiceCategory");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ServiceCategoryCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceCategories_Users");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ServiceCategoryModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceCategories_Users1");
        });

        modelBuilder.Entity<ServiceSubCategory>(entity =>
        {
            entity.Property(e => e.ServiceSubCategoryId)
                .ValueGeneratedNever()
                .HasColumnName("ServiceSubCategoryID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.ServiceCategoryId).HasColumnName("ServiceCategoryID");
            entity.Property(e => e.ServiceSubCategory1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ServiceSubCategory");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ServiceSubCategoryCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceSubCategories_Users");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ServiceSubCategoryModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceSubCategories_Users1");

            entity.HasOne(d => d.ServiceCategory).WithMany(p => p.ServiceSubCategories)
                .HasForeignKey(d => d.ServiceCategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceSubCategories_ServiceCategories");
        });

        modelBuilder.Entity<ServiceType>(entity =>
        {
            entity.Property(e => e.ServiceTypeId)
                .ValueGeneratedNever()
                .HasColumnName("ServiceTypeID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.ServiceType1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ServiceType");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ServiceTypeCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceTypes_Users1");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.ServiceTypeModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ServiceTypes_Users");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.Property(e => e.TaskId)
                .ValueGeneratedNever()
                .HasColumnName("TaskID");
            entity.Property(e => e.CancelationReasonId).HasColumnName("CancelationReasonID");
            entity.Property(e => e.CustomerUserId).HasColumnName("CustomerUserID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.LocationId).HasColumnName("LocationID");
            entity.Property(e => e.RatingId).HasColumnName("RatingID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.ServiceProviderUserId).HasColumnName("ServiceProviderUserID");

            entity.HasOne(d => d.CancelationReason).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.CancelationReasonId)
                .HasConstraintName("FK_Tasks_CancelationReasons");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TaskCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tasks_Users3");

            entity.HasOne(d => d.ModifiedByNavigation).WithMany(p => p.TaskModifiedByNavigations)
                .HasForeignKey(d => d.ModifiedBy)
                .HasConstraintName("FK_Tasks_Users2");

            entity.HasOne(d => d.Rating).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.RatingId)
                .HasConstraintName("FK_Tasks_Ratings");

            entity.HasOne(d => d.Service).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.ServiceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tasks_Services");

            entity.HasOne(d => d.ServiceProviderUser).WithMany(p => p.TaskServiceProviderUsers)
                .HasForeignKey(d => d.ServiceProviderUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tasks_Users");

            entity.HasOne(d => d.TaskNavigation).WithOne(p => p.Task)
                .HasForeignKey<Task>(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tasks_Locations");
        });

        modelBuilder.Entity<Tip>(entity =>
        {
            entity.Property(e => e.TipId)
                .ValueGeneratedNever()
                .HasColumnName("TipID");
            entity.Property(e => e.CustomerUserId).HasColumnName("CustomerUserID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.PaymentModeId).HasColumnName("PaymentModeID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.ServiceProviderUserId).HasColumnName("ServiceProviderUserID");
            entity.Property(e => e.TipValue).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.CustomerUser).WithMany(p => p.TipCustomerUsers)
                .HasForeignKey(d => d.CustomerUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tips_Users");

            entity.HasOne(d => d.PaymentMode).WithMany(p => p.Tips)
                .HasForeignKey(d => d.PaymentModeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tips_PaymentModes");

            entity.HasOne(d => d.ServiceProviderUser).WithMany(p => p.TipServiceProviderUsers)
                .HasForeignKey(d => d.ServiceProviderUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tips_Users1");
        });

        modelBuilder.Entity<Token>(entity =>
        {
            entity.Property(e => e.TokenId)
                .ValueGeneratedNever()
                .HasColumnName("TokenID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.PaymentModeId).HasColumnName("PaymentModeID");
            entity.Property(e => e.TokenName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TokenValidationHash).IsUnicode(false);

            entity.HasOne(d => d.PaymentMode).WithMany(p => p.Tokens)
                .HasForeignKey(d => d.PaymentModeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tokens_PaymentModes");
        });

        modelBuilder.Entity<Tool>(entity =>
        {
            entity.HasKey(e => e.ToolId).HasName("PK__Tool__CC0CEBB13FEFAF58");

            entity.ToTable("Tool");

            entity.Property(e => e.ToolId)
                .ValueGeneratedNever()
                .HasColumnName("ToolID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ToolName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Tools)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tool_Category");
        });

        modelBuilder.Entity<ToolBank>(entity =>
        {
            entity.HasKey(e => e.ToolId).HasName("PK_Tools");

            entity.ToTable("ToolBank");

            entity.Property(e => e.ToolId)
                .ValueGeneratedNever()
                .HasColumnName("ToolID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateLent).HasColumnType("datetime");
            entity.Property(e => e.DateReturned).HasColumnType("datetime");
            entity.Property(e => e.MarketValueAvg).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.ServiceProviderCurrentlyWithNavigation).WithMany(p => p.ToolBanks)
                .HasForeignKey(d => d.ServiceProviderCurrentlyWith)
                .HasConstraintName("FK_ToolBank_Users");
        });

        modelBuilder.Entity<ToolCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__ToolCate__19093A2BE4609DC4");

            entity.ToTable("ToolCategory");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ToolInventory>(entity =>
        {
            entity.HasKey(e => new { e.ToolId, e.VendorId });

            entity.ToTable("ToolInventory");

            entity.Property(e => e.ToolId).HasColumnName("ToolID");
            entity.Property(e => e.VendorId).HasColumnName("VendorID");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Tool).WithMany(p => p.ToolInventories)
                .HasForeignKey(d => d.ToolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ToolInventory_Tool");

            entity.HasOne(d => d.Vendor).WithMany(p => p.ToolInventories)
                .HasForeignKey(d => d.VendorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ToolInventory_Supplier");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Area).IsUnicode(false);
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HouseNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Is2Faenabeled).HasColumnName("Is2FAEnabeled");
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MobileNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PaswordHash).IsUnicode(false);
            entity.Property(e => e.ServiceProviderRating).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.StateId).HasColumnName("StateID");
            entity.Property(e => e.Street).IsUnicode(false);
            entity.Property(e => e.UserAccountTypeId).HasColumnName("UserAccountTypeID");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserRating).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.UserAccountType).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserAccountTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_UserAccountTypes");
        });

        modelBuilder.Entity<UserAccountType>(entity =>
        {
            entity.Property(e => e.UserAccountTypeId)
                .ValueGeneratedNever()
                .HasColumnName("UserAccountTypeID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.UserAccountType1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("UserAccountType");
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PK__Vendor__FC8618D36FE42DE5");

            entity.ToTable("Vendor");

            entity.Property(e => e.VendorId)
                .ValueGeneratedNever()
                .HasColumnName("VendorID");
            entity.Property(e => e.Phone1)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Phone2)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UnionId).HasColumnName("UnionID");
            entity.Property(e => e.VendorAddress)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.VendorName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.VendorRegistrationNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
