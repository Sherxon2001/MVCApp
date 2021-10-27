using Pension.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pension.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetUsersAsync();

        Task<IEnumerable<UserModel>> GetUserAsync(string str);
        Task<UserModel> GetUserAsync(int id);

        Task<UserModel> CreateUserAsync(UserModel model);

        Task<bool> DeleteUserAsync(int id);

        Task<UserModel> UpdateUserAsync(int id, UserModel model);
    }
}
