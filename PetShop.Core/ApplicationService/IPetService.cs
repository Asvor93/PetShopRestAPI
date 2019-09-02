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
        /// <param name="name"></param>
        /// <param name="petType"></param>
        /// <param name="birthDate"></param>
        /// <param name="soldDate"></param>
        /// <param name="color"></param>
        /// <param name="previousOwner"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        Pet AddPet(string name, string petType, DateTime birthDate, DateTime soldDate, string color, Owner previousOwner, double price);

        Pet FindPetById(int id);

        Pet FindPetByName(string petName);

        Pet Delete(Pet petToDelete);

        Pet Update(Pet petToUpdate);

        List<Pet> OrderByPrice();

        bool ValidateId(int inputId, int petId);

    }
}