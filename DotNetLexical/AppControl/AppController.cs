using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace DotNetLexical.AppControl
{
    public class AppController
    {
        private Task<IHost> hostTask;

        public AppController() { }

        public void StartApplication()
        {
            hostTask = Task.Run(() => WebHostStartup.StartWebHost());
        }
    }
}

