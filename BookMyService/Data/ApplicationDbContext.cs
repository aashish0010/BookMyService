using BookMyService.Models;
using Microsoft.EntityFrameworkCore;

namespace BookMyService.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {

        }
        public DbSet<Register> RegisterUser { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Booked> BookList { get; set; }
    }
}
