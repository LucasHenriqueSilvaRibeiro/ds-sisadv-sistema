using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAdv.Dominio
{
    public class Servico
    {
        public int Id { get; set; }

        public String Cliente { get; set; }

        public double Valor { get; set; }
        
        public String Descricao { get; set; }
    }
}
