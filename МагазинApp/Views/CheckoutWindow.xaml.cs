using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows;
using МагазинApp.DAL;
using МагазинApp.Models;

namespace МагазинApp
{
    public partial class CheckoutWindow : Window
    {
        private DatabaseHelper dbHelper;
        private List<Product> products;
        private List<CartItem> cartItems;

        public CheckoutWindow()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            products = dbHelper.GetProducts();
            cartItems = new List<CartItem>();
            LoadProducts();
        }

        private void LoadProducts()
        {
            ComboBoxProducts.ItemsSource = products;
            ComboBoxProducts.DisplayMemberPath = "Название";
        }

        private void ComboBoxProducts_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ComboBoxProducts.SelectedItem != null)
            {
                Product selectedProduct = ComboBoxProducts.SelectedItem as Product;
                TextBoxQuantity.Text = "1";
            }
        }

        private void ButtonAddToCart_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxProducts.SelectedItem != null && !string.IsNullOrEmpty(TextBoxQuantity.Text))
            {
                Product selectedProduct = ComboBoxProducts.SelectedItem as Product;
                int quantity = int.Parse(TextBoxQuantity.Text);

                CartItem cartItem = cartItems.FirstOrDefault(item => item.Product.ID == selectedProduct.ID);
                if (cartItem != null)
                {
                    cartItem.Quantity += quantity;
                }
                else
                {
                    cartItems.Add(new CartItem { Product = selectedProduct, Quantity = quantity });
                }

                UpdateCartList();
                UpdateTotal();
            }
        }

        private void UpdateCartList()
        {
            ListBoxCart.ItemsSource = cartItems.Select(item => $"{item.Product.Название} - {item.Quantity} шт.").ToList();
        }

        private void UpdateTotal()
        {
            decimal total = cartItems.Sum(item => item.Product.Цена * item.Quantity);
            TextBoxTotal.Text = total.ToString("F2");
        }

        private void ButtonConfirmPayment_Click(object sender, RoutedEventArgs e)
        {
            if (cartItems.Count > 0)
            {
                foreach (var item in cartItems)
                {
                    Sale sale = new Sale
                    {
                        Дата = DateTime.Now,
                        ID_Продукта = item.Product.ID,
                        ID_Сотрудника = 1, // Пример ID сотрудника
                        Количество = item.Quantity,
                        Сумма = item.Product.Цена * item.Quantity
                    };

                    dbHelper.AddSale(sale);

                    // Обновляем остатки на складе
                    Stock stock = dbHelper.GetStock().Find(s => s.ID_Продукта == sale.ID_Продукта);
                    if (stock != null)
                    {
                        stock.Количество -= sale.Количество;
                        dbHelper.UpdateStock(stock);
                    }
                }

                MessageBox.Show("Оплата успешно оформлена!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Корзина пуста!");
            }
        }
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
