using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net;
using System.IO;

namespace CurrencyConverter
{
    class ActualCurrencyRateUrlLoader
    {
        public List<string> AcutalCurrencyRateUrlList { get; set; }

        public ActualCurrencyRateUrlLoader()
        {
           string [] thisYearXmlFileNames = DownloadThisYearNbpXMLFileNames("http://www.nbp.pl/kursy/xml/dir.txt");
           string actualUrlNumber = GetLastFileNumber(thisYearXmlFileNames);
           AcutalCurrencyRateUrlList = FindActualUrls(thisYearXmlFileNames,actualUrlNumber);
        }
        private string[] DownloadThisYearNbpXMLFileNames(string _url)
        {
            try
            {
                var client = new WebClient();
                var nbpXmlURL = client.DownloadString(_url);
                string[] lines = nbpXmlURL.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                return lines;
            }
            catch
            {
                MessageBox.Show("Cannot load NBP text list, Check your internet connection");
                return null;
            }
           
        }

        private string GetLastFileNumber(string [] arr)
        {
            if (arr.Length > 0)
            {
                int peneUltimate = arr.Length - 2;

                string lastElement = arr[peneUltimate];
                return lastElement.Substring(5);
            }
            else
            {
                return "empty";
            }
        }

        private List<string> FindActualUrls ( string [] urls, string code)
        {
            List<string> actualUrlList = new List<string>();
            string p1 = "http://www.nbp.pl/kursy/xml/";

            var actualUrls = from line in urls
                             where line.Contains(code) && (line.Contains("a") || line.Contains("b"))
                             select line;

            foreach (var line in actualUrls)
            {
                actualUrlList.Add(Path.Combine(p1, line + ".xml"));
            }
            return actualUrlList;
        }

    }
}
