using AmdarisProject.Common.Dtos.User;
using AmdarisProject.Core.Interfaces;
using AmdarisProject.DataAccess.Interfaces;
using AmdarisProject.Domain;
using AutoMapper;

namespace AmdarisProject.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public async Task<UserDto> RegisterUserAsync(UserRegisterDto userRegisterDto)
        {
            var user = _mapper.Map<UserRegisterDto, User>(userRegisterDto);

            bool alreadyExists = (await _repository.GetAllAsync()).Any(u => u.UserName == user.UserName);

            if (alreadyExists)
            {
                throw new Exception(); //TODO Create new exception
            }
            
            await _repository.CreateAsync(user);

            return _mapper.Map<User, UserDto>(user);
        }
    }
}
