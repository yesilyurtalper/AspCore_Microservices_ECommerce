using ECommerce.ItemService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ECommerce.ItemService.Infrastructure.Configurations
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(u => u.Name).IsUnique();

            Category catA = new Category
            {
                Id = 1,
                Name = "CatA",
                Description = "CatA",
                CreatedBy = "admin",
                DateCreated = DateTime.Now,
                ModifiedBy = "admin",
                DateModified = DateTime.Now,
            };

            Category catB = new Category
            {
                Id = 2,
                Name = "CatB",
                Description = "CatB",
                CreatedBy = "admin",
                DateCreated = DateTime.Now,
                ModifiedBy = "admin",
                DateModified = DateTime.Now,
            };

            Category catC = new Category
            {
                Id = 3,
                Name = "CatC",
                Description = "CatC",
                CreatedBy = "admin",
                DateCreated = DateTime.Now,
                ModifiedBy = "admin",
                DateModified = DateTime.Now,
            };

            builder.HasData(catA);
            builder.HasData(catB);
            builder.HasData(catC);
        }
    }
}
