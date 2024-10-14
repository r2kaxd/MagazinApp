using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace МагазинApp.Models
{
    public class Employee
    {
        public int ID { get; set; }
        public string ФИО { get; set; }
        public string Должность { get; set; }
        public string Телефон { get; set; }
        public string Email { get; set; }
    }
}