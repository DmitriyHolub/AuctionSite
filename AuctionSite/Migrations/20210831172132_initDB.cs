using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionSite.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TypeLot",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeOfLot = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeLot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeOfUSer = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankCards",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankCards_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lots",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LotName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusLot = table.Column<int>(type: "int", nullable: false),
                    StartPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BuyoutPrice = table.Column<double>(type: "float", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastBidUserId = table.Column<long>(type: "bigint", nullable: true),
                    UserCreatorId = table.Column<long>(type: "bigint", nullable: true),
                    TypeOfLotId = table.Column<long>(type: "bigint", nullable: true),
                    CheckAdmin = table.Column<bool>(type: "bit", nullable: false),
                    StartBidding = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishBidding = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lots_TypeLot_TypeOfLotId",
                        column: x => x.TypeOfLotId,
                        principalTable: "TypeLot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lots_Users_LastBidUserId",
                        column: x => x.LastBidUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lots_Users_UserCreatorId",
                        column: x => x.UserCreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TypeLotUser",
                columns: table => new
                {
                    FavoriteTypesOfLotsId = table.Column<long>(type: "bigint", nullable: false),
                    UserFavoriteTypeOfLotId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeLotUser", x => new { x.FavoriteTypesOfLotsId, x.UserFavoriteTypeOfLotId });
                    table.ForeignKey(
                        name: "FK_TypeLotUser_TypeLot_FavoriteTypesOfLotsId",
                        column: x => x.FavoriteTypesOfLotsId,
                        principalTable: "TypeLot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypeLotUser_Users_UserFavoriteTypeOfLotId",
                        column: x => x.UserFavoriteTypeOfLotId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LotImage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LotImage_Lots_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Lots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LotUser",
                columns: table => new
                {
                    ObservedLotsId = table.Column<long>(type: "bigint", nullable: false),
                    ObserversId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LotUser", x => new { x.ObservedLotsId, x.ObserversId });
                    table.ForeignKey(
                        name: "FK_LotUser_Lots_ObservedLotsId",
                        column: x => x.ObservedLotsId,
                        principalTable: "Lots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LotUser_Users_ObserversId",
                        column: x => x.ObserversId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankCards_OwnerId",
                table: "BankCards",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_LotImage_ImageId",
                table: "LotImage",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_LastBidUserId",
                table: "Lots",
                column: "LastBidUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_TypeOfLotId",
                table: "Lots",
                column: "TypeOfLotId");

            migrationBuilder.CreateIndex(
                name: "IX_Lots_UserCreatorId",
                table: "Lots",
                column: "UserCreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_LotUser_ObserversId",
                table: "LotUser",
                column: "ObserversId");

            migrationBuilder.CreateIndex(
                name: "IX_TypeLotUser_UserFavoriteTypeOfLotId",
                table: "TypeLotUser",
                column: "UserFavoriteTypeOfLotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankCards");

            migrationBuilder.DropTable(
                name: "LotImage");

            migrationBuilder.DropTable(
                name: "LotUser");

            migrationBuilder.DropTable(
                name: "TypeLotUser");

            migrationBuilder.DropTable(
                name: "Lots");

            migrationBuilder.DropTable(
                name: "TypeLot");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
