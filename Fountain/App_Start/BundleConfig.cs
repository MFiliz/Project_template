using System.Web.Optimization;

namespace Fountain
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //Layout İçin Script
            bundles.Add(new ScriptBundle("~/bundles/LayoutScripts").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/modernizr-*",
                "~/Scripts/jquery.validate*",
                "~/Scripts/jquery-ui-{version}.js",
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/jquery.inputmask/jquery.inputmask.js"
                ));

            //Her sayfa için Özel kullanılacak Scriptler. Birden fazla yaratılabilir.
            //bundles.Add(new ScriptBundle("~/bundles/LayoutScripts").Include(
            //           "~/Scripts/jquery-{version}.js",
            //           "~/Scripts/modernizr-*",
            //           "~/Scripts/jquery.validate*",
            //           "~/Scripts/jquery-ui-{version}.js"
            //           ));


            //Layout için tüm sitede kullanılacak stiller
            bundles.Add(new StyleBundle("~/Content/LayoutStyles").Include(
                "~/Content/normalize.css"));

            //Her sayfaya özel olarak kullanılacak stiller. Birden fazla yaratılabilir.
            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //    "~/Content/site.css"));

        }
    }
}