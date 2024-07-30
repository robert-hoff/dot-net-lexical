using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DotNetLexical.AppControl
{
    public class WebHostStartup
    {
        public static async Task<IHost> StartWebHost()
        {
            var builder = Host.CreateDefaultBuilder().ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<WebHostStartup>();
                webBuilder.UseUrls("http://localhost:8090");
            });
            var host = builder.Build();
            await host.StartAsync();
            return host;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // Configure logging (suppress most messages)
            services.AddLogging(loggingBuilder =>
            {
                // Clear default logging providers, and add a console logger
                loggingBuilder.ClearProviders();
                loggingBuilder.AddConsole();
                loggingBuilder.SetMinimumLevel(LogLevel.Warning);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment whostEnv)
        {
            if (whostEnv.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // Serve static files from the assets folder
            app.UseStaticFiles();
            app.UseFileServer(new FileServerOptions
            {
                // whostEnv.ContentRootPath evaluates to
                // Z:\checkouts\dot-net-lexical\DotNetLexical\bin\Debug\net6.0-windows
                FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
                    System.IO.Path.Combine(whostEnv.ContentRootPath, "../../../../assets")),
                RequestPath = "/assets",
                EnableDirectoryBrowsing = false  // Set to true to enable directory browsing
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                // /callback route
                endpoints.MapGet("/editor", async context =>
                {
                    HttpRequest request = context.Request;
                    await context.Response.WriteAsync(HtmlShowEditor);
                });

                // all other routes
                endpoints.MapFallback(context => {
                    return context.Response.WriteAsync(HtmlUrlUnknown);
                });
            });
         }


        public static string GetHttpRequestStringDescription(HttpRequest request)
        {
            StringBuilder requestInfo = new();
            requestInfo.AppendLine($"Method: {request.Method}");
            requestInfo.AppendLine($"Scheme: {request.Scheme}");
            requestInfo.AppendLine($"Host: {request.Host}");
            requestInfo.AppendLine($"Path: {request.Path}");
            requestInfo.AppendLine($"QueryString: {request.QueryString}");
            // Adding header information
            requestInfo.AppendLine("Headers:");
            foreach (var header in request.Headers)
            {
                requestInfo.AppendLine($"{header.Key}: {header.Value}");
            }
            return requestInfo.ToString();
        }

        private static readonly string HtmlShowEditor = @"
            <!DOCTYPE html>
            <html lang='en'>
              <head>
                <meta charset='utf-8' />
                <meta name='viewport' content='width=device-width, initial-scale=1' />
                <meta name='theme-color' content='#000000' />
                <meta name='description' content='Lexical Playground' />
                <title>Lexical Playground</title>
                <link rel=""shortcut icon"" href=""/assets/default-favicon.ico"">
                <script type='module' crossorigin src='/assets/main.282e94fe.js'></script>
                <link rel='modulepreload' href='/assets/vendor.fa96dc44.js'>
                <link rel='stylesheet' href='/assets/main.28a2c6ba.css'>
              </head>
              <body>
                <noscript>You need to enable JavaScript to run this app.</noscript>
                <div id='root'></div>
                <div id='portal'></div>
              </body>
            </html>";

        private static readonly string HtmlUrlUnknown = @"
            <html>
                <head><title>localhost</title></head>
                <body><p>URL not valid</p></body>
            </html>";
    }
}

