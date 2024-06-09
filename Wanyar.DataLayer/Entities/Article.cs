using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanyar.DataLayer.Entities
{
    public  class Article
    {
        [Key]
        public int articleId { get; set; }

        [Required]
        public int GroupId { get; set; }

        public int? SubGroup { get; set; }

        [Required]
        public int TeacherId { get; set; }

       
        [Display(Name = "عنوان دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ArticleTitle { get; set; }

        [Display(Name = "شرح دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ArticleDescription { get; set; }

        [Display(Name = "قیمت دوره")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Text { get; set; }

        [MaxLength(600)]
        public string Tags { get; set; }

        [MaxLength(50)]
        public string ArticleImageName { get; set; }

       
        [Required]
        public DateTime CreateDate { get; set; }

        [Display(Name ="تعداد  بازدید")]
        public int Visit { get; set; }

        [Display(Name ="نمایش در اسلایدر")]
        public bool  ShowInSlider { get; set; }

        [Display(Name ="حذف شده")]
        public bool IsDeleted { get; set; }

        #region Relations

        [ForeignKey("TeacherId")]
        public User User { get; set; }

        [ForeignKey("GroupId")]
        public ArticleGroup ArticleGroup { get; set; }

        [ForeignKey("SubGroup")]
        public ArticleGroup Group { get; set; }

     
        #endregion
    }
}
