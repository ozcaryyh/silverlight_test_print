using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Text;
using PrinterLib;

namespace SilverlightTestPrint
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder label = new StringBuilder();

            // Use BY2
            label.AppendLine("^XA");
            label.Append("^FO5,20^BY2,2.0,20");
            label.Append("^BCN,80,N,N,N");
            label.Append("^FD");
            label.Append(tbxFNSKU.Text.TrimEnd());
            label.AppendLine("^FS");
            label.Append("^ADN,30,10^FO50,85");
            label.Append("^FD");
            label.Append(tbxFNSKU.Text.TrimEnd());
            label.AppendLine("^FS");
            if (tbxProductInfo.Text.Length > 20)
            {
                label.Append("^ADN,25,10^FO20,120");
                label.Append("^FD");
                label.Append(tbxProductInfo.Text.Substring(0,20).TrimEnd());
                label.AppendLine("^FS");

                label.Append("^ADN,25,10^FO20,145");
                label.Append("^FD");
                label.Append(tbxProductInfo.Text.Substring(20, 20).TrimEnd());
                label.AppendLine("^FS");
            }
            else
            {
                label.Append("^ADN,25,10^FO20,120");
                label.Append("^FD");
                label.Append(tbxProductInfo.Text.TrimEnd());
                label.AppendLine("^FS");
            }
            label.AppendLine("^XZ");

            label.AppendLine("^XA");
            label.Append("^FO5,20^BY2,2.0,20");
            label.Append("^BCN,80,N,N,N");
            label.Append("^FD");
            label.Append("X12345678");
            label.AppendLine("^FS");
            label.Append("^ADN,30,10^FO50,85");
            label.Append("^FD");
            label.Append("X12345678");
            label.AppendLine("^FS");
            label.Append("^ADN,25,10^FO20,120");
            label.Append("^FD");
            label.Append("AA*ABCDEFGHIJKLMNOPQ");
            label.AppendLine("^FS");
            label.Append("^ADN,25,10^FO20,145");
            label.Append("^FD");
            label.Append("RST#UV_WX-YZ(1234567890)");
            label.AppendLine("^FS");
            label.AppendLine("^XZ");

            

            bool result = RawPrinterHelper.SendStringToPrinter(tbxSelectedPrinter.Text, label.ToString());
            if (!result)
            {
                MessageBox.Show("Error Returned From Print Spool.  Check Setup.");
            }
        }

        private void btnPrintZPL_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder label = new StringBuilder();
            label.AppendLine(tbxZPL.Text);


            bool result = RawPrinterHelper.SendStringToPrinter(tbxSelectedPrinter.Text, label.ToString());
            if (!result)
            {
                MessageBox.Show("Error Returned From Print Spool.  Check Setup.");
            }
        }
    }
}
