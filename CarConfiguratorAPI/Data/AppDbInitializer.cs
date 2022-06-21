using CarConfiguratorAPI.Data.Models;
using CarConfiguratorAPI.Properties;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace CarConfiguratorAPI.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CarConfigDbContext>();

                if (!context.Engines.Any())
                {
                    context.Engines.AddRange(new EngineModel()
                    {
                        Name = "100 PS",
                        Price = 100
                    }, 
                    new EngineModel()
                    {
                        Name = "200 PS",
                        Price = 200
                    }, 
                    new EngineModel()
                    {
                        Name = "300 PS",
                        Price = 300
                    },
                    new EngineModel()
                    {
                        Name = "400 PS",
                        Price = 400
                    });
                }

                if (!context.Paints.Any())
                {
                    context.Paints.AddRange(new PaintModel()
                    {
                        Name = "Green",
                        Price = 100
                    },
                    new PaintModel()
                    {
                        Name = "Red",
                        Price = 200
                    },
                    new PaintModel()
                    {
                        Name = "Yellow",
                        Price = 300
                    },
                    new PaintModel()
                    {
                        Name = "Black",
                        Price = 400
                    });
                }

                if (!context.Optionals.Any())
                {
                    context.Optionals.AddRange(new OptionalModel()
                    {
                        Name = "Night Pack",
                        Price = 100
                    },
                    new OptionalModel()
                    {
                        Name = "Day Pack",
                        Price = 200
                    },
                    new OptionalModel()
                    {
                        Name = "Racing Pack",
                        Price = 300
                    },
                    new OptionalModel()
                    {
                        Name = "Travel Pack",
                        Price = 400
                    });
                }

                if (!context.Wheels.Any())
                {
                    context.Wheels.AddRange(new WheelModel()
                    {
                        Name = "Steel",
                        Price = 100
                    },
                    new WheelModel()
                    {
                        Name = "Aluminium",
                        Price = 200
                    },
                    new WheelModel()
                    {
                        Name = "Chrome",
                        Price = 300
                    },
                    new WheelModel()
                    {
                        Name = "Magnesium",
                        Price = 400
                    });
                }

                context.SaveChanges();
            }
        }
    }
}
