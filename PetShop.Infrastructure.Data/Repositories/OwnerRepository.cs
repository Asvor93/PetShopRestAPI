using System.Collections.Generic;
using System.Linq;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.Data.Repositories
{
    public class OwnerRepository: IOwnerRepository
    {

        public Owner CreateOwner(Owner owner)
        {
            owner.Id = FakeDb.OwnerId++;
            FakeDb.Owners.Add(owner);
            return owner;
        }

        public IEnumerable<Owner> ReadAllOwners()
        {
            return FakeDb.Owners;
        }

        public Owner UpdateOwner(Owner ownerToUpdate)
        {
            return ownerToUpdate;
        }

        public Owner DeleteOwner(int id)
        {
            var ownerToDelete = FakeDb.Owners.FirstOrDefault(owner => owner.Id == id);
            FakeDb.Owners.Remove(ownerToDelete);
            return ownerToDelete;
        }

        public Owner GetOwnerById(int id)
        {
            return FakeDb.Owners.Select(o => new Owner()
            {
                Id = o.Id,
                FirstName = o.FirstName,
                LastName = o.LastName,
                Address = o.Address,
                Email = o.Email,
                PhoneNumber = o.PhoneNumber
            }).FirstOrDefault(o => o.Id == id);

        }
    }
}