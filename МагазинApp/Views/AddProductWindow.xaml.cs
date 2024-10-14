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
    public partial class AddProductWindow : Window
    {
        private DatabaseHelper dbHelper;

        public AddProductWindow()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Product product = new Product
            {
                Название = TextBoxName.Text,
                Категория = TextBoxCategory.Text,
                Производитель = TextBoxManufacturer.Text,
                Цена = decimal.Parse(TextBoxPrice.Text),
                Количество = int.Parse(TextBoxQuantity.Text)
            };

            dbHelper.AddProduct(product);
            MessageBox.Show("Продукт успешно добавлен!");
            this.Close();
        }
    }
}