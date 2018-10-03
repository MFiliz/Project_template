using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Fountain.Security
{
    public class SecurityController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string User = !CurrentUser.Identity.IsAuthenticated ? "UnknowUser" : CurrentUser.FirstName;
            Fountain.Core.Logger.Logger.Debug(String.Format("OnActionExecuting - Controller Name:{0}, Action Name: {1}, User: {2}", filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, filterContext.ActionDescriptor.ActionName , User));
            base.OnActionExecuting(filterContext);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string User = !CurrentUser.Identity.IsAuthenticated ? "UnknowUser" : CurrentUser.FirstName;
            Fountain.Core.Logger.Logger.Debug(String.Format("OnActionExecuted - Controller Name:{0}, Action Name: {1}, User: {2} ", filterContext.ActionDescriptor.ControllerDescriptor.ControllerName, filterContext.ActionDescriptor.ActionName, User));
            base.OnActionExecuted(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            string User = !CurrentUser.Identity.IsAuthenticated ? "UnknowUser" : CurrentUser.FirstName;
            Fountain.Core.Logger.Logger.Debug("Hata Oluştu");
            Fountain.Core.Logger.Logger.Debug(string.Format("Hata Oluştu User:{0}",User));
            Fountain.Core.Logger.Logger.Error(filterContext.Exception.Message + filterContext.Exception.StackTrace);
            base.OnException(filterContext);
        }

        public AppUser CurrentUser
        {
            get { return new AppUser(this.User as ClaimsPrincipal); }
        }
       
        

        protected string RenderPartialViewToString()
        {
            return RenderPartialViewToString(null, null);
        }

        protected string RenderPartialViewToString(string viewName)
        {
            return RenderPartialViewToString(viewName, null);
        }

        protected string RenderPartialViewToString(object model)
        {
            return RenderPartialViewToString(null, model);
        }

        protected string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
    }
}