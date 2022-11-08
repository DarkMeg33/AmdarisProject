using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AmdarisProject.Common.Dtos.User;
using AmdarisProject.Core.Infrastructure;
using AmdarisProject.Core.Interfaces;
using AmdarisProject.DataAccess.Interfaces;
using AmdarisProject.Domain;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace AmdarisProject.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public AccountService(IRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserDto> RegisterUserAsync(UserRegisterDto userRegisterDto)
        {
            var user = _mapper.Map<UserRegisterDto, User>(userRegisterDto);
            
            var alreadyExists = await _repository.GetByQueryAsync(u => u.UserName == user.UserName);

            if (alreadyExists.Any())
            {
                throw new Exception(); //TODO Create new exception
            }

            //user.Password = Cryptography.HashString(user.Password);
            //TODO Configure hash method
            
            await _repository.CreateAsync(user);

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<string> LoginUserAsync(UserLoginDto userLoginDto, 
            (string Token, string Audience, string Issuer) authOptions)
        {
            var user = (await _repository
                .GetByQueryAsync(u => u.UserName == userLoginDto.UserName
                                      && u.Password == userLoginDto.Password))
                .FirstOrDefault();

            if (user is null)
            {
                throw new Exception(); //TODO Create new exception
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.Token));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var token = new JwtSecurityToken(
                audience: authOptions.Audience,
                issuer: authOptions.Issuer,
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credentials);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtToken;
        }
    }
}
