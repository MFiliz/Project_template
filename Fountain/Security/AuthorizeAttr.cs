using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using Fountain.Helper;
using Fountain.Core.Logger;

namespace Fountain.Security
{
    public class AuthorizeAttr : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            Logger.Debug("AuthorizeCore Başladı");
            var user = httpContext.User;
            //var claim = new ClaimsIdentity(user.Identity);
            var principal = ClaimsPrincipal.Current;
            var roles = principal.Claims.Where(x=>x.Type == ClaimTypes.Role).Select(e=> e.Value).ToList();
            if (Roles.Contains("Any") && user.Identity.IsAuthenticated)
            {
                return true;
            }
            foreach (var role in roles)
            {
                if (user.Identity.IsAuthenticated && Roles.Contains(role))
                {
                    return true;
                }
            }
           
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
                base.HandleUnauthorizedRequest(filterContext);
            else
            {
                filterContext.Result = new RedirectResult("/Error/Http404");
            }
        }
    }
}