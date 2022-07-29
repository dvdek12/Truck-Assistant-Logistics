using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq.Expressions;
using TruckAssistant.Data;

namespace TruckAssistant.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new TruckAssistantContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<TruckAssistantContext>>()))
            {
                if (context.Truck.Any())
                {
                    return;
                }


                context.Truck.AddRange(
                    new Truck
                    {
                        Name = "Zlota strzala",
                        Brand = "Volkswagen",
                        Vmax = 120,
                        DriverBreaksLength = 30,
                        DriverBreaksInterval = 8,
                    },

                    new Truck
                    {
                        Name = "Kolombia",
                        Brand = "BMW",
                        Vmax = 150,
                        DriverBreaksLength = 20,
                        DriverBreaksInterval = 6
                    },

                    new Truck
                    {
                        Name = "Niebieski wagon",
                        Brand = "Volkswagen",
                        Vmax = 200,
                        DriverBreaksLength = 15,
                        DriverBreaksInterval = 8
                    },

                    new Truck
                    {
                        Name = "Masterland",
                        Brand = "Audi",
                        Vmax = 120,
                        DriverBreaksLength = 30,
                        DriverBreaksInterval = 6
                    }
                    );

                context.Trip.AddRange(
                    new Trip
                    {
                        StartDate = DateTime.Parse("2022-2-12"),
                        CreateDate = DateTime.Parse("2022-2-11"),
                        Range = 2000,
                        Description = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here",
                        Truck = new Truck
                        {
                            Name = "Masterland",
                            Brand = "Audi",
                            Vmax = 120,
                            DriverBreaksLength = 30,
                            DriverBreaksInterval = 6
                        }
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
