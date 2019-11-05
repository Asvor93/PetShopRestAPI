using PetShop.Infrastructure.SQL;

namespace PetShop.Core.DomainService
{
    public interface IDbInitializer
    {
        void SeedDb(PetShopContext context);
    }
}