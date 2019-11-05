using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PetShop.Core.DomainService;
using PetShop.Core.DomainService.Filter;
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

        public FilteredList<Owner> ReadAllOwners(Filter filter)
        {
            var filteredList = new FilteredList<Owner>();

            if (filter != null && filter.ItemsPrPage > 0 && filter.CurrentPage > 0)
            {
                filteredList.List = _context.Owners.Include(o => o.Pets)
                    .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                    .Take(filter.ItemsPrPage);
                filteredList.Count = _context.Owners.Count();

                return filteredList;
            }

            filteredList.List = _context.Owners.Include(o => o.Pets);

            filteredList.Count = _context.Owners.Count();
            return filteredList;
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