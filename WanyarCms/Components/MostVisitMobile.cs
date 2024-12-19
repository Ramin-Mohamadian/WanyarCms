using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Wanyar.Core.Services.Interfaces;

namespace WanyarCms.Components
{
    public class MostVisitMobile:ViewComponent
    {
        private IArticleService _articleService;
        public MostVisitMobile(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("MostVisitsMobile", _articleService.GetArticleByVisit());
        }
    }
}
