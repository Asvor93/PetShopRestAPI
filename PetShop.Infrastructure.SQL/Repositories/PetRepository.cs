using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.SQL.Repositories
{
    public class PetRepository: IPetRepository
    {
        readonly PetShopContext _context;

        public PetRepository(PetShopContext context)
        {
            _context = context;
        }
        public Pet CreatePet(Pet pet)
        {
            /*
            if (pet.PreviousOwner != null && _context.ChangeTracker.Entries<Owner>().FirstOrDefault(pe => pe.Entity.Id == pet.PreviousOwner.Id) == null)
            {
                _context.Attach(pet.PreviousOwner);
            }
            
            var saved = _context.Pets.Add(pet).Entity;
            _context.SaveChanges();
            return saved;*/
            _context.Attach(pet).State = EntityState.Added;
            _context.SaveChanges();
            return pet;
        }

        public IEnumerable<Pet> ReadPets()
        {
            return _context.Pets.ToList();
        }

        public Pet UpdatePet(Pet pet)
        {
            _context.Attach(pet).State = EntityState.Modified;
            _context.Entry(pet).Reference(p => p.PreviousOwner).IsModified = true;
            _context.SaveChanges();
            return pet;
        }

        public Pet DeletePet(int id)
        {
            var entityToRemove = _context.Remove(new Pet {Id = id}).Entity;
            _context.SaveChanges();
            return entityToRemove;
        }

        public Pet GetSinglePetById(int id)
        {
            return _context.Pets.FirstOrDefault(p => p.Id == id);
        }

        public Pet GetPetByIdWithOwners(int id)
        {
            return _context.Pets.Include(p => p.PreviousOwner).FirstOrDefault(p => p.Id == id);
        }

        public Pet GetSinglePetByName(string petName)
        {
            return _context.Pets.FirstOrDefault(p => p.Name == petName);
        }
    }
}