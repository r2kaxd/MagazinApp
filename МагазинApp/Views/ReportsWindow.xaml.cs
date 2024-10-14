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
using System.Windows.Shapes;

namespace МагазинApp
{
    public partial class ReportsWindow : Window
    {
        public ReportsWindow()
        {
            InitializeComponent();
        }

        private void ButtonSalesReport_Click(object sender, RoutedEventArgs e)
        {
            SalesReportWindow salesReportWindow = new SalesReportWindow();
            salesReportWindow.ShowDialog();
        }

        private void ButtonStockReport_Click(object sender, RoutedEventArgs e)
        {
            StockReportWindow stockReportWindow = new StockReportWindow();
            stockReportWindow.ShowDialog();
        }
    }
}