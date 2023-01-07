using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Institue.DataLayer.Entities.User
{
    public class UserMajors
    {
        [Key]
        public int MU_Id { get; set; }
        public int MajorId { get; set; }
        public int UserId { get; set; }

        #region relations
        public User User { get; set; }
        public Major Major { get; set; }
        #endregion
    }
}
