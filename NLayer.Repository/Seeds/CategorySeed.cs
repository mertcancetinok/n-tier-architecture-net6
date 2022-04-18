using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayer.Core.Models;

namespace NLayer.Repository.Seeds;

public class CategorySeed:IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        List<Category> categories = new List<Category>
        {
            new Category {Id = 1, Name = "Pencils"},
            new Category {Id = 2, Name = "Books"},
            new Category {Id = 3, Name = "Notebooks"},
        };
        builder.HasData(categories);
    }
}