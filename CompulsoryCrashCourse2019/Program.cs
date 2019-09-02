using System;
using Microsoft.Extensions.DependencyInjection;
using PetShop.Core.ApplicationService;
using PetShop.Core.ApplicationService.Services;
using PetShop.Core.DomainService;
using PetShop.Infrastructure.Data;
using PetShop.Infrastructure.Data.Repositories;

namespace PetShop.Console2019
{
    class Program
    {
        static void Main(string[] args)
        {
            //PetPrinter petPrinter = new PetPrinter();

            FakeDb.InitData();

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IPetRepository, PetRepository>();
            serviceCollection.AddScoped<IPrinter, PetPrinter>();
            serviceCollection.AddScoped<IPetService, PetService>();
            serviceCollection.AddScoped<IOwnerService, OwnerService>();
            serviceCollection.AddScoped<IOwnerRepository, OwnerRepository>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            var petPrinter = serviceProvider.GetRequiredService<IPrinter>();
           
            petPrinter.MakeMenu();

            Console.ReadLine();
        }
    }
}
