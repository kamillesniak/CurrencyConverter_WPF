﻿using System;
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
         public bool statusFlag { get; private set; } = true;
         public string actualXDocumentData { get; private set; }

        public LoadCurrencyRates()
        {
            actualCurrencyRateURLs = LoadCurrencyRateURLs();

            actualCurrencyXDocuments = LoadAllCurrencyXDocuments();

            actualXDocumentData = LoadXDocumentDate(actualCurrencyXDocuments);

            actualCurrencyRatesList = FillActualCurencyList();
         
        }

        private IList<string> LoadCurrencyRateURLs()
        {
            try
            {
                var CurrenciesUrls = new LoadActualCurrencyRateURL();
                return CurrenciesUrls.AcutalCurrencyRateUrlList;
            }
            catch
            {
                statusFlag = false;
                return null;
            }
           
        }

        private IList<XDocument> LoadAllCurrencyXDocuments()
        {
            IList<XDocument> xdocList = new List<XDocument> ();
            try
            {
                foreach (string line in actualCurrencyRateURLs)
                {
                    var xdoc = new LoadXmlFromUrl(line);
                    xdocList.Add(xdoc.CurrecyRatesXDoc);
                }
                return xdocList;
            }
            catch
            {
                statusFlag = false;
                return null;
            }
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

        private string LoadXDocumentDate(IEnumerable<XDocument> xdocs)
        {
             var xdoc = xdocs.FirstOrDefault();
             var date = xdoc.Descendants()
                .Where(x => x.Name.LocalName == "data_publikacji")
                .FirstOrDefault().Value.ToString();
            return date;
        }



    }
}
