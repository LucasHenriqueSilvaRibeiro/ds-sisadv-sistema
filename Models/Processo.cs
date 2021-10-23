using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAdv.Models
{
    public class Processo
    {
        public int Id { get; set; }
        public double valor { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataProcesso { get; set; }
        public string Status { get; set; }
        public string Resultado { get; set; }

        //acho que dá pra pegar o código de cliente e advogado pelo próprio servico, verifique isso no banco de dados quem for ficar com essa tela
        public Servico servico { get; set; }
    }
}