using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;
using Wanyar.Core.Services.Interfaces;

namespace WanyarCms.Components
{
    public class PopularArticleComponent:ViewComponent
    {
        private IArticleService _articleService;
        public PopularArticleComponent(IArticleService articleService)
        {
            _articleService = articleService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("PopularArticle",_articleService.GetPopularArticle());
        }
    }
}
