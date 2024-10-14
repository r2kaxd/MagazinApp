using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace МагазинApp.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Название { get; set; }
        public string Категория { get; set; }
        public string Производитель { get; set; }
        public decimal Цена { get; set; }
        public int Количество { get; set; }
    }
}