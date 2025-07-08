using Microsoft.EntityFrameworkCore;
using WebProject.Models;

namespace WebProject.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }
    }
}
