using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Self_call_ii;

public partial class SelfCallIiContext : DbContext
{
    public SelfCallIiContext()
    {
    }

    public SelfCallIiContext(DbContextOptions<SelfCallIiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ScCart> ScCarts { get; set; }

    public virtual DbSet<ScCategory> ScCategories { get; set; }

    public virtual DbSet<ScOrder> ScOrders { get; set; }

    public virtual DbSet<ScOrderItem> ScOrderItems { get; set; }

    public virtual DbSet<ScPickupAudit> ScPickupAudits { get; set; }

    public virtual DbSet<ScPickupPoint> ScPickupPoints { get; set; }

    public virtual DbSet<ScPickupSecurity> ScPickupSecurities { get; set; }

    public virtual DbSet<ScProduct> ScProducts { get; set; }

    public virtual DbSet<ScProfile> ScProfiles { get; set; }

    public virtual DbSet<ScSession> ScSessions { get; set; }

    public virtual DbSet<ScUser> ScUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Self_call_ii;Username=postgres;Password=1111");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ScCart>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sc_cart_pkey");

            entity.ToTable("sc_cart");

            entity.HasIndex(e => e.UserId, "idx_cart_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("added_at");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Product).WithMany(p => p.ScCarts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sc_cart_product_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.ScCarts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("sc_cart_user_id_fkey");
        });

        modelBuilder.Entity<ScCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sc_categories_pkey");

            entity.ToTable("sc_categories");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.SortOrder)
                .HasDefaultValue(0)
                .HasColumnName("sort_order");
        });

        modelBuilder.Entity<ScOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sc_orders_pkey");

            entity.ToTable("sc_orders");

            entity.HasIndex(e => e.OrderNumber, "idx_orders_order_number");

            entity.HasIndex(e => e.PaymentStatus, "idx_orders_payment_status");

            entity.HasIndex(e => e.OrderStatus, "idx_orders_status");

            entity.HasIndex(e => e.UserId, "idx_orders_user_id");

            entity.HasIndex(e => e.OrderNumber, "sc_orders_order_number_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.IsPaid)
                .HasDefaultValue(false)
                .HasColumnName("is_paid");
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(50)
                .HasColumnName("order_number");
            entity.Property(e => e.OrderStatus)
                .HasMaxLength(30)
                .HasDefaultValueSql("'new'::character varying")
                .HasColumnName("order_status");
            entity.Property(e => e.PaidAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("paid_at");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(30)
                .HasDefaultValueSql("'pending'::character varying")
                .HasColumnName("payment_status");
            entity.Property(e => e.PickedUpAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("picked_up_at");
            entity.Property(e => e.PickupPointId).HasColumnName("pickup_point_id");
            entity.Property(e => e.ReadyAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("ready_at");
            entity.Property(e => e.TotalAmount)
                .HasPrecision(10, 2)
                .HasColumnName("total_amount");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.PickupPoint).WithMany(p => p.ScOrders)
                .HasForeignKey(d => d.PickupPointId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sc_orders_pickup_point_id_fkey");

            entity.HasOne(d => d.User).WithMany(p => p.ScOrders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sc_orders_user_id_fkey");
        });

        modelBuilder.Entity<ScOrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sc_order_items_pkey");

            entity.ToTable("sc_order_items");

            entity.HasIndex(e => e.OrderId, "idx_order_items_order_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.PriceAtOrder)
                .HasPrecision(10, 2)
                .HasColumnName("price_at_order");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ProductName)
                .HasMaxLength(200)
                .HasColumnName("product_name");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.ScOrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("sc_order_items_order_id_fkey");
        });

        modelBuilder.Entity<ScPickupAudit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sc_pickup_audit_pkey");

            entity.ToTable("sc_pickup_audit");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasMaxLength(50)
                .HasColumnName("action");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.IpAddress).HasColumnName("ip_address");
            entity.Property(e => e.Method)
                .HasMaxLength(20)
                .HasColumnName("method");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Success).HasColumnName("success");
            entity.Property(e => e.UserAgent).HasColumnName("user_agent");

            entity.HasOne(d => d.Order).WithMany(p => p.ScPickupAudits)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sc_pickup_audit_order_id_fkey");
        });

        modelBuilder.Entity<ScPickupPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sc_pickup_points_pkey");

            entity.ToTable("sc_pickup_points");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Building)
                .HasMaxLength(20)
                .HasColumnName("building");
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .HasColumnName("city");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.Street)
                .HasMaxLength(100)
                .HasColumnName("street");
            entity.Property(e => e.WorkTime)
                .HasMaxLength(100)
                .HasColumnName("work_time");
        });

        modelBuilder.Entity<ScPickupSecurity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sc_pickup_security_pkey");

            entity.ToTable("sc_pickup_security");

            entity.HasIndex(e => e.OrderId, "idx_pickup_security_order_id");

            entity.HasIndex(e => e.QrSecret, "idx_pickup_security_qr_secret");

            entity.HasIndex(e => e.OrderId, "sc_pickup_security_order_id_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.LastAttemptAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_attempt_at");
            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.PersonConfirmedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("person_confirmed_at");
            entity.Property(e => e.PersonConfirmedBy)
                .HasMaxLength(100)
                .HasColumnName("person_confirmed_by");
            entity.Property(e => e.PickupAttempts)
                .HasDefaultValue(0)
                .HasColumnName("pickup_attempts");
            entity.Property(e => e.QrCode).HasColumnName("qr_code");
            entity.Property(e => e.QrSecret)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("qr_secret");
            entity.Property(e => e.QrUsed)
                .HasDefaultValue(false)
                .HasColumnName("qr_used");
            entity.Property(e => e.QrUsedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("qr_used_at");
            entity.Property(e => e.QrUsedBy)
                .HasMaxLength(100)
                .HasColumnName("qr_used_by");
            entity.Property(e => e.SecurityMethod)
                .HasMaxLength(20)
                .HasColumnName("security_method");

            entity.HasOne(d => d.Order).WithOne(p => p.ScPickupSecurity)
                .HasForeignKey<ScPickupSecurity>(d => d.OrderId)
                .HasConstraintName("sc_pickup_security_order_id_fkey");
        });

        modelBuilder.Entity<ScProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sc_products_pkey");

            entity.ToTable("sc_products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.IsPromotion)
                .HasDefaultValue(false)
                .HasColumnName("is_promotion");
            entity.Property(e => e.IsTopProduct)
                .HasDefaultValue(false)
                .HasColumnName("is_top_product");
            entity.Property(e => e.Name)
                .HasMaxLength(200)
                .HasColumnName("name");
            entity.Property(e => e.PhotoUrl).HasColumnName("photo_url");
            entity.Property(e => e.Price)
                .HasPrecision(10, 2)
                .HasColumnName("price");
            entity.Property(e => e.StockQuantity)
                .HasDefaultValue(0)
                .HasColumnName("stock_quantity");

            entity.HasOne(d => d.Category).WithMany(p => p.ScProducts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sc_products_category_id_fkey");
        });

        modelBuilder.Entity<ScProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sc_profiles_pkey");

            entity.ToTable("sc_profiles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.IsVerified)
                .HasDefaultValue(false)
                .HasColumnName("is_verified");
            entity.Property(e => e.PassportData)
                .HasMaxLength(100)
                .HasColumnName("passport_data");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.VerifiedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("verified_at");

            entity.HasOne(d => d.User).WithMany(p => p.ScProfiles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("sc_profiles_user_id_fkey");
        });

        modelBuilder.Entity<ScSession>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sc_sessions_pkey");

            entity.ToTable("sc_sessions");

            entity.HasIndex(e => e.ExpiresAt, "idx_sessions_expires");

            entity.HasIndex(e => e.Token, "idx_sessions_token");

            entity.HasIndex(e => e.Token, "sc_sessions_token_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ExpiresAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("expires_at");
            entity.Property(e => e.Token)
                .HasMaxLength(255)
                .HasColumnName("token");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.ScSessions)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("sc_sessions_user_id_fkey");
        });

        modelBuilder.Entity<ScUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sc_users_pkey");

            entity.ToTable("sc_users");

            entity.HasIndex(e => e.Email, "sc_users_email_key").IsUnique();

            entity.HasIndex(e => e.Phone, "sc_users_phone_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.PasswordHash).HasColumnName("password_hash");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(50)
                .HasColumnName("patronymic");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.PhotoUrl).HasColumnName("photo_url");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
