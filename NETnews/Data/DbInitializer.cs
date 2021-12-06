using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace NETnews.Data {
    public class DbInitializer {
        public static void load(ApplicationBuilder applicationBuilder) {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope()) {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Persons.Any()) { 

                }
            }
        }
    }
}
