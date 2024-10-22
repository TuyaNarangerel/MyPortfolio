using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Data
{
    public static class DataInitializer
    {
        public static void Initialize(PortfolioDbContext context)
        {
            context.Database.Migrate();

            if (!context.Projects.Any())
            {
                context.Projects.AddRange(
                    new Project
                    {
                        Name = "BankAppen",
                        TechStack = "C#, ASP.NET Core, SQL",
                        Date = DateTime.Parse("2023-01-01"),
                        Description = "A banking application with secure transactions.",
                        OtherInfo = "GitHub link: https://github.com/TuyaNarangerel/BankApp"
                    },
                    new Project
                    {
                        Name = "Car Simulator",
                        TechStack = "Unit test, MS Test, NUnit",
                        Date = DateTime.Parse("2022-06-21"),
                        Description = "It is a console program that simulates a car driver driving a car.",
                        OtherInfo = "Live Demo: https://github.com/TuyaNarangerel/CarSimulator"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
