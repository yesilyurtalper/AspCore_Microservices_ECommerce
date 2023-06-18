using ECommerce.ItemService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ECommerce.ItemService.Infrastructure.Configurations
{
    internal class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasIndex(u => u.Name).IsUnique();

            Brand braA = new()
            {
                Id = 1,
                Name = "BraA",
                Description = "BraA",
                CreatedBy = "admin",
                DateCreated = DateTime.Now,
                ModifiedBy = "admin",
                DateModified = DateTime.Now,
            };

            Brand braB = new()
            {
                Id = 2,
                Name = "BraB",
                Description = "BraB",
                CreatedBy = "admin",
                DateCreated = DateTime.Now,
                ModifiedBy = "admin",
                DateModified = DateTime.Now,

            };

            Brand braC = new()
            {
                Id = 3,
                Name = "BraC",
                Description = "BraC",
                CreatedBy = "admin",
                DateCreated = DateTime.Now,
                ModifiedBy = "admin",
                DateModified = DateTime.Now,
            };

            builder.HasData(braA);
            builder.HasData(braB);
            builder.HasData(braC);
        }
    }
}
