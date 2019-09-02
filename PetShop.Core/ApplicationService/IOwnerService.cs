using System.Collections.Generic;
using System.Net.Sockets;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService
{
    public interface IOwnerService
    {
        Owner AddOwner(string firstName, string lastName, string address, string phoneNr, string email);

        List<Owner> ReaOwners();

        Owner UpdateOwner(Owner ownerToUpdate);

        Owner RemoveOwner(Owner ownerToDelete);

        Owner FindOwnerById(int id);
    }
}