﻿using System.Collections.Generic;
using System.Linq;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Services
{
    public class OwnerService: IOwnerService
    {
        private IOwnerRepository _ownerRepository;
        private IPetRepository _petRepository;

        public OwnerService(IOwnerRepository ownerRepository, IPetRepository petRepository)
        {
            this._ownerRepository = ownerRepository;
            _petRepository = petRepository;
        }

        public Owner AddOwner(Owner ownerToAdd)
        {
            Owner newOwner = new Owner
            {
                FirstName = ownerToAdd.FirstName,
                LastName = ownerToAdd.LastName,
                Address = ownerToAdd.Address,
                PhoneNumber = ownerToAdd.PhoneNumber,
                Email = ownerToAdd.Email
            };
            return _ownerRepository.CreateOwner(newOwner);
        }

        public List<Owner> ReadOwners()
        {
            return _ownerRepository.ReadAllOwners().ToList();
        }

        public Owner UpdateOwner(Owner ownerToUpdate)
        {
            var owner = FindOwnerById(ownerToUpdate.Id);

            if (owner != null)
            {
                owner.FirstName = ownerToUpdate.FirstName;
                owner.LastName = ownerToUpdate.LastName;
                owner.Address = ownerToUpdate.Address;
                owner.PhoneNumber = ownerToUpdate.PhoneNumber;
                owner.Email = ownerToUpdate.Email;

                return owner;
            }

            return null;
        }

        public Owner RemoveOwner(Owner ownerToDelete)
        {
            return _ownerRepository.DeleteOwner(ownerToDelete.Id);
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepository.ReadAllOwners().FirstOrDefault(owner => owner.Id == id);
        }

        public Owner FindOwnerByIdWithPets(int id)
        {
            var owner = _ownerRepository.GetOwnerById(id);
            owner.Pets = _petRepository.ReadPets().Where(pet => pet.PreviousOwner.Id == owner.Id).ToList();
            return owner;
        }
    }
}