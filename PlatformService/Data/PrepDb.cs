using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data...");

                context.Platforms.AddRange(
                    new Platform(){ Name = "Dot net", Publisher = "Microsoft", Cost = "Free"},
                    new Platform(){ Name = "SQL server", Publisher = "Microsoft", Cost = "Free"},
                    new Platform(){ Name = "Kubernetes", Publisher = "Cloud Native Computing", Cost = "Free"},
                    new Platform(){ Name = "Chrome", Publisher = "Google", Cost = "Free"},
                    new Platform(){ Name = "Visual Studio", Publisher = "Microsoft", Cost = "Free"}
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> Data already present.");
            }
        }
    }
}