namespace Car_E_shop.Services.ChechForNull
{
    public interface ICheckNull<T> where T : class
    {
        public bool IsNull(T entity);

        public void ValidateEntity(T entity);
    }
}
