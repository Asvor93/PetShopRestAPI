using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using PetShop.Core.Entity;

namespace PetShop.Core.ApplicationService
{
    public interface IPetService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Pet> GetPets();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="petToAdd"></param>
        /// <returns></returns>
        Pet AddPet(Pet petToAdd);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Pet FindPetById(int id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="petName"></param>
        /// <returns></returns>
        Pet FindPetByName(string petName);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="petToDelete"></param>
        /// <returns></returns>
        Pet Delete(Pet petToDelete);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="petToUpdate"></param>
        /// <returns></returns>
        Pet Update(Pet petToUpdate);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Pet> OrderByPrice();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Pet GetPetByIdWithOwners(int id);
    }
}