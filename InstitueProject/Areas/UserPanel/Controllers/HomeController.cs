using Institue.Core.Services.Interface;
using Institue.Core.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstitueProject.Areas.Controllers
{
    [Area("UserPanel")]
    [Authorize]
    public class HomeController : Controller
    {
        IUserService _user;
        ILessonService _lesson;
        public HomeController (IUserService user,ILessonService lesson)
        {
            _user = user;
            _lesson = lesson;
        }
        [Route("UserPanel/Index")]
         public IActionResult Index()
        {
            int userid = _user.GetUserByUsername(User.Identity.Name).UserId;
            ViewData["Lessons"] = _lesson.GetLessonsOfUser(userid);
            return View (_user.GetUserInformation(User.Identity.Name));
        }
        [Route("UserPanel/EditProfile")]
        public IActionResult EditProfile()
        {
            return View(_user.GetDataForEdit(User.Identity.Name));

        }

        [Route("UserPanel/EditProfile")]
        [HttpPost]
        public IActionResult EditProfile(EditProfileViewModel change)
        {
            if (!ModelState.IsValid)
                return View(change);

            var user = User.Identity.Name;
            if (change.OldPassword != null)
            {
                if (!_user.CompareOldPass(user, change.OldPassword))
                {
                    ViewBag.e = "s";
                    return View();

                }
            }
            _user.EditProfile(user, change);
            ViewBag.s = "sd";
            return RedirectToAction("Index");

        }

    }
}
