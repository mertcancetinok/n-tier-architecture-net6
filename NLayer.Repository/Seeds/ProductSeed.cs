using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Seeds;

public class ProductSeed:IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        List<Product> products = new List<Product>
        {
            new() {Id = 1,Name="Pencil 1",CategoryId = 1, Price = 100, Stock = 20, CreatedDate = DateTime.Now},
            new() {Id = 2,Name="Pencil 2",CategoryId = 1, Price = 200, Stock = 30, CreatedDate = DateTime.Now},
            new() {Id = 3,Name="Pencil 3",CategoryId = 1, Price = 600, Stock = 60, CreatedDate = DateTime.Now},
            new() {Id = 4,Name="Book 1",CategoryId = 2, Price = 700, Stock = 70, CreatedDate = DateTime.Now},
            new() {Id = 5,Name="Book 2",CategoryId = 2, Price = 800, Stock = 80, CreatedDate = DateTime.Now},
        };

        builder.HasData(products);
    }
}