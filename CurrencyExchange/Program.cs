using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CurrencyExchange
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //BuildWebHost(args).Run();

            //configuring for deployment onto aws/any external url
            //https://stackoverflow.com/questions/37974451/how-to-run-a-net-core-mvc-site-on-aws-linux-instance - setup port forwarding to 5000 from 80 if needed
            /*
			https://stackoverflow.com/questions/39732279/remotely-connect-to-net-core-self-hosted-web-api
			https://stackoverflow.com/questions/55885899/possibility-to-debug-both-http-and-https-in-kestrel-and-net-core-like-in-net-4
			https://stackoverflow.com/questions/50097268/asp-net-core-web-api-app-how-to-change-listening-address
			https://stackoverflow.com/questions/38755516/how-to-change-the-port-number-for-asp-net-core-app
			https://stackoverflow.com/questions/34212765/how-do-i-get-the-kestrel-web-server-to-listen-to-non-localhost-requests
			*/

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                //.UseUrls("http://localhost:5000", "http://xxxx:5000", "http://192.168.1.2:5000") //specified urls only
                .UseUrls("http://*:5000") //essential whether using kestrel or iis, accepts anything from the specified port
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
