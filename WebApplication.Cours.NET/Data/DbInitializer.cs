using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApplication.Cours.NET.Data
{
    public class DbInitializer
    {
        public static void Initialize(LibraryDbContext bookDbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (bookDbContext.Books.Any())
                return;

            var books = new Book[]
            {
                new Book { Content ="Lorem Ipsum", Name = "Test", Price=10.2f}
            };
            bookDbContext.Books.AddRange(books);
            bookDbContext.SaveChanges();

            var roles = new IdentityRole[] {
                new IdentityRole("basic"),
                new IdentityRole("advance"),
                new IdentityRole("admin")
            };
            foreach(var role in roles)
            {
                roleManager.CreateAsync(role).Wait();
            }

            var user = new IdentityUser()
            {
                Id= "ctisserand@dot.net",
                EmailConfirmed = true,
                NormalizedUserName = "ctisserand@dot.net",
                Email = "ctisserand@dot.net",
                UserName = "ctisserand@dot.net",
                NormalizedEmail = "ctisserand@dot.net"
            };

            userManager.CreateAsync(user, "Test1A$").Wait();
            userManager.AddToRoleAsync(user, roles[0].Name).Wait();
        }
    }
}
