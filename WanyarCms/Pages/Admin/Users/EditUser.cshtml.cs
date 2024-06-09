using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using Wanyar.Core.DTOs;
using Wanyar.Core.DTOs.User;
using Wanyar.Core.Security;
using Wanyar.Core.Services.Interfaces;
using Wanyar.DataLayer.Entities;

namespace WanyarCms.Pages.Admin.Users
{
    [PermissionChecker(1)]
    [PermissionChecker(2)]
    [PermissionChecker(4)]
    public class EditUserModel : PageModel
    {
        private IUserService _userService;
        private IPermisionService _permisionService;
        public EditUserModel(IUserService userService,IPermisionService permisionService)
        {
            _userService = userService;
            _permisionService = permisionService;
        }

        [BindProperty]
        public EditUserINAdminViewModel register { get; set; }



        public void OnGet(int id)
        {
            register=_userService.GetUserForShowInEditeMode(id);
            

            ViewData["Role"]=_userService.GetAllRoles();

            
            
        }



        public IActionResult OnPost(int id,List<int> SelectedRole)
        {
            var getUser=_userService.GetUserById(id);

            if(register.userName != null) 
            {
                getUser.userName = register.userName;
            }
            if (register.email != null)
            {
                getUser.email=register.email;
            }
            if(register.phoneNumber != null)
            {
                getUser.phoneNumber= register.phoneNumber;
            }   
            if (register.password!=null)
            {
                getUser.password=PasswordHelper.EncodePasswordMd5(register.password);
            }

            int userid= _userService.UpdateUser(getUser);

            _permisionService.UpdateUSerRole(SelectedRole, userid);

            return RedirectToPage("index");
        }
    }
}
