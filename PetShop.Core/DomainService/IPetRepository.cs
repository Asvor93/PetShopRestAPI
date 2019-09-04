using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.DomainService
{
    public interface IPetRepository
    {
        Pet CreatePet(Pet pet);

        IEnumerable<Pet> ReadPets();

        Pet UpdatePet(Pet pet);

        Pet DeletePet(int id);

        Pet GetSinglePetById(int id);

        Pet GetSinglePetByName(string petName);

    }
}