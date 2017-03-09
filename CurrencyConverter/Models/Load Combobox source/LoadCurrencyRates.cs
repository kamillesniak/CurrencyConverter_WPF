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
            List<string> actualCurrencyRatesURLs = CurrencyUrl.AcutalCurrencyRateUrlList;

            var currencyXDocuments = LoadAllCurrencyXDocuments(actualCurrencyRatesURLs);

            List<CurrencyRateValues> actualCurrencyRateValues = FillActualCurencyList(currencyXDocuments);

            return actualCurrencyRateValues;
        }
        private List<XDocument> LoadAllCurrencyXDocuments(List<string> actualCurrencyURLs)
        {
            var xdocList = new List<XDocument>();
            foreach (string line in actualCurrencyURLs)
            {
                var xdoc = new LoadXmlFromUrl(line);
                xdocList.Add(xdoc.CurrecyRatesXDoc);
            }
            return xdocList;
        }
        private List<CurrencyRateValues> FillActualCurencyList(List<XDocument> currencyXDocumentList)
        {
            var currencyList = new List<CurrencyRateValues>();
            currencyList.Add(AddPLNtoList());

            foreach (XDocument xdoc in currencyXDocumentList)
            {
                var currencyRatesList = new LoadActualCurrencyValues(xdoc);
                currencyList.AddRange(currencyRatesList.actualCurrencyRateList);
            }
            currencyList = SortList(currencyList);
            return currencyList;
        }
        private CurrencyRateValues AddPLNtoList()
        {
            var currValue = new CurrencyRateValues("polski Zloty", "PLN", 1, 1);
            return currValue;
        }
        private List<CurrencyRateValues> SortList(List<CurrencyRateValues> currList)
        {
            List<CurrencyRateValues> sortedList = currList.OrderBy(o => o.CurrencyName).ToList();
            return sortedList;
        }

    }
}
