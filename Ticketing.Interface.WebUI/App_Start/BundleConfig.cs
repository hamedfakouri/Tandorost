using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Ticketing.Interface.WebUI.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundles)
        {
            var jqScriptBundel = new ScriptBundle("~/bundles/Ticketing/scripts/js")
                .Include("~/Scripts/jquery-{version}.js");

            var scriptAppBundel = new ScriptBundle("~/bundles/Ticketing/scripts/app").Include(
                "~/dist/polyfills.dll*",
                "~/dist/polyfills*",

                "~/dist/vendor.dll*",
                "~/dist/vendor*",
                "~/dist/main*");

            var styleAppBundel=new StyleBundle("~/bundles/Ticketing/styles/app").Include(
                "~/Content/bootstrap.css"
            );

            bundles.Add(jqScriptBundel);
            bundles.Add(scriptAppBundel);
            bundles.Add(styleAppBundel);
#if !DEBUG 
             BundleTable.EnableOptimizations = true;
#endif
           
        }
    }
}