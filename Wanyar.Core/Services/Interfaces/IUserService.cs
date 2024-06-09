using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanyar.Core.DTOs;
using Wanyar.Core.DTOs.User;
using Wanyar.DataLayer.Entities;

namespace Wanyar.Core.Services.Interfaces
{
    public interface IUserService
    {
        int AddUser(User user);
        int UpdateUser(User user);
        User LoginUser(LoginViewModel login);
        bool IsUserExist(string username, string email);
        User GetUserByActiveCode(string activeCode);

        User GetUserByEmail(string email);

        #region AdminUser
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);

        IEnumerable<Role> GetAllRoles();

        EditUserINAdminViewModel GetUserForShowInEditeMode(int userid);

        #endregion

    }
}
