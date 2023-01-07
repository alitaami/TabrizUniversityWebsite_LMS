using Institue.Core.Security;
using Institue.Core.Services.Interface;
using Institue.DataLayer.Entities.Lesson;
using InstitueProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InstitueProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUserService _user;
        private ILessonService _lesson;

        public HomeController(ILogger<HomeController> logger, IUserService user, ILessonService lesson)
        {
            _logger = logger;
            _user = user;
            _lesson = lesson;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        #region Lesson Project Practice 
        [PermissionChecker(3)]
        [Route("/Home/SendProject/{id}")]
        public IActionResult SendProject(int id)
        {
            int userid = _user.GetUserByUsername(User.Identity.Name).UserId;
            ViewData["Lesson"] = _lesson.GetLessondetailForShow(id);
            ViewData["LessonProject"] = _lesson.GetLessonProjectsOfStudent(userid, id);
            return View();
        }
        [PermissionChecker(3)]
        [Route("/Home/SendProject/{id}")]
        [HttpPost]
        public IActionResult SendProject(LessonProject lp, IFormFile lessonproject, int id)
        {
            ViewData["Lesson"] = _lesson.GetLessondetailForShow(id);
            lp.LessonDetailId = id;

            int userid = _user.GetUserByUsername(User.Identity.Name).UserId;
            int lessonId = _lesson.GetLessonId(id); lp.LessonId = lessonId;
            lp.LessonProjectDescription = _lesson.lessonDetailById(id).LessonProjectFileDescription;
            _lesson.AddLessonProject(lp, lessonproject, userid);


            return Redirect("/Home/ShowLesson/" + lessonId);

        }
        [PermissionChecker(3)]
        [Route("/Home/SendPractice/{id}")]
        public IActionResult SendPractice(int id)
        {

            int userid = _user.GetUserByUsername(User.Identity.Name).UserId;
            ViewData["LessonPractice"] = _lesson.GetLessonPracticeOfStudent(userid, id);
            ViewData["Lesson"] = _lesson.GetLessondetailForShow(id);


            return View();
        }

        [PermissionChecker(3)]
        [Route("/Home/SendPractice/{id}")]
        [HttpPost]
        public IActionResult SendPractice(LessonPractice lp, IFormFile lessonpractice, int id)
        {
            lp.LessonDetailId = id;
            ViewData["Lesson"] = _lesson.GetLessondetailForShow(id);
            int userid = _user.GetUserByUsername(User.Identity.Name).UserId;
            int lessonId = _lesson.GetLessonId(id);
            lp.LessonId = lessonId;
            lp.LessonPracticeDescription = _lesson.lessonDetailById(id).LessonPracticeFileDescription;
            _lesson.AddLessonPractice(lp, lessonpractice, userid);

            return Redirect("/Home/ShowLesson/" + lessonId);
        }

        [PermissionChecker(3)]
        [Route("/Home/ShowLesson/{id}")]
        public IActionResult ShowLesson(int id)
        {
            ViewData["Lesson"] = _lesson.GetLessonForShow(id);
            return View();
        }

        #endregion

        #region Downloads
        [PermissionChecker(3)]
        [Route("DownloadProject/{detailId}")]
        public IActionResult DownloadProject(int detailId)
        {
            var detail = _lesson.GetLessonDetailById(detailId);
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Teacher/lessonproject",
                detail.LessonProjectFile);
            string fileName = detail.LessonProjectFile;

            if (User.Identity.IsAuthenticated && filepath != null)
            {

                byte[] file = System.IO.File.ReadAllBytes(filepath);
                return File(file, "application/force-download", fileName);

            }

            return Forbid();
        }
        [PermissionChecker(3)]
        [Route("DownloadPractice/{detailId}")]
        public IActionResult DownloadPractice(int detailId)
        {
            var detail = _lesson.GetLessonDetailById(detailId);
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Teacher/lessonpractice",
                detail.LessonPracticeFile);
            string fileName = detail.LessonPracticeFile;

            if (User.Identity.IsAuthenticated && filepath != null)
            {

                byte[] file = System.IO.File.ReadAllBytes(filepath);
                return File(file, "application/force-download", fileName);

            }

            return Forbid();
        }
 
        [Route("DownloadPROS/{LPId}")]
        public IActionResult DownloadPROS(int LPId)
        {
            var detail = _lesson.GetLessonPracticeById(LPId);
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Teacher/StudentPractices",
                detail.LessonPracticeFile);
            string fileName = detail.LessonPracticeFile;

            if (User.Identity.IsAuthenticated && filepath != null)
            {

                byte[] file = System.IO.File.ReadAllBytes(filepath);
                return File(file, "application/force-download", fileName);

            }

            return Forbid();
        }
 
        [Route("DownloadPOS/{LPId}")]
        public IActionResult DownloadPOS(int LPId)
        {
            var detail = _lesson.GetLessonProjectById(LPId);
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Teacher/StudentProjects",
                detail.LessonProjectFile);
            string fileName = detail.LessonProjectFile;

            if (User.Identity.IsAuthenticated && filepath != null)
            {

                byte[] file = System.IO.File.ReadAllBytes(filepath);
                return File(file, "application/force-download", fileName);

            }

            return Forbid();
        }
        [PermissionChecker(3)]
        [Route("DownloadFile/{detailId}")]
        public IActionResult DownloadFile(int detailId)
        {
            var detail = _lesson.GetLessonDetailById(detailId);
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Teacher/lessonpdf",
                detail.LessonPdfFile);
            string fileName = detail.LessonPdfFile;

            if (User.Identity.IsAuthenticated && filepath != null)
            {

                byte[] file = System.IO.File.ReadAllBytes(filepath);
                return File(file, "application/force-download", fileName);

            }

            return Forbid();
        }
        [PermissionChecker(3)]
        [Route("DownloadVideo/{detailId}")]
        public IActionResult DownloadVideo(int detailId)
        {
            var detail = _lesson.GetLessonDetailById(detailId);
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Teacher/lessonvideo",
                detail.LessonVideoFile);
            string fileName = detail.LessonVideoFile;

            if (User.Identity.IsAuthenticated && filepath != null)
            {

                byte[] file = System.IO.File.ReadAllBytes(filepath);
                return File(file, "application/force-download", fileName);

            }

            return Forbid();
        }



        #endregion


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
