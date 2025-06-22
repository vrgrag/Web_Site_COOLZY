using Microsoft.EntityFrameworkCore;
using TechnicalStoreBackEnd.Models;

namespace TechnicalStoreBackEnd.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

      public DbSet<Review> Reviews { get; set; }


        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<FavoriteItem> FavoriteItems { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Определение связей
            modelBuilder.Entity<FavoriteItem>().HasKey(f => f.Id);
            modelBuilder.Entity<FavoriteItem>().HasOne(f => f.User).WithMany().HasForeignKey(f => f.UserId);
            modelBuilder.Entity<FavoriteItem>().HasOne(f => f.Product).WithMany().HasForeignKey(f => f.ProductId);

            modelBuilder.Entity<Product>().HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId);
            modelBuilder.Entity<ProductImage>()
    .HasOne(p => p.Product)
    .WithMany(p => p.Images)
    .HasForeignKey(p => p.ProductId);




            modelBuilder.Entity<Admin>().HasOne(a => a.User).WithMany().HasForeignKey(a => a.UserId);
            modelBuilder.Entity<Order>().HasOne(o => o.User).WithMany().HasForeignKey(o => o.UserId);

            modelBuilder.Entity<OrderItem>().HasOne(oi => oi.Order).WithMany(o => o.Items).HasForeignKey(oi => oi.OrderId);
            modelBuilder.Entity<OrderItem>().HasOne(oi => oi.Product).WithMany().HasForeignKey(oi => oi.ProductId);

            modelBuilder.Entity<Cart>()
        .HasOne(c => c.User)
        .WithMany()
        .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.Items)
                .HasForeignKey(ci => ci.CartId);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId);

               


            modelBuilder.Entity<Category>().HasData(
     new Category { CategoryId = 1, Name = "Смартфоны" },
     new Category { CategoryId = 2, Name = "Телевизоры" },
     new Category { CategoryId = 3, Name = "Ноутбуки" },
     new Category { CategoryId = 4, Name = "Колонки" },
     new Category { CategoryId = 5, Name = "Планшеты" }
 );

            // Сидинг данных для Product и ProductImage
            modelBuilder.Entity<Product>().HasData(
                // Смартфоны (Категория 1)
                new Product
                {
                    ProductId = 100,
                    Model = "iPhone 14",
                    Brand = "Apple",
                    OldPrice = 1000m,
                    NewPrice = 900m,
                    Availability = "В наличии",
                    Ram = "8GB",
                    Storage = "128GB",
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 101,
                    Model = "Galaxy S23",
                    Brand = "Samsung",
                    OldPrice = 1100m,
                    NewPrice = 1000m,
                    Availability = "В наличии",
                    Ram = "8GB",
                    Storage = "128GB",
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 102,
                    Model = "Pixel 7",
                    Brand = "Google",
                    OldPrice = 900m,
                    NewPrice = 850m,
                    Availability = "В наличии",
                    Ram = "8GB",
                    Storage = "256GB",
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 103,
                    Model = "Xperia 1 IV",
                    Brand = "Sony",
                    OldPrice = 1200m,
                    NewPrice = 1100m,
                    Availability = "В наличии",
                    Ram = "12GB",
                    Storage = "256GB",
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 104,
                    Model = "OnePlus 11",
                    Brand = "OnePlus",
                    OldPrice = 950m,
                    NewPrice = 900m,
                    Availability = "В наличии",
                    Ram = "16GB",
                    Storage = "256GB",
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 105,
                    Model = "Redmi Note 12",
                    Brand = "Xiaomi",
                    OldPrice = 600m,
                    NewPrice = 550m,
                    Availability = "В наличии",
                    Ram = "6GB",
                    Storage = "128GB",
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 106,
                    Model = "Moto G Power",
                    Brand = "Motorola",
                    OldPrice = 500m,
                    NewPrice = 450m,
                    Availability = "В наличии",
                    Ram = "4GB",
                    Storage = "64GB",
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 107,
                    Model = "Find X5",
                    Brand = "Oppo",
                    OldPrice = 1000m,
                    NewPrice = 950m,
                    Availability = "В наличии",
                    Ram = "8GB",
                    Storage = "256GB",
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 108,
                    Model = "Zenfone 9",
                    Brand = "Asus",
                    OldPrice = 800m,
                    NewPrice = 750m,
                    Availability = "В наличии",
                    Ram = "8GB",
                    Storage = "128GB",
                    CategoryId = 1
                },
                new Product
                {
                    ProductId = 109,
                    Model = "Nord 3",
                    Brand = "OnePlus",
                    OldPrice = 700m,
                    NewPrice = 650m,
                    Availability = "В наличии",
                    Ram = "8GB",
                    Storage = "128GB",
                    CategoryId = 1
                },

                // Телевизоры (Категория 2)
                new Product
                {
                    ProductId = 200,
                    Model = "OLED55C2",
                    Brand = "LG",
                    OldPrice = 1500m,
                    NewPrice = 1400m,
                    Availability = "В наличии",
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 201,
                    Model = "QLED Q80B",
                    Brand = "Samsung",
                    OldPrice = 1600m,
                    NewPrice = 1500m,
                    Availability = "В наличии",
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 202,
                    Model = "Bravia XR",
                    Brand = "Sony",
                    OldPrice = 1700m,
                    NewPrice = 1600m,
                    Availability = "В наличии",
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 203,
                    Model = "Neo QLED",
                    Brand = "Samsung",
                    OldPrice = 2000m,
                    NewPrice = 1900m,
                    Availability = "В наличии",
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 204,
                    Model = "U8H",
                    Brand = "Hisense",
                    OldPrice = 1200m,
                    NewPrice = 1100m,
                    Availability = "В наличии",
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 205,
                    Model = "A90J",
                    Brand = "Sony",
                    OldPrice = 2500m,
                    NewPrice = 2400m,
                    Availability = "В наличии",
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 206,
                    Model = "C835",
                    Brand = "TCL",
                    OldPrice = 1300m,
                    NewPrice = 1200m,
                    Availability = "В наличии",
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 207,
                    Model = "QN85B",
                    Brand = "Samsung",
                    OldPrice = 1800m,
                    NewPrice = 1700m,
                    Availability = "В наличии",
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 208,
                    Model = "G2 OLED",
                    Brand = "LG",
                    OldPrice = 2200m,
                    NewPrice = 2100m,
                    Availability = "В наличии",
                    CategoryId = 2
                },
                new Product
                {
                    ProductId = 209,
                    Model = "R635",
                    Brand = "TCL",
                    OldPrice = 1000m,
                    NewPrice = 950m,
                    Availability = "В наличии",
                    CategoryId = 2
                },

                // Ноутбуки (Категория 3)
                new Product
                {
                    ProductId = 300,
                    Model = "MacBook Air M2",
                    Brand = "Apple",
                    OldPrice = 1300m,
                    NewPrice = 1200m,
                    Availability = "В наличии",
                    Ram = "8GB",
                    Storage = "256GB",
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 301,
                    Model = "XPS 13",
                    Brand = "Dell",
                    OldPrice = 1400m,
                    NewPrice = 1300m,
                    Availability = "В наличии",
                    Ram = "16GB",
                    Storage = "512GB",
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 302,
                    Model = "ThinkPad X1",
                    Brand = "Lenovo",
                    OldPrice = 1500m,
                    NewPrice = 1400m,
                    Availability = "В наличии",
                    Ram = "16GB",
                    Storage = "512GB",
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 303,
                    Model = "Spectre x360",
                    Brand = "HP",
                    OldPrice = 1600m,
                    NewPrice = 1500m,
                    Availability = "В наличии",
                    Ram = "16GB",
                    Storage = "1TB",
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 304,
                    Model = "ZenBook 14",
                    Brand = "Asus",
                    OldPrice = 1200m,
                    NewPrice = 1100m,
                    Availability = "В наличии",
                    Ram = "8GB",
                    Storage = "512GB",
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 305,
                    Model = "Surface Laptop 5",
                    Brand = "Microsoft",
                    OldPrice = 1400m,
                    NewPrice = 1300m,
                    Availability = "В наличии",
                    Ram = "8GB",
                    Storage = "256GB",
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 306,
                    Model = "Inspiron 14",
                    Brand = "Dell",
                    OldPrice = 1000m,
                    NewPrice = 950m,
                    Availability = "В наличии",
                    Ram = "8GB",
                    Storage = "256GB",
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 307,
                    Model = "Legion 5",
                    Brand = "Lenovo",
                    OldPrice = 1500m,
                    NewPrice = 1400m,
                    Availability = "В наличии",
                    Ram = "16GB",
                    Storage = "1TB",
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 308,
                    Model = "ROG Zephyrus",
                    Brand = "Asus",
                    OldPrice = 1800m,
                    NewPrice = 1700m,
                    Availability = "В наличии",
                    Ram = "16GB",
                    Storage = "1TB",
                    CategoryId = 3
                },
                new Product
                {
                    ProductId = 309,
                    Model = "Pavilion 15",
                    Brand = "HP",
                    OldPrice = 1100m,
                    NewPrice = 1000m,
                    Availability = "В наличии",
                    Ram = "8GB",
                    Storage = "512GB",
                    CategoryId = 3
                },

                // Колонки (Категория 4)
                new Product
                {
                    ProductId = 400,
                    Model = "HomePod Mini",
                    Brand = "Apple",
                    OldPrice = 100m,
                    NewPrice = 90m,
                    Availability = "В наличии",
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 401,
                    Model = "Echo Dot 5",
                    Brand = "Amazon",
                    OldPrice = 60m,
                    NewPrice = 50m,
                    Availability = "В наличии",
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 402,
                    Model = "SoundLink",
                    Brand = "Bose",
                    OldPrice = 150m,
                    NewPrice = 140m,
                    Availability = "В наличии",
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 403,
                    Model = "Nest Audio",
                    Brand = "Google",
                    OldPrice = 100m,
                    NewPrice = 90m,
                    Availability = "В наличии",
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 404,
                    Model = "Charge 5",
                    Brand = "JBL",
                    OldPrice = 180m,
                    NewPrice = 170m,
                    Availability = "В наличии",
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 405,
                    Model = "PartyBox 110",
                    Brand = "JBL",
                    OldPrice = 400m,
                    NewPrice = 380m,
                    Availability = "В наличии",
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 406,
                    Model = "Soundbar 300",
                    Brand = "Bose",
                    OldPrice = 450m,
                    NewPrice = 420m,
                    Availability = "В наличии",
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 407,
                    Model = "Roam",
                    Brand = "Sonos",
                    OldPrice = 180m,
                    NewPrice = 170m,
                    Availability = "В наличии",
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 408,
                    Model = "Flip 6",
                    Brand = "JBL",
                    OldPrice = 130m,
                    NewPrice = 120m,
                    Availability = "В наличии",
                    CategoryId = 4
                },
                new Product
                {
                    ProductId = 409,
                    Model = "One SL",
                    Brand = "Sonos",
                    OldPrice = 200m,
                    NewPrice = 190m,
                    Availability = "В наличии",
                    CategoryId = 4
                },

                // Планшеты (Категория 5)
                new Product
                {
                    ProductId = 500,
                    Model = "iPad Air 5",
                    Brand = "Apple",
                    OldPrice = 600m,
                    NewPrice = 550m,
                    Availability = "В наличии",
                    Ram = "8GB",
                    Storage = "64GB",
                    CategoryId = 5
                },
                new Product
                {
                    ProductId = 501,
                    Model = "Galaxy Tab S8",
                    Brand = "Samsung",
                    OldPrice = 700m,
                    NewPrice = 650m,
                    Availability = "В наличии",
                    Ram = "8GB",
                    Storage = "128GB",
                    CategoryId = 5
                },
                new Product
                {
                    ProductId = 502,
                    Model = "Surface Go 3",
                    Brand = "Microsoft",
                    OldPrice = 550m,
                    NewPrice = 500m,
                    Availability = "В наличии",
                    Ram = "4GB",
                    Storage = "64GB",
                    CategoryId = 5
                },
                new Product
                {
                    ProductId = 503,
                    Model = "MatePad 11",
                    Brand = "Huawei",
                    OldPrice = 500m,
                    NewPrice = 450m,
                    Availability = "В наличии",
                    Ram = "6GB",
                    Storage = "128GB",
                    CategoryId = 5
                },
                new Product
                {
                    ProductId = 504,
                    Model = "Tab P11 Pro",
                    Brand = "Lenovo",
                    OldPrice = 600m,
                    NewPrice = 550m,
                    Availability = "В наличии",
                    Ram = "6GB",
                    Storage = "128GB",
                    CategoryId = 5
                },
                new Product
                {
                    ProductId = 505,
                    Model = "iPad Pro 11",
                    Brand = "Apple",
                    OldPrice = 900m,
                    NewPrice = 850m,
                    Availability = "В наличии",
                    Ram = "8GB",
                    Storage = "256GB",
                    CategoryId = 5
                },
                new Product
                {
                    ProductId = 506,
                    Model = "Tab A8",
                    Brand = "Samsung",
                    OldPrice = 300m,
                    NewPrice = 280m,
                    Availability = "В наличии",
                    Ram = "4GB",
                    Storage = "64GB",
                    CategoryId = 5
                },
                new Product
                {
                    ProductId = 507,
                    Model = "Fire HD 10",
                    Brand = "Amazon",
                    OldPrice = 200m,
                    NewPrice = 180m,
                    Availability = "В наличии",
                    Ram = "3GB",
                    Storage = "32GB",
                    CategoryId = 5
                },
                new Product
                {
                    ProductId = 508,
                    Model = "Yoga Tab 13",
                    Brand = "Lenovo",
                    OldPrice = 700m,
                    NewPrice = 650m,
                    Availability = "В наличии",
                    Ram = "8GB",
                    Storage = "128GB",
                    CategoryId = 5
                },
                new Product
                {
                    ProductId = 509,
                    Model = "iPad Mini 6",
                    Brand = "Apple",
                    OldPrice = 500m,
                    NewPrice = 450m,
                    Availability = "В наличии",
                    Ram = "4GB",
                    Storage = "64GB",
                    CategoryId = 5
                }
            );

            // Сидинг данных для ProductImage
            modelBuilder.Entity<ProductImage>().HasData(
                // Смартфоны
                new ProductImage { ImageId = 1, ProductId = 100, ImageUrl = "/img/tovar/iphone14.jpg" },
                new ProductImage { ImageId = 2, ProductId = 101, ImageUrl = "/img/tovar/galaxys23.jpg" },
                new ProductImage { ImageId = 3, ProductId = 102, ImageUrl = "/img/tovar/pixel7.jpg" },
                new ProductImage { ImageId = 4, ProductId = 103, ImageUrl = "/img/tovar/xperia1iv.jpg" },
                new ProductImage { ImageId = 5, ProductId = 104, ImageUrl = "/img/tovar/oneplus11.jpg" },
                new ProductImage { ImageId = 6, ProductId = 105, ImageUrl = "/img/tovar/redminote12.jpg" },
                new ProductImage { ImageId = 7, ProductId = 106, ImageUrl = "/img/tovar/motogpower.jpg" },
                new ProductImage { ImageId = 8, ProductId = 107, ImageUrl = "/img/tovar/findx5.jpg" },
                new ProductImage { ImageId = 9, ProductId = 108, ImageUrl = "/img/tovar/zenfone9.jpg" },
                new ProductImage { ImageId = 10, ProductId = 109, ImageUrl = "/img/tovar/nord3.jpg" },

                // Телевизоры
                new ProductImage { ImageId = 11, ProductId = 200, ImageUrl = "/img/tovar/oled55c2.jpg" },
                new ProductImage { ImageId = 12, ProductId = 201, ImageUrl = "/img/tovar/qledq80b.jpg" },
                new ProductImage { ImageId = 13, ProductId = 202, ImageUrl = "/img/tovar/braviaxr.jpg" },
                new ProductImage { ImageId = 14, ProductId = 203, ImageUrl = "/img/tovar/neoqled.jpg" },
                new ProductImage { ImageId = 15, ProductId = 204, ImageUrl = "/img/tovar/u8h.jpg" },
                new ProductImage { ImageId = 16, ProductId = 205, ImageUrl = "/img/tovar/a90j.jpg" },
                new ProductImage { ImageId = 17, ProductId = 206, ImageUrl = "/img/tovar/c835.jpg" },
                new ProductImage { ImageId = 18, ProductId = 207, ImageUrl = "/img/tovar/qn85b.jpg" },
                new ProductImage { ImageId = 19, ProductId = 208, ImageUrl = "/img/tovar/g2oled.jpg" },
                new ProductImage { ImageId = 20, ProductId = 209, ImageUrl = "/img/tovar/r635.jpg" },

                // Ноутбуки
                new ProductImage { ImageId = 21, ProductId = 300, ImageUrl = "/img/tovar/macbookairm2.jpg" },
                new ProductImage { ImageId = 22, ProductId = 301, ImageUrl = "/img/tovar/xps13.jpg" },
                new ProductImage { ImageId = 23, ProductId = 302, ImageUrl = "/img/tovar/thinkpadx1.jpg" },
                new ProductImage { ImageId = 24, ProductId = 303, ImageUrl = "/img/tovar/spectrex360.jpg" },
                new ProductImage { ImageId = 25, ProductId = 304, ImageUrl = "/img/tovar/zenbook14.jpg" },
                new ProductImage { ImageId = 26, ProductId = 305, ImageUrl = "/img/tovar/surfacelaptop5.jpg" },
                new ProductImage { ImageId = 27, ProductId = 306, ImageUrl = "/img/tovar/inspiron14.jpg" },
                new ProductImage { ImageId = 28, ProductId = 307, ImageUrl = "/img/tovar/legion5.jpg" },
                new ProductImage { ImageId = 29, ProductId = 308, ImageUrl = "/img/tovar/rogzephyrus.jpg" },
                new ProductImage { ImageId = 30, ProductId = 309, ImageUrl = "/img/tovar/pavilion15.jpg" },

                // Колонки
                new ProductImage { ImageId = 31, ProductId = 400, ImageUrl = "/img/tovar/homepodmini.jpg" },
                new ProductImage { ImageId = 32, ProductId = 401, ImageUrl = "/img/tovar/echodot5.jpg" },
                new ProductImage { ImageId = 33, ProductId = 402, ImageUrl = "/img/tovar/soundlink.jpg" },
                new ProductImage { ImageId = 34, ProductId = 403, ImageUrl = "/img/tovar/nestaudio.jpg" },
                new ProductImage { ImageId = 35, ProductId = 404, ImageUrl = "/img/tovar/charge5.jpg" },
                new ProductImage { ImageId = 36, ProductId = 405, ImageUrl = "/img/tovar/partybox110.jpg" },
                new ProductImage { ImageId = 37, ProductId = 406, ImageUrl = "/img/tovar/soundbar300.jpg" },
                new ProductImage { ImageId = 38, ProductId = 407, ImageUrl = "/img/tovar/roam.jpg" },
                new ProductImage { ImageId = 39, ProductId = 408, ImageUrl = "/img/tovar/flip6.jpg" },
                new ProductImage { ImageId = 40, ProductId = 409, ImageUrl = "/img/tovar/onesl.jpg" },

                // Планшеты
                new ProductImage { ImageId = 41, ProductId = 500, ImageUrl = "/img/tovar/ipadair5.jpg" },
                new ProductImage { ImageId = 42, ProductId = 501, ImageUrl = "/img/tovar/galaxytabs8.jpg" },
                new ProductImage { ImageId = 43, ProductId = 502, ImageUrl = "/img/tovar/surfacego3.jpg" },
                new ProductImage { ImageId = 44, ProductId = 503, ImageUrl = "/img/tovar/matepad11.jpg" },
                new ProductImage { ImageId = 45, ProductId = 504, ImageUrl = "/img/tovar/tabp11pro.jpg" },
                new ProductImage { ImageId = 46, ProductId = 505, ImageUrl = "/img/tovar/ipadpro11.jpg" },
                new ProductImage { ImageId = 47, ProductId = 506, ImageUrl = "/img/tovar/taba8.jpg" },
                new ProductImage { ImageId = 48, ProductId = 507, ImageUrl = "/img/tovar/firehd10.jpg" },
                new ProductImage { ImageId = 49, ProductId = 508, ImageUrl = "/img/tovar/yogatab13.jpg" },
                new ProductImage { ImageId = 50, ProductId = 509, ImageUrl = "/img/tovar/ipadmini6.jpg" }
            );
        }
    }
}
