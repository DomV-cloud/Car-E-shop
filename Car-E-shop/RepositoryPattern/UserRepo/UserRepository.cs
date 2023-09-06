using Car_E_shop.Database.Context;
using Car_E_shop.Models;
using Car_E_shop.RepositoryPattern.Interfaces;
using Car_E_shop.Services;
using Car_E_shop.Services.ValidateId;

namespace Car_E_shop.RepositoryPattern.UserRepo
{
    public class UserRepository : IRepository<User>
    {

        private readonly EshopContext _context;

        private readonly IValidateIdService _validateId;

        public UserRepository(EshopContext context, IValidateIdService validateId)
        {
            _context = new EshopContext();
            _validateId = validateId;
        }


        public void DeleteById(int id)
        {
            if (_validateId.isIdValid(id))
            {
                throw new Exception();
            }

            User userToRemove = _context.Users.Find(id)!;

            if (userToRemove is null)
            {
                throw new Exception();
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {

            return _context.Users.Find(id);
        }

        public void Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
