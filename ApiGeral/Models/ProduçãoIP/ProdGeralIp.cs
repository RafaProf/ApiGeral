using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGeral.Models.ProduçãoIP
{
    public class ProdGeralIp
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public int Quantidade { get; set; }
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }
    }
}