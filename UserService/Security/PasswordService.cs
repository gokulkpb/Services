using Microsoft.AspNetCore.Identity;
using UserService.Models;

namespace UserService.Security
{
    public interface IPasswordService
    {
        bool VerifyPassword(User user, string password);
        string GetPasswordHash(User user, string password);
    }
    public class PasswordService:IPasswordService
    {
        public PasswordService()
        {
            
        }

        public bool VerifyPassword(User user, string password)
        {
            PasswordHasher<User> hasher = new();
            var result = hasher.VerifyHashedPassword(user, user.PasswordHash, password);
            return result == PasswordVerificationResult.Success;
        }

        public string GetPasswordHash(User user, string password)
        {
            PasswordHasher<User> hasher = new();
            return hasher.HashPassword(user, password);
        }
    }
}
