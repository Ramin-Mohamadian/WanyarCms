using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wanyar.Core.Security;
using Wanyar.Core.Services.Interfaces;

namespace WanyarCms.Pages.Admin.ArticleGroup
{
    [PermissionChecker(1)]
    [PermissionChecker(6)]
    [PermissionChecker(8)]
    public class EditGroupModel : PageModel
    {
        private IArticleGroupService _groupService;
        public EditGroupModel(IArticleGroupService groupService)
        {
            _groupService = groupService;
        }

        [BindProperty]
        public Wanyar.DataLayer.Entities.ArticleGroup ArticleGroup { get; set; }
        public void OnGet(int id)
        {
            ArticleGroup=_groupService.GetGroupById(id);
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            _groupService.UpdateGroup(ArticleGroup);

            return RedirectToPage("Index");
        }
    }
}
