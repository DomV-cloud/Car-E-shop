using AutoMapper;
using Car_E_shop.Database.Context;
using Car_E_shop.ErrorMessages;
using Car_E_shop.Models;
using Car_E_shop.RepositoryPattern.Interfaces;
using Car_E_shop.RepositoryPattern.UserRepo;
using Car_E_shop.Services.ChechForNull;
using Car_E_shop.Services.ValidateId;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Car_E_shop.Controllers
{
    [Route("api")]
    public class UserController : Controller
    {
        private readonly IRepository<User> _userRepository;

        private readonly ILogger<UserController> _logger;

        private readonly IValidateIdService _validateId;

        private readonly ICheckNull _checkNull;

        private readonly JWTConfig _jWTConfig;
        
        private readonly IMapper _mapper;


		public UserController(
            IRepository<User> userRepository,
            ILogger<UserController> logger,
            IValidateIdService validateId,
            ICheckNull checkNull,
            JWTConfig jWTConfig,
            IMapper  mapper)

        {
            _userRepository = userRepository;
            _logger = logger;
            _validateId = validateId;
            _checkNull = checkNull;
            _jWTConfig = jWTConfig;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/get/users")]
        //[Authorize(AuthenticationSchemes = "ApiKey")]
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
        [Route("/post/user")]
        //[Authorize(AuthenticationSchemes = "ApiKey")]
        public IActionResult PostUser(UserDto userDto)
        {
           
            try
            {
                if (_checkNull.IsNull(userDto))
                {
                    _logger.LogError(Message.ObjectIsNull(userDto));

                    return NotFound(Message.ObjectIsNull(userDto));
                }

                var user = _mapper.Map<User>(userDto);

                _userRepository.Insert(user);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }

            return Ok();
        }



    }
}
