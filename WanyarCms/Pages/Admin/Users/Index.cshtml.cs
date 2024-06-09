using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Wanyar.Core.Security;
using Wanyar.Core.Services.Interfaces;
using Wanyar.DataLayer.Entities;

namespace WanyarCms.Pages.Admin.Users
{

    [PermissionChecker(1)]
    [PermissionChecker(2)]
    public class IndexModel : PageModel
    {

        private IUserService _userService;
        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }


    
        public IEnumerable<User> GetUser { get; set; }
        public void OnGet()
        {
            GetUser=_userService.GetAllUsers();
        }
    }
}
