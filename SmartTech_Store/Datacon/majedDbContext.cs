using Microsoft.EntityFrameworkCore;
using SmartTech_Store.Models;

namespace SmartTech_Store.Datacon
{
    public class majedDbContext :DbContext
    {
        public majedDbContext(DbContextOptions<majedDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Shop> Shops { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Department> Departments { get; set; }

    }
}
