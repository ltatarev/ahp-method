using System.Web;
using System.Web.Optimization;

namespace AHP
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/datatables/jquery.datatables.js"                       
                        
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/scripts/datatables/datatables.bootrstrap.js"
              
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/Body.css",
                      "~/Content/Site.css",
                      "~/Content/Slider.css",
                      "~/Content/Placeholder.css",
                      "~/Content/Loader.css",
                      "~/Content/Pagination.css",
                      "~/content/datatables/css/datatables.bootstrap.css"
));
        }
    }
}
