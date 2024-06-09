using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanyar.Core.Services.Interfaces;
using Wanyar.DataLayer.Context;
using Wanyar.DataLayer.Entities;

namespace Wanyar.Core.Services
{
    public class PermisionService : IPermisionService
    {
        private WanyarContext _context;
        public PermisionService(WanyarContext context)
        {
            _context = context;
        }

     

        public void AddRoleToUser(List<int> rolesId, int usersId)
        {
            foreach (var role in rolesId)
            {
                _context.UserRoles.Add(new DataLayer.Entities.UserRole()
                {
                    roleId=role,
                    userId=usersId
                });
            }
            _context.SaveChanges();
        }

        public void UpdateUSerRole(List<int> rolesId, int userId)
        {
            _context.UserRoles.Where(r => r.userId==userId).ToList().ForEach(r => _context.UserRoles.Remove(r));
            AddRoleToUser(rolesId, userId);
        }


        public int AddRole(Role role)
        {
           _context.Roles.Add(role);
            _context.SaveChanges();
            return role.roleId;
        }

        public Role GetRoleById(int roleId)
        {
            return _context.Roles.Find(roleId);
        }

        public void UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
        }

        public List<Permission> GetAllPermissions()
        {
           return _context.Permissions.ToList();
        }

        public void AddPermissionsToRole(int id, List<int> permission)
        {
            foreach (var p in permission)
            {
                _context.RolePermissions.Add(new RolePermissions()
                {
                    PermissionId = p,
                    roleId = id
                });
            }

            _context.SaveChanges();
        }

        public List<int> PermissionRole(int roleId)
        {
            return _context.RolePermissions
                .Where(r=>r.roleId==roleId)
                .Select(r => r.PermissionId).ToList();
        }

        public void EditPermission(int roleId, List<int> permission)
        {
            _context.RolePermissions.Where(r=>r.roleId == roleId).ToList()
                .ForEach(r=>_context.RolePermissions.Remove(r));

            AddPermissionsToRole(roleId, permission);
            _context.SaveChanges() ;
        }

        public bool CheckPermission(int permissionId, string userName)
        {
            int userid=_context.Users.Single(u=>u.userName==userName).userId;

            List<int> UserRole = _context.UserRoles.Where(r => r.userId==userid).Select(r=>r.roleId).ToList();

            if(!UserRole.Any())
            {
                return false;
            }

            List<int> RolePermission=_context.RolePermissions.Where(r=>r.PermissionId==permissionId).Select(r=>r.roleId).ToList();

            return RolePermission.Any(p=>UserRole.Contains(p));
        }
    }
}
