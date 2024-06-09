using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Wanyar.Core.Security;
using Wanyar.Core.Services.Interfaces;

namespace WanyarCms.Pages.Admin.Article
{
    [PermissionChecker(1)]
    [PermissionChecker(10)]
    [PermissionChecker(12)]
    public class EditArticleModel : PageModel
    {
        private IArticleService _articleService;
        public EditArticleModel(IArticleService articleService) 
        {
            _articleService = articleService;
        }



        [BindProperty]
        public   Wanyar.DataLayer.Entities.Article article { get; set; }
        public void OnGet(int id)
        {
            article=_articleService.GetArticleById(id);

            var group = _articleService.GetGroupForAddArticle();
            ViewData["Groups"]=new SelectList(group, "Value", "Text");

            var subgroup = _articleService.GetSubGroupForAddArticle(article.GroupId);
            ViewData["SubGroups"]=new SelectList(subgroup, "Value", "Text");

            var teacher = _articleService.GetTeacherForAddArticle();
            ViewData["Teacher"]= new SelectList(teacher, "Value", "Text");
        }


        public IActionResult OnPost(IFormFile imgArticleUp)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            _articleService.EditArticle(article, imgArticleUp);



            return RedirectToPage("Index");
        }
    }
}
