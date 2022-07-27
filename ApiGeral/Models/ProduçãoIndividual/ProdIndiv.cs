using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGeral.Models.ProduçãoIndividual
{
    public class ProdIndiv
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public int Quantidade { get; set; }
        public string Data { get; set; }
    }
}