using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NETnews.Models;
using System.Collections.Generic;
using System.Linq;

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
    }
}
