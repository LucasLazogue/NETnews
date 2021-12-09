using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NETnews.Data.Enums;
using NETnews.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NETnews.Data {
    public class DbInitializer {
        public static void Load(IApplicationBuilder applicationBuilder) {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                if (!context.Users.Any()) {
                    context.Users.AddRange(new List<User>() {
                        new User() {
                            name = "admin",
                            UserName = "admin"
                        }
                    });
                    context.SaveChanges();
                }

                if (!context.Journalists.Any()) {
                    context.Journalists.AddRange(new List<Journalist>() {
                        new Journalist() {
                            name = "John Doe"
                        }
                    });
                    context.SaveChanges();
                }


            }
        }

        public static async Task loadUsers(IApplicationBuilder applicationBuilder) {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<User>>();
                string adminUserEmail = "admin@etickets.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null) {
                    var newAdminUser = new User() {
                        name = "Admin User",
                        UserName = "123admin123",
                    };
                    await userManager.CreateAsync(newAdminUser);
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }
            }
        }
    }
}
