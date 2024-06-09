using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanyar.DataLayer.Entities
{
    public  class RolePermissions
    {
        [Key]
        public int RP_Id { get; set; }
        public int roleId { get; set; }
        public int PermissionId { get; set; }

        public Role Role { get; set; }
        public Permission Permission { get; set; }

    }
}
