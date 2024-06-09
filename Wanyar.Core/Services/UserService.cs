using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanyar.Core.DTOs;
using Wanyar.Core.DTOs.User;
using Wanyar.Core.Security;
using Wanyar.Core.Services.Interfaces;
using Wanyar.DataLayer.Context;
using Wanyar.DataLayer.Entities;

namespace Wanyar.Core.Services
{
    public class UserService : IUserService
    {
        private WanyarContext _context;
        public UserService(WanyarContext wanyarContext)
        {
            _context = wanyarContext;
        }


        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.userId;
        }

        

        public bool IsUserExist(string username, string email)
        {
            return _context.Users.Any(u=>u.userName == username || u.email == email);
        }

        public User LoginUser(LoginViewModel login)
        {
            var password = PasswordHelper.EncodePasswordMd5(login.password);
            
            return _context.Users.SingleOrDefault(u=>u.password== password&&u.email==login.email);

        }

        public User GetUserByActiveCode(string activeCode)
        {
            return _context.Users.SingleOrDefault(u=>u.activeCode == activeCode);
        }

        public int UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges ();
            return user.userId;
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u=>u.email == email);
        }


        #region AdminUSser
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
           
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _context.Roles.ToList();
        }

        public EditUserINAdminViewModel GetUserForShowInEditeMode(int userid)
        {
            return _context.Users.Where(u => u.userId == userid).Select(u => new EditUserINAdminViewModel()
            {
                UserId=u.userId,
                email=u.email,
              
                userName=u.userName,
                phoneNumber=u.phoneNumber,
                UserRole=u.UserRoles.Select(u => u.roleId).ToList(),
            }).SingleOrDefault();
        }



        #endregion
    }
}
