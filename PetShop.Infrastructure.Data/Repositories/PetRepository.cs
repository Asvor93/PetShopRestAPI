using System;
using System.Collections.Generic;
using System.Linq;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class PetRepository: IPetRepository
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

        public Pet UpdatePet(Pet pet)
        {
            return pet;
        }

        public Pet DeletePet(int id)
        {
            var petToRemove = FakeDb.Pets.FirstOrDefault(pet => pet.Id == id);
            FakeDb.Pets.Remove(petToRemove);
            return petToRemove;
        }

        public Pet GetSinglePetById(int id)
        {
            foreach (var pet in FakeDb.Pets)
            {
                if (pet.Id == FakeDb.PetId)
                {
                    return pet;
                }
            }
            return null;
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