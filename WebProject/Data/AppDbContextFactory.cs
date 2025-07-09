using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebProject.Data
{
    public class AppDbContextFactory /*: IDesignTimeDbContextFactory<RRLContext>*/
    {
        //public RRLContext CreateDbContext(string[] args)
        //{
        //    IConfigurationRoot configuration = new ConfigurationBuilder()
        //        .SetBasePath(Directory.GetCurrentDirectory())
        //    .AddJsonFile("appsettings.json")
        //        .Build();

        //    var builder = new DbContextOptionsBuilder<RRLContext>();
        //    var connectionString = configuration.GetConnectionString("DefaultConnection");
        //    builder.UseSqlServer(connectionString);

        //    return new RRLContext(builder.Options);
        //}
    }
}
