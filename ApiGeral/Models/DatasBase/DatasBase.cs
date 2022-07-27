using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGeral.Models.DatasBase
{
    public class DatasBase
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }
        public string Opc { get; set; }
    }
}