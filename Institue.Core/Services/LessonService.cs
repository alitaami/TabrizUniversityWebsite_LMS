using Institue.Core.Generator;
using Institue.Core.Services.Interface;
using Institue.DataLayer.Entities.Lesson;
using Institue.DataLayer.Entities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Institue.Core.Services
{
    public class LessonService : ILessonService
    {
        DataLayer.Context.InstitueContext _context;
        IUserService _user;
        public LessonService(DataLayer.Context.InstitueContext context, IUserService user)
        {
            _context = context;
            _user = user;

        }

        public int AddLesson(Lesson lesson)
        {
            _context.Lessons.Add(lesson);
            _context.SaveChanges();
            return lesson.LessonId;
        }

        public void AddMajortoLesson(List<int> SelectedMajors, int lessonid)
        {
            foreach (var l in SelectedMajors)
            {
                _context.LessonMajors.Add(new LessonMajors()
                {

                    LessonId = lessonid,
                    MajorId = l

                });

            }
            _context.SaveChanges();
        }

        public List<LessonMajors> GetLessons()
        {
            return _context.LessonMajors.Where(l => !l.Lesson.IsDelete).Include(u => u.Major).ToList();
        }

        public Lesson Getlesson(int lessonId)
        {
            return _context.Lessons.Find(lessonId);
        }

        public List<LessonMajors> GetLessonsforcreateuser(int majorid)
        {
            return _context.LessonMajors.Where(l => l.MajorId == majorid).Include(l => l.Lesson).ToList();

        }

        public bool CheckMajorsOflesson(List<int> SelectedMajors, List<int> SelectedLesson)
        {
            throw new NotImplementedException();
        }

        public int GetMajorIdofUser(int userid)

        {


            return _context.UserMajors.FirstOrDefault(u => u.UserId == userid).MajorId;
        }

        public void addUserToLesson(List<int> Selectedlesson, int userid)
        {
            foreach (int l in Selectedlesson)
            {
                _context.UserLessons.Add(new UserLesson()
                {
                    UserId = userid,
                    LessonId = l

                });

            }
            _context.SaveChanges();
        }

        public List<UserLesson> GetLessonsOfUser(int userid)
        {
            return _context.UserLessons.Where(u => u.UserId == userid).Include(l => l.Lesson).Where(l => !l.Lesson.IsDelete).ToList();
        }

        public List<int> UserLessons(int userid)
        {
            return _context.UserLessons.Where(u => u.UserId == userid).Select(u => u.LessonId).ToList();
        }

        public void EditLessonUsers(List<int> selectedlessons, int userid)
        {
            _context.UserLessons.Where(u => u.UserId == userid).ToList().ForEach(u => _context.UserLessons.Remove(u));
            //add new roles
            addUserToLesson(selectedlessons, userid);
        }

        public List<int> MajorsOfLesson(int lessonid)
        {
            return _context.LessonMajors.Where(l => l.LessonId == lessonid).Select(l => l.MajorId).ToList();
        }

        public Lesson GetLessonByID(int id)
        {
            return _context.Lessons.Find(id);
        }

        public void EditLessonMajors(List<int> selectedMajors, int lessonid)
        {
            _context.LessonMajors.Where(u => u.LessonId == lessonid).ToList().ForEach(u => _context.LessonMajors.Remove(u));
            //add new roles
            AddMajortoLesson(selectedMajors, lessonid);


        }

        public void UpdateLesson(Lesson lesson)
        {
            _context.Lessons.Update(lesson);
            _context.SaveChanges();
        }

        public List<LessonDetail> GetLessonDetail(int Lessonid, int userid)
        {
            return _context.LessonDetails.Where(l => l.LessonId == Lessonid && l.UserId == userid).Include(l => l.Lesson).ToList();

        }

        public int AddLessonDetail(LessonDetail detail, IFormFile lessonpdf, IFormFile lessonpractice, IFormFile lessonproject, IFormFile lessonvideo)
        {
            if (lessonpdf != null)
            {
                detail.LessonPdfFile = NameGenerator.GenerateUniqueCode() + Path.GetExtension (lessonpdf.FileName);
                string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Teacher/lessonpdf", detail.LessonPdfFile);
                using (var stream = new FileStream(FilePath, FileMode.Create))
                {
                    lessonpdf.CopyTo(stream);
                }
            }
            if (lessonvideo != null)
            {

                detail.LessonVideoFile = NameGenerator.GenerateUniqueCode() + Path.GetExtension (lessonvideo.FileName);
                string FilePath3 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Teacher/lessonvideo", detail.LessonVideoFile);
                using (var stream = new FileStream(FilePath3, FileMode.Create))
                {
                    lessonvideo.CopyTo(stream);
                }

            }
            if (lessonproject != null)
            {

                detail.LessonProjectFile = NameGenerator.GenerateUniqueCode() + Path.GetExtension (lessonproject.FileName);
                string FilePath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Teacher/lessonproject", detail.LessonProjectFile);
                using (var stream = new FileStream(FilePath2, FileMode.Create))
                {
                    lessonproject.CopyTo(stream);
                }
            }
            if (lessonpractice != null)
            {

                detail.LessonPracticeFile = NameGenerator.GenerateUniqueCode() + Path.GetExtension ( lessonpractice.FileName);
                string FilePath1 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Teacher/lessonpractice", detail.LessonPracticeFile);
                using (var stream = new FileStream(FilePath1, FileMode.Create))
                {
                    lessonpractice.CopyTo(stream);
                }
            }


            _context.LessonDetails.Add(detail);
            _context.SaveChanges();
            return detail.LessonId;
        }

        public LessonDetail GetLessonDetailById(int id)
        {
            return _context.LessonDetails.Find(id);
        }

        public void EditLessonDetail(LessonDetail detail, IFormFile lessonpdf, IFormFile lessonpractice, IFormFile lessonproject, IFormFile lessonvideo)
        {
 
            if (lessonpdf != null)
            {
                if (detail.LessonPdfFile != null)
                {
                    string ImageDeletepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Teacher/lessonpdf", detail.LessonPdfFile);
                    if (File.Exists(ImageDeletepath))
                    {
                        File.Delete(ImageDeletepath);
                    }
                }
                detail.LessonPdfFile = NameGenerator.GenerateUniqueCode() + Path.GetExtension(lessonpdf.FileName) ;

                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Teacher/lessonpdf", detail.LessonPdfFile);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    lessonpdf.CopyTo(stream);
                }

            }
            if (lessonpractice != null)
            {
                if (detail.LessonPracticeFile != null)
                {
                    string ImageDeletepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Teacher/lessonpractice", detail.LessonPracticeFile);
                    if (File.Exists(ImageDeletepath))
                    {
                        File.Delete(ImageDeletepath);
                    }
                }
                detail.LessonPracticeFile = NameGenerator.GenerateUniqueCode() + Path.GetExtension (lessonpractice.FileName);

                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Teacher/lessonpractice", detail.LessonPracticeFile);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    lessonpractice.CopyTo(stream);
                }

            }
            if (lessonproject != null)
            {
                if (detail.LessonProjectFile != null)
                {
                    string ImageDeletepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Teacher/lessonproject", detail.LessonProjectFile);
                    if (File.Exists(ImageDeletepath))
                    {
                        File.Delete(ImageDeletepath);
                    }
                }
                detail.LessonProjectFile = NameGenerator.GenerateUniqueCode() + Path.GetExtension(lessonproject.FileName);

                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Teacher/lessonproject", detail.LessonProjectFile);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    lessonproject.CopyTo(stream);
                }

            }
            if (lessonvideo != null)
            {
                if (detail.LessonVideoFile != null)
                {
                    string ImageDeletepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Teacher/lessonvideo", detail.LessonVideoFile);
                    if (File.Exists(ImageDeletepath))
                    {
                        File.Delete(ImageDeletepath);
                    }
                }
                detail.LessonVideoFile = NameGenerator.GenerateUniqueCode() + Path.GetExtension(lessonvideo.FileName);

                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Teacher/lessonvideo", detail.LessonVideoFile);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    lessonvideo.CopyTo(stream);
                }

            }
            _context.Update(detail);
            _context.SaveChanges();
        }

        public List<UserLesson> GetLessonsForUser(string username)
        {

            int userid = _user.GetUserByUsername(username).UserId;
            return _context.UserLessons.Where(u => u.UserId == userid).Include(u => u.Lesson).ToList();
        }

        public List<LessonDetail> GetLessonForShow(int id)
        {
            return _context.LessonDetails.Include(l => l.Lesson).Where(l => l.LessonId == id).ToList();
        }

        public int AddLessonProject(LessonProject lp,IFormFile lessonproject,int userid )
        {
            if (lessonproject != null)
            {
                lp.LessonProjectFile = NameGenerator.GenerateUniqueCode() + Path.GetExtension(lessonproject.FileName); 
                string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Teacher/StudentProjects", lp.LessonProjectFile);
                using (var stream = new FileStream(FilePath, FileMode.Create))
                {
                    lessonproject.CopyTo(stream);
                }
            }

            lp.UploadDate = DateTime.Now;
            lp.UserId = userid;
           

            _context.Add(lp);
            _context.SaveChanges();
            return lp.LessonProjectId;
        }

        public List<LessonDetail> GetLessondetailForShow(int id)
        {
            return _context.LessonDetails.Where(l => l.LessonDetailId == id).ToList();
        }

        public int AddLessonPractice(LessonPractice lp, IFormFile lessonpractice, int userid)
        {
            if (lessonpractice != null)
            {
                lp.LessonPracticeFile = NameGenerator.GenerateUniqueCode() + Path.GetExtension(lessonpractice.FileName);
                string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Teacher/StudentPractices", lp.LessonPracticeFile);
                using (var stream = new FileStream(FilePath, FileMode.Create))
                {
                    lessonpractice.CopyTo(stream);
                }
            }

            lp.UploadDate = DateTime.Now;
            lp.UserId = userid;


            _context.LessonPractice.Add(lp);
            _context.SaveChanges();
            return lp.LessonPracticeId;
        }

        public bool CheckStudentProjectUpload(int userid, int detailId)
        {
            return _context.LessonProject.Any(l => l.UserId == userid && l.LessonDetailId == detailId);
        }

        public bool CheckStudentPracticeUpload(int userid, int detailId)
        {
            return _context.LessonPractice.Any(l => l.UserId == userid && l.LessonDetailId == detailId);
        }

        public List<LessonProject> GetLessonProjectsOfStudent(int userid, int detailId)
        {

            return _context.LessonProject.Where(l => l.UserId == userid && l.LessonDetailId == detailId).ToList();     
        }

        public LessonProject GetLessonProjectById(int id)
        {
            return _context.LessonProject.Find(id);
        }

        public LessonPractice GetLessonPracticeById(int id)
        {
            return _context.LessonPractice.Find(id);
        }

        public List<LessonPractice> GetLessonPracticeOfStudent(int userid, int detailId)
        {
            return _context.LessonPractice.Where(l => l.UserId == userid && l.LessonDetailId == detailId).ToList();
        }

        public int   GetLessonId(int id)
        {
            return _context.LessonDetails.Where(d=>d.LessonDetailId==id).Include(l => l.Lesson).Select(l=>l.LessonId).Single();

        }

       

        public List<LessonProject> GetLessonProjectsforTeacher(int lessonid)
        {
            return _context.LessonProject.Where(l => l.LessonId == lessonid).ToList();
        }

        public List<LessonPractice> GetLessonPracticesforTeacher(int lessonid)
        {
            return _context.LessonPractice.Where(l => l.LessonId == lessonid).ToList();

        }

        public LessonDetail lessonDetailById(int id)
        {
            return _context.LessonDetails.Find(id);
        }
    }
}
