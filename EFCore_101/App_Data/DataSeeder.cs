using EFCore_101.App_Data.Context;
using EFCore_101.App_Data.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EFCore_101.App_Data
{
    public static class DataSeeder
    {
        /// <summary>
        /// In order to seed the data by this way, application must be run
        /// </summary>
        public static async Task SeedData(IServiceProvider services)
        {
            IWebHostEnvironment environment = services.GetRequiredService<IWebHostEnvironment>();

            if (environment.IsDevelopment())
            {
                IServiceScope scope = services.CreateScope();

                AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                //if (context.Database.GetPendingMigrations().Any()) await context.Database.MigrateAsync();
                //else context.Database.EnsureCreated();

                await InitData(environment, context);
            }
        }

        private static async Task InitData(IWebHostEnvironment environment, AppDbContext context)
        {
            // IL
            if (!context.Iller.Any())
            {
                var iller = JsonConvert.DeserializeObject<List<IL>>(System.IO.File.ReadAllText(System.IO.Path.Combine(environment.WebRootPath, "static", "IL.json")));
                context.Iller.AddRange(iller);
                await context.SaveChangesAsync();
            }

            // ILCE
            if (!context.Ilceler.Any())
            {
                var ilceler = JsonConvert.DeserializeObject<List<ILCE>>(System.IO.File.ReadAllText(System.IO.Path.Combine(environment.WebRootPath, "static", "ILCE.json")));
                context.Ilceler.AddRange(ilceler);
                await context.SaveChangesAsync();
            }

            // SBB
            if (!context.SBBler.Any())
            {
                var sbbler = JsonConvert.DeserializeObject<List<SBB>>(System.IO.File.ReadAllText(System.IO.Path.Combine(environment.WebRootPath, "static", "SBB.json")));
                context.SBBler.AddRange(sbbler);
                await context.SaveChangesAsync();
            }

            // MAHALLE
            if (!context.Mahalleler.Any())
            {
                var mahalleler = JsonConvert.DeserializeObject<List<MAHALLE>>(System.IO.File.ReadAllText(System.IO.Path.Combine(environment.WebRootPath, "static", "MAHALLE.json")));
                context.Mahalleler.AddRange(mahalleler);
                await context.SaveChangesAsync();
            }
        }
    }
}
