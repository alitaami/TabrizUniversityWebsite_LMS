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
    public class IndexProjectsModel : PageModel
    {
        ILessonService _lesson;
        IUserService _user;
        public IndexProjectsModel(ILessonService lesson, IUserService user)
        {
            _lesson = lesson;
            _user = user;

        }
        public List<LessonProject> lessonProject { get; set; }
        public void OnGet(int id)
        {
            lessonProject = _lesson.GetLessonProjectsforTeacher(id);
        }
    }
}
