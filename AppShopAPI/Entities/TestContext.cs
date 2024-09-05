using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppShopAPI.Entities;

public partial class TestContext : DbContext
{
    public TestContext()
    {
    }

    public TestContext(DbContextOptions<TestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasComment("Mini Description of item");
            entity.Property(e => e.Icon)
                .HasMaxLength(100)
                .HasComment("Icon of item not images");
            entity.Property(e => e.MainDescription)
                .HasComment("Full desciption of item")
                .HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(35)
                .HasComment("Name of item");
            entity.Property(e => e.OldPrice).HasComment("Price of item without discount");
            entity.Property(e => e.Price).HasComment("Currect Price of item");
            entity.Property(e => e.ProductType)
                .HasMaxLength(35)
                .HasComment("Type of item");
            entity.Property(e => e.Quantity).HasComment("how many count of item");
            entity.Property(e => e.ReviewsCount)
                .HasDefaultValueSql("'0'")
                .HasComment("count of reviews for item");
            entity.Property(e => e.Specifications)
                .HasComment("Specifications of item")
                .HasColumnType("text");
            entity.Property(e => e.Stars).HasComment("stars count of item rating");
            entity.Property(e => e.Stock)
                .HasDefaultValueSql("'0'")
                .HasComment("is item in stock");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
