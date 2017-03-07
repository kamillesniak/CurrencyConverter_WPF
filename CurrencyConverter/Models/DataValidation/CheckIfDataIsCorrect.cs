using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Text.RegularExpressions;
using System.Windows;

namespace CurrencyConverter
{
    public static class CheckIfDataIsCorrect
    {
        static public bool CheckIfTextBoxValueIsNumber(string textBoxText)
        {
            if(Regex.IsMatch(textBoxText,@"\d"))
             {
                return true;
            }

            else
            {
                return false;
            }
       
        }
        static public bool CheckIfComboBoxHaveAnotherValues(ComboBox first, ComboBox second)
        {
            if(first.SelectedValue == second.SelectedValue)
            {
                MessageBox.Show("Currencies can not be the same ");
                return false;
            }
            {
                return true;
            }
        }
    }
}
