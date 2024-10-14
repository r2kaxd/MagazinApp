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
    public partial class ProductsWindow : Window
    {
        private DatabaseHelper dbHelper;

        public ProductsWindow()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadProducts();
        }

        private void LoadProducts()
        {
            List<Product> products = dbHelper.GetProducts();
            DataGridProducts.ItemsSource = products;
        }

        private void ButtonAddProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow addProductWindow = new AddProductWindow();
            addProductWindow.ShowDialog();
            LoadProducts();
        }
    }
}