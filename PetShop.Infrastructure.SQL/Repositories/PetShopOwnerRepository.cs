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

        public IEnumerable<Owner> ReadAllOwners()
        {
            return _context.Owners.ToList();
        }

        public Owner UpdateOwner(Owner ownerToUpdate)
        {
            throw new System.NotImplementedException();
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
    }
}