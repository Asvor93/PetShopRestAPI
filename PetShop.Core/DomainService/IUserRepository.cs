using System.Collections.Generic;
using PetShop.Core.Entity;

namespace PetShop.Core.DomainService
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();

        User GetUser(int id);

        void AddUser(User entity);

        void Edit(User entity);

        void RemoveUser(int id);
    }
}