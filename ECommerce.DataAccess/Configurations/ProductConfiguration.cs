﻿using ECommerce.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.DataAccess.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
  public void Configure(EntityTypeBuilder<Product> builder)
  {
    builder.ToTable("Products").HasKey(p => p.Id);
    builder.Property(p => p.Id).HasColumnName("ProductId");
    builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate");
    builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
    builder.Property(p => p.Name).HasColumnName("Name");
    builder.Property(p => p.Description).HasColumnName("Description");
    builder.Property(p => p.ImageUrl).HasColumnName("ImageUrl");
    builder.Property(p => p.Price).HasColumnName("Price").HasPrecision(18, 2);
    builder.Property(p => p.Stock).HasColumnName("Stock");
    builder.Property(p => p.IsActive).HasColumnName("IsActive");
    builder.Property(p => p.CategoryId).HasColumnName("CategoryId");

    builder
      .HasOne(p => p.Category)
      .WithMany(c => c.Products)
      .HasForeignKey(p => p.CategoryId)
      .OnDelete(DeleteBehavior.NoAction);
  }
}