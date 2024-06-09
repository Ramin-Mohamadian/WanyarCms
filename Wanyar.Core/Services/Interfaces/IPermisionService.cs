using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanyar.DataLayer.Entities;

namespace Wanyar.Core.Services.Interfaces
{
    public  interface IPermisionService
    {
        void AddRoleToUser(List<int> rolesId, int usersId);

        void UpdateUSerRole(List<int> rolesId, int userId);

        int AddRole(Role role);
        Role GetRoleById(int roleId);
        void UpdateRole(Role role);
        List<Permission> GetAllPermissions();
        void AddPermissionsToRole(int id, List<int> permission);

        List<int>PermissionRole(int roleId);

        void EditPermission(int roleId, List<int> permission);

        bool CheckPermission(int permissionId,string userName);
    }
}
