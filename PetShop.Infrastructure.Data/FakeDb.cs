using System;
using System.Collections.Generic;
using System.Linq;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.Data
{
    public static class FakeDb
    {
        public static int PetId = 1;
        public static int OwnerId = 1;

        public static List<Pet> Pets = new List<Pet>();
        public static List<Owner> Owners = new List<Owner>();


        public static void InitData()
        {
            Owner owner1 = new Owner
            {
                Id = OwnerId++,
                FirstName = "Ásvør",
                LastName = "Rasmussen",
                Address = "Unicorn Street 5",
                Email = "adventureTime@Unicorns.com",
                PhoneNumber = "55667788"
            };
            Owners.Add(owner1);

            Owner owner2 = new Owner
            {
                Id = OwnerId++,
                FirstName = "Timon",
                LastName = "Lion King",
                Address = "Hakuna Matata",
                Email = "timon@HakunaMatata.com",
                PhoneNumber = "90909090"
            };
            Owners.Add(owner2);

            Owner owner3 = new Owner
            {
                Id = OwnerId++,
                FirstName = "Pumba",
                LastName = "Farts a lot",
                Address = "Hakuna Matata",
                Email = "timon@HakunaMatata.com",
                PhoneNumber = "54343665"
            };
            Owners.Add(owner3);

            Owner owner4 = new Owner
            {
                Id = OwnerId++,
                FirstName = "Princess Rainicorn",
                LastName = "Li",
                Address = "Unicorn Street 8",
                Email = "adventureTime@Unicorns.com",
                PhoneNumber = "98797655"
            };
            Owners.Add(owner4);

            Pet pet1 = new Pet
            {
                Id = PetId++,
                Name = "Birk",
                PetType = "Dog",
                BirthDate = new DateTime(2000, 11, 3),
                SoldDate = new DateTime(2001, 2, 5),
                Color = "Black",
                PreviousOwner = new Owner{Id = 1},
                Price = 10000
            };
            Pets.Add(pet1);

            
            Pet pet2 = new Pet
            {
                Id = PetId++,
                Name = "Hercules",
                PetType = "Goat",
                BirthDate = new DateTime(2012, 5, 30),
                SoldDate = new DateTime(2018, 10, 13),
                Color = "Black",
                PreviousOwner = new Owner { Id = 1 },
                Price = 15300
            };
            Pets.Add(pet2);

            Pet pet3 = new Pet
            {
                Id = PetId++,
                Name = "Flappy",
                PetType = "Dog",
                BirthDate = new DateTime(2012, 5, 30),
                SoldDate = new DateTime(2018, 10, 13),
                Color = "Brown",
                PreviousOwner = new Owner { Id = 2 },
                Price = 30000
            };
            Pets.Add(pet3);

            Pet pet4 = new Pet
            {
                Id = PetId++,
                Name = "Bubble Gum",
                PetType = "Unicorn",
                BirthDate = new DateTime(2012, 5, 30),
                SoldDate = new DateTime(2018, 10, 13),
                Color = "White",
                PreviousOwner = new Owner { Id = 4 },
                Price = 100000
            };
            Pets.Add(pet4);

            Pet pet5 = new Pet
            {
                Id = PetId++,
                Name = "Amadeus jr",
                PetType = "Goat",
                BirthDate = new DateTime(2018, 5, 30),
                SoldDate = new DateTime(2018, 10, 13),
                Color = "Black and white",
                PreviousOwner = new Owner { Id = 3 },
                Price = 6000
            };
            Pets.Add(pet5);

            Pet pet6 = new Pet
            {
                Id = PetId++,
                Name = "poppy",
                PetType = "cat",
                BirthDate = new DateTime(2012, 5, 30),
                SoldDate = new DateTime(2018, 10, 13),
                Color = "orange",
                PreviousOwner = new Owner { Id = 2 },
                Price = 2000
            };
            Pets.Add(pet6);

            Pet pet7 = new Pet
            {
                Id = PetId++,
                Name = "Monty",
                PetType = "dog",
                BirthDate = new DateTime(2012, 5, 30),
                SoldDate = new DateTime(2018, 10, 13),
                Color = "White",
                PreviousOwner = new Owner { Id = 4 },
                Price = 20500
            };
            Pets.Add(pet7);

        }
    }

    
}