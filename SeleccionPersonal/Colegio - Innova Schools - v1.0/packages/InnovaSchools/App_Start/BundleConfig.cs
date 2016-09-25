using System.Web;
using System.Web.Optimization;

namespace InnovaSchools
{
    public class BundleConfig
    {
        // Para obtener más información acerca de Bundling, consulte http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //            "~/Scripts/jquery-ui-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.unobtrusive*",
            //            "~/Scripts/jquery.validate*"));

            //// Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios. De este modo, estará
            //// preparado para la producción y podrá utilizar la herramienta de creación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            //bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
            //            "~/Content/themes/base/jquery.ui.core.css",
            //            "~/Content/themes/base/jquery.ui.resizable.css",
            //            "~/Content/themes/base/jquery.ui.selectable.css",
            //            "~/Content/themes/base/jquery.ui.accordion.css",
            //            "~/Content/themes/base/jquery.ui.autocomplete.css",
            //            "~/Content/themes/base/jquery.ui.button.css",
            //            "~/Content/themes/base/jquery.ui.dialog.css",
            //            "~/Content/themes/base/jquery.ui.slider.css",
            //            "~/Content/themes/base/jquery.ui.tabs.css",
            //            "~/Content/themes/base/jquery.ui.datepicker.css",
            //            "~/Content/themes/base/jquery.ui.progressbar.css",
            //            "~/Content/themes/base/jquery.ui.theme.css"));

            //http://getbootstrap.com/css/

            //********************************************************************************************************************
            //********************************************************************************************************************
            //********************************************************************************************************************
            //bundles.Add(new ScriptBundle("~/bootstrap/js").Include(
            //            "~/Scripts/bootstrap.js", 
            //            "~/Scripts/bootbox.js",
            //            "~/Scripts/site.js"));

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
                        "~/Content/site.css",
                        "~/Content/justified-nav.css"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            ////bundles.Add(new ScriptBundle("~/bundles/knockout").Include("~/Scripts/knockout-{version}.js"));
            ////bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/unobtrusiveajax")
            .Include("~/Scripts/jquery.unobtrusive-ajax.js",
            "~/Scripts/jquery.validate.unobtrusive.js"));

            bundles.Add(new ScriptBundle("~/bundles/cascadingdropdown").
                Include("~/Scripts/app/jquery.cascadingdropdown.js")
                .Include("~/Scripts/app/cascadingdropdown.js"));


            //// MUC
            //bundles.Add(new ScriptBundle("~/bundles/generarRutas").Include(
            //            "~/Scripts/Views/GenerarRutas.js"));

            BundleTable.EnableOptimizations = true;
            //********************************************************************************************************************
            //********************************************************************************************************************
            //********************************************************************************************************************



            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js",
            //          "~/Scripts/bootstrap-dialog.min.js",
            //          "~/Scripts/bootbox.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/bootstrap-datetimepicker.css",
            //          "~/Content/bootstrap-dialog.min.css",
            //          "~/Content/site.css"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap-datetimepicker").Include(
            //          "~/Scripts/moment.js",
            //          "~/Scripts/moment-with-locales.js",
            //          "~/Scripts/bootstrap-datetimepicker.js"));














        }
    }
}