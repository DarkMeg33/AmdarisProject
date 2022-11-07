using AmdarisProject.Common.Dtos.User;

namespace AmdarisProject.Core.Interfaces
{
    public interface IAccountService
    {
        Task<UserDto> RegisterUserAsync(UserRegisterDto userRegisterDto);
    }
}
