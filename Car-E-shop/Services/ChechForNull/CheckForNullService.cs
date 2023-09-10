using Car_E_shop.ErrorMessages;
using Car_E_shop.Models;

namespace Car_E_shop.Services.ChechForNull
{
    public class CheckForNullService : ICheckNull
    {
        public bool IsNull(object entity)
        {
            return entity is null;
        }

       
    }
}
