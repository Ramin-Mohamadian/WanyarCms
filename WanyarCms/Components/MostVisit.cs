using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Wanyar.Core.Services.Interfaces;

namespace WanyarCms.Components
{
    public class MostVisit: ViewComponent
    {
        private IArticleService _articleService;
        public MostVisit(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("MostVisits", _articleService.GetArticleByVisit());
        }
    }
}
