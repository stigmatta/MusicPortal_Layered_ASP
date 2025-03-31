using Microsoft.EntityFrameworkCore;
using MusicPortal_Layered_ASP.DLL.Context;
using MusicPortal_Layered_ASP.DLL.Entities;
using MusicPortal_Layered_ASP.DLL.Interfaces;

namespace MusicPortal_Layered_ASP.DLL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly MusicContext _context;

        public UserRepository(MusicContext context)
        {
            _context = context;
        }
        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if(user != null)
                _context.Users.Remove(user);
        }

        public async Task<User?> GetUser(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>?> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        Task<User?> IUserRepository.GetUser(string username)
        {
            throw new NotImplementedException();
        }

        Task<User?> IUserRepository.GetUser(int id)
        {
            throw new NotImplementedException();
        }

        Task IUserRepository.UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
