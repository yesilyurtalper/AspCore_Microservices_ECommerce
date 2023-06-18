using ECommerce.ItemService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ECommerce.ItemService.Infrastructure.Configurations
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasIndex(u => u.Name).IsUnique();

            builder.HasData(new Product
            {
                Id = 1,
                Name = "ProA",
                Price = 15,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                ImageUrl = "https://alperazurestorage.blob.core.windows.net/mango/14.jpg",
                CategoryId = 1,
                BrandId = 1,
                CreatedBy = "admin",
                DateCreated = DateTime.Now,
                ModifiedBy = "admin",
                DateModified = DateTime.Now,
            });

            builder.HasData(new Product
            {
                Id = 2,
                Name = "ProB",
                Price = 13.99,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                ImageUrl = "https://alperazurestorage.blob.core.windows.net/mango/11.jpg",
                CategoryId = 2,
                BrandId = 2,
                CreatedBy = "admin",
                DateCreated = DateTime.Now,
                ModifiedBy = "admin",
                DateModified = DateTime.Now,
            });

            builder.HasData(new Product
            {
                Id = 3,
                Name = "ProC",
                Price = 10.99,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                ImageUrl = "https://alperazurestorage.blob.core.windows.net/mango/12.jpg",
                CategoryId = 1,
                BrandId = 1,
                CreatedBy = "admin",
                DateCreated = DateTime.Now,
                ModifiedBy = "admin",
                DateModified = DateTime.Now,
            });

            builder.HasData(new Product
            {
                Id = 4,
                Name = "Pro4",
                Price = 15,
                Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
                ImageUrl = "https://alperazurestorage.blob.core.windows.net/mango/13.jpg",
                CategoryId = 3,
                BrandId = 3,
                CreatedBy = "admin",
                DateCreated = DateTime.Now,
                ModifiedBy = "admin",
                DateModified = DateTime.Now,
            });
        }
    }
}
