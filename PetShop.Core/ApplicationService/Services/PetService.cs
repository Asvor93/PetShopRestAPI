using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Services
{
    public class PetService: IPetService
    {
        private readonly IPetRepository _petRepository;
        private IValidateIdService _validateId;

        public PetService(IPetRepository petRepository, IValidateIdService validateIdService)
        {
            this._petRepository = petRepository;
            _validateId = validateIdService;

        }

        public List<Pet> GetPets()
        {
            return this._petRepository.ReadPets().ToList();
        }

        public Pet AddPet(Pet petToAdd)
        {
            Pet pet = new Pet
            {
                Name = petToAdd.Name,
                PetType = petToAdd.PetType,
                BirthDate = petToAdd.BirthDate,
                SoldDate = petToAdd.SoldDate,
                Color = petToAdd.Color,
                PreviousOwner = petToAdd.PreviousOwner,
                Price = petToAdd.Price
            };
            return _petRepository.CreatePet(pet);
        }

        public Pet FindPetById(int id)
        {
            if (!_validateId.ValidateId(id))
            {
                throw new InvalidDataException("Invalid id!");
            }
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
            var pet = FindPetById(petToUpdate.Id);

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
    }
}