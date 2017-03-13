using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
     class CurrencyRateValues
    {
        public string CurrencyName { get; private set; }
        public string CurrencyCode { get; private set; }
        public string CurrencyDisplayValue { get; private set; }
        public decimal CurrencyAvargeCourse { get; private set; }
        public int CurrencyConverterValue { get; private set; } = 1;

       

        public CurrencyRateValues(string _CurrencyName, string _CurrencyCode, decimal _CurrencyAvargeCourse, int _CurrencyConverterValue)
        {
            CurrencyName = _CurrencyName;
            CurrencyCode = _CurrencyCode;
            CurrencyAvargeCourse = _CurrencyAvargeCourse;
            CurrencyConverterValue = _CurrencyConverterValue;
            CurrencyDisplayValue = CurrencyName + "(" + CurrencyCode + ")";
        }


    }
}
