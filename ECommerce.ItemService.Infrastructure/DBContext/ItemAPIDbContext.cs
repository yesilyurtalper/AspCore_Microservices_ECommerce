using Microsoft.EntityFrameworkCore;
using ECommerce.ItemService.Domain;
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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ItemAPIDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
