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

     


        public UserRepository(EshopContext context)
        {
            _context = context;
          
        }


        public void Delete(User user)
        {
            _context.Users.Remove(user);
        }

        public IEnumerable<User> GetAll()
        {
            using (_context)
            {
                return _context.Users.ToList();

            }
        }

        public User GetById(int id)
        {

            using (_context)
            {
                return _context.Users.Find(id);
            }

        }

        public void Insert(User entity)
        {
            using (_context)
            {
                _context.Users.Add(entity);
            }
        }

        public void Save()
        {
            _context.SaveChangesAsync();
        }

        public void Update(User entity)
        {
            using (_context)
            {
                _context.Users.Update(entity);
            }
        }
    }
}
