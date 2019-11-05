using System;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;
using PetShop.Core.Helper;

namespace PetShop.Infrastructure.SQL
{
    public class DbInitializer: IDbInitializer
    {
        private static IAuthenticationHelper authenticationHelper;

        public DbInitializer(IAuthenticationHelper authHelper)
        {
            authenticationHelper = authHelper;
        }

        public void SeedDb(PetShopContext context)
        {
            context.Database.EnsureCreated();

            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            authenticationHelper.CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            authenticationHelper.CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);

            var user = context.Users.Add(new User()
            {
                UserName = "user",
                PasswordHash = passwordHashJoe,
                PasswordSalt = passwordSaltJoe,
                IsAdmin = false
            });

            var user1 = context.Users.Add(new User()
            {
                UserName = "admin",
                PasswordHash = passwordHashAnn,
                PasswordSalt = passwordSaltAnn,
                IsAdmin = true
            });
            
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