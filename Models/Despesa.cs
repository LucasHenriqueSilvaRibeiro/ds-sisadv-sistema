using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAdv.Models
{
    public class Despesa
    {
        public String Origem { get; set; }
        public DateTime? Data { get; set; }
        public Boolean Mensal { get; set; }
        public double Valor { get; set; }
    }
}
