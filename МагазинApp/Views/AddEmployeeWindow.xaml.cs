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
    public partial class AddEmployeeWindow : Window
    {
        private DatabaseHelper dbHelper;

        public AddEmployeeWindow()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee
            {
                ФИО = TextBoxFullName.Text,
                Должность = TextBoxPosition.Text,
                Телефон = TextBoxPhone.Text,
                Email = TextBoxEmail.Text
            };

            dbHelper.AddEmployee(employee);
            MessageBox.Show("Сотрудник успешно добавлен!");
            this.Close();
        }
    }
}
