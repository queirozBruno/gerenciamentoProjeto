﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Projeto
    {
        public long? ProjetoId { get; set; }
        public string ProjetoNome { get; set; }
        public string ProjetoDescricao { get; set; }
        public string ProjetoStatus { get; set; }

        public virtual ICollection<Integrante> Integrantes { get; set; }
        public virtual ICollection<Funcionalidade> Funcionalidades { get; set; }
    }
}
