﻿using System.Collections.Generic;
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
            _context.Attach(pet).State = EntityState.Added;
            _context.SaveChanges();
            return pet;
        }

        public IEnumerable<Pet> ReadPets(Filter filter)
        {
            if (filter.CurrentPage > 0 && filter.ItemsPrPage > 0)
            {
                return _context.Pets.Skip((filter.CurrentPage - 1)
                                          * filter.ItemsPrPage).Take(filter.ItemsPrPage);
                
            }
            return _context.Pets;
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

        public int Count()
        {
            return _context.Pets.Count();
        }

        public Pet GetSinglePetByName(string petName)
        {
            return _context.Pets.FirstOrDefault(p => p.Name == petName);
        }
    }
}