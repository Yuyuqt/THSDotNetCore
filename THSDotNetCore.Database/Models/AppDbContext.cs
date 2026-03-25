using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace THSDotNetCore.Database.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblBlog> TblBlogs { get; set; }

    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            string _connectionString = "Data Source = DESKTOP-BP9A061;Initial Catalog=DotNetTraining;User ID=sa;Password=sasa@123;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(_connectionString);
        }

    }

//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
      //  => optionsBuilder.UseSqlServer("Server=DESKTOP-BP9A061;Database=DotNetTraining;User Id=sa;Password=sasa@123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblBlog>(entity =>
        {
            entity.HasKey(e => e.BlogId);

            entity.ToTable("Tbl_Blog");

            entity.Property(e => e.BlogAuthor).HasMaxLength(50);
            entity.Property(e => e.BlogTitle).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
