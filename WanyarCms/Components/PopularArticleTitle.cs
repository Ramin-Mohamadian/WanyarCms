using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Wanyar.Core.Services.Interfaces;

namespace WanyarCms.Components
{
    public class PopularArticleTitle:ViewComponent
    {
        private IArticleService _articleService;
        public PopularArticleTitle(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("PopularTitle",_articleService.GetPopularArticle());
        }


    }
}
