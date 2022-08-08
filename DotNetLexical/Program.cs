using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

/* dot-net-lexical */
namespace DotNetLexical
{
    internal static class Program
    {
        /*
         * Run the front-end in dev mode (recommended).
         *
         *  cd packages/lexical-playground && npm run dev
         *
         */
        // private const string LEXICAL_WEBSERVER = "http://localhost:3001/";

        /*
         * Use a built front-end (needs HTTP server)
         *
         *      npm run build
         */
        // private const string LEXICAL_WEBSERVER = "http://server-build/index.html";

        /*
         * Use the project's test server
         */
        private const string LEXICAL_WEBSERVER = "https://net-lexical.codecreation.dev/index-file.html";


        /// <summary>
        ///  Application starts here
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += ReportUnhandledException;
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            MainForm mainForm = new MainForm();
            WebViewLoaded(mainForm.webView2);
            Application.Run(mainForm);
        }


        public static async void WebViewLoaded(WebView2 webView2)
        {
            webView2.CoreWebView2InitializationCompleted += (sender, e) =>
            {
                WebView_InitCompleted(sender as WebView2, e);
            };
            await webView2.EnsureCoreWebView2Async(null);
        }

        private static void WebView_InitCompleted(WebView2 webView2, EventArgs e)
        {
            webView2.CoreWebView2.Navigate(LEXICAL_WEBSERVER);
        }

        private static void ReportUnhandledException(object sender, UnhandledExceptionEventArgs ex)
        {
            Debug.WriteLine($"Unhandled Exception {ex.ExceptionObject.GetType()} {ex.ExceptionObject}");
        }
    }
}
