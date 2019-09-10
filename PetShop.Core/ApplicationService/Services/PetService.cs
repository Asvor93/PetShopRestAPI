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
        private readonly IValidateIdService _validateId;
        private readonly IOwnerRepository _ownerRepository;

        public PetService(IPetRepository petRepository, IValidateIdService validateIdService, IOwnerRepository ownerRepository)
        {
            this._petRepository = petRepository;
            _validateId = validateIdService;
            _ownerRepository = ownerRepository;

        }

        public List<Pet> GetPets()
        {
            if (_petRepository.ReadPets() != null)
            {
                return this._petRepository.ReadPets().ToList();
            }

            return null;
        }

        public Pet AddPet(Pet petToAdd)
        {
            if (_validateId.ValidateId(petToAdd.Id))
            {
                throw new InvalidDataException("Do not enter id!");
            }
            if (string.IsNullOrEmpty(petToAdd.Name))
            {
                throw new InvalidDataException("You have to add a name to the pet");
            }

            if (petToAdd.PreviousOwner == null || petToAdd.PreviousOwner.Id <= 0)
            {
                {
                    throw new InvalidDataException("To create a pet you need an owner!");
                }
            }
            if (_ownerRepository.GetOwnerById(petToAdd.PreviousOwner.Id) == null)
            {
                {
                    throw new InvalidDataException("Owner not found!");
                }
            }

            return _petRepository.CreatePet(petToAdd);
        }

        public Pet FindPetById(int id)
        {
            if (_petRepository.ReadPets().FirstOrDefault(pet => pet.Id != id) == null)
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
            if (petToDelete != null)
            {
                return _petRepository.DeletePet(petToDelete.Id);
            }
            throw new InvalidDataException($"The pet you are trying to delete does not exist!");
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

                return _petRepository.UpdatePet(petToUpdate);
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