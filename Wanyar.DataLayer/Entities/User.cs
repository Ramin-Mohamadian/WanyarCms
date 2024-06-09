using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanyar.DataLayer.Entities
{
    public  class User
    {
        public User()
        {
            
        }

        [Key]
        public int userId { get; set; }


        [Display(Name ="نام کاربری")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(550, ErrorMessage = "تعداد کاراکتر های وارد شده بیش از حد مجاز است")]
        public string userName { get; set; }



        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350, ErrorMessage = "تعداد کاراکتر های وارد شده بیش از حد مجاز است")]
        public string email { get; set; }


		[Display(Name = "کد فعال سازی")]
		[Required(ErrorMessage = "لطفا {0} را وارد کنید")]
		[MaxLength(350, ErrorMessage = "تعداد کاراکتر های وارد شده بیش از حد مجاز است")]
		public string activeCode { get; set; }


		[Display(Name ="شماره مبایل")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(11, ErrorMessage = "تعداد کاراکتر های وارد شده بیش از حد مجاز است")]
        public string phoneNumber { get; set; }


        [Display(Name ="کلمه عبور")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]        
        public string password { get; set; }


        [Display(Name ="تاریخ ثبت نام")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        public DateTime registeDate { get; set; }


        [Display(Name ="فعال")]
        public bool IsActive { get; set; }


        [Display(Name = "حذف شده")]
        public bool Isdelete { get; set; }=false;



        #region Relations
        public virtual List<Article> articles { get; set; }

        public virtual List<UserRole> UserRoles { get; set; }

        #endregion
    }
}
