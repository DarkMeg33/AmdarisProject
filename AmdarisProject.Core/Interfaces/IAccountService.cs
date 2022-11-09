﻿using AmdarisProject.Common.Dtos.User;

namespace AmdarisProject.Core.Interfaces
{
    public interface IAccountService
    {
        Task<UserDto> RegisterUserAsync(UserRegisterDto userRegisterDto);
        Task<string> LoginUserAsync(UserLoginDto userLoginDto, (string Token, string Audience, string Issuer) authOptions);
    }
}