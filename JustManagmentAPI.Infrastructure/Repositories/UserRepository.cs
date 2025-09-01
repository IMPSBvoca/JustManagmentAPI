using Microsoft.EntityFrameworkCore;
using JustManagmentApi.Core.Entities;
using JustManagmentApi.Core.Interfaces;
using JustManagmentApi.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JustManagmentApi.Infrastructure.Repositories
{
    public class UserRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
