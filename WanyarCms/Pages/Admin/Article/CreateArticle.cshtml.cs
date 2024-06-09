using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Wanyar.Core.Security;
using Wanyar.Core.Services.Interfaces;

namespace WanyarCms.Pages.Admin.Article
{
    [PermissionChecker(1)]
    [PermissionChecker(10)]
    [PermissionChecker(11)]
    public class CreateArticleModel : PageModel
    {
        private IArticleService _articleService;

        public CreateArticleModel(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [BindProperty]
        public Wanyar.DataLayer.Entities.Article Article { get; set; }

        public void OnGet()
        {

            var group = _articleService.GetGroupForAddArticle();
            ViewData["Groups"]=new SelectList(group, "Value", "Text");



            List<SelectListItem> subgrouplist = new List<SelectListItem>()
            {
                new SelectListItem(){Text="انتخاب کنید!!!",Value=""}
            };
            subgrouplist.AddRange(_articleService.GetSubGroupForAddArticle(int.Parse(group.First().Value)));
            ViewData["SubGroups"]=new SelectList(subgrouplist, "Value", "Text");



            List<SelectListItem> teacherlist = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید",Value = ""}
            };
            teacherlist.AddRange(_articleService.GetTeacherForAddArticle());
            ViewData["Teacher"]=new SelectList(teacherlist, "Value", "Text");

        }


        public IActionResult OnPost(IFormFile imgArticleUp)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _articleService.AddArticle(Article, imgArticleUp);

            return RedirectToPage("index");
        }
    }
}
