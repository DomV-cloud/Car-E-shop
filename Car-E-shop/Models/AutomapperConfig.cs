using AutoMapper;
using Car_E_shop.Models;

namespace Car_E_shop
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
