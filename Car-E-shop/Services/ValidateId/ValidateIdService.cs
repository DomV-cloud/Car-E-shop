using Car_E_shop.Exceptions;
using Car_E_shop.Exceptions.ErrorMessages;

namespace Car_E_shop.Services.ValidateId
{
    public class ValidateIdService : IValidateIdService
    {
        public bool isIdValid(int? id)
        {
           return id.HasValue && id > 0;
        }

        public void Validate(int? id)
        {
            if (!isIdValid(id))
            {
                throw new InvalidIdException(Message.InvalidId(id));
            }

        }
    }
}
