using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.DomainService
{
    public interface IOwnerRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        Owner CreateOwner(Owner owner);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Owner> ReadAllOwners();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ownerToUpdate"></param>
        /// <returns></returns>
        Owner UpdateOwner(Owner ownerToUpdate);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Owner DeleteOwner(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Owner GetOwnerById(int id);

    }
}