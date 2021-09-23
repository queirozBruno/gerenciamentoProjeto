using System.Web.Optimization;

namespace gerenciamentoProjeto.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css")
                .Include(
                "~/Content/vendor/fontawesome-free/css/all.min.css",
                "~/Content/vendor/datatables/dataTables.bootstrap4.css",
                "~/Content/css/sb-admin.css"));

                  bundles.Add(new ScriptBundle("~/bundles/js")
                .Include(
                "~/Content/vendor/jquery/jquery.min.js",
                "~/Content/vendor/bootstrap/js/bootstrap.bundle.min.js",
                "~/Content/vendor/jquery-easing/jquery.easing.min.js",
                "~/Content/vendor/chart.js/Chart.min.js",
                "~/Content/vendor/datatables/jquery.dataTables.js",
                "~/Content/vendor/datatables/dataTables.bootstrap4.js",
                "~/Content/js/sb-admin.min.js",
                "~/Content/js/demo/datatables-demo.js",
                "~/Content/js/demo/chart-area-demo.js"));
        }
    }
}