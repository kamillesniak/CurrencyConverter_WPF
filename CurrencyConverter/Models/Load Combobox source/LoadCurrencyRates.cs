using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace CurrencyConverter
{
    class LoadCurrencyRates
    {
      public  List<CurrencyRateValues> actualCurrencyRatesList { get; private set; }
        public LoadCurrencyRates()
        {
            actualCurrencyRatesList = FillList();
        }
        private List<CurrencyRateValues> FillList()
        {
            var CurrencyUrl = new LoadActualCurrencyRateURL();
            List<string> actualCurrencyRatesUrl = CurrencyUrl.AcutalCurrencyRateUrlList;
            var xdocList = new List<XDocument>();

            foreach (string line in actualCurrencyRatesUrl)
            {
                var xdoc = new LoadXmlFromUrl(line);
                xdocList.Add(xdoc.CurrecyRatesXDoc);
            }

            var currencyList = new List<CurrencyRateValues>();

            currencyList.Add(new CurrencyRateValues("Polski Zloty", "PLN", 1, 1));

            foreach (XDocument xdoc in xdocList)
            {
                var currencyRatesList = new LoadActualCurrencyValues(xdoc);
                currencyList.AddRange(currencyRatesList.actualCurrencyRateList);
            }

            return currencyList;
        }
    }
}
