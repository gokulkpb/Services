
using Microsoft.AspNetCore.Identity;
using UserService.DTOs;
using UserService.Models;
using UserService.Repositories;
using UserService.Security;

namespace UserService.Services
{
    public interface IAuthService
    {
        Task<Result<string>> Register(RegisterRequest request);
        Task<Result<string>> Login(LoginRequest request);
    }
    public class AuthService: IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly ITokenService _tokenService;
        public AuthService(IUserRepository userRepository, IPasswordService passwordService, ITokenService tokenService)
        {
            _userRepository = userRepository;    
            _passwordService = passwordService;
            _tokenService = tokenService;
        }

        public async Task<Result<string>> Register(RegisterRequest request)
        {

            if(await _userRepository.GetUserByEmailAsync(request.email) != null)
                return Result<string>.Failure("Email already existing");

            User user = new User
            {
                Id = Guid.NewGuid(),
                Name = request.name,
                Email = request.email,
                Role = UserRole.Admin
            };

            user.PasswordHash = _passwordService.GetPasswordHash(user, request.password);

            await _userRepository.AddAsync(user);

            return Result<string>.Success("Successfully Created");
        }

        public async Task<Result<string>> Login(LoginRequest request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.email);
            if (user == null)
            {
                return Result<string>.Failure("User not found");
            }

            if(!_passwordService.VerifyPassword(user, request.password))
            {
                return Result<string>.Failure("Invalid password");
            }


            var token = _tokenService.GenerateToken(user);

            return Result<string>.Success(token);

        }
    }
}
