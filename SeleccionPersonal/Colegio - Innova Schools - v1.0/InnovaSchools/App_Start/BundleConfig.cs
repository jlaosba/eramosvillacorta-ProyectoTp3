using System.Web;
using System.Web.Optimization;

namespace InnovaSchools
{
    public class BundleConfig
    {
        // Para obtener más información acerca de Bundling, consulte http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bootstrap/js").Include(
                        "~/Scripts/site.js"));

            bundles.Add(new ScriptBundle("~/bootstrap/bootstrap-datetimepicker").Include(
                        "~/Scripts/moment.js",
                        "~/Scripts/moment-with-locales.js",
                        "~/Scripts/bootstrap-datetimepicker.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                       "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootstrap-dialog.min.js",
                      "~/Scripts/bootbox.js"));

            bundles.Add(new StyleBundle("~/bootstrap/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap-datetimepicker.css",
                        "~/Content/bootstrap-dialog.min.css",
                        "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/unobtrusiveajax")
            .Include("~/Scripts/jquery.unobtrusive-ajax.js",
            "~/Scripts/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/bundles/cascadingdropdown").
                Include("~/Scripts/app/jquery.cascadingdropdown.js")
                .Include("~/Scripts/app/cascadingdropdown.js"));


            BundleTable.EnableOptimizations = true;




        }
    }
}