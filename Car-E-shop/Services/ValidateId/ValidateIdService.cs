using Car_E_shop.ErrorMessages;

namespace Car_E_shop.Services.ValidateId
{
    public class ValidateIdService : IValidateIdService
    {
        public bool IsIdValid(int? id)
        {
           return id.HasValue && id > 0;
        }

      
    }
}
