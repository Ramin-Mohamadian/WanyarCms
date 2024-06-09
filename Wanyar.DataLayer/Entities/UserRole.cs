using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanyar.DataLayer.Entities
{
    public  class UserRole
    {
        public UserRole()
        {
            
        }

        [Key]
        public int UR_Id { get; set; }

        [Display(Name ="")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        public int userId { get; set; }


        [Display(Name ="")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        public int roleId { get; set; }

        #region Relations
        public User User { get; set; }
        public Role Role { get; set; }
        #endregion
    }
}
