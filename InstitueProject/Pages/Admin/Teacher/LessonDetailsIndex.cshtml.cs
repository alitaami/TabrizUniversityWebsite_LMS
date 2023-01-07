using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Institue.Core.Security;
using Institue.Core.Services.Interface;
using Institue.DataLayer.Entities.Lesson;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstitueProject.Pages.Admin.Teacher
{
    [PermissionChecker(2)]

    public class LessonDetailsIndexModel : PageModel
    {
        ILessonService _lesson;
        IUserService _user;
        public LessonDetailsIndexModel(ILessonService lesson,IUserService user)
        {
            _lesson = lesson;
            _user = user;

        }
        public List<LessonDetail> l { get; set; }
        public void OnGet(int id)
        {
            if (User.Identity.IsAuthenticated){

    int userid = _user.GetUserByUsername(User.Identity.Name).UserId;
            if (userid != null)
            {
                    ViewData["LessonId"] = id;
                    l = _lesson.GetLessonDetail(id, userid);

                  


            }
        
            }
        

        }
    }
}
