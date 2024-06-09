using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;
using System.Collections.Generic;
using Wanyar.Core.Security;
using Wanyar.Core.Services.Interfaces;


namespace WanyarCms.Pages.Admin.Role
{
    [PermissionChecker(1)]
    [PermissionChecker(14)]

    public class IndexModel : PageModel
    {
        private IPermisionService _permisionService;
        private IUserService _userService;
        public IndexModel(IPermisionService permisionService,IUserService userService)
        {
            _permisionService = permisionService;
            _userService = userService;
        }


        
        public IEnumerable<Wanyar.DataLayer.Entities.Role> Role { get; set; }
        public void OnGet()
        {
            Role=_userService.GetAllRoles();
        }
    }
}
