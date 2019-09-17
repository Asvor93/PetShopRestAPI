using System.Collections.Generic;
using System.IO;
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
           _ownerRepository = ownerRepository;
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
            if (ownerToUpdate == null)
            {
                throw new InvalidDataException("The owner does not exist!");
            }
            return _ownerRepository.UpdateOwner(ownerToUpdate);
        }

        public Owner RemoveOwner(Owner ownerToDelete)
        {
            if (ownerToDelete != null)
            {
                return _ownerRepository.DeleteOwner(ownerToDelete.Id);
            }
            throw new InvalidDataException($"The owner you are trying to delete does not exist!");
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepository.GetOwnerById(id);
        }

        public Owner FindOwnerByIdWithPets(int id)
        {
            var owner = FindOwnerById(id);
            owner.Pets = _petRepository.ReadPets().Where(pet => pet.PreviousOwner.Id == owner.Id).ToList();
            return owner;
        }
    }
}