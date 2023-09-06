namespace Car_E_shop.Services.ValidateId
{
    public interface IValidateIdService
    {
        public bool isIdValid(int? id);

        public void Validate(int? id);
        


    }
}
