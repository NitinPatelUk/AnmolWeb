using System;
using System.IO.Compression;
using System.Net;
using System.Web;
using System.Web.Optimization;

namespace _Anmol.WebApp
{
    #region GZip Compression

    /// <summary>
    /// Class GZipBundle.
    /// </summary>
    public class GZipBundle : Bundle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GZipBundle" /> class.
        /// </summary>
        /// <param name="virtualPath">The virtual path used to reference the <see cref="T:System.Web.Optimization.Bundle" /> from within a view or Web page.</param>
        /// <param name="transforms">A list of <see cref="T:System.Web.Optimization.IBundleTransfo rm" /> objects which process the contents of the bundle in the order which they are added.</param>
        public GZipBundle(string virtualPath, params IBundleTransform[] transforms)
            : base(virtualPath, null, transforms)
        {
        }

        /// <summary>
        /// GS the zip encode page.
        /// Sets up the current page or handler to use GZip through a Response.Filter.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        public static void GZipEncodePage(HttpContextBase httpContext)
        {
            if (null != httpContext && null != httpContext.Request && null != httpContext.Response && (null == httpContext.Response.Filter || !(httpContext.Response.Filter is GZipStream || httpContext.Response.Filter is DeflateStream)))
            {
                // Is GZip supported?
                string acceptEncoding = httpContext.Request.Headers["Accept-Encoding"];
                if (null != acceptEncoding && acceptEncoding.IndexOf(DecompressionMethods.GZip.ToString(), StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    if (httpContext.Response.Filter != null)
                        httpContext.Response.Filter = new GZipStream(httpContext.Response.Filter, CompressionMode.Compress);
                    httpContext.Response.AddHeader("Content-Encoding", DecompressionMethods.GZip.ToString().ToLowerInvariant());
                }
                else if (null != acceptEncoding && acceptEncoding.IndexOf(DecompressionMethods.Deflate.ToString(), StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    if (httpContext.Response.Filter != null)
                        httpContext.Response.Filter = new DeflateStream(httpContext.Response.Filter, CompressionMode.Compress);
                    httpContext.Response.AddHeader("Content-Encoding", DecompressionMethods.Deflate.ToString().ToLowerInvariant());
                }

                // Allow proxy servers to cache encoded and decoded versions separately
                httpContext.Response.AppendHeader("Vary", "Content-Encoding");
            }
        }

        /// <summary>
        /// Overrides this to implement own caching logic.
        /// </summary>
        /// <param name="context">The bundle context.</param>
        /// <returns>A bundle response.</returns>
        public override BundleResponse CacheLookup(BundleContext context)
        {
            if (null != context)
            {
                GZipEncodePage(context.HttpContext);
            }

            return base.CacheLookup(context);
        }
    }

    /// <summary>
    /// Class GZipStyleBundle. This class cannot be inherited.
    /// Represents a bundle that does CSS minification and GZip compression.
    /// </summary>
    public sealed class GZipStyleBundle : GZipBundle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GZipStyleBundle"/> class.
        /// </summary>
        /// <param name="virtualPath">The virtual path.</param>
        /// <param name="transforms">The transforms.</param>
        public GZipStyleBundle(string virtualPath, params IBundleTransform[] transforms)
            : base(virtualPath, transforms)
        {
        }
    }

