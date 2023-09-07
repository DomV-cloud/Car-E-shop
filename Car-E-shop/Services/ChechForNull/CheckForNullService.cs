using Car_E_shop.Exceptions;
using Car_E_shop.Exceptions.ErrorMessages;
using Car_E_shop.Models;

namespace Car_E_shop.Services.ChechForNull
{
    public class CheckForNullService : ICheckNull
    {
        private bool IsNull(object entity)
        {
            User userToCheck = (User) entity;

            return userToCheck is not null;
        }

        public void ValidateEntity(object entity)
        {

            User userToCheck = (User)entity;

            if (!IsNull(userToCheck))
            {
                throw new ObjectIsNullException(Message.ObjectIsNull(userToCheck));
            }
        }
    }
}
