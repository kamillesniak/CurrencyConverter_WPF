using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    class ConvertActualValues:Converter
    {
        public ConvertActualValues(UserActualValues firstCurrency, UserActualValues secondCurrency)
        {
            UseCorrectConverter(firstCurrency, secondCurrency);
            convertResult = DecimalToRound(convertResult, 3);
        }
        private void UseCorrectConverter(UserActualValues first, UserActualValues second)
        {
            if(first.currencyCode=="PLN")
            {
                convertResult = CalculatePLNtoX(first, second);
            }
            else if(second.currencyCode =="PLN")
            {
                convertResult = CalculateXtoPLN(first, second);
            }
            else
            {
                convertResult = CalculateCrossRate(first, second);
            }
        }
         private decimal DecimalToRound(decimal value, int decimalPlace)
        {
            return Decimal.Round(value, decimalPlace, MidpointRounding.AwayFromZero);
        }
    }
}
