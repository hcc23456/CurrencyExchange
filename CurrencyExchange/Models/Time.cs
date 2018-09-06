using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Models
{
    public class Time
    {
        public DateTime TimeStamp { get; set; }
        public List<Currency> Currencies { get; set; }

        public Time()
        { }

        public Time(DateTime timeStamp, List<Currency> currencies)
        {
            TimeStamp = timeStamp;
            Currencies = currencies;
        }
    }
}
