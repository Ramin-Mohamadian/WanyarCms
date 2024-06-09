using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wanyar.Core.Security;
using Wanyar.Core.Services.Interfaces;

namespace WanyarCms.Pages.Admin.Article
{
    [PermissionChecker(1)]
    [PermissionChecker(10)]
    [PermissionChecker(13)]
    public class DeleteArticleModel : PageModel
    {
        private IArticleService _articleService;
        public DeleteArticleModel(IArticleService articleService)
        {
            _articleService = articleService;
        }

        
        public Wanyar.DataLayer.Entities.Article Article { get; set; }
        public void OnGet(int id)
        {
            Article=_articleService.GetArticleById(id);            
        }


        public IActionResult OnPost(int id)
        {
            var article=_articleService.GetArticleById(id);
            article.IsDeleted = true;
            _articleService.EditArticleForDelete(article);


            return RedirectToPage("index");
        }
    }
}
