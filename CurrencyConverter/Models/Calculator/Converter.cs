using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    abstract class  Converter
    {
        public decimal convertResult { get; protected set; }

        protected decimal CalculatePLNtoX(UserActualValues firstCurr, UserActualValues secondCurr)
        {
            decimal result = firstCurr.moneyAmount * secondCurr.currencyConverterValue / secondCurr.currencyCourse;
            return result;
        }
        protected decimal CalculateXtoPLN(UserActualValues firstCurr, UserActualValues secondCurr)
        {
            decimal result = firstCurr.moneyAmount * firstCurr.currencyCourse / firstCurr.currencyConverterValue;
            return result;
        }
        protected decimal CalculateCrossRate(UserActualValues firstCurr, UserActualValues secondCurr)
        {
            decimal cross = firstCurr.moneyAmount * firstCurr.currencyCourse *secondCurr.currencyConverterValue / (secondCurr.currencyCourse *firstCurr.currencyConverterValue);
            decimal result =  firstCurr.currencyCourse / firstCurr.currencyConverterValue
                            / secondCurr.currencyCourse / secondCurr.currencyCourse* firstCurr.moneyAmount ;
                return cross;
        }
    }
}
