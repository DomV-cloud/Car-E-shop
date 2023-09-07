using Car_E_shop.Database.Context;
using Car_E_shop.Models;
using Car_E_shop.RepositoryPattern.Interfaces;
using Car_E_shop.Services;
using Car_E_shop.Services.ChechForNull;
using Car_E_shop.Services.ValidateId;
using System.ComponentModel.DataAnnotations;

namespace Car_E_shop.RepositoryPattern.UserRepo
{
    public class UserRepository : IRepository<User>
    {

        private readonly EshopContext _context;

        private readonly IValidateIdService _validateId;

        private readonly ICheckNull _checkNull;

        public UserRepository(EshopContext context, IValidateIdService validateId, ICheckNull checkNull)
        {
            _context = new EshopContext();
            _validateId = validateId;
            _checkNull = checkNull;
        }

        public IValidatableObject ValidateObject => _validateObject;

        public void DeleteById(int id)
        {
            _validateId.Validate(id);

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
