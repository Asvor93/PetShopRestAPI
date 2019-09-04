namespace PetShop.Core.ApplicationService.Services
{
    public class ValidateIdService : IValidateIdService
    {
        public bool ValidateId(int id)
        {
            if (id < 0)
            {
                return false;
            }
            return true;
        }
    }
}