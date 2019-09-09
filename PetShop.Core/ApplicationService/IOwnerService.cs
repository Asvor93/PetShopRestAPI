using System.Collections.Generic;
using System.Net.Sockets;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService
{
    public interface IOwnerService
    {
        Owner AddOwner(Owner ownerToAdd);

        List<Owner> ReadOwners();

        Owner UpdateOwner(Owner ownerToUpdate);

        Owner RemoveOwner(Owner ownerToDelete);

        Owner FindOwnerById(int id);

        Owner FindOwnerByIdWithPets(int id);
    }
}