
using Microsoft.EntityFrameworkCore;
using UserService.DbContext1;
using UserService.DTOs;
using UserService.Models;

namespace UserService.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
    }
    public class UserRepository: IUserRepository
    {
        private readonly UserDbContext _context;
        public UserRepository(UserDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            _context.SaveChanges();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync<User>(u => u.Email == email);
        }
    }
}
