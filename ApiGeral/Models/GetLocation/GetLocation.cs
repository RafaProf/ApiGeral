using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ApiGeral.Models.Getlocation
{
    public class GetLocation
    {
        public int Id { get; set; }
        public double Lc_id { get; set; }
        public int Id_regiao { get; set; }
        public string Lc_descricao { get; set; }

        public double Numeric { get; set; }
        public int? Id_poligono { get; set; }

    }
}