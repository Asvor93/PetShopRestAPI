using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        Pet CreatePet(Pet pet);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        IEnumerable<Pet> ReadPets(Filter filter = null);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pet"></param>
        /// <returns></returns>
        Pet UpdatePet(Pet pet);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Pet DeletePet(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Pet GetSinglePetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="petName"></param>
        /// <returns></returns>
        Pet GetSinglePetByName(string petName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Pet GetPetByIdWithOwners(int id);

        int Count();

    }
}