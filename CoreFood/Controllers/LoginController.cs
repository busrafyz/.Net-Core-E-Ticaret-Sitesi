using CoreFood.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreFood.Controllers
{
    public class LoginController : Controller
    {
        Context context = new Context();
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(Admin admin)
        {
            var value = context.Admins.FirstOrDefault(x => x.Password == admin.Password && x.UserName == admin.UserName);
            if (value != null)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, admin.UserName) };
                var useridendity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridendity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
    }
}
