using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanyar.Core.DTOs.Article;
using Wanyar.Core.Services.Interfaces;
using Wanyar.DataLayer.Context;
using Wanyar.DataLayer.Entities;

namespace Wanyar.Core.Services
{
    public class ArticleService : IArticleService
    {
        private WanyarContext _context;
        public ArticleService(WanyarContext context)
        {
            _context = context;
        }



        public List<ListOfArticleForAdminViewModel> GetListArticleForAdmin()
        {
            return _context.Articles.Select(a => new ListOfArticleForAdminViewModel()
            {
                ArticleId=a.articleId,
                ArticleTitle=a.ArticleTitle,
                ShowInSlider=a.ShowInSlider,
                ArticleImage= a.ArticleImageName,
                Visit = a.Visit,
            }).ToList();
        }



        public List<SelectListItem> GetGroupForAddArticle()
        {
            return _context.ArticleGroups.Where(g => g.parentId == null)
               .Select(g => new SelectListItem()
               {
                   Text = g.groupTitle,
                   Value = g.groupId.ToString()
               }).ToList();
        }

        public List<SelectListItem> GetSubGroupForAddArticle(int id)
        {
            return _context.ArticleGroups.Where(g => g.parentId==id).Select(g => new SelectListItem()
            {
                Text= g.groupTitle,
                Value = g.groupId.ToString()
            }).ToList();
        }

        public List<SelectListItem> GetTeacherForAddArticle()
        {
            return _context.Users.Select(u => new SelectListItem()
            {
                Text=u.userName,
                Value=u.userId.ToString()
            }).ToList();
        }

        public int AddArticle(Article article, IFormFile imgArticleUp)
        {
            article.CreateDate = DateTime.Now;
            if (imgArticleUp == null)
            {
                article.ArticleImageName="default.jpg";
            }
            else
            {
                article.ArticleImageName=Guid.NewGuid().ToString()+Path.GetExtension(imgArticleUp.FileName);
                var imgpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Picture", article.ArticleImageName);
                using (var stream = new FileStream(imgpath, FileMode.Create))
                {
                    imgArticleUp.CopyTo(stream);
                }
            }


            _context.Articles.Add(article);
            _context.SaveChanges();
            return article.articleId;
        }

        public Article GetArticleById(int id)
        {
            return _context.Articles.Find(id);
        }

        public void EditArticle(Article article, IFormFile imgArticleUp)
        {
            string imagePath = "";
            if (imgArticleUp !=null)
            {
                if (article.ArticleImageName!="default.jpg")
                {
                    imagePath=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/Picture",article.ArticleImageName);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }
                article.ArticleImageName=Guid.NewGuid().ToString()+Path.GetExtension(imgArticleUp.FileName);
                var imgpath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Picture", article.ArticleImageName);
                using (var stream = new FileStream(imgpath, FileMode.Create))
                {
                    imgArticleUp.CopyTo(stream);
                }
            }

            _context.Articles.Update(article);
            _context.SaveChanges(); 
            
        }

        public void EditArticleForDelete(Article article)
        {
            _context.Articles.Update(article);
            _context.SaveChanges();

        }

        public List<GetArticleForSHowViewModel> GetListArticleForSHow()
        {            
            return _context.Articles.OrderByDescending(a=>a.CreateDate).Take(6).Select(a=>new GetArticleForSHowViewModel()
            {
                articleId=a.articleId,
                ArticleTitle=a.ArticleTitle,
                ArticleImageName=a.ArticleImageName,
                CreateDate = a.CreateDate
            }).ToList();
        }

        public List<SliderViewModel> GetSliderForSHow()
        {
            return _context.Articles.Where(a=>a.ShowInSlider==true).Select(a=>new SliderViewModel()
            {
                articleId = a.articleId,
                ArticleImageName = a.ArticleImageName,
                ArticleTitle= a.ArticleTitle,
            }).ToList();
        }

        public void UpdateArticle(Article article)
        {
             _context.Articles.Update(article);
            _context.SaveChanges();
        }

        public List<SliderViewModel> GetPopularArticle()
        {
            return _context.Articles.OrderByDescending(a => a.Visit).Take(6).Select(a => new SliderViewModel()
            {
                articleId=a.articleId,
                ArticleImageName= a.ArticleImageName,
                ArticleTitle= a.ArticleTitle,
            }).ToList();
        }

        public List<SliderViewModel> LastArticles()
        {
            return _context.Articles.OrderByDescending(a=>a.CreateDate).Take(7).Select(a => new SliderViewModel()
            {
                articleId= a.articleId,
                ArticleImageName= a.ArticleImageName,
                ArticleTitle= a.ArticleTitle,
            }).ToList();
        }

        public List<GetArticleForSHowViewModel> GrtArticleByGroupid(int? groupid)
        {
            return _context.Articles.Where(a=>a.GroupId==groupid||a.SubGroup==groupid)
                .Select(a=>new GetArticleForSHowViewModel()
                {
                    articleId = a.articleId,
                    ArticleImageName= a.ArticleImageName,
                    ArticleTitle= a.ArticleTitle,
                    CreateDate= a.CreateDate,                    
                }).ToList();
        }
    }

}
