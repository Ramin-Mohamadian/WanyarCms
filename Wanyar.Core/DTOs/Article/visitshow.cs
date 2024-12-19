using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanyar.Core.DTOs.Article
{
    public class visitshow
    {

        public int articleId { get; set; }

        [Display(Name = "عنوان دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ArticleTitle { get; set; }

        [MaxLength(50)]
        public string ArticleImageName { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        public int visit { get; set; }
    }
}
