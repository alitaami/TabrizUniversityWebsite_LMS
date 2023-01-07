using Institue.Core.Services.Interface;
using Institue.Core.ViewModels;
using Institue.DataLayer.Entities.User;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InstitueProject.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _user;
        private IPermissionService _per;
        public AccountController(IUserService user,IPermissionService per)
        {
            _user = user;
            _per = per;
        }
         
        public IActionResult Login()
        {
            return View();
        }
      
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = _user.LoginUser(login);
            if (user != null)
            {
           
                if (user.IsActive && !user.IsDelete  )
                {
                    var Claims = new List<Claim>()
                        {
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                        new Claim(ClaimTypes.Name,user.UserName)
                        };
                    var identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = login.RememberMe
                    };
                    HttpContext.SignInAsync(principal, properties);
          
                    ViewBag.success = "S";

                       return View();

                


                }
                else
                {
                    ViewBag.e = "s";
                    return View();
                }
            }
            else
            {
                ViewBag.notfind = "s";
                return View(login);
            }


         


        }

         
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

    }
}
