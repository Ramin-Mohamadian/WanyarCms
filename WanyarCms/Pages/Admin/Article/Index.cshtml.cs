using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Wanyar.Core.DTOs.Article;
using Wanyar.Core.Security;
using Wanyar.Core.Services.Interfaces;

namespace WanyarCms.Pages.Admin.Article
{
    [PermissionChecker(1)]
    [PermissionChecker(10)]
    public class IndexModel : PageModel
    {
        private IArticleService _articleService;
        public IndexModel(IArticleService articleService)
        {
            _articleService = articleService;
        }



        public List<ListOfArticleForAdminViewModel> listArticle { get; set; }
        public void OnGet()
        {
            listArticle=_articleService.GetListArticleForAdmin();
        }
    }
}
