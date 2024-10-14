using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using МагазинApp.Models;

namespace МагазинApp.DAL
{
    public class DatabaseHelper
    {
        private string connectionString;

        public DatabaseHelper()
        {
            connectionString = ConfigurationManager.ConnectionStrings["МагазинConnectionString"].ConnectionString;
        }

        public List<Product> GetProducts()
        {
            List<Product> products = new List<Product>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Product", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        ID = (int)reader["ID"],
                        Название = reader["Название"].ToString(),
                        Категория = reader["Категория"].ToString(),
                        Производитель = reader["Производитель"].ToString(),
                        Цена = (decimal)reader["Цена"],
                        Количество = (int)reader["Количество"]
                    });
                }
            }
            return products;
        }

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Employee", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    employees.Add(new Employee
                    {
                        ID = (int)reader["ID"],
                        ФИО = reader["ФИО"].ToString(),
                        Должность = reader["Должность"].ToString(),
                        Телефон = reader["Телефон"].ToString(),
                        Email = reader["Email"].ToString()
                    });
                }
            }
            return employees;
        }

        public List<Sale> GetSales()
        {
            List<Sale> sales = new List<Sale>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Sale", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    sales.Add(new Sale
                    {
                        ID = (int)reader["ID"],
                        Дата = (DateTime)reader["Дата"],
                        ID_Продукта = (int)reader["ID_Продукта"],
                        ID_Сотрудника = (int)reader["ID_Сотрудника"],
                        Количество = (int)reader["Количество"],
                        Сумма = (decimal)reader["Сумма"]
                    });
                }
            }
            return sales;
        }

        public List<Stock> GetStock()
        {
            List<Stock> stock = new List<Stock>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Stock", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    stock.Add(new Stock
                    {
                        ID_Продукта = (int)reader["ID_Продукта"],
                        Количество = (int)reader["Количество"]
                    });
                }
            }
            return stock;
        }

        public void AddProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Product (Название, Категория, Производитель, Цена, Количество) VALUES (@Название, @Категория, @Производитель, @Цена, @Количество)", connection);
                command.Parameters.AddWithValue("@Название", product.Название);
                command.Parameters.AddWithValue("@Категория", product.Категория);
                command.Parameters.AddWithValue("@Производитель", product.Производитель);
                command.Parameters.AddWithValue("@Цена", product.Цена);
                command.Parameters.AddWithValue("@Количество", product.Количество);
                command.ExecuteNonQuery();
            }
        }

        public void AddEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Employee (ФИО, Должность, Телефон, Email) VALUES (@ФИО, @Должность, @Телефон, @Email)", connection);
                command.Parameters.AddWithValue("@ФИО", employee.ФИО);
                command.Parameters.AddWithValue("@Должность", employee.Должность);
                command.Parameters.AddWithValue("@Телефон", employee.Телефон);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.ExecuteNonQuery();
            }
        }

        public void AddSale(Sale sale)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Sale (Дата, ID_Продукта, ID_Сотрудника, Количество, Сумма) VALUES (@Дата, @ID_Продукта, @ID_Сотрудника, @Количество, @Сумма)", connection);
                command.Parameters.AddWithValue("@Дата", sale.Дата);
                command.Parameters.AddWithValue("@ID_Продукта", sale.ID_Продукта);
                command.Parameters.AddWithValue("@ID_Сотрудника", sale.ID_Сотрудника);
                command.Parameters.AddWithValue("@Количество", sale.Количество);
                command.Parameters.AddWithValue("@Сумма", sale.Сумма);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateStock(Stock stock)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Stock SET Количество = @Количество WHERE ID_Продукта = @ID_Продукта", connection);
                command.Parameters.AddWithValue("@Количество", stock.Количество);
                command.Parameters.AddWithValue("@ID_Продукта", stock.ID_Продукта);
                command.ExecuteNonQuery();
            }
        }
    }
}