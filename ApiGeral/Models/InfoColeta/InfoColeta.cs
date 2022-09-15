using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGeral.Models.InfoColeta
{
    public class InfoColeta
    {
        public int Id { get; set; }
        public string Coleta { get; set; }
        public string Data_criacao { get; set; }
        public string Usuario_Criacao { get; set; }
        public string Status { get; set; }
        public string Lc_descricao { get; set; }
        public int? Pontos_previstos { get; set; }
    }
}