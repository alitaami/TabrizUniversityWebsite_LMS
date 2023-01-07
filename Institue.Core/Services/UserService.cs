using Institue.Core.Convertors;
using Institue.Core.Generator;
using Institue.Core.Services.Interface;
using Institue.Core.ViewModels;
using Institue.DataLayer.Context;
using Institue.DataLayer.Entities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Toplearn.Core.Security;

namespace Institue.Core.Services
{
    public class UserService : IUserService
    {
        InstitueContext _context;
        public UserService(InstitueContext context)
        {
            _context = context;
        }

        public void AddMajorToUser(List<int> SelectedMajors, int userid)
        {
            foreach (var major in SelectedMajors)
            {
                _context.Add(new UserMajors
                {

                    MajorId = major,
                    UserId = userid

                });


            }
            _context.SaveChanges();
        }

        public int AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.UserId;
        }

        public int AddUserFromAdmin(CreateUsersViewModel u)
        {

            string Password = PasswordHelper.EncodePasswordMd5(u.Password);
            User user = new User();

            user.UserId = u.UserID;
            user.UserName = u.Username;
            user.FirstName = u.firstname;
            user.LastName = u.Lastname;
            user.Email = u.Email;

            user.HomeNumber = u.homenumber;
            user.PhoneNumber = u.phonenumber;
            user.Address = u.Address;
            user.Degree = u.degree;
            user.BirthDate = u.Birthdate.Date;
            user.IsActive = u.IsActive;
            user.IsDelete = u.IsDelete;
            user.IsTeacher = u.IsTeacher;
            user.Password = Password;

            user.StudentNumber = u.studentnumber;
            user.TeacherNumber = u.Teachernumber;
            user.UniversitySignDate = u.UniversitysignDate.Date;
            user.RegistersDate = DateTime.Now.Date;



            #region save avatar  
            if (u.UserAvatar != null)
            {
                string imagePath = "";


                user.UserAvatarName = NameGenerator.GenerateUniqueCode() + Path.GetExtension(u.UserAvatar.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", user.UserAvatarName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    u.UserAvatar.CopyTo(stream);
                }

            }
            #endregion
            if (user.UserAvatarName == null)
            {
                user.UserAvatarName = "defaultavatar.jpg";
            }
            return AddUser(user);
        }



        public User GetInfoByUsername(string username)
        {
            return _context.Users.SingleOrDefault(u => u.UserName == username);
        }

        public Major GetMajorName(int id)
        {
            return _context.UserMajors.Include(u => u.Major).FirstOrDefault(u => u.UserId == id).Major;
        }

        public List<Major> GetMajors()
        {
            return _context.Majors.Where(m => !m.IsDelete).ToList();
        }

