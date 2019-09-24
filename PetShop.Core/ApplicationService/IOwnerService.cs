using System.Collections.Generic;
using System.Net.Sockets;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService
{
    public interface IOwnerService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerToAdd"></param>
        /// <returns></returns>
        Owner AddOwner(Owner ownerToAdd);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Owner> ReadOwners();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerToUpdate"></param>
        /// <returns></returns>
        Owner UpdateOwner(Owner ownerToUpdate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerToDelete"></param>
        /// <returns></returns>
        Owner RemoveOwner(Owner ownerToDelete);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Owner FindOwnerById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Owner FindOwnerByIdWithPets(int id);

        List<Owner> GetFilteredOwners(Filter filter);

    }
}