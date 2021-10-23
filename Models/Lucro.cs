using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAdv.Models
{
    public class Lucro
    {
        public int Id { get; set; }
        public String Origem { get; set; }
        public String FormaPagamento { get; set; }
        public String Descricao { get; set; }
        public DateTime? Data { get; set; }
        public Boolean Mensal { get; set; }
        public double Valor { get; set; }

        //Acho que precisará criar uma tela para adicionar caixa
        public Caixa Caixa { get; set; }

        //verificar se há a necessidade de criar uma tela para processo, que o Jackson pediu pra adicionar no banco de dados ou pode ser direoto  o serviço
        public Processo Processo { get; set; }
    }
}
