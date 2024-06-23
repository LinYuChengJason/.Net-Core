using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prjTest.Models;

public partial class WebContext : DbContext
{
    public WebContext(DbContextOptions<WebContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employee { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<NewsFiles> NewsFiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.employeeId).HasName("PK_employee");

            entity.Property(e => e.name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasKey(e => e.newsId).HasName("PK_news");

            entity.Property(e => e.newsId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.endDateTime).HasColumnType("datetime");
            entity.Property(e => e.insertDateTime).HasColumnType("datetime");
            entity.Property(e => e.startDateTime).HasColumnType("datetime");
            entity.Property(e => e.title).HasMaxLength(250);
            entity.Property(e => e.updateDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<NewsFiles>(entity =>
        {
            entity.HasKey(e => e.newsFilesId).HasName("PK_newsFiles");

            entity.Property(e => e.newsFilesId).ValueGeneratedNever();
            entity.Property(e => e.extension).HasMaxLength(50);
            entity.Property(e => e.name).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
