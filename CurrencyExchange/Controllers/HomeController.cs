using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CurrencyExchange.Models;
using System.Xml;

namespace CurrencyExchange.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //load data
            string url = "http://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist-90d.xml";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(url);

            XmlNodeList outerTagData = xmlDoc.GetElementsByTagName("Cube");
            XmlNode allTagData = outerTagData[0]; //because only 1 level
            XmlNodeList eachDayData = allTagData.ChildNodes;

            //put into in memory data structure
            List<Time> formattedData = new List<Time>();

            foreach (XmlNode day in eachDayData) //loop thru nested levels
            {
                Time eachDay = new Time();
                eachDay.TimeStamp = DateTime.ParseExact(day.Attributes["time"].Value, "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture);

                List<Currency> todaysCurr = new List<Currency>();

                XmlNodeList currencyPairs = day.ChildNodes;
                foreach (XmlNode currPair in currencyPairs)
                {
                    Currency eachDayCurrencyData = new Currency();
                    eachDayCurrencyData.Symbol = currPair.Attributes["currency"].Value;
                    eachDayCurrencyData.Rate = Convert.ToDouble(currPair.Attributes["rate"].Value);
                    todaysCurr.Add(eachDayCurrencyData);
                }
                eachDay.Currencies = todaysCurr;
                formattedData.Add(eachDay);
            }

            return View(formattedData);
        }

        /*public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }*/

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
