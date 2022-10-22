using System.Security.Claims;
using ECommerce.Services.Identity.Models;
using IdentityModel;
using Microsoft.AspNetCore.Identity;

namespace ECommerce.Services.Identity.Services
{
    public class DBInitializer : IDBInitializer
    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public  DBInitializer(UserManager<ApplicationUser> um,
            RoleManager<IdentityRole> rm, AppDbContext db)
        {
            _db = db;
            _roleManager = rm;
            _userManager = um;
        }

        public async Task InitializeAsync()
        {
            if (await _roleManager.FindByNameAsync(StaticData.Admin) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole(StaticData.Admin));
                await _roleManager.CreateAsync(new IdentityRole(StaticData.Customer));
            }
            else
                return;

            ApplicationUser adminUser = new ApplicationUser()
            {
                UserName = "admin1",
                Email = "admin1@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "111111111111",
                FirstName = "adminfirst",
                LastName = "adminlast"
            };

            await _userManager.CreateAsync(adminUser,"Admin123*");
            await _userManager.AddToRoleAsync(adminUser,StaticData.Admin);
            await _userManager.AddClaimsAsync(adminUser, new Claim[]
            {
                new Claim(JwtClaimTypes.Name,adminUser.FirstName+ " " + adminUser.LastName),
                new Claim(JwtClaimTypes.GivenName,adminUser.FirstName),
                new Claim(JwtClaimTypes.FamilyName,adminUser.LastName),
                new Claim(JwtClaimTypes.Role,StaticData.Admin)
            });

            ApplicationUser customer = new ApplicationUser()
            {
                UserName = "customer1",
                Email = "customer@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "111111111111",
                FirstName = "customerfirst",
                LastName = "customerlast"
            };

            await _userManager.CreateAsync(customer, "Customer123*");
            await _userManager.AddToRoleAsync(customer, StaticData.Customer);
            await _userManager.AddClaimsAsync(customer, new Claim[]
            {
                new Claim(JwtClaimTypes.Name,customer.FirstName+ " " + adminUser.LastName),
                new Claim(JwtClaimTypes.GivenName,customer.FirstName),
                new Claim(JwtClaimTypes.FamilyName,customer.LastName),
                new Claim(JwtClaimTypes.Role,StaticData.Customer)
            });
        }
    }
}
