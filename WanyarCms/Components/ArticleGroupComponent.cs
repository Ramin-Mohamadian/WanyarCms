using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Wanyar.Core.Services.Interfaces;
using Wanyar.DataLayer.Entities;

namespace WanyarCms.Components
{
    public class ArticleGroupComponent:ViewComponent
    {
        private IArticleGroupService _articleGroupService;
        public ArticleGroupComponent(IArticleGroupService articleGroupService)
        {
            _articleGroupService = articleGroupService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult) View("ArticleGroup",_articleGroupService.GetAllArticleGroups()));
        }

    }
}
