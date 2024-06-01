using Dot_Net_Web_API.Models;

namespace Dot_Net_Web_API.Interfaces
{
    public interface IUserRepository
    {
        ICollection<Users> GetUser();
        Task<IEnumerable<Users>> GetAllUsersAsync();
        public Users GetUser       (int  Id);
        public Users GetUser       (string Name);
        public Users GetUserEmail  (string email);
        Task<Users> CreateUserAsync(Users user);
        bool save();
        bool UpdateUser (Users user);    
        bool DeleteUser (Users user);
    }
}
