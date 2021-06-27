using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAdv
{
    public class Servico
    {
        //Observação: criei fora da pasta Domínio porque estava dando erro :(
        public int Id { get; set; }

        public String Cliente { get; set; }

        public double Valor { get; set; }

        public String Descricao { get; set; }
    }
}
