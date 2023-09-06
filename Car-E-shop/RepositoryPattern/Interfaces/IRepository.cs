namespace Car_E_shop.RepositoryPattern.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        public IEnumerable<T> GetAll();

        public T GetById(int id);

        public void Update(T entity);

        public void Insert(T entity);

        public void DeleteById(int id);
    }
}
