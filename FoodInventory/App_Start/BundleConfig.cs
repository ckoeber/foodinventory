using System.Web;
using System.Web.Optimization;

namespace FoodInventory
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

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-dialog").Include(
                        "~/Scripts/bootstrap-dialog.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-datepicker").Include(
                        "~/Scripts/bootstrap-datepicker*"
                ));

            bundles.Add(new ScriptBundle("~/bundles/momentjs").Include(
                        "~/Scripts/moment*"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jquery-mask").Include(
                        "~/Scripts/jquery.mask*"
                ));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/dataTables.bootstrap.js",
                        "~/Scripts/Yadcf/jquery.dataTables.yadcf.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/index").Include(
                        "~/Scripts/index.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/bootstrap-datepicker/css/bootstrap-datepicker3.css")
                .Include("~/Content/DataTables/css/jquery.dataTables.css")
                .Include("~/Content/DataTables/css/dataTables.bootstrap4.css")
                .Include("~/Content/Yadcf/css/jquery.dataTables.yadcf.css")
                .Include("~/Content/bootstrap-dialog.css")
                .Include("~/Content/theme.css")
                .Include("~/Content/site.css")
                );
        }
    }
}
