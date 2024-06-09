using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Wanyar.Core.Security;
using Wanyar.Core.Services.Interfaces;

namespace WanyarCms.Pages.Admin.Role
{
    [PermissionChecker(1)]
    [PermissionChecker(14)]
    [PermissionChecker(15)]
    public class CreateRoleModel : PageModel
    {
        private IPermisionService _permisionService;
        public CreateRoleModel(IPermisionService permisionService)
        {
            _permisionService = permisionService;
        }

        [BindProperty]
        public Wanyar.DataLayer.Entities.Role Role { get; set; }
        public void OnGet()
        {
            ViewData["permission"]=_permisionService.GetAllPermissions();
        }

        public IActionResult OnPost(List<int> SelectedPermission)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            Role.IsDelete=false;
            int id=_permisionService.AddRole(Role);

            _permisionService.AddPermissionsToRole(id, SelectedPermission);
            return RedirectToPage("Index");
        }
    }
}
