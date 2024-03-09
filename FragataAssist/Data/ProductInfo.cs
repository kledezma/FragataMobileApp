using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FragataAssist.Data
{
    public class ProductInfo
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }

        public decimal Price { get; set; }

        public DateTime Hora { get; set; }

        public DateTime Fecha { get; set; }


    }
}
