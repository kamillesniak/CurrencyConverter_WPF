using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace CurrencyConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool StatusFlag = true;
        public MainWindow()
        {
            InitializeComponent();
            FillActualComboBox();
        }

        #region FillControlsWithData
        private void FillActualComboBox()
        {
            var currencyList = new List<CurrencyRateValues>();
            var currRates = new LoadCurrencyRates();
            currencyList = currRates.actualCurrencyRatesList;
            ActualStatusLabel =  CheckStatus.CheckIfOnline(currRates.statusFlag, ActualStatusLabel);

            FirstCurrencyComboBox.ItemsSource = currencyList;
            FirstCurrencyComboBox.DisplayMemberPath = "CurrencyDisplayValue";
            FirstCurrencyComboBox.SelectedValuePath = "CurrencyAvargeCourse";
            FirstCurrencyComboBox.SelectedIndex = 0;

            SecondCurrencyComboBox.ItemsSource = currencyList;
            SecondCurrencyComboBox.DisplayMemberPath = "CurrencyDisplayValue";
            SecondCurrencyComboBox.SelectedValuePath = "CurrencyAvargeCourse";
            SecondCurrencyComboBox.SelectedIndex = 0;

        }
     


        #endregion

        #region LoadUserData

        private UserActualValues LoadUserTypedData(TextBox myTextBox, ComboBox cbox)
        {
            
            if (CheckIfDataIsCorrect.CheckIfTextBoxValueIsNumber(myTextBox.Text))
            {
                cbox.SelectedValuePath = "CurrencyAvargeCourse";
                int currConverterValue = ((CurrencyRateValues)cbox.SelectedItem).CurrencyConverterValue;
                string currCode = ((CurrencyRateValues)cbox.SelectedItem).CurrencyCode;
                decimal currCourse = ((CurrencyRateValues)cbox.SelectedItem).CurrencyAvargeCourse;
                var user = new UserActualValues(decimal.Parse(myTextBox.Text),currCode,currConverterValue, currCourse);
                return user;
            }
            else
            {
                MessageBox.Show("Wrong data typed, try again");
                //reset values
                return null;
            }
        }

        #endregion

        private void ConvertCurrency(object sender, RoutedEventArgs e)
        {
            try
            {
                var firstCurrency = LoadUserTypedData(FirstCurrencyValueComboBox, FirstCurrencyComboBox);
                var secondCurrency = LoadUserTypedData(SecondCurrencyValueComboBox, SecondCurrencyComboBox);

                if (CheckIfDataIsCorrect.CheckIfComboBoxHaveAnotherValues(FirstCurrencyComboBox, SecondCurrencyComboBox))
                {
                    
                    var convert = new ConvertActualValues(firstCurrency,secondCurrency);
                    SecondCurrencyValueComboBox.Text = convert.convertResult.ToString();

                }
                else
                {
                    //do nothing
                }
            }
            catch
            {

            }
        }
    }
}
