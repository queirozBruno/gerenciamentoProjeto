﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    class Publicacao
    {
        public long? PublicacaoId { get; set; }
        public string PublicacaoTitulo { get; set; }
        public string PublicacaoEditora { get; set; }
        public DateTime PublicaçãoData { get; set; }
        public string PublicacaoUrl { get; set; }
    }
}
