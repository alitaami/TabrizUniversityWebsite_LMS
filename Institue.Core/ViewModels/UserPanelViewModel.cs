using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Institue.Core.ViewModels
{

    public class EditProfileViewModel
    {

        public string Email { get; set; }
        public string AvatarName { get; set; }
        public IFormFile UserAvatar { get; set; }
        public string OldPassword { get; set; }
        public string Password { get; set; }
    [Compare("Password")]
        public string RePassword { get; set; }

    }


}
