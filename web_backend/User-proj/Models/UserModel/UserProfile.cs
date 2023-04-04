using AutoMapper;
using User_proj.Models.UserModel.Dto;

namespace User_proj.Models.UserModel
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserDeleteDto, User>();
            CreateMap<UserLoginDto, User>();
            CreateMap<UserChangeDto, User>();
        }
    }
}
