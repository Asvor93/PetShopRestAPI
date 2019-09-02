using System.Collections.Generic;
using System.Linq;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService.Services
{
    public class OwnerService: IOwnerService
    {
        private IOwnerRepository _ownerRepository;
        public OwnerService(IOwnerRepository ownerRepository)
        {
            this._ownerRepository = ownerRepository;

        }

        public Owner AddOwner(string firstName, string lastName, string address, string phoneNr, string email)
        {
            Owner newOwner = new Owner
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address,
                PhoneNumber = phoneNr,
                Email = email
            };
            return _ownerRepository.CreateOwner(newOwner);
        }

        public List<Owner> ReaOwners()
        {
            return _ownerRepository.ReadAllOwners().ToList();
        }

        public Owner UpdateOwner(Owner ownerToUpdate)
        {
            return _ownerRepository.UpdateOwner(ownerToUpdate);
        }

        public Owner RemoveOwner(Owner ownerToDelete)
        {
            return _ownerRepository.DeleteOwner(ownerToDelete.Id);
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepository.ReadAllOwners().FirstOrDefault(owner => owner.Id == id);
        }
    }
}