using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Fountain
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        //protected void Application_BeginRequest()
        //{
        //    if (Context.Request.IsLocal) return;
        //    if (!Context.Request.IsSecureConnection)
        //        Response.Redirect(Context.Request.Url.ToString().Replace("http:", "https:"));
        //}

        //protected void Application_Error()
        //{

        //    var exception = Server.GetLastError(); //Oluşan hatayı değişkene atadık.
        //    //Eğer hata kaydı (log) tutulacak ise gerekli kodlar buraya.
        //    var httpException = exception as HttpException;
        //    Response.Clear();
        //    Server.ClearError(); //Sunucudaki hatayı temizledik.
        //    Response.TrySkipIisCustomErrors = true; //IIS'in tipik hata sayfalarını görmezden geldik.
        //    var routeData = new RouteData();
        //    routeData.Values["controller"] = "Error"; //Hata mesajlarını yöneteceğimiz Controller ismi
        //    routeData.Values["action"] = "Index"; //Controller içindeki default Action ismi
        //    routeData.Values["exception"] = exception;
        //    Response.StatusCode = 500;

        //    if (httpException != null)
        //    {
        //        Response.StatusCode = httpException.GetHttpCode();

        //        switch (Response.StatusCode)
        //        {
        //            case 403: //Eğer 403 hatası meydana gelmiş ise Http403 Action'ı devreye girecek.
        //                routeData.Values["action"] = "Http403";
        //                break;

        //            case 404: //Eğer 404 hatası meydana gelmiş ise Http404 Action'ı devreye girecek.
        //                routeData.Values["action"] = "Http404";
        //                break;
        //        }
        //    }

        //    IController errorsController = new Controllers.ErrorController();
        //    var rc = new RequestContext(new HttpContextWrapper(Context), routeData);
        //    errorsController.Execute(rc);

        //}
    }
}