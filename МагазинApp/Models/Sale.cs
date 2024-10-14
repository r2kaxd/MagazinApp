using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace МагазинApp.Models
{
    public class Sale
    {
        public int ID { get; set; }
        public DateTime Дата { get; set; }
        public int ID_Продукта { get; set; }
        public int ID_Сотрудника { get; set; }
        public int Количество { get; set; }
        public decimal Сумма { get; set; }
    }
}