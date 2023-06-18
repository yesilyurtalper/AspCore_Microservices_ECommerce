using Microsoft.EntityFrameworkCore;
using ECommerce.ItemService.Domain;
using System.Security.Claims;
using Org.BouncyCastle.Bcpg;
using Microsoft.AspNetCore.Http;

namespace ECommerce.ItemService.Infra.DBContext;

public class ItemAPIDbContext : DbContext
{
    private IHttpContextAccessor _httpContextAccessor;

    public ItemAPIDbContext(DbContextOptions<ItemAPIDbContext> options,
        IHttpContextAccessor accessor) : base(options)
    {
        _httpContextAccessor = accessor;
    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<BrandCategory> BrandCategories { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseItem>()
            .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            
            if (entry.State == EntityState.Added)
            {
                entry.Entity.DateModified = DateTime.Now;
                entry.Entity.ModifiedBy = _httpContextAccessor.HttpContext.User.Claims.
                    FirstOrDefault(c => c.Type == "preferred_username").Value;
                entry.Entity.DateCreated = entry.Entity.DateModified;
                entry.Entity.CreatedBy = entry.Entity.ModifiedBy;
            }
            else
            {
                entry.Entity.DateModified = DateTime.Now;
                entry.Entity.ModifiedBy = _httpContextAccessor.HttpContext.User.Claims.
                    FirstOrDefault(c => c.Type == "preferred_username").Value;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {          
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Brand>().HasIndex(u => u.Name).IsUnique();
        modelBuilder.Entity<Category>().HasIndex(u => u.Name).IsUnique();
        modelBuilder.Entity<Product>().HasIndex(u => u.Name).IsUnique();
        modelBuilder.Entity<BrandCategory>().HasKey(o => new { o.BrandId, o.CategoryId });

        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        //Data seeding

        Brand braA = new Brand
        {
            Id = 1,
            Name = "BraA",
            Description = "BraA",
            CreatedBy = "admin",
            DateCreated = DateTime.Now,
            ModifiedBy = "admin",
            DateModified = DateTime.Now,
        };

        Brand braB = new Brand
        {
            Id = 2,
            Name = "BraB",
            Description = "BraB",
            CreatedBy = "admin",
            DateCreated = DateTime.Now,
            ModifiedBy = "admin",
            DateModified = DateTime.Now,
        };

        Brand braC = new Brand
        {
            Id = 3,
            Name = "BraC",
            Description = "BraC",
            CreatedBy = "admin",
            DateCreated = DateTime.Now,
            ModifiedBy = "admin",
            DateModified = DateTime.Now,
        };

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

        modelBuilder.Entity<Brand>().HasData(braA);
        modelBuilder.Entity<Brand>().HasData(braB);
        modelBuilder.Entity<Brand>().HasData(braC);

        modelBuilder.Entity<Category>().HasData(catA);
        modelBuilder.Entity<Category>().HasData(catB);
        modelBuilder.Entity<Category>().HasData(catC);

        modelBuilder.Entity<BrandCategory>().HasData(new BrandCategory
        {
            BrandId = 1,
            CategoryId = 1
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
            BrandId = braA.Id,
            CreatedBy = "admin",
            DateCreated = DateTime.Now,
            ModifiedBy = "admin",
            DateModified = DateTime.Now,
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 2,
            Name = "ProB",
            Price = 13.99,
            Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
            ImageUrl = "https://alperazurestorage.blob.core.windows.net/mango/11.jpg",
            CategoryId = catB.Id,
            BrandId = braB.Id,
            CreatedBy = "admin",
            DateCreated = DateTime.Now,
            ModifiedBy = "admin",
            DateModified = DateTime.Now,
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 3,
            Name = "ProC",
            Price = 10.99,
            Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
            ImageUrl = "https://alperazurestorage.blob.core.windows.net/mango/12.jpg",
            CategoryId = catA.Id,
            BrandId = braA.Id,
            CreatedBy = "admin",
            DateCreated = DateTime.Now,
            ModifiedBy = "admin",
            DateModified = DateTime.Now,
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 4,
            Name = "Pro4",
            Price = 15,
            Description = "Praesent scelerisque, mi sed ultrices condimentum, lacus ipsum viverra massa, in lobortis sapien eros in arcu. Quisque vel lacus ac magna vehicula sagittis ut non lacus.<br/>Sed volutpat tellus lorem, lacinia tincidunt tellus varius nec. Vestibulum arcu turpis, facilisis sed ligula ac, maximus malesuada neque. Phasellus commodo cursus pretium.",
            ImageUrl = "https://alperazurestorage.blob.core.windows.net/mango/13.jpg",
            CategoryId = catC.Id,
            BrandId = braC.Id,
            CreatedBy = "admin",
            DateCreated = DateTime.Now,
            ModifiedBy = "admin",
            DateModified = DateTime.Now,
        });
    }
}
