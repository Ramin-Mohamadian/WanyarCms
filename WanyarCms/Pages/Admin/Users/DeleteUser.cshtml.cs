using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Wanyar.Core.Security;
using Wanyar.Core.Services.Interfaces;
using Wanyar.DataLayer.Entities;

namespace WanyarCms.Pages.Admin.Users
{
    [PermissionChecker(1)]
    [PermissionChecker(2)]
    [PermissionChecker(5)]
    public class DeleteUserModel : PageModel
    {
        private IUserService _userService;
        public DeleteUserModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public User deleteUser { get; set; }


        public void OnGet(int id)
        {
            deleteUser = _userService.GetUserById(id);
            ViewData["Name"] = deleteUser.userName;
        }



        public IActionResult OnPost(int id)
        {

            var user=_userService.GetUserById(id);
            if(user != null)
            {
                user.Isdelete = true;
                _userService.UpdateUser(user);
            }
            
            return RedirectToPage("index");
        }

    }
}
