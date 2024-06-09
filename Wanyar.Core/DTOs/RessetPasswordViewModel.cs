using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Wanyar.Core.DTOs
{
    public  class RessetPasswordViewModel
    {

        public string activecode { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public string password { get; set; }


        [Display(Name = " تکرار کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Compare("password", ErrorMessage = "کلمه های عبور با هم مغایرت دارند")]
        public string RePassword { get; set; }
    }
}
