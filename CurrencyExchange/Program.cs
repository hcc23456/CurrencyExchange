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
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            /*WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();*/
				
			//configuring for deployment onto aws/any external url
			//https://stackoverflow.com/questions/37974451/how-to-run-a-net-core-mvc-site-on-aws-linux-instance - setup port forwarding to 5000 from 80 if needed
			var host = new WebHostBuilder()
				.UseKestrel()
				.UseContentRoot(Directory.GetCurrentDirectory())
				//.UseUrls("http://localhost:5000", "http://xxxx:5000", "http://192.168.1.2:5000") //specified urls only
				.UseUrls("http://*:80") //essential whether using kestrel or iis, accepts anything from the specified port
				.UseIISIntegration()
				.UseStartup<Startup>()
				.Build();
				
			host.Run();
    }
}
