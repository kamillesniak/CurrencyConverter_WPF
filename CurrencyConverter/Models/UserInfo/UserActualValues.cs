using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    class UserActualValues
    {
        public decimal moneyAmount { get; private set; }
        public string currencyCode { get; private set; }
        public int currencyConverterValue { get; private set; }
        public decimal currencyCourse { get; private set; }

        public UserActualValues(decimal _moneyAmount,string _currencyCode, int _currencyConverterValue, decimal _currencyCourse)
        {
            moneyAmount = _moneyAmount;
            currencyCode = _currencyCode;
            currencyConverterValue = _currencyConverterValue;
            currencyCourse = _currencyCourse;
        }
    }
}
