using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CurrencyConverter
{
    class BindComboBoxSource
    {
      public ComboBox currencyListComboBox { get; private set; }

        public BindComboBoxSource()
        {
            currencyListComboBox = BindSource();
        }
        private ComboBox BindSource()
        {
            List<CurrencyRateValues> currencyList = new List<CurrencyRateValues>();
            var currRates = new LoadCurrencyRates();
            currencyList = currRates.actualCurrencyRatesList;

            var cbox = new ComboBox
            {

                ItemsSource = currencyList,
                DisplayMemberPath = "CurrencyDisplayValue",
                SelectedValuePath = "CurrencyAvargeCourse",
                SelectedIndex = 0,
            };
            return cbox;   

        }
    }
}
