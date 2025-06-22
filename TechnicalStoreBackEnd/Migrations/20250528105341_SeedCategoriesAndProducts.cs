using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TechnicalStoreBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategoriesAndProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CategoryName",
                value: "Телевизоры");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "CategoryName",
                value: "Ноутбуки");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "CategoryName",
                value: "Колонки");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "CategoryName",
                value: "Планшеты");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Availability", "Brand", "CategoryId", "Images", "Model", "NewPrice", "OldPrice", "Ram", "Storage" },
                values: new object[,]
                {
                    { 100, "В наличии", "Apple", 1, "/img/tovar/iphone14.jpg", "iPhone 14", 900m, 1000m, "8GB", "128GB" },
                    { 101, "В наличии", "Samsung", 1, "/img/tovar/galaxys23.jpg", "Galaxy S23", 1000m, 1100m, "8GB", "128GB" },
                    { 102, "В наличии", "Google", 1, "/img/tovar/pixel7.jpg", "Pixel 7", 850m, 900m, "8GB", "256GB" },
                    { 103, "В наличии", "Sony", 1, "/img/tovar/xperia1iv.jpg", "Xperia 1 IV", 1100m, 1200m, "12GB", "256GB" },
                    { 104, "В наличии", "OnePlus", 1, "/img/tovar/oneplus11.jpg", "OnePlus 11", 900m, 950m, "16GB", "256GB" },
                    { 105, "В наличии", "Xiaomi", 1, "/img/tovar/redminote12.jpg", "Redmi Note 12", 550m, 600m, "6GB", "128GB" },
                    { 106, "В наличии", "Motorola", 1, "/img/tovar/motogpower.jpg", "Moto G Power", 450m, 500m, "4GB", "64GB" },
                    { 107, "В наличии", "Oppo", 1, "/img/tovar/findx5.jpg", "Find X5", 950m, 1000m, "8GB", "256GB" },
                    { 108, "В наличии", "Asus", 1, "/img/tovar/zenfone9.jpg", "Zenfone 9", 750m, 800m, "8GB", "128GB" },
                    { 109, "В наличии", "OnePlus", 1, "/img/tovar/nord3.jpg", "Nord 3", 650m, 700m, "8GB", "128GB" },
                    { 200, "В наличии", "LG", 2, "/img/tovar/oled55c2.jpg", "OLED55C2", 1400m, 1500m, null, null },
                    { 201, "В наличии", "Samsung", 2, "/img/tovar/qledq80b.jpg", "QLED Q80B", 1500m, 1600m, null, null },
                    { 202, "В наличии", "Sony", 2, "/img/tovar/braviaxr.jpg", "Bravia XR", 1600m, 1700m, null, null },
                    { 203, "В наличии", "Samsung", 2, "/img/tovar/neoqled.jpg", "Neo QLED", 1900m, 2000m, null, null },
                    { 204, "В наличии", "Hisense", 2, "/img/tovar/u8h.jpg", "U8H", 1100m, 1200m, null, null },
                    { 205, "В наличии", "Sony", 2, "/img/tovar/a90j.jpg", "A90J", 2400m, 2500m, null, null },
                    { 206, "В наличии", "TCL", 2, "/img/tovar/c835.jpg", "C835", 1200m, 1300m, null, null },
                    { 207, "В наличии", "Samsung", 2, "/img/tovar/qn85b.jpg", "QN85B", 1700m, 1800m, null, null },
                    { 208, "В наличии", "LG", 2, "/img/tovar/g2oled.jpg", "G2 OLED", 2100m, 2200m, null, null },
                    { 209, "В наличии", "TCL", 2, "/img/tovar/r635.jpg", "R635", 950m, 1000m, null, null },
                    { 300, "В наличии", "Apple", 3, "/img/tovar/macbookairm2.jpg", "MacBook Air M2", 1200m, 1300m, "8GB", "256GB" },
                    { 301, "В наличии", "Dell", 3, "/img/tovar/xps13.jpg", "XPS 13", 1300m, 1400m, "16GB", "512GB" },
                    { 302, "В наличии", "Lenovo", 3, "/img/tovar/thinkpadx1.jpg", "ThinkPad X1", 1400m, 1500m, "16GB", "512GB" },
                    { 303, "В наличии", "HP", 3, "/img/tovar/spectrex360.jpg", "Spectre x360", 1500m, 1600m, "16GB", "1TB" },
                    { 304, "В наличии", "Asus", 3, "/img/tovar/zenbook14.jpg", "ZenBook 14", 1100m, 1200m, "8GB", "512GB" },
                    { 305, "В наличии", "Microsoft", 3, "/img/tovar/surfacelaptop5.jpg", "Surface Laptop 5", 1300m, 1400m, "8GB", "256GB" },
                    { 306, "В наличии", "Dell", 3, "/img/tovar/inspiron14.jpg", "Inspiron 14", 950m, 1000m, "8GB", "256GB" },
                    { 307, "В наличии", "Lenovo", 3, "/img/tovar/legion5.jpg", "Legion 5", 1400m, 1500m, "16GB", "1TB" },
                    { 308, "В наличии", "Asus", 3, "/img/tovar/rogzephyrus.jpg", "ROG Zephyrus", 1700m, 1800m, "16GB", "1TB" },
                    { 309, "В наличии", "HP", 3, "/img/tovar/pavilion15.jpg", "Pavilion 15", 1000m, 1100m, "8GB", "512GB" },
                    { 400, "В наличии", "Apple", 4, "/img/tovar/homepodmini.jpg", "HomePod Mini", 90m, 100m, null, null },
                    { 401, "В наличии", "Amazon", 4, "/img/tovar/echodot5.jpg", "Echo Dot 5", 50m, 60m, null, null },
                    { 402, "В наличии", "Bose", 4, "/img/tovar/soundlink.jpg", "SoundLink", 140m, 150m, null, null },
                    { 403, "В наличии", "Google", 4, "/img/tovar/nestaudio.jpg", "Nest Audio", 90m, 100m, null, null },
                    { 404, "В наличии", "JBL", 4, "/img/tovar/charge5.jpg", "Charge 5", 170m, 180m, null, null },
                    { 405, "В наличии", "JBL", 4, "/img/tovar/partybox110.jpg", "PartyBox 110", 380m, 400m, null, null },
                    { 406, "В наличии", "Bose", 4, "/img/tovar/soundbar300.jpg", "Soundbar 300", 420m, 450m, null, null },
                    { 407, "В наличии", "Sonos", 4, "/img/tovar/roam.jpg", "Roam", 170m, 180m, null, null },
                    { 408, "В наличии", "JBL", 4, "/img/tovar/flip6.jpg", "Flip 6", 120m, 130m, null, null },
                    { 409, "В наличии", "Sonos", 4, "/img/tovar/onesl.jpg", "One SL", 190m, 200m, null, null },
                    { 500, "В наличии", "Apple", 5, "/img/tovar/ipadair5.jpg", "iPad Air 5", 550m, 600m, "8GB", "64GB" },
                    { 501, "В наличии", "Samsung", 5, "/img/tovar/galaxytabs8.jpg", "Galaxy Tab S8", 650m, 700m, "8GB", "128GB" },
                    { 502, "В наличии", "Microsoft", 5, "/img/tovar/surfacego3.jpg", "Surface Go 3", 500m, 550m, "4GB", "64GB" },
                    { 503, "В наличии", "Huawei", 5, "/img/tovar/matepad11.jpg", "MatePad 11", 450m, 500m, "6GB", "128GB" },
                    { 504, "В наличии", "Lenovo", 5, "/img/tovar/tabp11pro.jpg", "Tab P11 Pro", 550m, 600m, "6GB", "128GB" },
                    { 505, "В наличии", "Apple", 5, "/img/tovar/ipadpro11.jpg", "iPad Pro 11", 850m, 900m, "8GB", "256GB" },
                    { 506, "В наличии", "Samsung", 5, "/img/tovar/taba8.jpg", "Tab A8", 280m, 300m, "4GB", "64GB" },
                    { 507, "В наличии", "Amazon", 5, "/img/tovar/firehd10.jpg", "Fire HD 10", 180m, 200m, "3GB", "32GB" },
                    { 508, "В наличии", "Lenovo", 5, "/img/tovar/yogatab13.jpg", "Yoga Tab 13", 650m, 700m, "8GB", "128GB" },
                    { 509, "В наличии", "Apple", 5, "/img/tovar/ipadmini6.jpg", "iPad Mini 6", 450m, 500m, "4GB", "64GB" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 406);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 407);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 408);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 409);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 500);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 502);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 503);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 504);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 505);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 506);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 507);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 508);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 509);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                column: "CategoryName",
                value: "Ноутбуки");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "CategoryName",
                value: "Планшеты");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                column: "CategoryName",
                value: "Телевизоры");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                column: "CategoryName",
                value: "Колонки");
        }
    }
}
