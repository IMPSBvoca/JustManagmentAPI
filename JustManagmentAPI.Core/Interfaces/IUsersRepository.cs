using JustManagmentApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustManagmentApi.Core.Interfaces
{
    public interface IUsersRepository
    {
        Task AddUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task<List<User>> GetAllUsersAsync();

    }
}
