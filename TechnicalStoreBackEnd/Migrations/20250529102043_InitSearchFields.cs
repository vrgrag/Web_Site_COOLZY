using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalStoreBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class InitSearchFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 100,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 101,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 102,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 103,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 104,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 105,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 106,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 107,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 108,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 109,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 200,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 201,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 202,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 203,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 204,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 205,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 206,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 207,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 208,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 209,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 300,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 301,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 302,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 303,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 304,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 305,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 306,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 307,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 308,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 309,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 400,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 401,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 402,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 403,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 404,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 405,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 406,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 407,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 408,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 409,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 500,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 501,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 502,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 503,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 504,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 505,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 506,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 507,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 508,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 509,
                columns: new[] { "Description", "Name" },
                values: new object[] { "", "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "CategoryName");
        }
    }
}
