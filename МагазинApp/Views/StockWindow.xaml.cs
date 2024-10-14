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
using МагазинApp.DAL;
using МагазинApp.Models;

namespace МагазинApp
{
    public partial class StockWindow : Window
    {
        private DatabaseHelper dbHelper;

        public StockWindow()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadStock();
        }

        private void LoadStock()
        {
            List<Stock> stock = dbHelper.GetStock();
            DataGridStock.ItemsSource = stock;
        }
    }
}