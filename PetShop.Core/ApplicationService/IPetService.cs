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

        Pet AddPet(Pet petToAdd);

        Pet FindPetById(int id);

        Pet FindPetByName(string petName);

        Pet Delete(Pet petToDelete);

        Pet Update(Pet petToUpdate);

        List<Pet> OrderByPrice();
    }
}