using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Wanyar.Core.DTOs.Article
{
    public  class SliderViewModel
    {
        public int articleId { get; set; }

        [Display(Name = "عنوان دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ArticleTitle { get; set; }

        [MaxLength(50)]
        public string ArticleImageName { get; set; }
    }
}
