using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using Institue.Core.Services.Interface;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Institue.Core.Security
{
    public class PermissionCheckerAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        int _permissionId = 0;
        private IPermissionService _per;
        public PermissionCheckerAttribute (int permissionId)
        {
            _permissionId = permissionId;

        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _per =
                (IPermissionService)context.HttpContext.RequestServices.GetService(typeof(IPermissionService));
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                string username = context.HttpContext.User.Identity.Name;
                if (!_per.Checkpermission(_permissionId, username))
                { 
                    context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    context.Result = new RedirectResult("/?"+context.HttpContext.Request.Path);
                 }
                 
            }
            else
            {

            
                context.Result = new RedirectResult("/");
            }
        }
    }
}
