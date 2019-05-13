﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Cargo
    {
        public long? CargoId { get; set; }
        public string CargoNome { get; set; }

        public virtual ICollection<Integrante> Integrantes { get; set; }
    }
}
