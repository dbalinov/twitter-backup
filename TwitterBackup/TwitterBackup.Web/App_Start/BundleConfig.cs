using System.Web.Optimization;

namespace TwitterBackup.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.blockUI.js"));

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
                      "~/Scripts/loading-bar.js",
                      "~/Scripts/toastr.min.js",
                      "~/Scripts/ng-infinite-scroll.min.js"));

            var appBundle = new ScriptBundle("~/bundles/app");
            appBundle.Include(
                // controllers
                "~/app/controllers/baseController.js",
                "~/app/controllers/favoriteUserController.js",
                "~/app/controllers/searchUserController.js",
                "~/app/controllers/timelineController.js",
                // services
                "~/app/services/favoriteUserService.js",
                "~/app/services/searchUserService.js",
                "~/app/services/timelineService.js",
                "~/app/services/notificationService.js",
                // app
                "~/app/app.js",
                "~/app/app.route.js",
                // directives
                "~/app/directives/userProfileDirective.js",
                "~/app/directives/statusDirective.js",
                "~/app/directives/tooltipDirective.js");

            appBundle.Transforms.Clear();
            bundles.Add(appBundle);

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/loading-bar.css",
                      "~/Content/toastr.min.css",
                      "~/Content/site.css"));
        }
    }
}
