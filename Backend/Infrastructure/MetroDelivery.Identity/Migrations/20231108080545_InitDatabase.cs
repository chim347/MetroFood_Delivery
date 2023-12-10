using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MetroDelivery.Identity.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Wallet = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTimeService = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTimeService = table.Column<TimeSpan>(type: "time", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentHistory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Success = table.Column<bool>(type: "bit", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VnPayResponseCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentMethodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FromLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Store",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreOpenTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    StoreCloseTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WithDraw",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentMethodID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Balance = table.Column<double>(type: "float", nullable: true),
                    Deposit = table.Column<double>(type: "float", nullable: true),
                    CreateTimeOfWithdraw = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithDraw", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WithDraw_AspNetUsers_ApplicationUserID",
                        column: x => x.ApplicationUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WithDraw_PaymentMethod_PaymentMethodID",
                        column: x => x.PaymentMethodID,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RouteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TripName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TripStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TripEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trip_Route_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Route",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Station",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Station_Store_StoreID",
                        column: x => x.StoreID,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Store_Menu",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplyDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<bool>(type: "bit", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Store_Menu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Store_Menu_Menu_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Store_Menu_Store_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menu_Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriceOfProductBelongToTimeService = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_Product_Menu_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Menu_Product_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TripID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoreID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: true),
                    TotalPrice = table.Column<double>(type: "float", nullable: true),
                    OrderTokenQR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_ApplicationUserID",
                        column: x => x.ApplicationUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Store_StoreID",
                        column: x => x.StoreID,
                        principalTable: "Store",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Trip_TripID",
                        column: x => x.TripID,
                        principalTable: "Trip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Route_Station",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RouteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: true),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: true),
                    StopTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route_Station", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Route_Station_Route_RouteID",
                        column: x => x.RouteID,
                        principalTable: "Route",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Route_Station_Station_StationID",
                        column: x => x.StationID,
                        principalTable: "Station",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Station_Trip",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TripID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StationID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Arrived = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Station_Trip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Station_Trip_Station_StationID",
                        column: x => x.StationID,
                        principalTable: "Station",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Station_Trip_Trip_TripID",
                        column: x => x.TripID,
                        principalTable: "Trip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quanity = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "04D67210-257D-4DD5-BAFC-13DDE8CA0DFE", "d6f99604-ef40-43f5-a372-ae1e0beb73ed", "Manager", "Manager" },
                    { "647D9649-F5A2-4F24-808F-6FC326EC2AA3", "f92f0b1c-e041-45a0-b591-791018699b42", "Staff", "Staff" },
                    { "AF5EB4AC-219A-4BC1-99FE-8C23876536EA", "7328ef59-e6ff-4535-b6e5-8397ba90a920", "Admin", "Admin" },
                    { "CF531396-C1CD-427B-9D17-0383B7675394", "7ac1e4f2-6256-474e-b724-acc8787614d3", "EndUser", "EndUser" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Birthday", "ConcurrencyStamp", "Created", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StoreId", "TwoFactorEnabled", "UserName", "Wallet" },
                values: new object[,]
                {
                    { "1F11BA64-2870-43F7-BB03-867112867F25", 0, "Gia Lai", new DateTime(1998, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "230b0417-0301-489f-8a26-6f803b5c5696", null, "thaivin537@gmail.com", true, "Thái", "Vĩ", false, null, "THAIVIN537@GMAIL.COM", "THAIVIN537@GMAIL.COM", "AQAAAAEAACcQAAAAELr7PbG73aU1WnZ03VsVMpFyFQnkusqpUdznVE+kDLp9wnQWUJxd6u7CZmP3fscSsw==", "0914009910", false, "6cd0b002-2ae2-4aea-82f1-9b9067c714a2", null, false, "thaivin537@gmail.com", null },
                    { "2198E4CD-3305-49C5-B78A-0B54DD76898F", 0, "da nang", new DateTime(2002, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "08897360-0051-4111-be9b-4a460dd79f14", null, "admin@gmail.com", true, "Nhan", "Admin", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEETrxBz479d0yQiTnFWfxwnFBrL56Vh8GAaWvYdmraxurO5/FZ2MiJ5YwpgUMT1uMw==", "03030303", false, "ecf497fa-5e3c-47d3-8ff2-ef361f56f314", null, false, "admin@gmail.com", null },
                    { "2C0B43BB-B991-408E-A8F3-2FD3B4A2AB84", 0, "Cần Thơ", new DateTime(2002, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "93552b4f-9f70-41d2-82bc-76b12abd5a61", null, "staff@gmail.com", true, "Vi", "Staff", false, null, "STAFF@GMAIL.COM", "STAFF@GMAIL.COM", "AQAAAAEAACcQAAAAEOyBneaEmRNFZDJdIrMHVVdEJpftgcY8hdmpR8I9mbOYWM+q16qG28eBMqghiYUU1w==", "0961868641", false, "cb35aaf1-978d-4d62-9701-93886c9193f1", new Guid("2f3eee35-1b8e-43af-956f-eacd94eea7cd"), false, "staff@gmail.com", null },
                    { "2E089AF6-3437-4DD6-9956-BB792E783AFB", 0, "Đắk Lắk", new DateTime(1899, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "adba88d6-73fb-4119-b39b-2952d39c562c", null, "nguyenthanhn537@gmail.com", true, "Nhân", "Nguyễn", false, null, "NGUYENTHANHN537@GMAIL.COM", "NGUYENTHANHN537@GMAIL.COM", "AQAAAAEAACcQAAAAEKI/3PKD+YiWu+LR76h6YTYJUE8Y49vHtB4YYbJWFO/SS75ACu5ECOKkdIvEgRD3TA==", "0903182861", false, "a09cbf73-c716-4009-b588-99208ea84092", new Guid("ef443e4b-886c-4c06-8528-51e9cf623867"), false, "nguyenthanhn537@gmail.com", null },
                    { "8E48858E-7089-4512-BB79-75AEDC2003D6", 0, "Suối Tiên", new DateTime(1998, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "16f126a1-81a1-45e5-af3f-1b4b5e21084d", null, "vinhttran537@gmail.com", true, "Vinh", "Trần", false, null, "VINHTTRAN537@GMAIL.COM", "VINHTRAN537@GMAIL.COM", "AQAAAAEAACcQAAAAELXzlb4KDLq8OWVWmJR1aREOAiDexlQUY1Iaew6Qk5bynxASptBHMqqdR0mEz0OQAw==", "0123456789", false, "138cc3e2-a3a7-4c82-b7ff-f91936098fde", null, false, "vinhtran537@gmail.com", null },
                    { "B76C9C1E-7F7F-4175-93B3-39B1285F0E71", 0, "Tây NGuyên", new DateTime(1998, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "08f03817-e7af-4fe3-acb6-bc903bfad810", null, "nguyentrieu537@gmail.com", true, "Nguyên", "Triệu", false, null, "NGUYENTRIEU537@GMAIL.COM", "NGUYENTRIEU537@GMAIL.COM", "AQAAAAEAACcQAAAAEEZBNEvybO17xMqk0z59Ekond/4+Sw9QADBhzoj2j/2OWf2UrjJVg/BkvBCTbgYQRA==", "0123456789", false, "a07aa85c-bf91-4be6-a111-1df8fbf028eb", null, false, "nguyentrieu537@gmail.com", 123456789.0 },
                    { "C4EE82A1-DB88-49A6-81A8-4B9521FF01F9", 0, "Kon Tum", new DateTime(1998, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "3a4ddadf-8653-4bea-9ef9-62c271399662", null, "anhjenda537@gmail.com", true, "Anh", "Da Đen", false, null, "ANHJENDA537@GMAIL.COM", "ANHJENDA537@GMAIL.COM", "AQAAAAEAACcQAAAAEB6FQy5LlldnGFkThbXTUe+kGkUI0tnUpvC+KufB8zek7a3En1rwEoT1y6qRtLPT0g==", "0123456789", false, "b3e70121-3217-47e5-838c-67d1fd61049d", null, false, "anhjenda537@gmail.com", null },
                    { "DB903C85-4C75-428B-A7B0-9B56130F4813", 0, "Đồng Nai", new DateTime(1998, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "3724c5d5-7493-4e35-8405-100b73ae7df4", null, "dungho537@gmail.com", true, "Dũng", "Hồ", false, null, "DUNGHO537@GMAIL.COM", "DUNGHO537@GMAIL.COM", "AQAAAAEAACcQAAAAENIxKGX/899AZxtiMeaVc5R8rmY1rtxZ3BvMfOLAAzKjqD6+f+zFidLJtiMyBjKPXQ==", "0123456789", false, "9ad8305d-2071-49c5-a078-cfa8737f120a", null, false, "dungHo537@gmail.com", null },
                    { "E6DE8827-B7C2-46E9-9227-66E6ECE676A8", 0, "hcm", new DateTime(2010, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "61a37abe-f438-4cde-90df-5688cac2cb13", null, "enduser@gmail.com", true, "Vi", "EndUser", false, null, "ENDUSER@GMAIL.COM", "ENDUSER@GMAIL.COM", "AQAAAAEAACcQAAAAECF1TJnUGjocPWHgLmmIGvivkGYNHZ6iqeNXrD9WENt609elhgoJdIZ6W8HPVT/T1Q==", "03030303", false, "1496b348-9239-4932-8ebd-19f3819cd3f0", null, false, "enduser@gmail.com", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName", "CreateBy", "Created", "IsDelete", "LastModified", "LastModifiedBy" },
                values: new object[,]
                {
                    { new Guid("175d4c8d-d2f0-441b-85cb-45a1cb0b6756"), "Candy", null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2150), false, null, null },
                    { new Guid("39696f0c-2c8a-480f-b917-141b7da708e4"), "Dairy", null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2158), false, null, null },
                    { new Guid("4078ef19-ba53-481d-9c5a-1c37dfe0e0dc"), "Beverages", null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2138), false, null, null },
                    { new Guid("8908ea98-b421-420b-9634-03ed356bb921"), "Chips", null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2153), false, null, null },
                    { new Guid("9afcdfac-1a27-496b-84e5-0c8e5804e40e"), "Food", null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2108), false, null, null },
                    { new Guid("9b2cccb2-f5fa-4358-8265-0fe4f7a52253"), "Cookies", null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2155), false, null, null },
                    { new Guid("b7a3a853-73c6-4f02-913b-9765019e9bd0"), "Bread", null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2141), false, null, null }
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "Id", "CreateBy", "Created", "EndTimeService", "IsDelete", "LastModified", "LastModifiedBy", "MenuName", "StartTimeService" },
                values: new object[,]
                {
                    { new Guid("5263453c-dae9-45e4-8204-5430a7256cde"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(3464), new TimeSpan(0, 22, 0, 0, 0), false, null, null, "Bữa chiều 1", new TimeSpan(0, 13, 0, 0, 0) },
                    { new Guid("d3fd2009-c658-4498-bf59-26936918a0c8"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(3474), new TimeSpan(0, 22, 0, 0, 0), false, null, null, "Bữa chiều 2", new TimeSpan(0, 13, 0, 0, 0) },
                    { new Guid("e7a15238-5db0-49bd-94e6-d5f8b77ae6ce"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(3404), new TimeSpan(0, 13, 0, 0, 0), false, null, null, "Bữa sáng 1", new TimeSpan(0, 6, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethod",
                columns: new[] { "Id", "CreateBy", "Created", "IsDelete", "LastModified", "LastModifiedBy", "PaymentMethodName" },
                values: new object[,]
                {
                    { new Guid("36672051-5437-4d2c-a42e-c71a9b67a2b1"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5499), false, null, null, "thanh toán trên app MetroPickUp" },
                    { new Guid("47bd4dd4-3fb4-463e-b9b9-5ebfb7e1f960"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5494), false, null, null, "Paypal" },
                    { new Guid("71b4bf27-e569-47a0-b16a-e484533bd9f2"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5484), false, null, null, "thanh toán tiền mặt" },
                    { new Guid("7db43916-e061-42cb-b0a7-9734423d00cd"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5491), false, null, null, "thanh toán ngân hàng" }
                });

            migrationBuilder.InsertData(
                table: "Route",
                columns: new[] { "Id", "CreateBy", "Created", "FromLocation", "IsDelete", "LastModified", "LastModifiedBy", "ToLocation" },
                values: new object[,]
                {
                    { new Guid("001a254c-02d4-40e7-a01f-95f393fb41ef"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(7220), "Quận 1, Tp.Hcm", false, null, null, "Suối Tiên, Đồng Nai" },
                    { new Guid("42f184eb-58b3-4b9b-be52-1da57f8ffb3f"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(7232), "Quận Bình Thạnh", false, null, null, "Bến Thành, Quận 1, TP HCM" },
                    { new Guid("a437b242-55fc-4146-a2b9-8c952b107e3a"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(7223), "Quận 1, Tp.Hcm", false, null, null, "Quận Thủ Đức, Tp.Hcm" },
                    { new Guid("b9f8f712-92ee-4611-ad55-000a8e1b84c6"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(7229), "Quận 1, Tp.Hcm", false, null, null, "Bến xe Miền Đông" },
                    { new Guid("ccc66514-0597-4d43-aaff-0c5d8ee59ffa"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(7226), "Quận 1, Tp.Hcm", false, null, null, "Quận Bình Thạnh, Tp.Hcm" },
                    { new Guid("ea675490-eecd-4308-bb71-61b72a9c979f"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(7214), "Quận 1, Tp.Hcm", false, null, null, "Quận 9, Tp.Hcm" }
                });

            migrationBuilder.InsertData(
                table: "Store",
                columns: new[] { "Id", "CreateBy", "Created", "IsDelete", "LastModified", "LastModifiedBy", "StoreCloseTime", "StoreLocation", "StoreName", "StoreOpenTime" },
                values: new object[,]
                {
                    { new Guid("2f3eee35-1b8e-43af-956f-eacd94eea7cd"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(8663), false, null, null, new TimeSpan(0, 6, 0, 0, 0), "Số 1, Võ Văn Ngân, Thành Phố Thủ Đức", "Metro PickUp 3", new TimeSpan(0, 6, 0, 0, 0) },
                    { new Guid("6507b7db-7255-4274-87a4-6e2dc3d8a3c4"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(8725), false, null, null, new TimeSpan(0, 6, 0, 0, 0), "Bến Xe Miền Đông", "Metro PickUp 6", new TimeSpan(0, 6, 0, 0, 0) },
                    { new Guid("70c6a937-f285-4495-8407-b20a0c9b10f3"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(8671), false, null, null, new TimeSpan(0, 6, 0, 0, 0), "Khu Công Nghệ Cao Thành Phố Thủ Đức ", "Metro PickUp 4", new TimeSpan(0, 6, 0, 0, 0) },
                    { new Guid("aa2610a8-de94-42b7-b12b-1cf8710e05d8"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(8629), false, null, null, new TimeSpan(0, 23, 0, 0, 0), "Số 2, Đường Lê Lai, Quận 1", "Metro PickUp 1", new TimeSpan(0, 6, 0, 0, 0) },
                    { new Guid("d3599df7-877e-41c7-832d-14850e5c88bd"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(8654), false, null, null, new TimeSpan(0, 6, 0, 0, 0), "Số 3, Vincom, Quận Bình Thạnh", "Metro PickUp 2", new TimeSpan(0, 6, 0, 0, 0) },
                    { new Guid("ef443e4b-886c-4c06-8528-51e9cf623867"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(8715), false, null, null, new TimeSpan(0, 6, 0, 0, 0), "Suối tiên", "Metro PickUp 5", new TimeSpan(0, 6, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "04D67210-257D-4DD5-BAFC-13DDE8CA0DFE", "1F11BA64-2870-43F7-BB03-867112867F25" },
                    { "AF5EB4AC-219A-4BC1-99FE-8C23876536EA", "2198E4CD-3305-49C5-B78A-0B54DD76898F" },
                    { "647D9649-F5A2-4F24-808F-6FC326EC2AA3", "2C0B43BB-B991-408E-A8F3-2FD3B4A2AB84" },
                    { "04D67210-257D-4DD5-BAFC-13DDE8CA0DFE", "2E089AF6-3437-4DD6-9956-BB792E783AFB" },
                    { "04D67210-257D-4DD5-BAFC-13DDE8CA0DFE", "8E48858E-7089-4512-BB79-75AEDC2003D6" },
                    { "CF531396-C1CD-427B-9D17-0383B7675394", "B76C9C1E-7F7F-4175-93B3-39B1285F0E71" },
                    { "04D67210-257D-4DD5-BAFC-13DDE8CA0DFE", "C4EE82A1-DB88-49A6-81A8-4B9521FF01F9" },
                    { "04D67210-257D-4DD5-BAFC-13DDE8CA0DFE", "DB903C85-4C75-428B-A7B0-9B56130F4813" },
                    { "CF531396-C1CD-427B-9D17-0383B7675394", "E6DE8827-B7C2-46E9-9227-66E6ECE676A8" }
                });

            migrationBuilder.InsertData(
                table: "Product",
                columns: new[] { "Id", "CategoryID", "CreateBy", "Created", "Image", "IsDelete", "LastModified", "LastModifiedBy", "Price", "ProductDescription", "ProductName" },
                values: new object[,]
                {
                    { new Guid("09955444-1d34-43cb-aeb4-2af974f05847"), new Guid("b7a3a853-73c6-4f02-913b-9765019e9bd0"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5836), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/b%C3%A1nh%20m%C3%AC%20ch%E1%BA%A3%20l%E1%BB%A5a.jpg?alt=media&token=939bb3f4-7236-4a33-99d2-2fda0843c529&_gl=1*1leh2mz*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODEzODEuNTIuMC4w", false, null, null, 25000.0, "bánh mì chả lụa siêu topping thịt trứng cút, ăn là ghiền!!!", "bánh mì chả lụa" },
                    { new Guid("0c308b93-b26a-4224-9d63-28294711aa15"), new Guid("9afcdfac-1a27-496b-84e5-0c8e5804e40e"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5786), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/g%C3%A0%20r%C3%A1n.jpg?alt=media&token=7124c118-a77e-49b7-b589-bff2880072c6&_gl=1*10iygcf*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE3MTIuMTAuMC4w", false, null, null, 50000.0, "Gà rán giòn tan thơm ngon", "Gà rán" },
                    { new Guid("107f1f75-b23b-4bc4-92d7-f2e90d067d1f"), new Guid("9afcdfac-1a27-496b-84e5-0c8e5804e40e"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5790), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/sandwich.jpg?alt=media&token=da94c867-c82b-4f87-9d71-9a42d7720e04&_gl=1*1eghpk1*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE4NDguMTIuMC4w", false, null, null, 25000.0, "sandwich ngon ngon", "sandwich" },
                    { new Guid("1616cc05-8c82-4f8b-a6e0-f60ab3de0d38"), new Guid("9afcdfac-1a27-496b-84e5-0c8e5804e40e"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5765), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/v%E1%BB%8Bt%20n%C6%B0%E1%BB%9Bng.jpg?alt=media&token=b040622b-edac-4823-9a54-0b1aac95dddc&_gl=1*ykk2i6*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE5NDYuNDQuMC4w", false, null, null, 230000.0, "vịt nướng thơm ngon", "vịt nướng" },
                    { new Guid("18d806c4-c26f-4042-8254-c2fc8af3a3fc"), new Guid("9afcdfac-1a27-496b-84e5-0c8e5804e40e"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5862), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/b%C3%A1nh%20%C6%B0%E1%BB%9Bt.jpg?alt=media&token=81f658b4-bf13-4f9e-8eea-59d2eaf42b6d&_gl=1*1b4idwu*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE1NjMuMzIuMC4w", false, null, null, 25000.0, "bánh ướt topping thịt trứng cút, ăn là ghiền!!!", "bánh ướt" },
                    { new Guid("1d8bd70c-7eec-4630-b297-729d81467d28"), new Guid("b7a3a853-73c6-4f02-913b-9765019e9bd0"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5856), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/b%C3%A1nh%20m%C3%AC%20x%C3%A1%20x%C3%ADu.jpg?alt=media&token=f6baaee9-fdc2-42bb-93e6-d25426686461&_gl=1*stg2d2*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE1NDcuNDguMC4w", false, null, null, 25000.0, "bánh mì xá xiu topping thịt trứng cút, ăn là ghiền!!!", "bánh mì xá xiu" },
                    { new Guid("23149dda-19b1-40cf-9023-2ab388f4e2e7"), new Guid("4078ef19-ba53-481d-9c5a-1c37dfe0e0dc"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5967), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/sinh%20t%E1%BB%91%20d%C3%A2u.jpg?alt=media&token=00b7feac-3084-443b-82b7-25ce815abb06&_gl=1*1yabqww*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE4MDAuNjAuMC4w", false, null, null, 15000.0, "sinh tố dâu thơm phức, uống là ghiền!!!", "sinh tố dâu" },
                    { new Guid("2f2c8c92-e8fe-4687-8b07-a3266edcec95"), new Guid("b7a3a853-73c6-4f02-913b-9765019e9bd0"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5841), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/b%C3%A1nh%20m%C3%AC%20kh%C3%B4%20g%C3%A0.jpg?alt=media&token=ed098e6f-cdd6-4073-9e54-18246793bcb5&_gl=1*17fps7l*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE0MjcuNi4wLjA.", false, null, null, 25000.0, "bánh mì khô gà siêu topping thịt trứng cút, ăn là ghiền!!!", "bánh mì khô gà" },
                    { new Guid("315b5b06-546c-45c5-be94-62e7b08965b9"), new Guid("b7a3a853-73c6-4f02-913b-9765019e9bd0"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5831), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/b%C3%A1nh%20cu%E1%BB%91n.jpg?alt=media&token=04ae26bd-7eb5-472b-acdf-1c1644f05908&_gl=1*ntrrnv*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODEwNTQuNS4wLjA.", false, null, null, 25000.0, "Bánh cuốn siêu topping thịt trứng cút, ăn là ghiền!!!", "bánh cuốn" },
                    { new Guid("35819f39-bca6-49df-828d-f861f888b985"), new Guid("9afcdfac-1a27-496b-84e5-0c8e5804e40e"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5806), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/g%C3%A0%20quay.jpg?alt=media&token=92dd0724-9117-41db-9129-ff9198ee957b&_gl=1*1rost1c*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE2OTMuMjkuMC4w", false, null, null, 90000.0, "gà quay thơm phức", "gà quay" },
                    { new Guid("43203ce4-d82c-4c78-8794-2aef22d7ec5b"), new Guid("9afcdfac-1a27-496b-84e5-0c8e5804e40e"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5811), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/c%C6%A1m%20chi%C3%AAn.jpg?alt=media&token=566c478b-4b30-4ba1-b33b-c79b48979b2a&_gl=1*1ffrh5g*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE2MzMuMjkuMC4w", false, null, null, 25000.0, "Cơm chiên dương châu thơm ngon", "Cơm chiên dương châu" },
                    { new Guid("45da4260-ba13-489b-995a-1f6adb13ab75"), new Guid("175d4c8d-d2f0-441b-85cb-45a1cb0b6756"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5722), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/k%E1%BA%B9o%20b%C3%B4ng%20g%C3%B2n.jpg?alt=media&token=bfa15235-90f4-498e-b305-68ca0d0c9943&_gl=1*1bh2z2a*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE3NTEuNDAuMC4w", false, null, null, 5000.5, "Kẹo thơm ngon được tạo ra từ các loại đường, được làm nóng và tạo nên hương vị ngọt ngào", "Keo bông gòn" },
                    { new Guid("4c9ec4b9-1c16-4c7a-90bf-d620aab257b6"), new Guid("9afcdfac-1a27-496b-84e5-0c8e5804e40e"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5802), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/g%C3%A0%20n%C6%B0%E1%BB%9Bng%20mu%E1%BB%91i%20%E1%BB%9Bt.jpg?alt=media&token=b0ee7b37-0c08-4275-8b4d-52113060cce1&_gl=1*jik9qm*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE2NzguNDQuMC4w", false, null, null, 80000.0, "gà nướng muối ớt thơm phức", "gà nướng muối ớt" },
                    { new Guid("4ecd72e3-f43d-490f-8b46-8e92ea29f85c"), new Guid("4078ef19-ba53-481d-9c5a-1c37dfe0e0dc"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5778), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/sinh%20t%E1%BB%91%20b%C6%A1.jpg?alt=media&token=790ace46-99c9-4c33-b179-3778a1a2b9e8&_gl=1*1dyuw6p*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE4NDEuMTkuMC4w", false, null, null, 15000.0, "sinh tố bơ dâu tây thơm ngon", "sinh tố bơ" },
                    { new Guid("55265d3b-fa02-4e09-84db-d4e8c8a9a9b5"), new Guid("4078ef19-ba53-481d-9c5a-1c37dfe0e0dc"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5794), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/sinh%20t%E1%BB%91%20m%C3%A3ng%20c%E1%BA%A7u.jpg?alt=media&token=50c23ce0-ec9e-45bf-a1d6-7839d9b72966&_gl=1*1ek709c*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE4MjAuNDAuMC4w", false, null, null, 25000.0, "sinh tố mãng cầu mát lạnh", "sinh tố mãng cầu" },
                    { new Guid("61a3d1ac-3785-4185-b880-5c92eb995c04"), new Guid("4078ef19-ba53-481d-9c5a-1c37dfe0e0dc"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5974), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/tr%C3%A0%20tr%C3%A1i%20c%C3%A2y.jpg?alt=media&token=1c94927e-1591-40df-9b19-cbfdea2ab617&_gl=1*1o9pywy*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE5MzAuNjAuMC4w", false, null, null, 15000.0, "trà trái cây thơm phức, uống là ghiền!!!", "trà trái cây" },
                    { new Guid("6d60bf44-b775-4d87-bb47-aace85d49ac4"), new Guid("175d4c8d-d2f0-441b-85cb-45a1cb0b6756"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5755), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR8-8BIO05l5p1gp2W5sgCgVLLr1YG6dt4gvw&usqp=CAU", false, null, null, 2500.0, "Kẹo dẻo mềm, đàn hồi", "Kẹo dẻo" },
                    { new Guid("6d9d1080-424e-435e-91ee-7d094dbae04b"), new Guid("b7a3a853-73c6-4f02-913b-9765019e9bd0"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5845), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/b%C3%A1nh%20m%C3%AC%20nh%E1%BA%ADn.jpg?alt=media&token=ab5d5464-752e-4eaf-9a53-8a8ed21a472b&_gl=1*133ff4j*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE0NDQuNjAuMC4w", false, null, null, 25000.0, "bánh mì thịt siêu topping thịt trứng cút, ăn là ghiền!!!", "bánh mì thịt" },
                    { new Guid("7292efb8-15bf-404c-bad0-128991819f7a"), new Guid("4078ef19-ba53-481d-9c5a-1c37dfe0e0dc"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5871), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/b%E1%BA%A1c%20x%E1%BB%89u.jpg?alt=media&token=c638c3a8-b5e5-4a53-8b43-2444e6759b4e&_gl=1*z64tep*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE1ODkuNi4wLjA.", false, null, null, 20000.0, "bạc xỉu thơm phức, uống là ghiền!!!", "bạc xỉu" },
                    { new Guid("7d661a30-e180-498c-9a77-cb6112a7cb22"), new Guid("175d4c8d-d2f0-441b-85cb-45a1cb0b6756"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5737), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRgRlQzLWTXBOHfbDD7NnZleCaXH0xyMjPdQQ&usqp=CAU", false, null, null, 3000.0, "Kẹo lạc thơm ngon, giòn tan", "Kẹo lạc" },
                    { new Guid("7da34092-5747-42b7-b059-4a5aad57e740"), new Guid("175d4c8d-d2f0-441b-85cb-45a1cb0b6756"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5746), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT4WKJkaumJIGoZ2SdHjV_gOlqBc1BRCgacPQ&usqp=CAU", false, null, null, 3000.0, "Kẹo lạc thơm ngon, giòn tan", "Kẹo chup" },
                    { new Guid("8108e3ca-e67a-415c-94a8-673917e29b1b"), new Guid("4078ef19-ba53-481d-9c5a-1c37dfe0e0dc"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5875), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/c%C3%A0%20ph%C3%AA%20mu%E1%BB%91i.jpg?alt=media&token=fbd2e24d-9db6-45ed-b641-04f42576d46c&_gl=1*1qr7ux3*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE2MDIuNjAuMC4w", false, null, null, 18000.0, "cà phê muối thơm phức, uống là ghiền!!!", "cà phê muối" },
                    { new Guid("9ca658d0-f207-43b4-9adb-946f5c0506d5"), new Guid("4078ef19-ba53-481d-9c5a-1c37dfe0e0dc"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5880), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/c%C3%A0%20ph%C3%AA%20s%E1%BB%AFa.jpg?alt=media&token=9bd6dae8-b648-41a7-a2ee-7929dc4cb906&_gl=1*o2kslq*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE2MjAuNDIuMC4w", false, null, null, 15000.0, "cà phê sữa thơm phức, uống là ghiền!!!", "cà phê sữa" },
                    { new Guid("9f7798d8-10df-4783-b825-b27d2023d347"), new Guid("9afcdfac-1a27-496b-84e5-0c8e5804e40e"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5815), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/c%C6%A1m%20n%E1%BA%A5m.jpg?alt=media&token=b8a9cf42-0a22-4336-8a84-cabac450f5fa&_gl=1*1d5cihv*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE2NDguMTQuMC4w", false, null, null, 19000.0, "cơm nấm thơm ngon", "cơm nấm" },
                    { new Guid("ac5a5d34-5a6b-4013-a850-d19a5bf9a659"), new Guid("4078ef19-ba53-481d-9c5a-1c37dfe0e0dc"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5889), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/n%C6%B0%E1%BB%9Bc%20%C3%A9p%20cam.jpg?alt=media&token=d0fbb985-ca14-488c-99e2-2663e0306676&_gl=1*1bdx014*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE3NzguMTMuMC4w", false, null, null, 15000.0, "nước ép cam thơm phức, uống là ghiền!!!", "nước ép cam" },
                    { new Guid("ac9f9657-e5ed-4e92-8ee7-3028df33f98b"), new Guid("4078ef19-ba53-481d-9c5a-1c37dfe0e0dc"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5885), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/expresso.jpg?alt=media&token=c5d7f433-e733-4c7e-b1ff-2a3496145a9e&_gl=1*adgji4*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE2NjIuNjAuMC4w", false, null, null, 15000.0, "expresso thơm phức, uống là ghiền!!!", "expresso" },
                    { new Guid("b834cf11-cc28-4e7d-9846-2acc8ad33d8c"), new Guid("8908ea98-b421-420b-9634-03ed356bb921"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5751), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/khoai%20t%C3%A2y%20chi%C3%AAn.jpg?alt=media&token=2d6af011-8f6b-4f6f-9749-7c2885ef00d3&_gl=1*165nmqq*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE3MzEuNjAuMC4w", false, null, null, 10000.0, "Khoai tây chiên giòn tan", "Khoai tây chiên" },
                    { new Guid("d4fe048d-ff12-4715-93e7-3250f49c15c8"), new Guid("9b2cccb2-f5fa-4358-8265-0fe4f7a52253"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5769), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/tr%C3%A1i%20c%C3%A2y%20s%E1%BA%A5y.jpg?alt=media&token=934c1049-364c-4947-985b-688b06bd2451&_gl=1*1rimqyr*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE5NDEuNDkuMC4w", false, null, null, 5000.0, "trái cây sấy giòn tan trong miệng", "trái cây sấy" },
                    { new Guid("dd1655de-7493-4b65-8c92-fad2275a3ec9"), new Guid("b7a3a853-73c6-4f02-913b-9765019e9bd0"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5850), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/b%C3%A1nh%20m%C3%AC%20tr%E1%BB%A9ng.jpg?alt=media&token=67e9bd91-80d8-49cd-8413-166c99806d5c&_gl=1*ajhxeb*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE1MzUuNjAuMC4w", false, null, null, 25000.0, "bánh mì trứng topping thịt trứng cút, ăn là ghiền!!!", "bánh mì trứng" },
                    { new Guid("e1fe83d3-270f-408e-98b2-0af436c510b9"), new Guid("4078ef19-ba53-481d-9c5a-1c37dfe0e0dc"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5901), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/n%C6%B0%E1%BB%9Bc%20%C3%A9p%20d%C6%B0a%20h%E1%BA%A5u.jpg?alt=media&token=91ce4a1c-4db6-43e0-af43-ee62e0a0d492&_gl=1*14wa5cu*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE3ODcuNC4wLjA.", false, null, null, 15000.0, "nước ep dưa hấu thơm phức, uống là ghiền!!!", "nước ep dưa hấu" },
                    { new Guid("e802b6c5-f08e-4eff-b7e7-af95514b4341"), new Guid("4078ef19-ba53-481d-9c5a-1c37dfe0e0dc"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5827), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/tr%C3%A0%20chanh%20.jpg?alt=media&token=531d6da6-9098-4532-a547-96ce4a376f2f&_gl=1*1v8uv0r*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE4NjcuNjAuMC4w", false, null, null, 25000.0, "Trà chanh, uống là ghiền!!!", "trà chanh" },
                    { new Guid("f31c789c-4a46-45c7-9009-d36681d788c5"), new Guid("4078ef19-ba53-481d-9c5a-1c37dfe0e0dc"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5774), "https://firebasestorage.googleapis.com/v0/b/metrofood-ab636.appspot.com/o/tr%C3%A0%20s%E1%BB%AFa%20tr%C3%A2n%20ch%C3%A2u%20%C4%91%C6%B0%E1%BB%9Dng%20%C4%91en.jpg?alt=media&token=d88eae6c-2da9-40c1-9a1a-3ce1cffeddc1&_gl=1*dhxzv6*_ga*NjAxOTEyNDY1LjE2OTQ0MTkxMzc.*_ga_CW55HF8NVT*MTY5OTI4MDg2NS4yMS4xLjE2OTkyODE5MTcuMTAuMC4w", false, null, null, 10000.0, "trà sữa sô cô la ngọt thanh", "trà sữa" },
                    { new Guid("ffb05663-954d-4af3-8a41-91af39446f81"), new Guid("175d4c8d-d2f0-441b-85cb-45a1cb0b6756"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5798), "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQxu7OGjZjXXrJHyR6o_v7PSl4Q9PEGKxOfEQ&usqp=CAU", false, null, null, 2500.0, "Kẹo mút mềm dẻo", "Kẹo mút" }
                });

            migrationBuilder.InsertData(
                table: "Station",
                columns: new[] { "Id", "CreateBy", "Created", "IsDelete", "LastModified", "LastModifiedBy", "StationName", "StoreID" },
                values: new object[,]
                {
                    { new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c4"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(8209), false, null, null, "Ga Metro Bến Thành", new Guid("aa2610a8-de94-42b7-b12b-1cf8710e05d8") },
                    { new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c5"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(8217), false, null, null, "Ga Metro Vincom Bình Thạnh", new Guid("d3599df7-877e-41c7-832d-14850e5c88bd") },
                    { new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c6"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(8221), false, null, null, "Ga Metro Chợ Thủ Đức", new Guid("2f3eee35-1b8e-43af-956f-eacd94eea7cd") },
                    { new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c7"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(8226), false, null, null, "Ga Metro Khu Công Nghệ Cao", new Guid("70c6a937-f285-4495-8407-b20a0c9b10f3") },
                    { new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c8"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(8229), false, null, null, "Ga Metro Suối Tiên", new Guid("ef443e4b-886c-4c06-8528-51e9cf623867") },
                    { new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c9"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(8238), false, null, null, "Ga Metro Bến xe Miền Đông", new Guid("6507b7db-7255-4274-87a4-6e2dc3d8a3c4") }
                });

            migrationBuilder.InsertData(
                table: "Store_Menu",
                columns: new[] { "Id", "ApplyDate", "CreateBy", "Created", "IsDelete", "LastModified", "LastModifiedBy", "MenuId", "Priority", "StoreId" },
                values: new object[,]
                {
                    { new Guid("16f8d4b6-7f63-4f78-a827-4a2385918cb9"), "Thursday", null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(8419), false, null, null, new Guid("5263453c-dae9-45e4-8204-5430a7256cde"), true, new Guid("aa2610a8-de94-42b7-b12b-1cf8710e05d8") },
                    { new Guid("2d98e549-c1f1-457a-b09e-5fe8b064ddba"), "Monday", null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(8439), false, null, null, new Guid("e7a15238-5db0-49bd-94e6-d5f8b77ae6ce"), false, new Guid("2f3eee35-1b8e-43af-956f-eacd94eea7cd") },
                    { new Guid("47aba512-c74a-4bda-9044-86afc6b3845e"), "Monday", null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(8435), false, null, null, new Guid("e7a15238-5db0-49bd-94e6-d5f8b77ae6ce"), false, new Guid("d3599df7-877e-41c7-832d-14850e5c88bd") },
                    { new Guid("a44e8cf6-5155-4336-a8c9-767b739e3a44"), "Thursday", null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(8427), false, null, null, new Guid("d3fd2009-c658-4498-bf59-26936918a0c8"), false, new Guid("aa2610a8-de94-42b7-b12b-1cf8710e05d8") },
                    { new Guid("bd53bd12-82ee-4d6b-be9e-48f7d902bf7c"), "Thursday", null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(8431), false, null, null, new Guid("5263453c-dae9-45e4-8204-5430a7256cde"), false, new Guid("6507b7db-7255-4274-87a4-6e2dc3d8a3c4") },
                    { new Guid("ea9d62e7-ffa5-4ddc-894d-c004e6d87fbf"), "Monday", null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(8446), false, null, null, new Guid("5263453c-dae9-45e4-8204-5430a7256cde"), false, new Guid("ef443e4b-886c-4c06-8528-51e9cf623867") },
                    { new Guid("fc6ab5f9-3a13-47cf-ae26-6bcd9529341a"), "Monday", null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(8443), false, null, null, new Guid("e7a15238-5db0-49bd-94e6-d5f8b77ae6ce"), false, new Guid("70c6a937-f285-4495-8407-b20a0c9b10f3") }
                });

            migrationBuilder.InsertData(
                table: "Trip",
                columns: new[] { "Id", "CreateBy", "Created", "IsDelete", "LastModified", "LastModifiedBy", "RouteId", "TripEndTime", "TripName", "TripStartTime" },
                values: new object[,]
                {
                    { new Guid("02859382-d88c-4e69-8c47-b8e0456677d5"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(9073), false, null, null, new Guid("a437b242-55fc-4146-a2b9-8c952b107e3a"), new DateTime(2023, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), "Cruise Vacation", new DateTime(2023, 9, 10, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("27421cac-1da7-4df8-9928-7fb636ca42aa"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(9092), false, null, null, new Guid("ccc66514-0597-4d43-aaff-0c5d8ee59ffa"), new DateTime(2023, 11, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), "Hiking Adventure", new DateTime(2023, 11, 12, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5b30c4e9-31ab-456c-b212-dc6b2ba9a3e7"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(9111), false, null, null, new Guid("001a254c-02d4-40e7-a01f-95f393fb41ef"), new DateTime(2023, 12, 23, 14, 0, 0, 0, DateTimeKind.Unspecified), "Ski Getaway", new DateTime(2023, 12, 20, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("823ad122-7b51-4dab-9d37-b0f238d4a2ff"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(8992), false, null, null, new Guid("ea675490-eecd-4308-bb71-61b72a9c979f"), new DateTime(2023, 7, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), "Camping Trip", new DateTime(2023, 7, 15, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8a2ba7d5-7019-49c6-a47d-ab0a072e7932"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(9166), false, null, null, new Guid("b9f8f712-92ee-4611-ad55-000a8e1b84c6"), new DateTime(2023, 10, 19, 15, 0, 0, 0, DateTimeKind.Unspecified), "African Safari", new DateTime(2023, 10, 19, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9b4d232c-0fda-4ec0-beed-ecd649ee9c52"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(9129), false, null, null, new Guid("42f184eb-58b3-4b9b-be52-1da57f8ffb3f"), new DateTime(2023, 8, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), "Tropical Vacation", new DateTime(2023, 8, 13, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9c2ab923-4c57-44d7-9c1a-b44c0d3e6b00"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(9046), false, null, null, new Guid("001a254c-02d4-40e7-a01f-95f393fb41ef"), new DateTime(2023, 5, 25, 20, 0, 0, 0, DateTimeKind.Unspecified), "Road Trip", new DateTime(2023, 5, 20, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bf736039-33e9-466f-ac4e-78c89f3317e6"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(9147), false, null, null, new Guid("a437b242-55fc-4146-a2b9-8c952b107e3a"), new DateTime(2023, 7, 6, 23, 0, 0, 0, DateTimeKind.Unspecified), "Amusement Park Fun", new DateTime(2023, 7, 4, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d9852f0d-e836-4a6e-94f4-d229b297933d"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(9186), false, null, null, new Guid("a437b242-55fc-4146-a2b9-8c952b107e3a"), new DateTime(2023, 5, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), "Botanical Gardens Tour", new DateTime(2023, 5, 6, 13, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "WithDraw",
                columns: new[] { "Id", "ApplicationUserID", "Balance", "CreateBy", "CreateTimeOfWithdraw", "Created", "Deposit", "IsDelete", "LastModified", "LastModifiedBy", "PaymentMethodID" },
                values: new object[,]
                {
                    { new Guid("0bd9818a-5ef1-45e3-a6fe-0c932f970fe8"), "E6DE8827-B7C2-46E9-9227-66E6ECE676A8", 2000000.0, null, new DateTime(2022, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(9598), 125000.0, false, null, null, new Guid("71b4bf27-e569-47a0-b16a-e484533bd9f2") },
                    { new Guid("4e917707-0edb-49da-b6f4-804d2c52821b"), "E6DE8827-B7C2-46E9-9227-66E6ECE676A8", 150000.0, null, new DateTime(2023, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(9532), 60000.0, false, null, null, new Guid("71b4bf27-e569-47a0-b16a-e484533bd9f2") },
                    { new Guid("8efb8acc-2eb9-448d-bfa2-825995f50b59"), "E6DE8827-B7C2-46E9-9227-66E6ECE676A8", 0.0, null, new DateTime(2023, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(9586), 30000.0, false, null, null, new Guid("71b4bf27-e569-47a0-b16a-e484533bd9f2") }
                });

            migrationBuilder.InsertData(
                table: "Menu_Product",
                columns: new[] { "Id", "CreateBy", "Created", "IsDelete", "LastModified", "LastModifiedBy", "MenuID", "PriceOfProductBelongToTimeService", "ProductID" },
                values: new object[,]
                {
                    { new Guid("00285241-9cc8-48f5-8faa-cde955712008"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2975), false, null, null, new Guid("e7a15238-5db0-49bd-94e6-d5f8b77ae6ce"), 35000.0, new Guid("43203ce4-d82c-4c78-8794-2aef22d7ec5b") },
                    { new Guid("188f24e0-7ba1-4fb4-ae2e-3bb0def77b96"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2859), false, null, null, new Guid("5263453c-dae9-45e4-8204-5430a7256cde"), 25000.0, new Guid("b834cf11-cc28-4e7d-9846-2acc8ad33d8c") },
                    { new Guid("2634a773-5bd7-4003-8aa8-a86488337950"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2847), false, null, null, new Guid("5263453c-dae9-45e4-8204-5430a7256cde"), 159000.0, new Guid("4c9ec4b9-1c16-4c7a-90bf-d620aab257b6") },
                    { new Guid("275486aa-5855-4d8a-9dfc-71083d5e615a"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2663), false, null, null, new Guid("e7a15238-5db0-49bd-94e6-d5f8b77ae6ce"), 1000.0, new Guid("ffb05663-954d-4af3-8a41-91af39446f81") },
                    { new Guid("2b7380d8-b37b-4636-a849-63f8e1fc4691"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2842), false, null, null, new Guid("5263453c-dae9-45e4-8204-5430a7256cde"), 35000.0, new Guid("43203ce4-d82c-4c78-8794-2aef22d7ec5b") },
                    { new Guid("2c82caa2-4d5d-46e7-855d-883b537ca3db"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2983), false, null, null, new Guid("5263453c-dae9-45e4-8204-5430a7256cde"), 20000.0, new Guid("43203ce4-d82c-4c78-8794-2aef22d7ec5b") },
                    { new Guid("36600f7b-9a2c-4b32-80de-844ef7d86c8f"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2676), false, null, null, new Guid("5263453c-dae9-45e4-8204-5430a7256cde"), 35000.0, new Guid("1616cc05-8c82-4f8b-a6e0-f60ab3de0d38") },
                    { new Guid("3ed0a42f-6695-4912-bb27-c4f5e305f6ee"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2672), false, null, null, new Guid("e7a15238-5db0-49bd-94e6-d5f8b77ae6ce"), 50000.0, new Guid("107f1f75-b23b-4bc4-92d7-f2e90d067d1f") },
                    { new Guid("4d3f6496-bba0-4314-a86a-2cdb6af35720"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(3000), false, null, null, new Guid("5263453c-dae9-45e4-8204-5430a7256cde"), 50000.0, new Guid("107f1f75-b23b-4bc4-92d7-f2e90d067d1f") },
                    { new Guid("50cf8eec-06b2-4379-a268-228f0e40f73d"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2979), false, null, null, new Guid("e7a15238-5db0-49bd-94e6-d5f8b77ae6ce"), 159000.0, new Guid("4c9ec4b9-1c16-4c7a-90bf-d620aab257b6") },
                    { new Guid("60214b39-89bd-43e1-b076-d3b818e95fe4"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2940), false, null, null, new Guid("e7a15238-5db0-49bd-94e6-d5f8b77ae6ce"), 25000.0, new Guid("b834cf11-cc28-4e7d-9846-2acc8ad33d8c") },
                    { new Guid("712d6610-3b42-454c-84b8-d79e2f186eaa"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2996), false, null, null, new Guid("5263453c-dae9-45e4-8204-5430a7256cde"), 30000.0, new Guid("f31c789c-4a46-45c7-9009-d36681d788c5") },
                    { new Guid("7220929c-a3b6-420d-852f-51f279d4d7aa"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2659), false, null, null, new Guid("e7a15238-5db0-49bd-94e6-d5f8b77ae6ce"), 15000.0, new Guid("e802b6c5-f08e-4eff-b7e7-af95514b4341") },
                    { new Guid("8a43700d-2b59-4183-978c-98f71464913c"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2986), false, null, null, new Guid("5263453c-dae9-45e4-8204-5430a7256cde"), 15000.0, new Guid("e802b6c5-f08e-4eff-b7e7-af95514b4341") },
                    { new Guid("8fe864fb-371e-4dfa-8aa1-4171b6fab6ad"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2934), false, null, null, new Guid("e7a15238-5db0-49bd-94e6-d5f8b77ae6ce"), 100000.0, new Guid("0c308b93-b26a-4224-9d63-28294711aa15") },
                    { new Guid("a617d9bf-0450-461e-9a54-f7aa1f85da66"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2851), false, null, null, new Guid("5263453c-dae9-45e4-8204-5430a7256cde"), 100000.0, new Guid("0c308b93-b26a-4224-9d63-28294711aa15") },
                    { new Guid("a82e3c4b-b394-45b5-8483-4c6b9ad9d183"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2643), false, null, null, new Guid("d3fd2009-c658-4498-bf59-26936918a0c8"), 20000.0, new Guid("43203ce4-d82c-4c78-8794-2aef22d7ec5b") },
                    { new Guid("e5fff3f4-e868-409a-83e1-70108baf390d"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2668), false, null, null, new Guid("5263453c-dae9-45e4-8204-5430a7256cde"), 30000.0, new Guid("f31c789c-4a46-45c7-9009-d36681d788c5") },
                    { new Guid("f3712943-e5b7-43b4-aa77-294370e3d9ed"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(2990), false, null, null, new Guid("5263453c-dae9-45e4-8204-5430a7256cde"), 1000.0, new Guid("ffb05663-954d-4af3-8a41-91af39446f81") }
                });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "Id", "ApplicationUserID", "CreateBy", "Created", "IsDelete", "LastModified", "LastModifiedBy", "OrderStatus", "OrderTokenQR", "StoreID", "TotalPrice", "TripID" },
                values: new object[,]
                {
                    { new Guid("814860c5-ab72-4605-bb47-7e78c78d6fb0"), "E6DE8827-B7C2-46E9-9227-66E6ECE676A8", null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(4940), false, null, null, 0, "1231212QR", new Guid("d3599df7-877e-41c7-832d-14850e5c88bd"), 0.0, new Guid("27421cac-1da7-4df8-9928-7fb636ca42aa") },
                    { new Guid("a8af2f67-447f-4f70-b660-4dd08fa47d4d"), "E6DE8827-B7C2-46E9-9227-66E6ECE676A8", null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(4906), false, null, null, 0, "1231212QR", new Guid("ef443e4b-886c-4c06-8528-51e9cf623867"), 0.0, new Guid("823ad122-7b51-4dab-9d37-b0f238d4a2ff") },
                    { new Guid("d68ee4e5-980e-4ec7-8060-df214d458c79"), "E6DE8827-B7C2-46E9-9227-66E6ECE676A8", null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(4934), false, null, null, 0, "11789212QR", new Guid("aa2610a8-de94-42b7-b12b-1cf8710e05d8"), 0.0, new Guid("9c2ab923-4c57-44d7-9c1a-b44c0d3e6b00") }
                });

            migrationBuilder.InsertData(
                table: "Route_Station",
                columns: new[] { "Id", "CreateBy", "Created", "Duration", "Index", "IsDelete", "LastModified", "LastModifiedBy", "RouteID", "StationID", "StopTime" },
                values: new object[,]
                {
                    { new Guid("15fefdbf-b178-49ba-aa7c-7b3e2dd575bc"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(6580), new TimeSpan(0, 1, 0, 0, 0), 2, false, null, null, new Guid("001a254c-02d4-40e7-a01f-95f393fb41ef"), new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c6"), new TimeSpan(0, 2, 0, 0, 0) },
                    { new Guid("1b22bdb7-1688-42fa-8fae-4af92e32df7f"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(6542), new TimeSpan(0, 0, 30, 0, 0), 1, false, null, null, new Guid("ccc66514-0597-4d43-aaff-0c5d8ee59ffa"), new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c5"), new TimeSpan(0, 0, 30, 0, 0) },
                    { new Guid("2ff9d0d9-474c-4466-b9a8-707b730f415c"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(6558), new TimeSpan(0, 0, 30, 0, 0), 1, false, null, null, new Guid("a437b242-55fc-4146-a2b9-8c952b107e3a"), new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c5"), new TimeSpan(0, 1, 0, 0, 0) },
                    { new Guid("5004477e-1446-467d-8157-972185d64290"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(6627), new TimeSpan(0, 0, 40, 0, 0), 0, false, null, null, new Guid("42f184eb-58b3-4b9b-be52-1da57f8ffb3f"), new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c4"), new TimeSpan(0, 0, 40, 0, 0) },
                    { new Guid("6a82db5a-23cf-4764-b7d1-ccabce5cc317"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(6617), new TimeSpan(0, 1, 40, 0, 0), 3, false, null, null, new Guid("b9f8f712-92ee-4611-ad55-000a8e1b84c6"), new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c9"), new TimeSpan(0, 3, 0, 0, 0) },
                    { new Guid("6e841857-2712-4da3-a15f-aed820adef5a"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(6486), new TimeSpan(0, 0, 30, 0, 0), 2, false, null, null, new Guid("ea675490-eecd-4308-bb71-61b72a9c979f"), new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c7"), new TimeSpan(0, 1, 30, 0, 0) },
                    { new Guid("8de6ed00-50c8-434e-95ce-cc921426e697"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(6605), new TimeSpan(0, 1, 30, 0, 0), 3, false, null, null, new Guid("001a254c-02d4-40e7-a01f-95f393fb41ef"), new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c7"), new TimeSpan(0, 2, 0, 0, 0) },
                    { new Guid("ab2099b4-e511-42ff-9e6a-ee71bddcd482"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(6570), new TimeSpan(0, 0, 30, 0, 0), 1, false, null, null, new Guid("001a254c-02d4-40e7-a01f-95f393fb41ef"), new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c5"), new TimeSpan(0, 2, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Station_Trip",
                columns: new[] { "Id", "Arrived", "CreateBy", "Created", "IsDelete", "LastModified", "LastModifiedBy", "StationID", "TripID" },
                values: new object[,]
                {
                    { new Guid("042d35bc-3a67-487a-be7b-9a8a5442a443"), new DateTime(2023, 12, 23, 14, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(7733), false, null, null, new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c8"), new Guid("5b30c4e9-31ab-456c-b212-dc6b2ba9a3e7") },
                    { new Guid("0e795b79-9fc0-4e82-a022-01f1c55c078d"), new DateTime(2023, 7, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(7427), false, null, null, new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c7"), new Guid("823ad122-7b51-4dab-9d37-b0f238d4a2ff") },
                    { new Guid("141e19cf-f327-4398-bf5f-59d416464c7f"), new DateTime(2023, 6, 16, 13, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(7857), false, null, null, new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c6"), new Guid("9b4d232c-0fda-4ec0-beed-ecd649ee9c52") },
                    { new Guid("42603642-d68e-4079-9c9a-9c094ac02582"), new DateTime(2023, 6, 16, 19, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(7783), false, null, null, new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c5"), new Guid("9c2ab923-4c57-44d7-9c1a-b44c0d3e6b00") },
                    { new Guid("5b3a3f6b-8d09-4508-bc8a-ed3ba3c34ffc"), new DateTime(2023, 10, 19, 22, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(7910), false, null, null, new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c6"), new Guid("8a2ba7d5-7019-49c6-a47d-ab0a072e7932") },
                    { new Guid("786a0332-e6ae-4ade-86dd-85aed1d64d5e"), new DateTime(2023, 11, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(7721), false, null, null, new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c5"), new Guid("27421cac-1da7-4df8-9928-7fb636ca42aa") },
                    { new Guid("8f49a0d1-42d5-4935-bb84-cbd1bf8c3fb0"), new DateTime(2023, 5, 26, 20, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(7765), false, null, null, new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c6"), new Guid("9c2ab923-4c57-44d7-9c1a-b44c0d3e6b00") },
                    { new Guid("add4dbfa-7d32-40de-99da-dfc91ec3a191"), new DateTime(2023, 5, 25, 20, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(7745), false, null, null, new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c8"), new Guid("9c2ab923-4c57-44d7-9c1a-b44c0d3e6b00") },
                    { new Guid("b4d1b7ed-fa0e-4381-9be8-24390478dc4e"), new DateTime(2023, 10, 19, 21, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(7898), false, null, null, new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c5"), new Guid("8a2ba7d5-7019-49c6-a47d-ab0a072e7932") },
                    { new Guid("e4b58354-d532-45d8-860d-952376125871"), new DateTime(2023, 10, 19, 15, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(7949), false, null, null, new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c9"), new Guid("8a2ba7d5-7019-49c6-a47d-ab0a072e7932") },
                    { new Guid("ecf5ddba-e3a8-45d1-ac70-0b29da0e28ca"), new DateTime(2023, 10, 19, 13, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(7936), false, null, null, new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c8"), new Guid("8a2ba7d5-7019-49c6-a47d-ab0a072e7932") },
                    { new Guid("f6ce8a30-a916-45a9-a62e-e53cada57875"), new DateTime(2023, 9, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(7700), false, null, null, new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c6"), new Guid("02859382-d88c-4e69-8c47-b8e0456677d5") }
                });

            migrationBuilder.InsertData(
                table: "Station_Trip",
                columns: new[] { "Id", "Arrived", "CreateBy", "Created", "IsDelete", "LastModified", "LastModifiedBy", "StationID", "TripID" },
                values: new object[] { new Guid("fd2af338-6ff2-4916-8d8a-0ab7742d0b01"), new DateTime(2023, 10, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(7925), false, null, null, new Guid("50cb67f8-421e-4aec-85ed-7114e763d6c7"), new Guid("8a2ba7d5-7019-49c6-a47d-ab0a072e7932") });

            migrationBuilder.InsertData(
                table: "OrderDetail",
                columns: new[] { "Id", "CreateBy", "Created", "IsDelete", "LastModified", "LastModifiedBy", "OrderID", "Price", "ProductID", "Quanity" },
                values: new object[] { new Guid("05a027a2-01b0-40d2-91f7-2a33fc29753f"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5227), false, null, null, new Guid("814860c5-ab72-4605-bb47-7e78c78d6fb0"), 125000.0, new Guid("4c9ec4b9-1c16-4c7a-90bf-d620aab257b6"), 1 });

            migrationBuilder.InsertData(
                table: "OrderDetail",
                columns: new[] { "Id", "CreateBy", "Created", "IsDelete", "LastModified", "LastModifiedBy", "OrderID", "Price", "ProductID", "Quanity" },
                values: new object[] { new Guid("a8b7026d-5def-44ef-9666-6b78682a77cc"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5221), false, null, null, new Guid("d68ee4e5-980e-4ec7-8060-df214d458c79"), 30000.0, new Guid("43203ce4-d82c-4c78-8794-2aef22d7ec5b"), 1 });

            migrationBuilder.InsertData(
                table: "OrderDetail",
                columns: new[] { "Id", "CreateBy", "Created", "IsDelete", "LastModified", "LastModifiedBy", "OrderID", "Price", "ProductID", "Quanity" },
                values: new object[] { new Guid("f6d015a9-d5bb-40e8-a287-623f0af19fc9"), null, new DateTime(2023, 11, 8, 15, 5, 44, 678, DateTimeKind.Local).AddTicks(5210), false, null, null, new Guid("a8af2f67-447f-4f70-b660-4dd08fa47d4d"), 60000.0, new Guid("e802b6c5-f08e-4eff-b7e7-af95514b4341"), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Product_MenuID",
                table: "Menu_Product",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Menu_Product_ProductID",
                table: "Menu_Product",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ApplicationUserID",
                table: "Order",
                column: "ApplicationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StoreID",
                table: "Order",
                column: "StoreID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_TripID",
                table: "Order",
                column: "TripID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderID",
                table: "OrderDetail",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductID",
                table: "OrderDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryID",
                table: "Product",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Route_Station_RouteID",
                table: "Route_Station",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_Route_Station_StationID",
                table: "Route_Station",
                column: "StationID");

            migrationBuilder.CreateIndex(
                name: "IX_Station_StoreID",
                table: "Station",
                column: "StoreID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Station_Trip_StationID",
                table: "Station_Trip",
                column: "StationID");

            migrationBuilder.CreateIndex(
                name: "IX_Station_Trip_TripID",
                table: "Station_Trip",
                column: "TripID");

            migrationBuilder.CreateIndex(
                name: "IX_Store_Menu_MenuId",
                table: "Store_Menu",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_Store_Menu_StoreId",
                table: "Store_Menu",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_RouteId",
                table: "Trip",
                column: "RouteId");

            migrationBuilder.CreateIndex(
                name: "IX_WithDraw_ApplicationUserID",
                table: "WithDraw",
                column: "ApplicationUserID");

            migrationBuilder.CreateIndex(
                name: "IX_WithDraw_PaymentMethodID",
                table: "WithDraw",
                column: "PaymentMethodID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Menu_Product");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "PaymentHistory");

            migrationBuilder.DropTable(
                name: "Route_Station");

            migrationBuilder.DropTable(
                name: "Station_Trip");

            migrationBuilder.DropTable(
                name: "Store_Menu");

            migrationBuilder.DropTable(
                name: "WithDraw");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Station");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Trip");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Store");

            migrationBuilder.DropTable(
                name: "Route");
        }
    }
}
