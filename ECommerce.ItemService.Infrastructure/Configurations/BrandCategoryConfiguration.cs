using ECommerce.ItemService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ECommerce.ItemService.Infrastructure.Configurations
{
    internal class BrandCategoryConfiguration : IEntityTypeConfiguration<BrandCategory>
    {
        public void Configure(EntityTypeBuilder<BrandCategory> builder)
        {
            builder.HasKey(bc => new {bc.BrandId, bc.CategoryId});

            builder.HasData(new BrandCategory
            {
                BrandId = 1,
                CategoryId = 1
            });

            builder.HasData(new BrandCategory
            {
                BrandId = 1,
                CategoryId = 2
            });

            builder.HasData(new BrandCategory
            {
                BrandId = 1,
                CategoryId = 3
            });

            builder.HasData(new BrandCategory
            {
                BrandId = 2,
                CategoryId = 3
            });

            builder.HasData(new BrandCategory
            {
                BrandId = 3,
                CategoryId = 2
            });

            builder.HasData(new BrandCategory
            {
                BrandId = 3,
                CategoryId = 1
            });
        }
    }
}
