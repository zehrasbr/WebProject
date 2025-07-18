using Microsoft.EntityFrameworkCore;
using WebProject.Models;

namespace WebProject.Data
{
    public class RRLContext : DbContext
    {
        public RRLContext(DbContextOptions<RRLContext> options)
            : base(options) { }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Email> Emails { get; set; }
    }
}
