﻿using AmdarisProject.Common.Dtos.User;
using AmdarisProject.Common.Exeptions;
using AmdarisProject.Core.Interfaces;
using AmdarisProject.Domain.Identity;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AmdarisProject.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public AccountService(IMapper mapper, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _mapper = mapper;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> RegisterUserAsync(UserRegisterDto userRegisterDto)
        {
            var existingUser =await _userManager.FindByNameAsync(userRegisterDto.UserName);

            if (existingUser is not null)
            {
                throw new ConflictException("User with this credentials exists");
            }

            var user = _mapper.Map<UserRegisterDto, User>(userRegisterDto);

            var identityResult = await _userManager.CreateAsync(user, userRegisterDto.Password);

            if (!identityResult.Succeeded)
            {
                throw new Exception("An error happened"); //TODO Change exception
            }

            return true;
        }

        public async Task<string> LoginUserAsync(UserLoginDto userLoginDto,
            (string Token, string Audience, string Issuer) authOptions)
        {
            var existingUser = await _userManager.FindByNameAsync(userLoginDto.UserName);

            if (existingUser is not null)
            {
                throw new NotFoundException("User with this credentials not found");
            }

            var signResult = await _signInManager.CheckPasswordSignInAsync(existingUser, userLoginDto.Password, false);

            if (!signResult.Succeeded)
            {
                throw new Exception("An error happened"); //TODO Change exception
            }

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authOptions.Token));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha512);

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userLoginDto.UserName),
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
