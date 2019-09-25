using System;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.SQL
{
    public class DbInitializer
    {
        public static void SeedDb(PetShopContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var owner1 = context.Owners.Add(new Owner()
            {
                FirstName = "Lady",
                LastName = "Rainicorn",
                Address = "Adventure road 104",
                Email = "rainicorn@adventureTime.com",
                PhoneNumber = "45634523"
            }).Entity;

            var owner2 = context.Owners.Add(new Owner()
            {
                FirstName = "Jake",
                LastName = "Adventure",
                Address = "Treehouse road 1",
                Email = "Jake@adventureTime.com",
                PhoneNumber = "44578564"
            }).Entity;

            var pet1 = context.Pets.Add(new Pet()
            {
                Name = "Finn",
                PetType = "Human",
                PreviousOwner = owner2,
                BirthDate = new DateTime(2000, 5, 23),
                SoldDate = new DateTime(2002, 9, 2),
                Price = 100
            }).Entity;

            var pet2 = context.Pets.Add(new Pet()
            {
                Name = "Princess Bubblegum",
                PetType = "cow",
                PreviousOwner = owner2,
                BirthDate = new DateTime(2000, 5, 23),
                SoldDate = new DateTime(2002, 9, 2),
                Price = 10000
            }).Entity;

            context.SaveChanges();
        }
    }
}