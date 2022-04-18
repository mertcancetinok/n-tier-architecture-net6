﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;
using NLayer.Core.Models;

namespace NLayer.Repository;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductFeature> ProductFeatures { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {   /* Different method for seed */
        modelBuilder.Entity<ProductFeature>().HasData(new ProductFeature
        {
            Id = 1,
            Color = "Red",
            Width = 100,
            Height = 200,
            ProductId = 1,
        },
        new ProductFeature
        {
            Id = 2,
            Color = "Blue",
            Width = 300,
            Height = 500,
            ProductId = 2,
        });

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }
}