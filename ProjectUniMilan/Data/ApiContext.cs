using Microsoft.EntityFrameworkCore;
using ProjectUniMilan.Models;
namespace ProjectUniMilan.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<FoodItem> FoodItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Menu> Menus { get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) 
        {

        }





    }
}