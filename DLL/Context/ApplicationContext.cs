using Microsoft.EntityFrameworkCore;
using DLL.DTO;

namespace DLL.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationContext()
        {
            //Database.EnsureDeleted();//TO Delete before release
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb1)\\mssqllocaldb;Database=diploma;Trusted_Connection=True;");
        }
    }
}
