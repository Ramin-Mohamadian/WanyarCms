using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using Wanyar.Core.DTOs;
using Wanyar.Core.Security;
using Wanyar.Core.Services.Interfaces;
using Wanyar.DataLayer.Entities;

namespace WanyarCms.Pages.Admin.Users
{
    [PermissionChecker(1)]
    [PermissionChecker(2)]
    [PermissionChecker(3)]
    public class AddUserModel : PageModel
    {
        private IUserService _userService;
        private IPermisionService _permisionService;

        public AddUserModel(IUserService userService, IPermisionService permisionService)
        {
            _userService = userService;
            _permisionService = permisionService;
        }


        [BindProperty]
        public SignUpViewModel register { get; set; }

        public void OnGet()
        {
            ViewData["Roles"]=_userService.GetAllRoles();
        }



        public IActionResult OnPost(List<int> SelectedRole)
        {
            if (register == null)
            {
                return Page();
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }

            User user = new User()
            {
                activeCode=Guid.NewGuid().ToString(),
                email=register.email,
                password=PasswordHelper.EncodePasswordMd5(register.password),
                IsActive=true,
                phoneNumber=register.phoneNumber,
                registeDate=DateTime.Now,
                userName=register.userName,
            };

            int userid = _userService.AddUser(user);

            _permisionService.AddRoleToUser(SelectedRole, userid);
            return RedirectToPage("index");
        }

    }
}
