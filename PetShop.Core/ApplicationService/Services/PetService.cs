using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Services
{
    public class PetService: IPetService
    {
        private readonly IPetRepository _petRepository;

        public PetService(IPetRepository petRepository)
        {
            this._petRepository = petRepository;
        }

        public List<Pet> GetPets()
        {
            return this._petRepository.ReadPets().ToList();
        }

        public Pet AddPet(string name, string petType, DateTime birthDate, DateTime soldDate, string color, Owner previousOwner,
            double price)
        {
            Pet pet = new Pet
            {
                Name = name,
                PetType = petType,
                BirthDate = birthDate,
                SoldDate = soldDate,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price
            };
            return _petRepository.CreatePet(pet);
        }

        public Pet FindPetById(int id)
        {

            return _petRepository.ReadPets().FirstOrDefault(pet => pet.Id == id);
        }

        public Pet FindPetByName(string petName)
        {
            return _petRepository.GetSinglePetByName(petName);
        }

        public Pet Delete(Pet petToDelete)
        {
            return _petRepository.DeletePet(petToDelete.Id);
        }

        public Pet Update(Pet petToUpdate)
        {
            return _petRepository.UpdatePet(petToUpdate);
        }

        public List<Pet> OrderByPrice()
        {
            var sortBy = _petRepository.ReadPets().OrderBy(pets => pets.Price).ToList();

            foreach (var pet in sortBy)
            {
                Console.WriteLine($"The pets ordered by price: Id {pet.Id} name: {pet.Name} Type: {pet.PetType}, Birthday: {pet.BirthDate}, Color: {pet.Color}, " +
                                  $"Previous owner: {pet.PreviousOwner} Price: {pet.Price}, Sold date: {pet.SoldDate}\n");


            }

            return sortBy;
        }

        public bool ValidateId(int inputId, int petId)
        {
            return _petRepository.ValidateId(inputId, petId);
        }
    }
}