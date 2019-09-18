using System;
using System.Collections.Generic;
using System.Linq;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class PetRepository
    {
        public Pet CreatePet(Pet pet)
        {
            pet.Id = FakeDb.PetId++;
            FakeDb.Pets.Add(pet);
            return pet;
        }

        public IEnumerable<Pet> ReadPets()
        {
            List<Pet> petsNoOwner = new List<Pet>();
            foreach (var pet in FakeDb.Pets)
            {
                petsNoOwner.Add(new Pet()
                {
                    BirthDate = pet.BirthDate,
                    Color = pet.Color,
                    Id = pet.Id,
                    Name = pet.Name,
                    PetType = pet.PetType,
                    Price = pet.Price,
                    SoldDate = pet.SoldDate,
                    PreviousOwner = pet.PreviousOwner != null ? new Owner { Id = pet.PreviousOwner.Id}: null
                });
            }
            return petsNoOwner;
        }

        public Pet UpdatePet(Pet petToUpdate)
        {
            var pet = GetSinglePetById(petToUpdate.Id);

            if (pet != null)
            {
                pet.Name = petToUpdate.Name;
                pet.PetType = petToUpdate.PetType;
                pet.BirthDate = petToUpdate.BirthDate;
                pet.SoldDate = petToUpdate.SoldDate;
                pet.Color = petToUpdate.Color;
                pet.PreviousOwner = petToUpdate.PreviousOwner;
                pet.Price = petToUpdate.Price;

                return pet;
            }

            return null;
        }

        public Pet DeletePet(int id)
        {
            var petToRemove = FakeDb.Pets.FirstOrDefault(pet => pet.Id == id);
            FakeDb.Pets.Remove(petToRemove);
            return petToRemove;
        }

        public Pet GetSinglePetById(int id)
        {
            return FakeDb.Pets.FirstOrDefault(pet => pet.Id == id);
        }

        public Pet GetSinglePetByName(string petName)
        {
            foreach (var petToGet in FakeDb.Pets)
            {
                if (petToGet.Name.ToLower().Equals(petName.ToLower()))
                {
                    return petToGet;
                }
            }
            return null;
        }
    }
}