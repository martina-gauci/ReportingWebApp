using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace NEMESYS {
    public class Program {
        //Starting point of the web application
        public static void Main(string[] args) {
            CreateWebHostBuilder(args).Build().Run(); //Calls function below
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>(); //Creates an instance of the Startup.cs class
    }
}
