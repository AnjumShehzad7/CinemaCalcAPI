using Microsoft.EntityFrameworkCore;
using CinemaCalcAPI.Models;

namespace CinemaCalcAPI.Data
{
    public class CinemaCalcContext : DbContext
    {
        // Constructor to pass DbContext options to the base class
        public CinemaCalcContext(DbContextOptions<CinemaCalcContext> options) : base(options) { }

        // DbSet representing the Expenses table in the database
        public DbSet<Expense> Expenses { get; set; }

        // Optional: Configure DbContext to use MySQL if not already configured
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=CinemaCalcDB;User=cinema_user;Password=cinema_password;",
                    new MySqlServerVersion(new Version(8, 0, 21)));
            }
        }
    }
}
