using Microsoft.EntityFrameworkCore;
using WebProject.Models;

namespace WebProject.Context
{
    public class Context: DbContext
    {

        public DbSet<Appointment> Appointments { get; set; }
    }
}
