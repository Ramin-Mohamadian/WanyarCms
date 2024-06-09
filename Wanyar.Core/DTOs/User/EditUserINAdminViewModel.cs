﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Wanyar.Core.DTOs.User
{
    public  class EditUserINAdminViewModel
    {
        public int UserId { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(550, ErrorMessage = "تعداد کاراکتر های وارد شده بیش از حد مجاز است")]
        public string userName { get; set; }



        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350, ErrorMessage = "تعداد کاراکتر های وارد شده بیش از حد مجاز است")]
        public string email { get; set; }


        [Display(Name = "شماره مبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(11, ErrorMessage = "تعداد کاراکتر های وارد شده بیش از حد مجاز است")]
        public string phoneNumber { get; set; }


        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public string password { get; set; }


        [Display(Name = " تکرار کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Compare("password", ErrorMessage = "کلمه های عبور با هم مغایرت دارند")]
        public string RePassword { get; set; }

        public List<int> UserRole { get; set; }


    }
}