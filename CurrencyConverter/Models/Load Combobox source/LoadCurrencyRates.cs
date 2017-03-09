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
         private IList <string> actualCurrencyRateURLs { get; set; }
         private IList<XDocument> actualCurrencyXDocuments { get; set; }

        public LoadCurrencyRates()
        {
            actualCurrencyRateURLs = LoadCurrencyRateURLs();

            actualCurrencyXDocuments = LoadAllCurrencyXDocuments();

            actualCurrencyRatesList = FillActualCurencyList();

        }

        private IList<string> LoadCurrencyRateURLs()
        {
            var CurrenciesUrls = new LoadActualCurrencyRateURL();
            return CurrenciesUrls.AcutalCurrencyRateUrlList;
        }

        private IList<XDocument> LoadAllCurrencyXDocuments()
        {
            IList<XDocument> xdocList = new List<XDocument> ();
            foreach (string line in actualCurrencyRateURLs)
            {
                var xdoc = new LoadXmlFromUrl(line);
                xdocList.Add(xdoc.CurrecyRatesXDoc);
            }
            return xdocList;
        }

        private List<CurrencyRateValues> FillActualCurencyList()
        {
            List<CurrencyRateValues> currencyList = new List<CurrencyRateValues>();
            currencyList.Add(AddPLNtoList());

            foreach (XDocument xdoc in actualCurrencyXDocuments)
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
