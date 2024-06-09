using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanyar.DataLayer.Entities
{
    public  class ArticleGroup
    {
        [Key]
        public int groupId { get; set; }

        [Display(Name ="عنوان گروه")]
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(350, ErrorMessage = "تعداد کاراکتر های وارد شده بیش از حد مجاز است")]
        public string groupTitle { get; set; }

        [Display(Name ="گروه اصلی")]
        public int? parentId { get; set; }

        [Display(Name = "حذف شده")]
        public bool isDeleted { get; set; }

        [ForeignKey("parentId")]
        public List<ArticleGroup> ArticleGroups { get; set; }


        #region Relations

        [InverseProperty("ArticleGroup")]
        public List<Article> article { get; set; }

        [InverseProperty("Group")]
        public List<Article> SubGroup { get; set; }
        #endregion

    }
}
