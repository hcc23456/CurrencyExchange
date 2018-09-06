using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyExchange.Models
{
    public class Currency
    {
        public string Symbol { get; set; }
        public double Rate { get; set; }

        public Currency()
        { }

        public Currency(string symbol, double rate)
        {
            Symbol = symbol;
            Rate = rate;
        }
    }
}
