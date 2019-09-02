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
            return FakeDb.Pets;
        }

        public Pet UpdatePet(Pet pet)
        {
            var petFromDb = GetSinglePetById(pet.Id);

            if (petFromDb != null)
            {
                petFromDb.Name = pet.Name;
                petFromDb.PetType = pet.PetType;
                petFromDb.BirthDate = pet.BirthDate;
                petFromDb.SoldDate = pet.SoldDate;
                petFromDb.Color = pet.Color;
                petFromDb.PreviousOwner = pet.PreviousOwner;
                petFromDb.Price = pet.Price;

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

        public bool ValidateId(int inputId, int petId)
        {
            if (inputId == FakeDb.PetId)
            {
                return true;
            }
            return false;
        }
    }
}