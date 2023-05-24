using System;
using System.Collections.Generic;
using System.Text;

namespace Bank_Orange
{
    //Class for saving/editing currency exchanges
    public class CurrencyExchanges
    {
        public decimal EuroCurrencyRate = 10;
        public decimal DollarCurrencyRate = 10;

        public CurrencyExchanges(decimal euro, decimal dollar)
        {
            EuroCurrencyRate = euro;
            DollarCurrencyRate = dollar;
        }
    }
}
