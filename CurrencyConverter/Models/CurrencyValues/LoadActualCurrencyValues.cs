using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CurrencyConverter
{
    class LoadActualCurrencyValues
    {
       public List<CurrencyRateValues> actualCurrencyRateList { get; private set; }

        public LoadActualCurrencyValues(XDocument currencyRatesXdoc)
        {
            actualCurrencyRateList = FillList(currencyRatesXdoc);
        }
        private List<CurrencyRateValues> FillList(XDocument xdoc)
        {
            var actualRatesList = new List<CurrencyRateValues>();

            var query = from position in xdoc.Root.Elements("pozycja")
                        select position;
            foreach (var item in query)
            {
                actualRatesList.Add(new CurrencyRateValues(item.Element("nazwa_waluty").Value,
                    item.Element("kod_waluty").Value,
                   StringToDecimal(item.Element("kurs_sredni").Value),
                    Int32.Parse(item.Element("przelicznik").Value)));
            }
            return actualRatesList;

        }
             private decimal StringToDecimal(string value)
        {
            decimal decimalVal = 0;
            Decimal.TryParse(value, out decimalVal);       
            return decimalVal;
        }
    
    }
}
