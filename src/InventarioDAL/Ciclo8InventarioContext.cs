using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InventarioDAL;

public partial class Ciclo8InventarioContext : DbContext
{
    public Ciclo8InventarioContext(DbContextOptions<Ciclo8InventarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Deparment> Deparments { get; set; }

    public virtual DbSet<District> Districts { get; set; }

    public virtual DbSet<InventoryMovement> InventoryMovements { get; set; }

    public virtual DbSet<InventoryMoventDetail> InventoryMoventDetails { get; set; }

    public virtual DbSet<Municipality> Municipalities { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<SupplierContact> SupplierContacts { get; set; }

    public virtual DbSet<UnitMeasure> UnitMeasures { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserPosition> UserPositions { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<Warehouse> Warehouses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.IdBrand).HasName("PK__brand__4D3CE1286A7467AB");

            entity.ToTable("brand", "sale");

            entity.Property(e => e.IdBrand).HasColumnName("id_brand");
            entity.Property(e => e.BrandCountry)
                .HasMaxLength(40)
                .HasColumnName("brand_country");
            entity.Property(e => e.BrandName)
                .HasMaxLength(40)
                .HasColumnName("brand_name");
            entity.Property(e => e.BrandStatus).HasColumnName("brand_status");
            entity.Property(e => e.IdSupplier).HasColumnName("id_supplier");

            entity.HasOne(d => d.IdSupplierNavigation).WithMany(p => p.Brands)
                .HasForeignKey(d => d.IdSupplier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_brand_supplier");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PK__category__E548B673DA2BB3C4");

            entity.ToTable("category", "catalog");

            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(40)
                .HasColumnName("category_name");
            entity.Property(e => e.CategoryStatus).HasColumnName("category_status");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("PK__client__6EC2B6C0E131A88B");

            entity.ToTable("client", "sale");

            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.ClientComplementAddress)
                .HasMaxLength(40)
                .HasColumnName("client_complement_address");
            entity.Property(e => e.ClientName)
                .HasMaxLength(40)
                .HasColumnName("client_name");
            entity.Property(e => e.ClientPhone)
                .HasMaxLength(40)
                .HasColumnName("client_phone");
            entity.Property(e => e.IdDistrict).HasColumnName("id_district");

            entity.HasOne(d => d.IdDistrictNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdDistrict)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_client_district");
        });

        modelBuilder.Entity<Deparment>(entity =>
        {
            entity.HasKey(e => e.IdDeparment).HasName("PK__deparmen__822391585D084085");

            entity.ToTable("deparment", "catalog");

            entity.Property(e => e.IdDeparment).HasColumnName("id_deparment");
            entity.Property(e => e.DeparmentName)
                .HasMaxLength(40)
                .HasColumnName("deparment_name");
        });

        modelBuilder.Entity<District>(entity =>
        {
            entity.HasKey(e => e.IdDistrict).HasName("PK__district__65E6DD955C563318");

            entity.ToTable("district", "catalog");

            entity.Property(e => e.IdDistrict).HasColumnName("id_district");
            entity.Property(e => e.DistrictName)
                .HasMaxLength(40)
                .HasColumnName("district_name");
            entity.Property(e => e.IdMunicipality).HasColumnName("id_municipality");

            entity.HasOne(d => d.IdMunicipalityNavigation).WithMany(p => p.Districts)
                .HasForeignKey(d => d.IdMunicipality)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_district_municipality");
        });

        modelBuilder.Entity<InventoryMovement>(entity =>
        {
            entity.HasKey(e => e.IdMovement).HasName("PK__inventor__465F1AE4D4A7E848");

            entity.ToTable("inventory_movement", "sale");

            entity.Property(e => e.IdMovement).HasColumnName("id_movement");
            entity.Property(e => e.IdClient).HasColumnName("id_client");
            entity.Property(e => e.IdSupplier).HasColumnName("id_supplier");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.MovementDate).HasColumnName("movement_date");
            entity.Property(e => e.MovementType).HasColumnName("movement_type");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.InventoryMovements)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("FK_inventory_movement_client");

