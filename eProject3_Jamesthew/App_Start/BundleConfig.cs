using System.Web;
using System.Web.Optimization;

namespace eProject3_Jamesthew
{
    public class BundleConfig
    {
        
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            BundleTable.EnableOptimizations = true;
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

            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                      "~/Scripts/custom.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                        "~/Scripts/Home/bootstrap/popper.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/plugin").Include(
                        "~/Scripts/Home/plugins/plugins.js"));

            bundles.Add(new ScriptBundle("~/bundles/active").Include(
                        "~/Scripts/Home/active.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/csbootrap").Include(
                      "~/Content/Custom/bootstrap.min.css"));

            bundles.Add(new StyleBundle("~/Content/font").Include(
                      "~/Content/Custom/font-awesome.min.css"));

            bundles.Add(new StyleBundle("~/Content/cscss").Include(
                      "~/Content/Custom/custom.min.css"));

            bundles.Add(new StyleBundle("~/Content/style").Include(
                    "~/Content/Home/style.css",
                    "~/Content/Home/css/bootstrap.min.css",
                    "~/Content/Home/css/animate.css",
                    "~/Content/Home/css/magnific-popup.css",
                    "~/Content/Home/css/font-awesome.min.css",
                    "~/Content/Home/css/custom-icon.css",
                    "~/Content/Home/css/classy-nav.min.css",
                    "~/Content/Home/css/nice-select.min.css"));
            bundles.Add(new StyleBundle("~/Content/Login").Include(
                    "~/Content/Home/css/bootstrap.min.css",
                    "~/Content/Home/css/animate.css",
                    "~/Content/Home/css/font-awesome.min.css",
                    "~/Content/Home/css/main.css",
                    "~/Content/Home/css/util.css"));
        }
    }
}
