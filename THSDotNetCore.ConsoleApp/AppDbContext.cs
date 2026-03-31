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
       
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //   if (!optionsBuilder.IsConfigured)
        //    {
        //        string _connectionString = "Data Source = DESKTOP-BP9A061;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa@123;TrustServerCertificate=True;";
        //        optionsBuilder.UseSqlServer(_connectionString);
        //    }
            
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogDataModel>(entity =>
            {
                entity.ToTable("Tbl_Blog");
                entity.HasKey(e => e.BlogId);
                entity.Property(e => e.BlogId).HasColumnName("BlogId").ValueGeneratedOnAdd();
                entity.Property(e => e.BlogTitle).HasColumnName("BlogTitle").HasMaxLength(200).IsRequired();
                entity.Property(e => e.BlogContent).HasColumnName("BlogContent").HasMaxLength(1000).IsRequired();
            });
        }


        public DbSet<BlogDataModel> Blogs { get; set; }        
    
    }
}
