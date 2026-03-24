using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THSDotNetCore.ConsoleApp.Models;

namespace THSDotNetCore.ConsoleApp
{
    public class AppDbContext : DbContext 

    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           if (!optionsBuilder.IsConfigured)
            {
                string _connectionString = "Data Source = DESKTOP-BP9A061;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa@123;TrustServerCertificate=True;";
                optionsBuilder.UseSqlServer(_connectionString);
            }
            
        }
    public DbSet<BlogDataModel> Blogs { get; set; }        
    
    }
}
