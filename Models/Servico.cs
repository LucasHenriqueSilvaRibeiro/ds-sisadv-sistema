﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAdv.Models
{
    public class Servico
    {
        public int Id { get; set; }

        public int Cliente { get; set; }

        public String ClienteNome { get; set; }

        public DateTime Data { get; set; }

        public String Tipo { get; set; }

        public double Valor { get; set; }   

        public String Descricao { get; set; }

        public int Advogado { get; set; }

        public String AdvogadoNome { get; set; }

        //public int Evento { get; set; }
    }
}