            entity.HasOne(d => d.IdSupplierNavigation).WithMany(p => p.InventoryMovements)
                .HasForeignKey(d => d.IdSupplier)
                .HasConstraintName("FK_inventory_movement_supplier");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.InventoryMovements)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_inventory_movement_user");
        });

        modelBuilder.Entity<InventoryMoventDetail>(entity =>
        {
            entity.HasKey(e => e.IdMoventDetail).HasName("PK__inventor__9CE4D813C247B080");

            entity.ToTable("inventory_movent_detail", "sale");

            entity.Property(e => e.IdMoventDetail).HasColumnName("id_movent_detail");
            entity.Property(e => e.IdMovement).HasColumnName("id_movement");
            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.TotalCost)
                .HasMaxLength(40)
                .HasColumnName("total_cost");
            entity.Property(e => e.UnitCost)
                .HasMaxLength(40)
                .HasColumnName("unit_cost");

            entity.HasOne(d => d.IdMovementNavigation).WithMany(p => p.InventoryMoventDetails)
                .HasForeignKey(d => d.IdMovement)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_inventory_movent_detail_inventory_movement");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.InventoryMoventDetails)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_inventory_movent_detail_product");
        });

        modelBuilder.Entity<Municipality>(entity =>
        {
            entity.HasKey(e => e.IdMunicipality).HasName("PK__municipa__8060473BB7AF71E3");

            entity.ToTable("municipality", "catalog");

            entity.Property(e => e.IdMunicipality).HasColumnName("id_municipality");
            entity.Property(e => e.IdDeparment).HasColumnName("id_deparment");
            entity.Property(e => e.MunicipalityName)
                .HasMaxLength(40)
                .HasColumnName("municipality_name");

            entity.HasOne(d => d.IdDeparmentNavigation).WithMany(p => p.Municipalities)
                .HasForeignKey(d => d.IdDeparment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_municipality_deparment");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.IdPermission).HasName("PK__permissi__5180B3BFAE25F8B0");

            entity.ToTable("permission", "administration");

            entity.Property(e => e.IdPermission).HasColumnName("id_permission");
            entity.Property(e => e.PermissionName)
                .HasMaxLength(40)
                .HasColumnName("permission_name");
            entity.Property(e => e.PermissionStatus).HasColumnName("permission_status");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__product__BA39E84F6A3D2F5E");

            entity.ToTable("product", "product");

            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.IdBrand).HasColumnName("id_brand");
            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.IdUnitMeasure).HasColumnName("id_unit_measure");
            entity.Property(e => e.IdWarehouse).HasColumnName("id_warehouse");
            entity.Property(e => e.ProductBatch)
                .HasMaxLength(40)
                .HasColumnName("product_batch");
            entity.Property(e => e.ProductDescription)
                .HasMaxLength(40)
                .HasColumnName("product_description");
            entity.Property(e => e.ProductExpirationDate).HasColumnName("product_expiration_date");
            entity.Property(e => e.ProductFabricationDate).HasColumnName("product_fabrication_date");
            entity.Property(e => e.ProductName)
                .HasMaxLength(40)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");
            entity.Property(e => e.ProductReference)
                .HasMaxLength(40)
                .HasColumnName("product_reference");
            entity.Property(e => e.ProductSerial)
                .HasMaxLength(40)
                .HasColumnName("product_serial");
            entity.Property(e => e.ProductStatus).HasColumnName("product_status");

            entity.HasOne(d => d.IdBrandNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdBrand)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_brand");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_category");

            entity.HasOne(d => d.IdUnitMeasureNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdUnitMeasure)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_unit_measure");

            entity.HasOne(d => d.IdWarehouseNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdWarehouse)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_warehouse");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PK__role__3D48441D3F794731");

            entity.ToTable("role", "administration");

            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.RoleName)
                .HasMaxLength(40)
                .HasColumnName("role_name");
            entity.Property(e => e.RoleStatus).HasColumnName("role_status");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => new { e.IdRole, e.IdPermission }).HasName("PK__role_per__D8504F26554CE3BE");

            entity.ToTable("role_permission", "administration");

            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.IdPermission).HasColumnName("id_permission");
            entity.Property(e => e.RolePermissionStatus).HasColumnName("role_permission_status");

            entity.HasOne(d => d.IdPermissionNavigation).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.IdPermission)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_role_permission_permission");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_role_permission_role");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.IdSupplier).HasName("PK__supplier__F6C576E6C554F6F9");

            entity.ToTable("supplier", "sale");

            entity.Property(e => e.IdSupplier).HasColumnName("id_supplier");
            entity.Property(e => e.SupplierAddress)
                .HasMaxLength(40)
                .HasColumnName("supplier_address");
            entity.Property(e => e.SupplierCountry)
                .HasMaxLength(40)
                .HasColumnName("supplier_country");
            entity.Property(e => e.SupplierEmail)
                .HasMaxLength(40)
                .HasColumnName("supplier_email");
            entity.Property(e => e.SupplierName)
                .HasMaxLength(40)
                .HasColumnName("supplier_name");
            entity.Property(e => e.SupplierPhone)
                .HasMaxLength(40)
                .HasColumnName("supplier_phone");
            entity.Property(e => e.SupplierStatus).HasColumnName("supplier_status");
        });

        modelBuilder.Entity<SupplierContact>(entity =>
        {
            entity.HasKey(e => e.IdContactSupplier).HasName("PK__supplier__DB73AB298CEA1B71");

            entity.ToTable("supplier_contact", "sale");

            entity.Property(e => e.IdContactSupplier).HasColumnName("id_contact_supplier");
            entity.Property(e => e.ContactSupplierEmail)
                .HasMaxLength(40)
                .HasColumnName("contact_supplier_email");
            entity.Property(e => e.ContactSupplierName)
                .HasMaxLength(40)
                .HasColumnName("contact_supplier_name");
            entity.Property(e => e.ContactSupplierPhone)
                .HasMaxLength(40)
                .HasColumnName("contact_supplier_phone");
            entity.Property(e => e.ContactSupplierStatus).HasColumnName("contact_supplier_status");
            entity.Property(e => e.IdSupplier).HasColumnName("id_supplier");

            entity.HasOne(d => d.IdSupplierNavigation).WithMany(p => p.SupplierContacts)
                .HasForeignKey(d => d.IdSupplier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_supplier_contact_supplier");
        });

        modelBuilder.Entity<UnitMeasure>(entity =>
        {
            entity.HasKey(e => e.IdUnitMeasure).HasName("PK__unit_mea__C1F80F579056E92A");

            entity.ToTable("unit_measure", "catalog");

            entity.Property(e => e.IdUnitMeasure).HasColumnName("id_unit_measure");
            entity.Property(e => e.UnitMeasureName)
                .HasMaxLength(40)
                .HasColumnName("unit_measure_name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__user__D2D146371E661864");

            entity.ToTable("user", "administration");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .HasColumnName("email");
            entity.Property(e => e.IdUserPosition).HasColumnName("id_user_position");
            entity.Property(e => e.NameUser)
                .HasMaxLength(40)
                .HasColumnName("name_user");
            entity.Property(e => e.Password)
                .HasMaxLength(40)
                .HasColumnName("password");
            entity.Property(e => e.UserName)
                .HasMaxLength(40)
                .HasColumnName("user_name");
            entity.Property(e => e.UserPosition)
                .HasMaxLength(40)
                .HasColumnName("user_position");
            entity.Property(e => e.UserStatus).HasColumnName("user_status");

            entity.HasOne(d => d.IdUserPositionNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdUserPosition)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_user_position");
        });

        modelBuilder.Entity<UserPosition>(entity =>
        {
            entity.HasKey(e => e.IdUserPosition).HasName("PK__user_pos__939046604D4E0387");

            entity.ToTable("user_position", "catalog");

            entity.Property(e => e.IdUserPosition).HasColumnName("id_user_position");
            entity.Property(e => e.UserPositionName)
                .HasMaxLength(40)
                .HasColumnName("user_position_name");
            entity.Property(e => e.UserPositionStatus).HasColumnName("user_position_status");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => new { e.IdUser, e.IdRole }).HasName("PK__user_rol__1105C27688FC510B");

            entity.ToTable("user_role");

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.UserRoleStatus).HasColumnName("user_role_status");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_role_role");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.IdUser)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_role_user");
        });

        modelBuilder.Entity<Warehouse>(entity =>
        {
            entity.HasKey(e => e.IdWarehouse).HasName("PK__warehous__BBAE61068F4D4915");

            entity.ToTable("warehouse", "catalog");

            entity.Property(e => e.IdWarehouse).HasColumnName("id_warehouse");
            entity.Property(e => e.WarehouseClimateControlled).HasColumnName("warehouse_climate_controlled");
            entity.Property(e => e.WarehouseLocation)
                .HasMaxLength(40)
                .HasColumnName("warehouse_location");
            entity.Property(e => e.WarehouseName)
                .HasMaxLength(40)
                .HasColumnName("warehouse_name");
            entity.Property(e => e.WarehouseStatus).HasColumnName("warehouse_status");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
