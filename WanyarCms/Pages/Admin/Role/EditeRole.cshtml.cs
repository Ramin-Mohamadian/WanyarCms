using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Wanyar.Core.Security;
using Wanyar.Core.Services.Interfaces;

namespace WanyarCms.Pages.Admin.Role
{
    [PermissionChecker(1)]
    [PermissionChecker(14)]
    [PermissionChecker(16)]
    public class EditeRoleModel : PageModel
    {
        private IPermisionService _permisionService;
        public EditeRoleModel(IPermisionService permisionService)
        {
            _permisionService = permisionService;
        }

        [BindProperty]
        public Wanyar.DataLayer.Entities.Role Role { get; set; }
        public void OnGet(int id)
        {
            Role=_permisionService.GetRoleById(id);
            ViewData["permission"]=_permisionService.GetAllPermissions();
            ViewData["SelectedPermission"]=_permisionService.PermissionRole(id);

        }

        public IActionResult OnPost(List<int> SelectedPermission)
        {
            if (!ModelState.IsValid)
                return Page();


            _permisionService.UpdateRole(Role);

            //ToDO:UpdatePermission
            _permisionService.EditPermission(Role.roleId,SelectedPermission);
          
            return RedirectToPage("Index");

        }
    }
}
