using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERPSystem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class migE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Birim",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Durum",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Durum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fatura",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupplierName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fatura", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IslemTuru",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IslemTuru", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sirket",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sirket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Urun",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BrandName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urun_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Departman",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CompanyId = table.Column<long>(type: "bigint", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departman", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departman_Sirket_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Sirket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Kullanıcı",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanıcı", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kullanıcı_Departman_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departman",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Stok",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    UnitId = table.Column<long>(type: "bigint", nullable: false),
                    DepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stok_Birim_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Birim",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Stok_Departman_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departman",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Stok_Urun_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Urun",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Istek",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    UnitId = table.Column<long>(type: "bigint", nullable: false),
                    RequesterId = table.Column<long>(type: "bigint", nullable: false),
                    ApproverId = table.Column<long>(type: "bigint", nullable: true),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Istek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Istek_Birim_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Birim",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Istek_Durum_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Durum",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Istek_Kullanıcı_ApproverId",
                        column: x => x.ApproverId,
                        principalTable: "Kullanıcı",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Istek_Kullanıcı_RequesterId",
                        column: x => x.RequesterId,
                        principalTable: "Kullanıcı",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Istek_Urun_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Urun",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KullanıcıRol",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullanıcıRol", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KullanıcıRol_Kullanıcı_UserId",
                        column: x => x.UserId,
                        principalTable: "Kullanıcı",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KullanıcıRol_Rol_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Rol",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StokDetay",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockId = table.Column<long>(type: "bigint", nullable: false),
                    ProcessTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ReceiverId = table.Column<long>(type: "bigint", nullable: false),
                    DelivererId = table.Column<long>(type: "bigint", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StokDetay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StokDetay_IslemTuru_ProcessTypeId",
                        column: x => x.ProcessTypeId,
                        principalTable: "IslemTuru",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StokDetay_Kullanıcı_DelivererId",
                        column: x => x.DelivererId,
                        principalTable: "Kullanıcı",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StokDetay_Kullanıcı_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Kullanıcı",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StokDetay_Stok_StockId",
                        column: x => x.StockId,
                        principalTable: "Stok",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Teklif",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StatusId = table.Column<long>(type: "bigint", nullable: false),
                    ApproverUserId = table.Column<long>(type: "bigint", nullable: true),
                    RequestId = table.Column<long>(type: "bigint", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teklif", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teklif_Durum_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Durum",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teklif_Istek_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Istek",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Teklif_Kullanıcı_ApproverUserId",
                        column: x => x.ApproverUserId,
                        principalTable: "Kullanıcı",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departman_CompanyId",
                table: "Departman",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Istek_ApproverId",
                table: "Istek",
                column: "ApproverId");

            migrationBuilder.CreateIndex(
                name: "IX_Istek_ProductId",
                table: "Istek",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Istek_RequesterId",
                table: "Istek",
                column: "RequesterId");

            migrationBuilder.CreateIndex(
                name: "IX_Istek_StatusId",
                table: "Istek",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Istek_UnitId",
                table: "Istek",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanıcı_DepartmentId",
                table: "Kullanıcı",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_KullanıcıRol_RoleId",
                table: "KullanıcıRol",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_KullanıcıRol_UserId",
                table: "KullanıcıRol",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stok_DepartmentId",
                table: "Stok",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Stok_ProductId",
                table: "Stok",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Stok_UnitId",
                table: "Stok",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_StokDetay_DelivererId",
                table: "StokDetay",
                column: "DelivererId");

            migrationBuilder.CreateIndex(
                name: "IX_StokDetay_ProcessTypeId",
                table: "StokDetay",
                column: "ProcessTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StokDetay_ReceiverId",
                table: "StokDetay",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_StokDetay_StockId",
                table: "StokDetay",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_Teklif_ApproverUserId",
                table: "Teklif",
                column: "ApproverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Teklif_RequestId",
                table: "Teklif",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Teklif_StatusId",
                table: "Teklif",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Urun_CategoryId",
                table: "Urun",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fatura");

            migrationBuilder.DropTable(
                name: "KullanıcıRol");

            migrationBuilder.DropTable(
                name: "StokDetay");

            migrationBuilder.DropTable(
                name: "Teklif");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "IslemTuru");

            migrationBuilder.DropTable(
                name: "Stok");

            migrationBuilder.DropTable(
                name: "Istek");

            migrationBuilder.DropTable(
                name: "Birim");

            migrationBuilder.DropTable(
                name: "Durum");

            migrationBuilder.DropTable(
                name: "Kullanıcı");

            migrationBuilder.DropTable(
                name: "Urun");

            migrationBuilder.DropTable(
                name: "Departman");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Sirket");
        }
    }
}
