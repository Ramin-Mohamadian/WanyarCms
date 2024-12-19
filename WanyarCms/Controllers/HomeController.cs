using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using System;
using Wanyar.Core.Services.Interfaces;

namespace WanyarCms.Controllers
{
    public class HomeController : Controller
    {
        private IArticleService _articleService;
        public HomeController(IArticleService articleService)
        {
            _articleService = articleService;
        }


        public IActionResult Index(string search = "")
        {
            var article = _articleService.GetListArticleForSHow(search);
            return View(article);
        }

        public IActionResult Slider()
        {
            var slider = _articleService.GetSliderForSHow();
            return PartialView("_Slider", slider);
        }



        public IActionResult ShowArticle(int Id)
        {
            var article = _articleService.GetArticleById(Id);
            article.Visit += 1;
            _articleService.UpdateArticle(article);
            return View(article);
        }


        [Route("Group/{id}/{name}")]
        public IActionResult GrtArticleByGroupid(int id, string name)
        {
            ViewData["name"] = name;
            var group = _articleService.GrtArticleByGroupid(id);
            return View(group);
        }


        [Route("Search")]
        public IActionResult SearchBook(string search="")
        { 
            return View(_articleService.GrtArticleBysearch(search));
        
        }



     


        [Route("AboutUs")]
        public IActionResult AboutUs()
        {
            return View();
        }

        #region ckeditor
        [HttpPost]
        [Route("file-upload")]
        public IActionResult UploadImage(IFormFile upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            if (upload.Length <= 0) return null;

            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();



            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/MyImages",
                fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                upload.CopyTo(stream);

            }



            var url = $"{"/MyImages/"}{fileName}";


            return Json(new { uploaded = true, url });
        }
        #endregion

    }
}
