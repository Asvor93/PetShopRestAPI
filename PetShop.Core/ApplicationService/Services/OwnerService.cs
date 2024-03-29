﻿using System.Collections.Generic;
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
            
            return _ownerRepository.CreateOwner(ownerToAdd);
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
            return _ownerRepository.FindOwnerByIdWithPets(id);

        }

        public List<Owner> GetFilteredOwners(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0)
            {
                throw new InvalidDataException("page and items must be 0 or more!");
            }
            if ((filter.CurrentPage - 1 * filter.ItemsPrPage) >= _ownerRepository.Count())
            {
                throw new InvalidDataException("No Items to show!");
            }
            if (filter.ItemsPrPage > _ownerRepository.Count())
            {
                throw new InvalidDataException("the items number is to  high!");
            }
            return _ownerRepository.ReadAllOwners(filter).ToList();
        }
    }
}