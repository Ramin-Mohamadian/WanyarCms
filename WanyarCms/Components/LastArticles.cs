using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Wanyar.Core.Services.Interfaces;

namespace WanyarCms.Components
{
    public class LastArticles:ViewComponent
    {
        private IArticleService _articleService;
        public LastArticles(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("LastArticle",_articleService.LastArticles());
        }

    }
}
