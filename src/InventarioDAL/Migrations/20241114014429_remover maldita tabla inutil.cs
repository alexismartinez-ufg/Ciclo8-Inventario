using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventarioDAL.Migrations
{
    /// <inheritdoc />
    public partial class removermalditatablainutil : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sale");

            migrationBuilder.EnsureSchema(
                name: "catalog");

            migrationBuilder.EnsureSchema(
                name: "administration");

            migrationBuilder.EnsureSchema(
                name: "product");

            migrationBuilder.CreateTable(
                name: "category",
                schema: "catalog",
                columns: table => new
                {
                    id_category = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    category_status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__category__E548B673DA2BB3C4", x => x.id_category);
                });

            migrationBuilder.CreateTable(
                name: "deparment",
                schema: "catalog",
                columns: table => new
                {
                    id_deparment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deparment_name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__deparmen__822391585D084085", x => x.id_deparment);
                });

            migrationBuilder.CreateTable(
                name: "permission",
                schema: "administration",
                columns: table => new
                {
                    id_permission = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    permission_name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    permission_status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__permissi__5180B3BFAE25F8B0", x => x.id_permission);
                });

            migrationBuilder.CreateTable(
                name: "role",
                schema: "administration",
                columns: table => new
                {
                    id_role = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role_name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    role_status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__role__3D48441D3F794731", x => x.id_role);
                });

            migrationBuilder.CreateTable(
                name: "supplier",
                schema: "sale",
                columns: table => new
                {
                    id_supplier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    supplier_name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    supplier_address = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    supplier_phone = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    supplier_email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    supplier_country = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    supplier_status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__supplier__F6C576E6C554F6F9", x => x.id_supplier);
                });

            migrationBuilder.CreateTable(
                name: "unit_measure",
                schema: "catalog",
                columns: table => new
                {
                    id_unit_measure = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    unit_measure_name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__unit_mea__C1F80F579056E92A", x => x.id_unit_measure);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "administration",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name_user = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    user_name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    password = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    user_status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user__D2D146371E661864", x => x.id_user);
                });

            migrationBuilder.CreateTable(
                name: "warehouse",
                schema: "catalog",
                columns: table => new
                {
                    id_warehouse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    warehouse_name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    warehouse_location = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    warehouse_climate_controlled = table.Column<bool>(type: "bit", nullable: false),
                    warehouse_status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__warehous__BBAE61068F4D4915", x => x.id_warehouse);
                });

            migrationBuilder.CreateTable(
                name: "municipality",
                schema: "catalog",
                columns: table => new
                {
                    id_municipality = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_deparment = table.Column<int>(type: "int", nullable: false),
                    municipality_name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__municipa__8060473BB7AF71E3", x => x.id_municipality);
                    table.ForeignKey(
                        name: "FK_municipality_deparment",
                        column: x => x.id_deparment,
                        principalSchema: "catalog",
                        principalTable: "deparment",
                        principalColumn: "id_deparment");
                });

            migrationBuilder.CreateTable(
                name: "role_permission",
                schema: "administration",
                columns: table => new
                {
                    id_role = table.Column<int>(type: "int", nullable: false),
                    id_permission = table.Column<int>(type: "int", nullable: false),
                    role_permission_status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__role_per__D8504F26554CE3BE", x => new { x.id_role, x.id_permission });
                    table.ForeignKey(
                        name: "FK_role_permission_permission",
                        column: x => x.id_permission,
                        principalSchema: "administration",
                        principalTable: "permission",
                        principalColumn: "id_permission");
                    table.ForeignKey(
                        name: "FK_role_permission_role",
                        column: x => x.id_role,
                        principalSchema: "administration",
                        principalTable: "role",
                        principalColumn: "id_role");
                });

            migrationBuilder.CreateTable(
                name: "brand",
                schema: "sale",
                columns: table => new
                {
                    id_brand = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_supplier = table.Column<int>(type: "int", nullable: false),
                    brand_name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    brand_status = table.Column<bool>(type: "bit", nullable: false),
                    brand_country = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__brand__4D3CE1286A7467AB", x => x.id_brand);
                    table.ForeignKey(
                        name: "FK_brand_supplier",
                        column: x => x.id_supplier,
                        principalSchema: "sale",
                        principalTable: "supplier",
                        principalColumn: "id_supplier");
                });

            migrationBuilder.CreateTable(
                name: "supplier_contact",
                schema: "sale",
                columns: table => new
                {
                    id_contact_supplier = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_supplier = table.Column<int>(type: "int", nullable: false),
                    contact_supplier_name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    contact_supplier_email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    contact_supplier_phone = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    contact_supplier_status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__supplier__DB73AB298CEA1B71", x => x.id_contact_supplier);
                    table.ForeignKey(
                        name: "FK_supplier_contact_supplier",
                        column: x => x.id_supplier,
                        principalSchema: "sale",
                        principalTable: "supplier",
                        principalColumn: "id_supplier");
                });

            migrationBuilder.CreateTable(
                name: "user_role",
                columns: table => new
                {
                    id_user = table.Column<int>(type: "int", nullable: false),
                    id_role = table.Column<int>(type: "int", nullable: false),
                    user_role_status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_rol__1105C27688FC510B", x => new { x.id_user, x.id_role });
                    table.ForeignKey(
                        name: "FK_user_role_role",
                        column: x => x.id_role,
                        principalSchema: "administration",
                        principalTable: "role",
                        principalColumn: "id_role");
                    table.ForeignKey(
                        name: "FK_user_role_user",
                        column: x => x.id_user,
                        principalSchema: "administration",
                        principalTable: "user",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "district",
                schema: "catalog",
                columns: table => new
                {
                    id_district = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    district_name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    id_municipality = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__district__65E6DD955C563318", x => x.id_district);
                    table.ForeignKey(
                        name: "FK_district_municipality",
                        column: x => x.id_municipality,
                        principalSchema: "catalog",
                        principalTable: "municipality",
                        principalColumn: "id_municipality");
                });

            migrationBuilder.CreateTable(
                name: "product",
                schema: "product",
                columns: table => new
                {
                    id_product = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_warehouse = table.Column<int>(type: "int", nullable: false),
                    id_category = table.Column<int>(type: "int", nullable: false),
                    id_brand = table.Column<int>(type: "int", nullable: false),
                    id_unit_measure = table.Column<int>(type: "int", nullable: false),
                    product_reference = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    product_name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    product_description = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    product_batch = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    product_serial = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    product_fabrication_date = table.Column<DateOnly>(type: "date", nullable: false),
                    product_expiration_date = table.Column<DateOnly>(type: "date", nullable: false),
                    product_quantity = table.Column<int>(type: "int", nullable: false),
                    product_status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__product__BA39E84F6A3D2F5E", x => x.id_product);
                    table.ForeignKey(
                        name: "FK_product_brand",
                        column: x => x.id_brand,
                        principalSchema: "sale",
                        principalTable: "brand",
                        principalColumn: "id_brand");
                    table.ForeignKey(
                        name: "FK_product_category",
                        column: x => x.id_category,
                        principalSchema: "catalog",
                        principalTable: "category",
                        principalColumn: "id_category");
                    table.ForeignKey(
                        name: "FK_product_unit_measure",
                        column: x => x.id_unit_measure,
                        principalSchema: "catalog",
                        principalTable: "unit_measure",
                        principalColumn: "id_unit_measure");
                    table.ForeignKey(
                        name: "FK_product_warehouse",
                        column: x => x.id_warehouse,
                        principalSchema: "catalog",
                        principalTable: "warehouse",
                        principalColumn: "id_warehouse");
                });

            migrationBuilder.CreateTable(
                name: "client",
                schema: "sale",
                columns: table => new
                {
                    id_client = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    client_name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    client_phone = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    client_complement_address = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    id_district = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__client__6EC2B6C0E131A88B", x => x.id_client);
                    table.ForeignKey(
                        name: "FK_client_district",
                        column: x => x.id_district,
                        principalSchema: "catalog",
                        principalTable: "district",
                        principalColumn: "id_district");
                });

            migrationBuilder.CreateTable(
                name: "inventory_movement",
                schema: "sale",
                columns: table => new
                {
                    id_movement = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    movement_type = table.Column<bool>(type: "bit", nullable: true),
                    movement_date = table.Column<DateOnly>(type: "date", nullable: true),
                    id_user = table.Column<int>(type: "int", nullable: false),
                    id_supplier = table.Column<int>(type: "int", nullable: true),
                    id_client = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__inventor__465F1AE4D4A7E848", x => x.id_movement);
                    table.ForeignKey(
                        name: "FK_inventory_movement_client",
                        column: x => x.id_client,
                        principalSchema: "sale",
                        principalTable: "client",
                        principalColumn: "id_client");
                    table.ForeignKey(
                        name: "FK_inventory_movement_supplier",
                        column: x => x.id_supplier,
                        principalSchema: "sale",
                        principalTable: "supplier",
                        principalColumn: "id_supplier");
                    table.ForeignKey(
                        name: "FK_inventory_movement_user",
                        column: x => x.id_user,
                        principalSchema: "administration",
                        principalTable: "user",
                        principalColumn: "id_user");
                });

            migrationBuilder.CreateTable(
                name: "inventory_movent_detail",
                schema: "sale",
                columns: table => new
                {
                    id_movent_detail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    quantity = table.Column<double>(type: "float", nullable: true),
                    unit_cost = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    total_cost = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    id_movement = table.Column<int>(type: "int", nullable: false),
                    id_product = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__inventor__9CE4D813C247B080", x => x.id_movent_detail);
                    table.ForeignKey(
                        name: "FK_inventory_movent_detail_inventory_movement",
                        column: x => x.id_movement,
                        principalSchema: "sale",
                        principalTable: "inventory_movement",
                        principalColumn: "id_movement");
                    table.ForeignKey(
                        name: "FK_inventory_movent_detail_product",
                        column: x => x.id_product,
                        principalSchema: "product",
                        principalTable: "product",
                        principalColumn: "id_product");
                });

            migrationBuilder.CreateIndex(
                name: "IX_brand_id_supplier",
                schema: "sale",
                table: "brand",
                column: "id_supplier");

            migrationBuilder.CreateIndex(
                name: "IX_client_id_district",
                schema: "sale",
                table: "client",
                column: "id_district");

            migrationBuilder.CreateIndex(
                name: "IX_district_id_municipality",
                schema: "catalog",
                table: "district",
                column: "id_municipality");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_movement_id_client",
                schema: "sale",
                table: "inventory_movement",
                column: "id_client");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_movement_id_supplier",
                schema: "sale",
                table: "inventory_movement",
                column: "id_supplier");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_movement_id_user",
                schema: "sale",
                table: "inventory_movement",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_movent_detail_id_movement",
                schema: "sale",
                table: "inventory_movent_detail",
                column: "id_movement");

            migrationBuilder.CreateIndex(
                name: "IX_inventory_movent_detail_id_product",
                schema: "sale",
                table: "inventory_movent_detail",
                column: "id_product");

            migrationBuilder.CreateIndex(
                name: "IX_municipality_id_deparment",
                schema: "catalog",
                table: "municipality",
                column: "id_deparment");

            migrationBuilder.CreateIndex(
                name: "IX_product_id_brand",
                schema: "product",
                table: "product",
                column: "id_brand");

            migrationBuilder.CreateIndex(
                name: "IX_product_id_category",
                schema: "product",
                table: "product",
                column: "id_category");

            migrationBuilder.CreateIndex(
                name: "IX_product_id_unit_measure",
                schema: "product",
                table: "product",
                column: "id_unit_measure");

            migrationBuilder.CreateIndex(
                name: "IX_product_id_warehouse",
                schema: "product",
                table: "product",
                column: "id_warehouse");

            migrationBuilder.CreateIndex(
                name: "IX_role_permission_id_permission",
                schema: "administration",
                table: "role_permission",
                column: "id_permission");

            migrationBuilder.CreateIndex(
                name: "IX_supplier_contact_id_supplier",
                schema: "sale",
                table: "supplier_contact",
                column: "id_supplier");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_id_role",
                table: "user_role",
                column: "id_role");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "inventory_movent_detail",
                schema: "sale");

            migrationBuilder.DropTable(
                name: "role_permission",
                schema: "administration");

            migrationBuilder.DropTable(
                name: "supplier_contact",
                schema: "sale");

            migrationBuilder.DropTable(
                name: "user_role");

            migrationBuilder.DropTable(
                name: "inventory_movement",
                schema: "sale");

            migrationBuilder.DropTable(
                name: "product",
                schema: "product");

            migrationBuilder.DropTable(
                name: "permission",
                schema: "administration");

            migrationBuilder.DropTable(
                name: "role",
                schema: "administration");

            migrationBuilder.DropTable(
                name: "client",
                schema: "sale");

            migrationBuilder.DropTable(
                name: "user",
                schema: "administration");

            migrationBuilder.DropTable(
                name: "brand",
                schema: "sale");

            migrationBuilder.DropTable(
                name: "category",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "unit_measure",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "warehouse",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "district",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "supplier",
                schema: "sale");

            migrationBuilder.DropTable(
                name: "municipality",
                schema: "catalog");

            migrationBuilder.DropTable(
                name: "deparment",
                schema: "catalog");
        }
    }
}
