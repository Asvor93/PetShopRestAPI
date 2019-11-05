using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.Entity;

namespace PetShop.Infrastructure.SQL.Repositories
{
    public class PetShopOwnerRepository: IOwnerRepository
    {
        private PetShopContext _context;

        public PetShopOwnerRepository(PetShopContext context)
        {
            _context = context;
        }
        public Owner CreateOwner(Owner owner)
        {
            _context.Attach(owner).State = EntityState.Added;
            _context.SaveChanges();
            return owner;
        }

        public IEnumerable<Owner> ReadAllOwners(Filter filter)
        {
            if (filter.CurrentPage > 0 && filter.ItemsPrPage > 0)
            {
                return _context.Owners.Skip((filter.CurrentPage - 1)
                                            * filter.ItemsPrPage).Take(filter.ItemsPrPage).OrderBy(o => o.FirstName);
            }
            return _context.Owners;
        }

        public Owner UpdateOwner(Owner ownerToUpdate)
        {
            _context.Attach(ownerToUpdate).State = EntityState.Modified;
            _context.Entry(ownerToUpdate).Collection(o => o.Pets).IsModified = true;
            _context.SaveChanges();
            return ownerToUpdate;
        }

        public Owner DeleteOwner(int id)
        {
            var ownerToRemove = _context.Remove(new Owner() { Id = id }).Entity;
            _context.SaveChanges();
            return ownerToRemove;
        }

        public Owner GetOwnerById(int id)
        {
            return _context.Owners.FirstOrDefault(o => o.Id == id);
        }

        public Owner FindOwnerByIdWithPets(int id)
        {
            return _context.Owners.Include(o => o.Pets).FirstOrDefault(o => o.Id == id);
        }

        public int Count()
        {
            return _context.Owners.Count();
        }
    }
}