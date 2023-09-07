using Car_E_shop.Database.Context;
using Car_E_shop.Exceptions.ErrorMessages;
using Car_E_shop.Models;
using Car_E_shop.RepositoryPattern.Interfaces;
using Car_E_shop.RepositoryPattern.UserRepo;
using Car_E_shop.Services.ChechForNull;
using Car_E_shop.Services.ValidateId;
using Microsoft.AspNetCore.Mvc;

namespace Car_E_shop.Controllers
{
    public class UserController : Controller
    {
        private readonly IRepository<User> _userRepository;

        private readonly ILogger<UserController> _logger;

        private readonly IValidateIdService _validateId;

        private readonly ICheckNull _checkNull;

        public UserController(IRepository<User> userRepository, ILogger<UserController> logger, IValidateIdService validateId, ICheckNull checkNull)
        {
            _userRepository = userRepository;
            _logger = logger;
            _validateId = validateId;
            _checkNull = checkNull;
        }

        [HttpGet]
        [Route("/api/get/users")]
        public IActionResult GetAllUsers()
        {
            IEnumerable<User>? users = null;
            try
            {
                 users = _userRepository.GetAll();

                if (_checkNull.IsNull(users))
                {
                    _logger.LogError(Message.ObjectIsNull(users));

                   return NotFound(Message.ObjectIsNull(users));
                }


            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }

            return Ok(users);
        }

        [HttpPost]
        [Route("api/post/user")]
        public IActionResult PostUser(User user)
        {
           
            try
            {
                if (_checkNull.IsNull(user))
                {
                    _logger.LogError(Message.ObjectIsNull(user));

                    return NotFound(Message.ObjectIsNull(user));
                }

                _userRepository.Insert(user);
                _userRepository.Save();

            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }

            return Ok();
        }
    }
}
