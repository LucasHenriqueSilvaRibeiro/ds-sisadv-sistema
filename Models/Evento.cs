using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAdv.Models
{
    public class Evento
    {
        public String Titulo { get; set; }

        public DateTime Data { get; set; }

        public String Horario { get; set; }

        public String Descricao { get; set; }

        public String Importancia { get; set; }

        public Boolean Notificacao { get; set; }
    }
}
