using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Wanyar.Core.Services.Interfaces;

namespace WanyarCms.Components
{
    public class SuggestionBook:ViewComponent
    {
        private readonly IArticleService _articleService;
        public SuggestionBook(IArticleService articleService)
        {
            _articleService = articleService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View("SuggestionBooks",_articleService.GetListArticleForSHow());
        }
    }
}
