using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Fountain.DTO.Login;
using Fountain.Helper;
using Fountain.Repository.IOC;
using Fountain.Repository.RepositoryClasses;
using Fountain.Security;
using Microsoft.Owin.Security;
using Fountain.Core.Logger;

namespace Fountain.Controllers
{
    public class LoginController : SecurityController
    {
        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult GetLoginPartial()
        {
            return PartialView("_LoginPartial");
        }

        [AllowAnonymous]
        public ActionResult GetForgotPasswordPartial()
        {
            return PartialView("_ForgotPasswordPartial");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                var user = Repositories.LoginRepository.LoginUser(loginDto);
                Logger.Debug("Login Mehodu Çalıştı"+loginDto.EMail);
                if (user != null)
                {
                    Logger.Debug("Kullanıcı Login Oldu" + loginDto.EMail);
                    var identity = new ClaimsIdentity(new[]
                    {
                        new Claim(ClaimTypes.Email, user.EMail),
                        new Claim(ClaimTypes.Name, user.FullName),
                        new Claim("Id", user.Id.ToString(CultureInfo.InvariantCulture)),
                        new Claim("SellerId", user.SellerId.ToString(CultureInfo.InvariantCulture)),
                    }, "ApplicationCookie");
                    foreach (var role in user.Roles)
                    {
                        identity.AddClaim(new Claim(ClaimTypes.Role, role));
                    }
                    //Identity Login işlemi için Context alındı
                    Request.GetOwinContext().Authentication.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true //LoginDto.RememberMe,
                    }, identity);

                    if (user.IsFirstLogin)
                    {
                        Logger.Debug("Kullanıcı İlk Defa Login Oldu" + loginDto.EMail);
                        return Json(new {url = "../ChangePassword/Index"});
                    }
                    Logger.Debug("Kullanıcı İlgili Sayfaya Yönlendiriliyor" + loginDto.EMail);
                    return Json(new {url = "../Home/Index"});
                }

                return PartialView("_LoginPartial", loginDto);
            }
            return PartialView("_LoginPartial", loginDto);
        }

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Login");
        }


        public ActionResult Chart()
        {
            return View();
        }

        public PartialViewResult GetMenu()
        {
            var principal = ClaimsPrincipal.Current;
            var dto = new MenuDto();
            dto.Roles = principal.Claims.Where(x => x.Type == ClaimTypes.Role).Select(e => e.Value).Distinct().ToList();
           
            return PartialView("_MenuPartial", dto);
        }

        public int GetTicketCount()
        {
            return -1;
        }

        public PartialViewResult GetTicketCountForOperation()
        {
            
            var principal = ClaimsPrincipal.Current;
            if ( principal.Claims.Where(x => x.Type == ClaimTypes.Role).Select(e => e.Value).ToList().Contains(RoleHelper.Operasyon))
            {
                return PartialView("_OperationTicketNotificationPartial",
                    null);
                
            }

            return null;
            

        }

       
    }
}