using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Wanyar.Core.Services.Interfaces;

namespace WanyarCms.Components
{
    public class SliderComponent:ViewComponent
    {
        private IArticleService _articleService;
        public SliderComponent(IArticleService articleService)
        {
                _articleService = articleService;
        }

        public async Task<IViewComponentResult>InvokeAsync()
        {
            var slider=_articleService.GetSliderForSHow();
            return  View("Slider", slider);
        }

        

    }
}
