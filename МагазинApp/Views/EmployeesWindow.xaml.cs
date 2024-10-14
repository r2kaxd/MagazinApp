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
    public partial class EmployeesWindow : Window
    {
        private DatabaseHelper dbHelper;

        public EmployeesWindow()
        {
            InitializeComponent();
            dbHelper = new DatabaseHelper();
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            List<Employee> employees = dbHelper.GetEmployees();
            DataGridEmployees.ItemsSource = employees;
        }

        private void ButtonAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            AddEmployeeWindow addEmployeeWindow = new AddEmployeeWindow();
            addEmployeeWindow.ShowDialog();
            LoadEmployees();
        }
    }
}