using Dot_Net_Web_API.Data;
using Dot_Net_Web_API.Interfaces;
using Dot_Net_Web_API.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Dot_Net_Web_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context) 
        {
            _context = context;
        }
        public async Task<Users> CreateUserAsync(Users user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
                return await _context.users
                                     .Include(u => u.Wallets)
                                     .Include(u => u.FollowedCoins)
                                     .ToListAsync();
        }

        public ICollection<Users> GetUser()
        {
            return _context.users.OrderBy(u => u.UserID).ToList();
        }

        public Users GetUser(int id)
        {
            return _context.users.Where(u => u.UserID == id).FirstOrDefault();
        }

        public Users GetUser(string username)
        {
            return _context.users.Where(u => u.UserName == username).FirstOrDefault();
        }

        public Users GetUserEmail(string email)
        {
            return _context.users.Where(u => u.Email == email).FirstOrDefault();
        }

        public bool save()
        {
           var saved  = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateUser(Users user)
        {
            _context.Update(user);
            return save();
        }

        public bool DeleteUser(Users user)
        {
            _context.Remove(user);
            return save();
        }
    }
}
