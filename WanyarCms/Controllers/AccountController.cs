using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using Wanyar.Core.Convertors;
using Wanyar.Core.DTOs;
using Wanyar.Core.Security;
using Wanyar.Core.Senders;
using Wanyar.Core.Services;
using Wanyar.Core.Services.Interfaces;
using Wanyar.DataLayer.Entities;

namespace WanyarCms.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        private IViewRenderService _viewRender;
        private IArticleService _articleService;
        public AccountController(IUserService userService, IViewRenderService viewRender,IArticleService articleService)
        {
            _userService = userService;
            _viewRender = viewRender;
            _articleService = articleService;
        }
        public IActionResult Index()
        {
            return View();
        }


        #region Register
        [HttpGet]
        [Route("/SignUp")]
        public IActionResult SignUp()
        {

            return View();
        }



        [HttpPost]
        [Route("/SignUp")]
        public IActionResult SignUp(SignUpViewModel user)
        {

            if (!ModelState.IsValid)
            {
                return View(user);
            }


            User getuser = new User()
            {
                userName=user.userName,
                email=user.email,
                phoneNumber=user.phoneNumber,
                password=PasswordHelper.EncodePasswordMd5(user.password),
                registeDate=DateTime.Now,
                IsActive=false,
                activeCode=Guid.NewGuid().ToString(),
            };
            if (_userService.IsUserExist(user.userName, user.email))
            {
                ViewBag.userexist=true;
                return View(user);
            }
            //TODo:SendActivateEmail
            #region SendEmail
            string body = _viewRender.RenderToStringAsync("ActiveEmail", getuser);
            SendEmail.Send(user.email, "فعالسازی", body);
            #endregion



            _userService.AddUser(getuser);

            return View("SuccessRegister", getuser);
        }
        #endregion

        #region Login
        [HttpGet]
        [Route("/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("/Login")]
        public IActionResult Login(LoginViewModel login)
        {

            if (!ModelState.IsValid)
            {
                return View(login);
            }


            var user = _userService.LoginUser(login);
            if (user==null)
            {
                ModelState.AddModelError("email", "کاربری با این مشخصات یافت نشد.");

            }
            else
            {
                if (user.IsActive==true)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.userId.ToString()),
                        new Claim(ClaimTypes.Name, user.userName)
                     };

                    var Identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(Identity);
                    var propertis = new AuthenticationProperties
                    {
                        IsPersistent=login.RememberMe
                    };

                    HttpContext.SignInAsync(principal, propertis);
                    ViewBag.IsActive = user.IsActive;
                    return View("Login");
                }
                else
                {
                    ModelState.AddModelError("email", "حساب کاربری شما فعال نمی باشد لطفا به ایمیل خود مراجعه کنید");
                }
            }


            return View();
        }
        #endregion

        #region LogOut
        [Route("/LogOut")]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
        #endregion

        #region Activation Account
        [Route("/ActiveAccount/{activecode}")]
        public IActionResult ActiveAccount(string activecode)
        {
            User user = _userService.GetUserByActiveCode(activecode);
            if (user == null)
            {
                return BadRequest();
            }
            user.IsActive = true;
            _userService.UpdateUser(user);
            ViewBag.ActiveMessage=user.IsActive;
            return View("ShowActiveMessage");
        }
        #endregion

        #region ForgotPassword
        [Route("/ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [Route("/ForgotPassword")]
        public IActionResult ForgotPassword(ForgotPasswordViewModel useremail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = _userService.GetUserByEmail(useremail.email);
            if (user == null)
            {
                ModelState.AddModelError("email", "ایمیل وارد شده یافت نشد");

            }

            var emailBody = _viewRender.RenderToStringAsync("_ForgotPassword", user);
            SendEmail.Send(user.email, "بازیابی کلمه عبور {وانیار}. ", emailBody);
            ViewBag.IsSuccess=true;
            return View();
        }
        #endregion


        #region RessetPassword
        [Route("/RessetPassword/{id}")]
        public IActionResult RessetPassword(string id)
        {

            var resset=new RessetPasswordViewModel()
            {
                activecode = id,
            };   
            return View(resset);
        }


        [HttpPost]
        [Route("/RessetPassword/{id}")]
        public IActionResult RessetPassword(RessetPasswordViewModel resset)
        {
            var user=_userService.GetUserByActiveCode(resset.activecode);
            if (user == null)
            {
                return NotFound();
            }
            if(!ModelState.IsValid)
            {
                return View(resset);
            }
            
            user.password = PasswordHelper.EncodePasswordMd5(resset.password);
            _userService.UpdateUser(user);
            
            return Redirect("/Login");
        }
        #endregion




        public IActionResult GetSubGroup(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید",Value = ""}
            };
            list.AddRange(_articleService.GetSubGroupForAddArticle(id));
            return Json(new SelectList(list, "Value", "Text"));
        }
    }
}
