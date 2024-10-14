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
    public partial class AddSaleWindow : Window
    {
        private DatabaseHelper dbHelper;

        public AddSaleWindow()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Sale sale = new Sale
            {
                Дата = DatePickerDate.SelectedDate.Value,
                ID_Продукта = int.Parse(TextBoxProductID.Text),
                ID_Сотрудника = int.Parse(TextBoxEmployeeID.Text),
                Количество = int.Parse(TextBoxQuantity.Text),
                Сумма = 0 // Сумма будет рассчитана автоматически
            };

            // Получаем цену продукта
            Product product = dbHelper.GetProducts().Find(p => p.ID == sale.ID_Продукта);
            if (product != null)
            {
                sale.Сумма = product.Цена * sale.Количество;
            }

            dbHelper.AddSale(sale);

            // Обновляем остатки на складе
            Stock stock = dbHelper.GetStock().Find(s => s.ID_Продукта == sale.ID_Продукта);
            if (stock != null)
            {
                stock.Количество -= sale.Количество;
                dbHelper.UpdateStock(stock);
            }

            MessageBox.Show("Продажа успешно добавлена!");
            this.Close();
        }
    }
}
