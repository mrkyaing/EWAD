using CloudPOS.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CloudPOS.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult List()
        {
            IList<UserViewModel> users=_userManager.Users.Select(u=>new UserViewModel
            {
                UserName=u.UserName,
                Email=u.Email,
                Role=string.Join(",",_userManager.GetRolesAsync(u).Result.ToArray())
            }).ToList();
            return View(users);
        }
    }
}
