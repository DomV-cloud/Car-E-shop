namespace Car_E_shop.Services.ChechForNull
{
    public interface ICheckNull
    {
        private bool IsNull(Object entity);

        public void ValidateEntity(Object entity);
    }
}
