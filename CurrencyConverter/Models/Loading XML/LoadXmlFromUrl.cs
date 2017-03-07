using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CurrencyConverter
{
    class LoadXmlFromUrl
    {
        public XDocument CurrecyRatesXDoc { get; private set; }

        public LoadXmlFromUrl(string _url)
        {
            CurrecyRatesXDoc = DownloadExchangeRates(_url);
        }
        public XDocument DownloadExchangeRates(string url)
        {

            return XDocument.Load(url);
        }
    }
}
