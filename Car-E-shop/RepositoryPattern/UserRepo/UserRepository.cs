using Car_E_shop.Database.Context;
using Car_E_shop.Exceptions;
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

        private readonly ILogger _logger;

        public UserRepository(EshopContext context, IValidateIdService validateId, ICheckNull checkNull, ILogger logger)
        {
            _context = new EshopContext();
            _validateId = validateId;
            _checkNull = checkNull;
            _logger = logger;
        }


        public void DeleteById(int id)
        {
            try
            {
                _validateId.Validate(id);


                User userToRemove = _context.Users.Find(id)!;

                _checkNull.ValidateEntity(userToRemove);

                _context.Users.Remove(userToRemove);

            }
            catch (InvalidIdException ex)
            {

                _logger.LogError(ex.Message);
            }
            catch (ObjectIsNullException ex)
            {

                _logger.LogError(ex.Message);
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetById(int id)
        {

            try
            {
                _validateId.Validate(id);

            }
            catch (InvalidIdException ex)
            {

                _logger.LogError(ex.Message);
            }


            return _context.Users.Find(id);
        }

        public void Insert(User entity)
        {
            try
            {
                _checkNull.ValidateEntity(entity);

                _context.Users.Add(entity);
            }
            catch (ObjectIsNullException ex)
            {

                _logger.LogError(ex.Message);
            }
        }

        public void Update(User entity)
        {
            try
            {
                _checkNull.ValidateEntity(entity);

                _context.Users.Update(entity);
            }
            catch (ObjectIsNullException ex)
            {

                _logger.LogError(ex.Message);
            }
        }
    }
}
