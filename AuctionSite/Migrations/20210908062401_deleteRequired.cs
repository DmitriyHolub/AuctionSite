using Microsoft.EntityFrameworkCore.Migrations;

namespace AuctionSite.Migrations
{
    public partial class deleteRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LotImage_Lots_ImageId",
                table: "LotImage");

            migrationBuilder.DropForeignKey(
                name: "FK_Lots_TypeLot_TypeOfLotId",
                table: "Lots");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeLotUser_TypeLot_FavoriteTypesOfLotsId",
                table: "TypeLotUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeLot",
                table: "TypeLot");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LotImage",
                table: "LotImage");

            migrationBuilder.RenameTable(
                name: "TypeLot",
                newName: "TypeLots");

            migrationBuilder.RenameTable(
                name: "LotImage",
                newName: "LotImages");

            migrationBuilder.RenameIndex(
                name: "IX_LotImage_ImageId",
                table: "LotImages",
                newName: "IX_LotImages_ImageId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ProductDescription",
                table: "Lots",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LotName",
                table: "Lots",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeLots",
                table: "TypeLots",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LotImages",
                table: "LotImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LotImages_Lots_ImageId",
                table: "LotImages",
                column: "ImageId",
                principalTable: "Lots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lots_TypeLots_TypeOfLotId",
                table: "Lots",
                column: "TypeOfLotId",
                principalTable: "TypeLots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeLotUser_TypeLots_FavoriteTypesOfLotsId",
                table: "TypeLotUser",
                column: "FavoriteTypesOfLotsId",
                principalTable: "TypeLots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LotImages_Lots_ImageId",
                table: "LotImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Lots_TypeLots_TypeOfLotId",
                table: "Lots");

            migrationBuilder.DropForeignKey(
                name: "FK_TypeLotUser_TypeLots_FavoriteTypesOfLotsId",
                table: "TypeLotUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeLots",
                table: "TypeLots");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LotImages",
                table: "LotImages");

            migrationBuilder.RenameTable(
                name: "TypeLots",
                newName: "TypeLot");

            migrationBuilder.RenameTable(
                name: "LotImages",
                newName: "LotImage");

            migrationBuilder.RenameIndex(
                name: "IX_LotImages_ImageId",
                table: "LotImage",
                newName: "IX_LotImage_ImageId");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductDescription",
                table: "Lots",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LotName",
                table: "Lots",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeLot",
                table: "TypeLot",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LotImage",
                table: "LotImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LotImage_Lots_ImageId",
                table: "LotImage",
                column: "ImageId",
                principalTable: "Lots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lots_TypeLot_TypeOfLotId",
                table: "Lots",
                column: "TypeOfLotId",
                principalTable: "TypeLot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TypeLotUser_TypeLot_FavoriteTypesOfLotsId",
                table: "TypeLotUser",
                column: "FavoriteTypesOfLotsId",
                principalTable: "TypeLot",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
