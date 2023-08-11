
using Microsoft.EntityFrameworkCore;
using WebAppEShop.Model.Models;

namespace WebAppEShop.DataAccess.Data
{
    public class ApplicationDbContextClass : DbContext
    {
        public ApplicationDbContextClass(DbContextOptions<ApplicationDbContextClass> options) : base(options)
        {

        }

        public DbSet<CategoryModelClass> CategoriesTableName { get; set; }
        public DbSet<ProductModelClass> ProductTableName { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryModelClass>().HasData(
                new CategoryModelClass { Id = 1016, Name = "Action", DisplayOrder = 1 },
                new CategoryModelClass { Id = 1017, Name = "Sci-fi", DisplayOrder = 2 },
                new CategoryModelClass { Id = 1018, Name = "History", DisplayOrder = 3 },
                new CategoryModelClass { Id = 1019, Name = "Horror", DisplayOrder = 4 },
                new CategoryModelClass { Id = 1020, Name = "Mystery", DisplayOrder = 5 },
                new CategoryModelClass { Id = 1021, Name = "Comedy", DisplayOrder = 6 }
                );
            
            modelBuilder.Entity<ProductModelClass>().HasData(
                new ProductModelClass
                {
                    Id = 1,
                    Title = "Fortune of Time",
                    Author = "Billy Spark",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SWD9999001",
                    ListPrice = 99,
                    Price = 90,
                    Price50 = 85,
                    Price100 = 80,
                    ImageUrl = "",
                    CategoryId = 1016,
                },
                new ProductModelClass
                {
                    Id = 2,
                    Title = "Dark Skies",
                    Author = "Nancy Hoover",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "CAW777777701",
                    ListPrice = 40,
                    Price = 30,
                    Price50 = 25,
                    Price100 = 20,
                    ImageUrl = "",
                    CategoryId = 1017,
                },
                new ProductModelClass
                {
                    Id = 3,
                    Title = "Vanish in the Sunset",
                    Author = "Julian Button",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "RITO5555501",
                    ListPrice = 55,
                    Price = 50,
                    Price50 = 40,
                    Price100 = 35,
                    ImageUrl = "",
                    CategoryId = 1018,
                },
                new ProductModelClass
                {
                    Id = 4,
                    Title = "Cotton Candy",
                    Author = "Abby Muscles",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "WS3333333301",
                    ListPrice = 70,
                    Price = 65,
                    Price50 = 60,
                    Price100 = 55,
                    ImageUrl = "",
                    CategoryId = 1019,
                },
                new ProductModelClass
                {
                    Id = 5,
                    Title = "Rock in the Ocean",
                    Author = "Ron Parker",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "SOTJ1111111101",
                    ListPrice = 30,
                    Price = 27,
                    Price50 = 25,
                    Price100 = 20,
                    ImageUrl = "",
                    CategoryId = 1020,
                },
                new ProductModelClass
                {
                    Id = 6,
                    Title = "Leaves and Wonders",
                    Author = "Laura Phantom",
                    Description = "Praesent vitae sodales libero. Praesent molestie orci augue, vitae euismod velit sollicitudin ac. Praesent vestibulum facilisis nibh ut ultricies.\r\n\r\nNunc malesuada viverra ipsum sit amet tincidunt. ",
                    ISBN = "FOT000000001",
                    ListPrice = 25,
                    Price = 23,
                    Price50 = 22,
                    Price100 = 20,
                    ImageUrl = "",
                    CategoryId = 1021,
                }
                );
        }
    }
}