    /// <summary>
    /// Class GZipScriptBundle. This class cannot be inherited.
    /// Represents a bundle that does JS minification and GZip compression.
    /// </summary>
    public sealed class GZipScriptBundle : GZipBundle
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GZipScriptBundle"/> class.
        /// </summary>
        /// <param name="virtualPath">The virtual path.</param>
        /// <param name="transforms">The transforms.</param>
        public GZipScriptBundle(string virtualPath, params IBundleTransform[] transforms)
            : base(virtualPath, transforms)
        {
            ConcatenationToken = ";" + Environment.NewLine;
        }
    }

    #endregion
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            //bundles.Add(new GZipScriptBundle("~/bundles/modernizr", new JsMinify()).Include(
            //           "~/assets/modernizr-*"));
            //bundles.Add(new GZipScriptBundle("~/bundles/jquery", new JsMinify()).Include(
            //          "~/assets/jquery.min.js"));


            //bundles.Add(new GZipScriptBundle("~/bundles/jqueryval", new JsMinify()).Include(
            //          // no delete this file 
            //          "~/assets/jquery/jquery.js",
            //          "~/assets/Jquery/jquery.cookie-1.4.1.min.js",
            //          "~/assets/jquery/jquery-1.10.3-ui.js",
            //          "~/assets/jquery/jquery.validate.js",
            //          "~/assets/jquery/jquery.validate.unobtrusive.js",
            //          "~/assets/jquery/jquery.validate.unobtrusive.min.js",
            //          "~/assets/jquery.dataTables.min.js",
            //          "~/assets/dataTables.buttons.min.js"
            //          ));

            //bundles.Add(new GZipScriptBundle("~/bundles/bootstrap", new JsMinify()).Include(

            //     //design files              
            //     "~/assets/js/jquery-3.0.0.min.js",
            //     // "~/app-assets/vendors/js/core/jquery-3.2.1.min.js",
            //     "~/app-assets/vendors/js/core/popper.min.js",
            //     "~/app-assets/vendors/js/core/bootstrap.min.js",
            //     "~/app-assets/vendors/js/perfect-scrollbar.jquery.min.js",
            //     "~/app-assets/vendors/js/prism.min.js",
            //     "~/app-assets/vendors/js/jquery.matchHeight-min.js",
            //     "~/app-assets/vendors/js/screenfull.min.js",
            //     "~/app-assets/vendors/js/pace/pace.min.js",
            //     "~/app-assets/vendors/js/chartist.min.js",
            //     "~/app-assets/js/app-sidebar.js",
            //     "~/app-assets/js/notification-sidebar.js",
            //     "~/app-assets/js/customizer.js",
            //     "~/app-assets/js/dashboard1.js",


            //     //project files 
            //     "~/assets/jquery.dataTables.min.js",
            //     "~/assets/buttons.dataTables.min.js",
            //     "~/assets/moment.js",
            //     "~/assets/bootstrap/bootstrap-toggle.js",
            //     "~/assets/dist/fastselect.standalone.js",
            //     "~/assets/Themes/ckeditor/ckeditor.js",
            //     "~/assets/formden.js",
            //     "~/assets/star-rating.js",
            //     "~/assets/moment-with-locales.js",
            //     "~/assets/bootbox.min.js"));


            //bundles.Add(new GZipScriptBundle("~/bundles/toastr", new JsMinify()).Include(
            //      "~/assets/vendors/js/toastr.js",
            //      "~/assets/vendors/js/toastr.min.js"));

            //bundles.Add(new GZipStyleBundle("~/Content/bootstrap", new CssMinify()).Include(


            //    //design files
            //    "~/app-assets/fonts/feather/style.min.css",
            //    "~/app-assets/fonts/simple-line-icons/style.css",
            //    "~/app-assets/fonts/font-awesome/css/font-awesome.min.css",
            //    "~/app-assets/vendors/css/perfect-scrollbar.min.css",
            //    "~/app-assets/vendors/css/prism.min.css",
            //    "~/app-assets/vendors/css/chartist.min.css",
            //    "~/app-assets/css/app.css",


            //     //project files :- like datalist datatable , grid view ,sorting searching 
            //     "~/assets/jquery.dataTables.min.css",
            //     "~/assets/buttons.dataTables.min.css",
            //     "~/assets/vendors/css/toastr.css",
            //     "~/assets/bootstrap/bootstrap-slider.min.css",
            //     "~/assets/bootstrap/bootstrap-toggle.css",
            //     "~/assets/dist/fastselect.min.css",
            //     "~/assets/bootstrap-iso.css",
            //     "~/assets/tempusdominus-bootstrap-4.min.css",
            //     "~/assets/bootstrap/bootstrap-glyphicons.css",
            //     "~/assets/bootbox.css"
            //    ));

            //bundles.Add(new GZipStyleBundle("~/Content/css", new CssMinify()).Include(
            //           "~/app-assets/fonts/Simple-Line-Icons.ttf ",
            //            "~/assets/5star.css",
            //            "~/assets/star-rating.css"
            //            ));

        }
    }
}

