using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment.Domain.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "User",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 15, 9, 29, 55, 194, DateTimeKind.Local).AddTicks(1960),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2022, 6, 29, 7, 32, 0, 600, DateTimeKind.Local).AddTicks(380));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "ProductRating",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 15, 9, 29, 55, 193, DateTimeKind.Local).AddTicks(6688),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2022, 6, 29, 7, 32, 0, 599, DateTimeKind.Local).AddTicks(5033));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Product",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 15, 9, 29, 55, 193, DateTimeKind.Local).AddTicks(7881),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2022, 6, 29, 7, 32, 0, 599, DateTimeKind.Local).AddTicks(6236));

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "OrderDetail",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 15, 9, 29, 55, 193, DateTimeKind.Local).AddTicks(5855),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2022, 6, 29, 7, 32, 0, 599, DateTimeKind.Local).AddTicks(3959));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Order",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 15, 9, 29, 55, 193, DateTimeKind.Local).AddTicks(5009),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2022, 6, 29, 7, 32, 0, 599, DateTimeKind.Local).AddTicks(3151));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Category",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2022, 7, 15, 9, 29, 55, 193, DateTimeKind.Local).AddTicks(3336),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2022, 6, 29, 7, 32, 0, 599, DateTimeKind.Local).AddTicks(1403));

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId",
                table: "Images",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Product");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "User",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 29, 7, 32, 0, 600, DateTimeKind.Local).AddTicks(380),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2022, 7, 15, 9, 29, 55, 194, DateTimeKind.Local).AddTicks(1960));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "ProductRating",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 29, 7, 32, 0, 599, DateTimeKind.Local).AddTicks(5033),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2022, 7, 15, 9, 29, 55, 193, DateTimeKind.Local).AddTicks(6688));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Product",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 29, 7, 32, 0, 599, DateTimeKind.Local).AddTicks(6236),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2022, 7, 15, 9, 29, 55, 193, DateTimeKind.Local).AddTicks(7881));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "OrderDetail",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 29, 7, 32, 0, 599, DateTimeKind.Local).AddTicks(3959),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2022, 7, 15, 9, 29, 55, 193, DateTimeKind.Local).AddTicks(5855));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Order",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 29, 7, 32, 0, 599, DateTimeKind.Local).AddTicks(3151),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2022, 7, 15, 9, 29, 55, 193, DateTimeKind.Local).AddTicks(5009));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Category",
                type: "smalldatetime",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 29, 7, 32, 0, 599, DateTimeKind.Local).AddTicks(1403),
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValue: new DateTime(2022, 7, 15, 9, 29, 55, 193, DateTimeKind.Local).AddTicks(3336));
        }
    }
}
