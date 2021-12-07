﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using NETnews.Models;
using System.Collections.Generic;
using System.Linq;

namespace NETnews.Data {
    public class DbInitializer {
        public static void Load(IApplicationBuilder applicationBuilder) {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Persons.Any()) {
                    context.Persons.AddRange(new List<Person>() {
                        new User() {
                            name = "admin",
                            username = "admin",
                        },

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