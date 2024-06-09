using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Wanyar.Core.Security;
using Wanyar.Core.Services.Interfaces;


namespace WanyarCms.Pages.Admin.ArticleGroup
{
    [PermissionChecker(1)]
    [PermissionChecker(6)]
    
    public class IndexModel : PageModel
    {
        private IArticleGroupService _groupService;
        public IndexModel(IArticleGroupService groupService)
        {
            _groupService = groupService;
        }


        public List<Wanyar.DataLayer.Entities.ArticleGroup>  ArticleGroups { get; set; } 
        public void OnGet()
        {
            ArticleGroups=_groupService.GetAllArticleGroups();
        }
    }
}