        public USerForAdminViewModel GetTeachers(int pageId = 1, string TNumber = "", string lastname = "")
        {
            IQueryable<User> result = _context.Users.Where(u => u.IsTeacher && !u.IsDelete);

            if (!string.IsNullOrEmpty(lastname))
            {
                result = result.Where(r => r.LastName.Contains(lastname));
            }
            if (!string.IsNullOrEmpty(TNumber))
            {
                result = result.Where(r => r.TeacherNumber.Contains(TNumber));

            }
            int take = 10;
            int skip = (pageId - 1) * take;
            USerForAdminViewModel list = new USerForAdminViewModel();
            list.CurrentPage = pageId;
            list.PageCount = result.Count() / take;
            list.Users = result.OrderBy(u => u.RegistersDate).Skip(skip).Take(take).ToList();
            return list;
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public bool IsEmailExist(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool IsUserExist(string StNumber, string TNumber, string name)
        {

            return _context.Users.Any(u => u.StudentNumber == StNumber || u.TeacherNumber == TNumber && u.FirstName + "" + u.LastName == name);
        }

        public bool IsUserNameExist(string username)
        {
            return _context.Users.Any(u => u.UserName == username);
        }
        public List<SelectListItem> GetMajorsForEdit()
        {
            return _context.Majors.Select(s => new SelectListItem
            {
                Value = s.MajorId.ToString(),
                Text = s.MajorTitle
            }).ToList();
        }
        public User LoginUser(LoginViewModel login)
        {
            string username = FixedText.FixUsername(login.Username);
            string hashpassword = PasswordHelper.EncodePasswordMd5(login.Password);

            return _context.Users.SingleOrDefault(u => u.Password == hashpassword && u.UserName == username);

        }

        USerForAdminViewModel IUserService.GetUsers(int pageId = 1, string StNumber = "", string lastname = "")
        {
            IQueryable<User> result = _context.Users.Where(u => !u.IsDelete);

            if (!string.IsNullOrEmpty(lastname))
            {
                result = result.Where(r => r.LastName.Contains(lastname));
            }
            if (!string.IsNullOrEmpty(StNumber))
            {
                result = result.Where(r => r.StudentNumber.Contains(StNumber));

            }
            int take = 10;
            int skip = (pageId - 1) * take;
            USerForAdminViewModel list = new USerForAdminViewModel();
            list.CurrentPage = pageId;
            list.PageCount = result.Count() / take;
            list.Users = result.OrderBy(u => u.RegistersDate).Skip(skip).Take(take).ToList();
            return list;
        }

        public List<int> GetRolesIdFromUSerRoles(int userId)
        {
            return _context.UserRoles.Where(u => u.UserId == userId).Select(u => u.RoleId).ToList();
        }

        public EditUsersViewModel GetUserforShowInEditMode(int id)
        {
            return _context.Users.Where(e => e.UserId == id).Select(e => new EditUsersViewModel()
            {


                UserID = e.UserId,
                Username = e.UserName,
                firstname = e.FirstName,
                Lastname = e.LastName,
                Email = e.Email,
                UserAvatarName = e.UserAvatarName,
                homenumber = e.HomeNumber,
                phonenumber = e.PhoneNumber,
                Address = e.Address,
                degree = e.Degree,
                Birthdate = e.BirthDate,
                IsActive = e.IsActive,
                IsDelete = e.IsDelete,
                IsTeacher = e.IsTeacher,

                UserMajors = e.UserMajors.Select(u => u.MajorId).FirstOrDefault(),
                studentnumber = e.StudentNumber,
                Teachernumber = e.TeacherNumber,
                UniversitysignDate = e.UniversitySignDate,
                UserRoles = e.UserRoles.Select(ur => ur.RoleId).ToList()


            }).Single();
        }

        public void EditUserForAdmin(EditUsersViewModel editUser)
        {
            User user = GetUserById(editUser.UserID);

            user.UserName = editUser.Username;
            user.FirstName = editUser.firstname;
            user.LastName = editUser.Lastname;
            user.Email = editUser.Email;

            user.HomeNumber = editUser.homenumber;
            user.PhoneNumber = editUser.phonenumber;
            user.Address = editUser.Address;
            user.Degree = editUser.degree;
            user.BirthDate = editUser.Birthdate;
            user.IsActive = editUser.IsActive;
            user.IsDelete = editUser.IsDelete;
            user.IsTeacher = editUser.IsTeacher;

            user.StudentNumber = editUser.studentnumber;
            user.TeacherNumber = editUser.Teachernumber;
            user.UniversitySignDate = editUser.UniversitysignDate;


            if (!string.IsNullOrEmpty(editUser.Password))
            {
                user.Password = PasswordHelper.EncodePasswordMd5(editUser.Password);
            }

            if (editUser.UserAvatar != null)
            {
                //delete old image
                if (editUser.UserAvatarName != "defaultavatar.jpg")
                {
                    string deletePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", editUser.UserAvatarName);
                    if (File.Exists(deletePath))
                    {
                        File.Delete(deletePath);
                    }
                }
                // Save new image
                string imagePath = "";
                user.UserAvatarName = NameGenerator.GenerateUniqueCode() + Path.GetExtension(editUser.UserAvatar.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", user.UserAvatarName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    editUser.UserAvatar.CopyTo(stream);
                }
            }
            UpdateUser(user);

        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void EditMajorsToUser(List<int> SelectedMajors, int userid)
        {
            //remove
            _context.UserMajors.Where(u => u.UserId == userid).ToList().ForEach(u => _context.UserMajors.Remove(u));

            //add new majors to user
            AddMajorToUser(SelectedMajors, userid);
        }

        public List<SelectListItem> getMajorForManage(int majorId, int userid)
        {
            //return _context.UserMajors.Where(u => u.MajorId == majorId && u.UserId==userid).Select(u => new SelectListItem() {
            //    Value = u.MajorId.ToString(),
            //    Text = u.Major.MajorTitle

            //}).ToList() ;

            return _context.Majors.Where(m => !m.IsDelete).Include(u => u.UserMajors).Select(u => new SelectListItem()
            {
                Value = u.MajorId.ToString(),
                Text = u.MajorTitle

            }).ToList();
        }

        public USerForAdminViewModel GetDeletedUsers(int pageId = 1, string StNumber = "", string TNumber = "", string lastname = "")
        {
            IQueryable<User> result = _context.Users.Where(u => u.IsDelete);

            if (!string.IsNullOrEmpty(lastname))
            {
                result = result.Where(r => r.LastName.Contains(lastname));
            }
            if (!string.IsNullOrEmpty(StNumber))
            {
                result = result.Where(r => r.TeacherNumber.Contains(StNumber));

            }
            if (!string.IsNullOrEmpty(TNumber))
            {
                result = result.Where(r => r.TeacherNumber.Contains(TNumber));

            }
            int take = 10;
            int skip = (pageId - 1) * take;
            USerForAdminViewModel list = new USerForAdminViewModel();
            list.CurrentPage = pageId;
            list.PageCount = result.Count() / take;
            list.Users = result.OrderBy(u => u.RegistersDate).Skip(skip).Take(take).ToList();
            return list;
        }

        public void AddMajor(Major major)
        {
            _context.Majors.Add(major);
            _context.SaveChanges();
        }

        public Major GetMajorById(int id)
        {
            return _context.Majors.Find(id);
        }

        public void UpdateMajor(Major major)
        {
            _context.Majors.Update(major);
            _context.SaveChanges();
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.SingleOrDefault(u => u.UserName == username);
        }

        public User GetUserInformation(string username)
        {
            return _context.Users.SingleOrDefault(u => u.UserName == username);
        }

        public Major GetMajorByMajorId(string username)
        {
            var userid = GetUserByUsername(username).UserId;

            int majorid = _context.UserMajors.FirstOrDefault(u => u.UserId == userid).MajorId;
            return _context.Majors.Where(m => m.MajorId == majorid).Single();


        }
        public EditProfileViewModel GetDataForEdit(string username)
        {
            return _context.Users.Where(u => u.UserName == username).Select(u => new EditProfileViewModel
            {

                Email = u.Email,
                AvatarName = u.UserAvatarName


            }).Single();
        }
        public void EditProfile(string username, EditProfileViewModel profile)
        {

            if (profile.UserAvatar != null)
            {


                string imagePath = "";
                if (profile.AvatarName != "defaultavatar.jpg")
                {
                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", profile.AvatarName);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }

                profile.AvatarName = NameGenerator.GenerateUniqueCode() + Path.GetExtension(profile.UserAvatar.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", profile.AvatarName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    profile.UserAvatar.CopyTo(stream);
                }
            }
            var User = GetUserInformation(username);

            if (profile.AvatarName != null)
            {
                User.UserAvatarName = profile.AvatarName;

            }
            if (profile.Email != null)
            {
                User.Email = profile.Email;

            }
            if (profile.Password != null)
            {
                var hashnewpassword = PasswordHelper.EncodePasswordMd5(profile.Password);
                User.Password = hashnewpassword;

            }


            UpdateUser(User);



        }
        public bool CompareOldPass(string username, string oldpassword)
        {
            string hashold = PasswordHelper.EncodePasswordMd5(oldpassword);
            return _context.Users.Any(u => u.UserName == username && u.Password == hashold);
        }


    }
}
