using DemoLibrary.Data;
using DemoLibrary.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoLibrary.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<LibraryDbContext>>()))
            {
                
                if (context.Countries.Any())
                {
                    return;   // DB has been seeded
                }

                context.Countries.AddRange(
                    new Country
                    {
                        Name= "Австралия"
                    },
                    new Country
                    {
                        Name = "Австрия"
                    },
                    new Country
                    {
                        Name = "България"
                    },
                    new Country
                    {
                        Name = "Великобритания"
                    },
                    new Country
                    {
                        Name = "Германия"
                    },
                    new Country
                    {
                        Name = "Испания"
                    },
                    new Country
                    {
                        Name = "Италия"
                    },
                    new Country
                    {
                        Name = "Франция"
                    }
                );
                context.SaveChanges();
            }
            }
        }
}
