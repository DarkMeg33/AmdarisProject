using AmdarisProject.Common.Dtos.User;
using AmdarisProject.Domain;
using AutoMapper;

namespace AmdarisProject.Core.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserLoginDto, User>();
            CreateMap<UserRegisterDto, User>();
        }
    }
}
