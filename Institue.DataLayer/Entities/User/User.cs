using Institue.DataLayer.Entities.Lesson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Institue.DataLayer.Entities.User
{
    public class User
    {
        public User()
        {

        }
        [Key]
        public int UserId { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string UserName { get; set; }
        [Display(Name = "نام ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]

        public string FirstName { get; set; }
        [Display(Name = "نام خانوادگی ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string LastName { get; set; }
        [Display(Name = "ایمیل")]
         [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده نامعتبر است")]
        public string Email { get; set; }

        [Display(Name = "رمزعبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string Password { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]

        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(11, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]

        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(11, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]


        public string HomeNumber { get; set; }
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]


        public string Address { get; set; }
  
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public DateTime UniversitySignDate { get; set; }

        public string StudentNumber { get; set; }
        

        public bool IsTeacher { get; set; }
        public string TeacherNumber { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Degree { get; set; }


        [Display(Name = "وضعیت")]
        public bool IsActive { get; set; }

        [Display(Name = "آواتار")]
        [MaxLength(200, ErrorMessage = "{0} نمیتواند بیشتر از {1} کاراکتر باشد")]
        public string UserAvatarName { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        public DateTime RegistersDate { get; set; }

        public bool IsDelete { get; set; }
      
        #region relation
        [ForeignKey("MajorId")]
        
        public List<UserLesson> UserLessons { get; set; }
        public List<UserMajors> UserMajors { get; set; }
        public virtual List<UserRole> UserRoles { get; set; }

        #endregion

    }
}
