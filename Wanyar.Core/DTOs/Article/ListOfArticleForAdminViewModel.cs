using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanyar.Core.DTOs.Article
{
    public class ListOfArticleForAdminViewModel
    {
        public int ArticleId { get; set; }
        public string ArticleImage { get; set; }
        public string ArticleTitle { get; set; }
        public int Visit { get; set; }
        public bool ShowInSlider { get; set; }

    }
}
