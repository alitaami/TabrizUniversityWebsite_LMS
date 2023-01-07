using Institue.Core.ViewModels;
using Institue.DataLayer.Entities.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Institue.Core.Services.Interface
{
    public interface IUserService
    {
        #region Account
        bool IsUserNameExist(string username);
        bool IsEmailExist(string email);
        bool IsUserExist(string StNumber,string TNumber,string name);
        int AddUser(User user);
        User LoginUser(ViewModels.LoginViewModel login);
        User GetInfoByUsername(string username);

        #endregion

        #region AdminPanel
       USerForAdminViewModel GetUsers(int pageId = 1, string StNumber = "", string lastname = "");
        USerForAdminViewModel GetTeachers(int pageId = 1, string TNumber = "", string lastname = "");
        USerForAdminViewModel GetDeletedUsers(int pageId = 1, string StNumber = "", string TNumber = "", string lastname = "");
        void AddMajorToUser(List<int> SelectedMajors, int userid);
        Major GetMajorName(int id);
        List<Major> GetMajors();
         int AddUserFromAdmin(CreateUsersViewModel user);
        User GetUserById(int id);
        List<int> GetRolesIdFromUSerRoles(int userId);
       List<SelectListItem> GetMajorsForEdit();
        EditUsersViewModel GetUserforShowInEditMode(int id);
        void EditUserForAdmin(EditUsersViewModel editUser);
        void UpdateUser(User user);
        void EditMajorsToUser(List<int>SelectedMajors,int userid);
        List<SelectListItem> getMajorForManage(int majorId, int userid);
        void AddMajor(Major major);
        Major GetMajorById(int id);
        void UpdateMajor(Major major);

        User GetUserByUsername(string username);

        User GetUserInformation(string username);
        Major GetMajorByMajorId( string username);
        void EditProfile(string username, EditProfileViewModel profile);
        public bool CompareOldPass(string username, string oldpassword);
        public EditProfileViewModel GetDataForEdit(string username);
       

        #endregion
    }
}
