
using Microsoft.AspNetCore.Identity;
using UserService.DTOs;
using UserService.Models;
using UserService.Repositories;

namespace UserService.Services
{
    public interface IAuthService
    {
        Task<Result<string>> Register(RegisterRequest request);
        void Login();
    }
    public class AuthService: IAuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;    
        }

        public async Task<Result<string>> Register(RegisterRequest request)
        {
            PasswordHasher<User> hasher = new();
            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = request.name,
                Email = request.email,
                Role = UserRole.Admin
            };

            user.PasswordHash = hasher.HashPassword(user, request.password);

            await _userRepository.AddAsync(user);

            return Result<string>.Success("Successfully Created");
        }

        public void Login()
        {

        }
    }
}
