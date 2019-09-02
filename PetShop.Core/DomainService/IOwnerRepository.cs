using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.DomainService
{
    public interface IOwnerRepository
    {
        Owner CreateOwner(Owner owner);

        IEnumerable<Owner> ReadAllOwners();

        Owner UpdateOwner(Owner ownerToUpdate);

        Owner DeleteOwner(int id);

    }
}