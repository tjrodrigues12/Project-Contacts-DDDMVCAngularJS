using System.Web;
using System.Web.Optimization;

namespace Project.Application
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            #region Angular

            bundles.Add(new Bundle("~/bundles/angular/scripts").Include(
                "~/Scripts/angular.min.js",
                "~/Scripts/angular-route.min.js",
                "~/Scripts/angular-touch.min.js",
                "~/Scripts/angular-sanitize.min.js",
                "~/Scripts/angular-animate.min.js",
                "~/Scripts/i18n/angular-locale_pt-br.js",
                "~/Scripts/ui-grid.min.js",
                "~/Scripts/ui-grid.pagination.js",
                "~/Scripts/ui-grid.resize-columns.js",
                "~/Scripts/ui-grid.move-columns.js",
                "~/Scripts/ui-grid.pinning.js",
                "~/Scripts/ui-grid.selection.js",
                "~/Scripts/ui-grid.auto-resize.js",
                "~/Scripts/ui-grid.exporter.js",
                "~/App/Modules/globalMdl.js",
                "~/App/Services/globalSrv.js"
                //"~/App/Diretives/alert.js"
            ));

            bundles.Add(new StyleBundle("~/bundles/angular/css").Include(
              "~/Content/ui-grid.css" //,
                                      //"~/Content/angular-busy.min.css",
                                      //"~/Content/select.css",
                                      //"~/Content/select.min.css",
                                      //"~/Content/select.min.css.map",
                                      //"~/Content/select2.css",
                                      //"~/Content/angular-toastr.min.css"
                                      //"~/Scripts/angular-csp.css",

              ));

            #endregion           

            #region Contact

            bundles.Add(new Bundle("~/bundles/contact").Include(
              "~/App/Modules/contactMdl.js",
              "~/App/Services/contactSvc.js",
              "~/App/Controllers/contact/addCtrl.js",
              "~/App/Controllers/contact/editCtrl.js",
              "~/App/Controllers/contact/indexCtrl.js"
            ));

            #endregion
        }
    }
}
