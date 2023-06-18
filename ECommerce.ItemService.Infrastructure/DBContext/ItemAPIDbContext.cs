using Microsoft.EntityFrameworkCore;
using ECommerce.ItemService.Domain;

namespace ECommerce.ItemService.Infra.DBContext;

public class ItemAPIDbContext : DbContext
{
    public ItemAPIDbContext(DbContextOptions<ItemAPIDbContext> options) : base(options)
    {

    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<BrandCategory> BrandCategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {          
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Brand>().HasIndex(u => u.Name).IsUnique();
        modelBuilder.Entity<Category>().HasIndex(u => u.Name).IsUnique();
        modelBuilder.Entity<Product>().HasIndex(u => u.Name).IsUnique();
        modelBuilder.Entity<BrandCategory>().HasKey(o => new { o.BrandId, o.CategoryId });

        //Data seeding

        Brand braA = new Brand
        {
            Id = 1,
            Name = "BraA",
            Description = "BraA"
        };

        Brand braB = new Brand
        {
            Id = 2,
            Name = "BraB",
            Description = "BraB"
        };

        Brand braC = new Brand
        {
            Id = 3,
            Name = "BraC",
            Description = "BraC"
        };

        Category catA = new Category
        {
            Id = 1,
            Name = "CatA",
            Description = "CatA"
        };

        Category catB = new Category
        {
            Id = 2,
            Name = "CatB",
            Description = "CatB"
        };

        Category catC = new Category
        {
            Id = 3,
            Name = "CatC",
            Description = "CatC"
        };

        modelBuilder.Entity<Brand>().HasData(braA);
        modelBuilder.Entity<Brand>().HasData(braB);
        modelBuilder.Entity<Brand>().HasData(braC);

        modelBuilder.Entity<Category>().HasData(catA);
        modelBuilder.Entity<Category>().HasData(catB);
        modelBuilder.Entity<Category>().HasData(catC);

        modelBuilder.Entity<BrandCategory>().HasData(new BrandCategory
        {
            BrandId=1,
            CategoryId=1
        });

        modelBuilder.Entity<BrandCategory>().HasData(new BrandCategory
        {
            BrandId = 1,
            CategoryId = 2
        });

        modelBuilder.Entity<BrandCategory>().HasData(new BrandCategory
        {
            BrandId = 1,
            CategoryId = 3
        });

        modelBuilder.Entity<BrandCategory>().HasData(new BrandCategory
        {
            BrandId = 2,
            CategoryId = 3
        });

        modelBuilder.Entity<BrandCategory>().HasData(new BrandCategory
        {
            BrandId = 3,
            CategoryId = 2
        });

        modelBuilder.Entity<BrandCategory>().HasData(new BrandCategory
        {
            BrandId = 3,
            CategoryId = 1
        });

        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 1,
            Name = "ProA",
            Price = 15,
            Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
            ImageUrl = "https://alperazurestorage.blob.core.windows.net/mango/14.jpg",
            CategoryId = catA.Id,
            BrandId = braA.Id
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 2,
            Name = "ProB",
            Price = 13.99,
            Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
            ImageUrl = "https://alperazurestorage.blob.core.windows.net/mango/11.jpg",
            CategoryId = catB.Id,
            BrandId = braB.Id
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 3,
            Name = "ProC",
            Price = 10.99,
            Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
            ImageUrl = "https://alperazurestorage.blob.core.windows.net/mango/12.jpg",
            CategoryId = catA.Id,
            BrandId = braA.Id
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 4,
            Name = "Pro4",
            Price = 15,
            Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
            ImageUrl = "https://alperazurestorage.blob.core.windows.net/mango/13.jpg",
            CategoryId = catC.Id,
            BrandId = braC.Id
        });
    }
}
