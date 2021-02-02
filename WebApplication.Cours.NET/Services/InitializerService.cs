using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Cours.NET.Data;

namespace WebApplication.Cours.NET.Services
{
    public class InitializerService
    {
        public InitializerService(LibraryDbContext libraryDbContext, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            Console.WriteLine(userManager);
            DbInitializer.Initialize(libraryDbContext, userManager, roleManager);
        }
    }
}
