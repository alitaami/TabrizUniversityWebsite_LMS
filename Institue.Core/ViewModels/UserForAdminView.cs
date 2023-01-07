using Institue.DataLayer.Entities.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Institue.Core.ViewModels
{
    public class USerForAdminViewModel
    {
        public List<User> Users { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }


    }

    public class CreateUsersViewModel
    {
        public int UserID { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Username { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string firstname { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Email { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Password { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime Birthdate { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string phonenumber { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string homenumber { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Address { get; set; }
 

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime UniversitysignDate { get; set; }
         public bool IsTeacher { get; set; }

         public string studentnumber { get; set; }
         public string Teachernumber { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string degree { get; set; }
         public bool IsActive { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
 

        public bool IsDelete { get; set; }

        public IFormFile UserAvatar { get; set; }

    }
    public class EditUsersViewModel
    {
        public int UserID { get; set; }
        
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Username { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string firstname { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Email { get; set; }
         public string Password { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime Birthdate { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string phonenumber { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string homenumber { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Address { get; set; }

 

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime UniversitysignDate { get; set; }
        public bool IsTeacher { get; set; }

        public string studentnumber { get; set; }
        public string Teachernumber { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string degree { get; set; }
        public bool IsActive { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]


        public bool IsDelete { get; set; }

        public IFormFile UserAvatar { get; set; }
        public string UserAvatarName { get; set; }
        public List<int> UserRoles { get; set; }
        public int UserMajors { get; set; }

    }

}

