using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechnicalStoreBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class FixProductImageRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Images",
                table: "Products");

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "ImageId", "ImageUrl", "ProductId" },
                values: new object[,]
                {
                    { 1, "/img/tovar/iphone14.jpg", 100 },
                    { 2, "/img/tovar/galaxys23.jpg", 101 },
                    { 3, "/img/tovar/pixel7.jpg", 102 },
                    { 4, "/img/tovar/xperia1iv.jpg", 103 },
                    { 5, "/img/tovar/oneplus11.jpg", 104 },
                    { 6, "/img/tovar/redminote12.jpg", 105 },
                    { 7, "/img/tovar/motogpower.jpg", 106 },
                    { 8, "/img/tovar/findx5.jpg", 107 },
                    { 9, "/img/tovar/zenfone9.jpg", 108 },
                    { 10, "/img/tovar/nord3.jpg", 109 },
                    { 11, "/img/tovar/oled55c2.jpg", 200 },
                    { 12, "/img/tovar/qledq80b.jpg", 201 },
                    { 13, "/img/tovar/braviaxr.jpg", 202 },
                    { 14, "/img/tovar/neoqled.jpg", 203 },
                    { 15, "/img/tovar/u8h.jpg", 204 },
                    { 16, "/img/tovar/a90j.jpg", 205 },
                    { 17, "/img/tovar/c835.jpg", 206 },
                    { 18, "/img/tovar/qn85b.jpg", 207 },
                    { 19, "/img/tovar/g2oled.jpg", 208 },
                    { 20, "/img/tovar/r635.jpg", 209 },
                    { 21, "/img/tovar/macbookairm2.jpg", 300 },
                    { 22, "/img/tovar/xps13.jpg", 301 },
                    { 23, "/img/tovar/thinkpadx1.jpg", 302 },
                    { 24, "/img/tovar/spectrex360.jpg", 303 },
                    { 25, "/img/tovar/zenbook14.jpg", 304 },
                    { 26, "/img/tovar/surfacelaptop5.jpg", 305 },
                    { 27, "/img/tovar/inspiron14.jpg", 306 },
                    { 28, "/img/tovar/legion5.jpg", 307 },
                    { 29, "/img/tovar/rogzephyrus.jpg", 308 },
                    { 30, "/img/tovar/pavilion15.jpg", 309 },
                    { 31, "/img/tovar/homepodmini.jpg", 400 },
                    { 32, "/img/tovar/echodot5.jpg", 401 },
                    { 33, "/img/tovar/soundlink.jpg", 402 },
                    { 34, "/img/tovar/nestaudio.jpg", 403 },
                    { 35, "/img/tovar/charge5.jpg", 404 },
                    { 36, "/img/tovar/partybox110.jpg", 405 },
                    { 37, "/img/tovar/soundbar300.jpg", 406 },
                    { 38, "/img/tovar/roam.jpg", 407 },
                    { 39, "/img/tovar/flip6.jpg", 408 },
                    { 40, "/img/tovar/onesl.jpg", 409 },
                    { 41, "/img/tovar/ipadair5.jpg", 500 },
                    { 42, "/img/tovar/galaxytabs8.jpg", 501 },
                    { 43, "/img/tovar/surfacego3.jpg", 502 },
                    { 44, "/img/tovar/matepad11.jpg", 503 },
                    { 45, "/img/tovar/tabp11pro.jpg", 504 },
                    { 46, "/img/tovar/ipadpro11.jpg", 505 },
                    { 47, "/img/tovar/taba8.jpg", 506 },
                    { 48, "/img/tovar/firehd10.jpg", 507 },
                    { 49, "/img/tovar/yogatab13.jpg", 508 },
                    { 50, "/img/tovar/ipadmini6.jpg", 509 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "ImageId",
                keyValue: 50);

            migrationBuilder.AddColumn<string>(
                name: "Images",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 100,
                column: "Images",
                value: "/img/tovar/iphone14.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 101,
                column: "Images",
                value: "/img/tovar/galaxys23.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 102,
                column: "Images",
                value: "/img/tovar/pixel7.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 103,
                column: "Images",
                value: "/img/tovar/xperia1iv.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 104,
                column: "Images",
                value: "/img/tovar/oneplus11.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 105,
                column: "Images",
                value: "/img/tovar/redminote12.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 106,
                column: "Images",
                value: "/img/tovar/motogpower.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 107,
                column: "Images",
                value: "/img/tovar/findx5.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 108,
                column: "Images",
                value: "/img/tovar/zenfone9.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 109,
                column: "Images",
                value: "/img/tovar/nord3.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 200,
                column: "Images",
                value: "/img/tovar/oled55c2.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 201,
                column: "Images",
                value: "/img/tovar/qledq80b.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 202,
                column: "Images",
                value: "/img/tovar/braviaxr.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 203,
                column: "Images",
                value: "/img/tovar/neoqled.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 204,
                column: "Images",
                value: "/img/tovar/u8h.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 205,
                column: "Images",
                value: "/img/tovar/a90j.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 206,
                column: "Images",
                value: "/img/tovar/c835.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 207,
                column: "Images",
                value: "/img/tovar/qn85b.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 208,
                column: "Images",
                value: "/img/tovar/g2oled.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 209,
                column: "Images",
                value: "/img/tovar/r635.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 300,
                column: "Images",
                value: "/img/tovar/macbookairm2.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 301,
                column: "Images",
                value: "/img/tovar/xps13.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 302,
                column: "Images",
                value: "/img/tovar/thinkpadx1.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 303,
                column: "Images",
                value: "/img/tovar/spectrex360.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 304,
                column: "Images",
                value: "/img/tovar/zenbook14.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 305,
                column: "Images",
                value: "/img/tovar/surfacelaptop5.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 306,
                column: "Images",
                value: "/img/tovar/inspiron14.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 307,
                column: "Images",
                value: "/img/tovar/legion5.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 308,
                column: "Images",
                value: "/img/tovar/rogzephyrus.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 309,
                column: "Images",
                value: "/img/tovar/pavilion15.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 400,
                column: "Images",
                value: "/img/tovar/homepodmini.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 401,
                column: "Images",
                value: "/img/tovar/echodot5.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 402,
                column: "Images",
                value: "/img/tovar/soundlink.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 403,
                column: "Images",
                value: "/img/tovar/nestaudio.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 404,
                column: "Images",
                value: "/img/tovar/charge5.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 405,
                column: "Images",
                value: "/img/tovar/partybox110.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 406,
                column: "Images",
                value: "/img/tovar/soundbar300.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 407,
                column: "Images",
                value: "/img/tovar/roam.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 408,
                column: "Images",
                value: "/img/tovar/flip6.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 409,
                column: "Images",
                value: "/img/tovar/onesl.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 500,
                column: "Images",
                value: "/img/tovar/ipadair5.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 501,
                column: "Images",
                value: "/img/tovar/galaxytabs8.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 502,
                column: "Images",
                value: "/img/tovar/surfacego3.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 503,
                column: "Images",
                value: "/img/tovar/matepad11.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 504,
                column: "Images",
                value: "/img/tovar/tabp11pro.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 505,
                column: "Images",
                value: "/img/tovar/ipadpro11.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 506,
                column: "Images",
                value: "/img/tovar/taba8.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 507,
                column: "Images",
                value: "/img/tovar/firehd10.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 508,
                column: "Images",
                value: "/img/tovar/yogatab13.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 509,
                column: "Images",
                value: "/img/tovar/ipadmini6.jpg");
        }
    }
}
