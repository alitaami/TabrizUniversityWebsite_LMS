using Institue.DataLayer.Entities.Lesson;
using Institue.DataLayer.Entities.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Institue.Core.Services.Interface
{
   public interface ILessonService
    {
        #region lesson
        List<LessonMajors> GetLessons();
        List<LessonMajors> GetLessonsforcreateuser(int majorid);

        public Lesson Getlesson(int lessonId);
        bool CheckMajorsOflesson(List<int> SelectedMajors , List<int> SelectedLesson);
        int GetMajorIdofUser(int userid);
        void addUserToLesson(List<int> Selectedlesson,int userid);
        int AddLesson(Lesson lesson);
        void AddMajortoLesson(List<int> SelectedMajors, int lessonid);
        List<UserLesson> GetLessonsOfUser(int userid);
        List<int> UserLessons( int userid);
        void EditLessonUsers(List<int> selectedlessons, int userid);
        List<int> MajorsOfLesson(int lessonid);
        Lesson GetLessonByID(int id);
        void EditLessonMajors(List<int> selectedMajors, int lessonid);
        void UpdateLesson(Lesson lesson);
        List<LessonDetail> GetLessonDetail(int Lessonid, int userid);

        int AddLessonDetail(LessonDetail detail ,IFormFile lessonpdf, IFormFile lessonpractice, IFormFile lessonproject, IFormFile lessonvideo);
        LessonDetail GetLessonDetailById(int id);
        void EditLessonDetail(LessonDetail detail, IFormFile lessonpdf, IFormFile lessonpractice, IFormFile lessonproject, IFormFile lessonvideo);

        List<UserLesson> GetLessonsForUser(string username);

       List< LessonDetail> GetLessonForShow(int id);
        int AddLessonProject(LessonProject lp, IFormFile lessonproject, int userid );
        int AddLessonPractice(LessonPractice lp, IFormFile lessonpractice, int userid);
        List<LessonDetail> GetLessondetailForShow(int id);
        bool CheckStudentProjectUpload(int userid,int detailId);
        bool CheckStudentPracticeUpload(int userid, int detailId);
        List<LessonProject> GetLessonProjectsOfStudent(int userid, int detailId);
        List<LessonPractice> GetLessonPracticeOfStudent(int userid, int detailId);
        LessonProject GetLessonProjectById(int id);
        LessonPractice GetLessonPracticeById(int id);

        int  GetLessonId(int id);
    
        List<LessonProject> GetLessonProjectsforTeacher(int lessonid);
        List<LessonPractice> GetLessonPracticesforTeacher(int lessonid);
        LessonDetail lessonDetailById(int id);
        #endregion
    }
}
