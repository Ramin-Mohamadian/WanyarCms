using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanyar.DataLayer.Entities
{
    public  class Role
    {
        public Role()
        {
            
        }

        [Key]
        public int roleId { get; set; }

        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [Display(Name ="عنوان نقش")]
        [MaxLength(350, ErrorMessage = "تعداد کاراکتر های وارد شده بیش از حد مجاز است")]
        public string RoleTitle { get; set; }

        [Display(Name ="حذف شده؟")]
        public bool IsDelete { get; set; }


        #region Relations
        public virtual List<UserRole> UserRoles { get; set; }
        public List<RolePermissions> RolePermissions { get; set; }
        #endregion

    }
}
