using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAdv.Models
{
    public class Cliente
    {
        public String Nome { get; set; }
        public String Cpf { get; set; }
        public String Rg { get; set; }
        public int Id { get; set; }
        public String Profissao { get; set; }
        public String Descricao { get; set; }
        public String Telefone { get; set; }


        //adicionar email no banco de dados, pelo que eu vi não colocaram
        public String Email { get; set; }
    }
}
