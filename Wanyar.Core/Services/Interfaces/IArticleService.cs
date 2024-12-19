using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanyar.Core.DTOs.Article;
using Wanyar.DataLayer.Entities;

namespace Wanyar.Core.Services.Interfaces
{
    public  interface IArticleService
    {
       List<ListOfArticleForAdminViewModel> GetListArticleForAdmin();

        List<SelectListItem> GetGroupForAddArticle();
        List<SelectListItem> GetSubGroupForAddArticle(int id);

        List<SelectListItem> GetTeacherForAddArticle();

        int AddArticle(Article article,IFormFile imgArticleUp);
        Article GetArticleById(int id);

        void EditArticle(Article article,IFormFile imgArticleUp);

        void EditArticleForDelete(Article article);

        List<GetArticleForSHowViewModel> GetListArticleForSHow(string search="");

        List<SliderViewModel> GetSliderForSHow();

        void UpdateArticle(Article article);
        List<SliderViewModel> GetPopularArticle();
        List<SliderViewModel> LastArticles();

        List<GetArticleForSHowViewModel> GrtArticleByGroupid(int? groupid,string search="");
        List<GetArticleForSHowViewModel> GrtArticleBysearch(string search = "");
        List<GetArticleForSHowViewModel> GetArticleByVisit();
        List<GetArticleForSHowViewModel> GetArticleBySugestion();

    }
}
