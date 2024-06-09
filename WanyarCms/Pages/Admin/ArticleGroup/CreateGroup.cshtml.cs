using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wanyar.Core.Security;
using Wanyar.Core.Services.Interfaces;


namespace WanyarCms.Pages.Admin.ArticleGroup
{
    [PermissionChecker(1)]
    [PermissionChecker(6)]
    [PermissionChecker(7)]
    public class CreateGroupModel : PageModel
    {
        private IArticleGroupService _groupService;
        public CreateGroupModel(IArticleGroupService groupService)
        {
            _groupService = groupService;
        }

        [BindProperty]
        public Wanyar.DataLayer.Entities.ArticleGroup ArticleGroup { get; set; }

        public void OnGet(int? id)
        {
            ArticleGroup=new Wanyar.DataLayer.Entities.ArticleGroup()
            {
                parentId = id
            };
        }


        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }


            _groupService.AddGroup(ArticleGroup);

            return RedirectToPage("index");
        }
    }
}
