using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter
{
    internal static class IsStatusChanged
    {

        public static Label CheckIfOnline( bool status, Label lbl)
        {
            if(status)
            {
                lbl.Content = "ONLINE";
                lbl.Foreground = Brushes.Green;
                return lbl;
            }
            else
            {
                lbl.Content = "OFFLINE";
                lbl.Foreground = Brushes.Red;
                return lbl;
            }
          
        }

    }
}
