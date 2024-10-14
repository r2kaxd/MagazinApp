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
    public partial class SalesWindow : Window
    {
        private DatabaseHelper dbHelper;

        public SalesWindow()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadSales();
        }

        private void LoadSales()
        {
            List<Sale> sales = dbHelper.GetSales();
            DataGridSales.ItemsSource = sales;
        }

        private void ButtonAddSale_Click(object sender, RoutedEventArgs e)
        {
            AddSaleWindow addSaleWindow = new AddSaleWindow();
            addSaleWindow.ShowDialog();
            LoadSales();
        }

        private void ButtonCheckout_Click(object sender, RoutedEventArgs e)
        {
            CheckoutWindow checkoutWindow = new CheckoutWindow();
            checkoutWindow.ShowDialog();
            LoadSales();
        }
    }
}