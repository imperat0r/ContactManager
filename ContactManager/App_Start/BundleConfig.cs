using System.Web;
using System.Web.Optimization;

namespace ContactManager
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                   "~/Scripts/angular.min.js",
                   "~/Scripts/angular-route.min.js",
                   "~/Scripts/angular-animate.min.js",
                   "~/Scripts/plugins/ui-bootstrap-tpls-0.11.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular-app").Include(
                   "~/Scripts/app/app.js",
                   "~/Scripts/app/services.js",
                   "~/Scripts/app/filters.js",
                   "~/Scripts/app/directives.js",
                   "~/Scripts/app/controllers/home-controller.js",
                   "~/Scripts/app/controllers/contact-details.js",
                   "~/Scripts/app/controllers/addcontact-controller.js",
                   "~/Scripts/app/controllers/modal-delete-contact-controller.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/sb-admin.css",
                      "~/Content/angular-view-animation.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
