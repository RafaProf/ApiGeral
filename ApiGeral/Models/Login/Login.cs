using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGeral.Models.Login
{
    public class Login
    {
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Descricao { get; set; }
        public string Email { get; set; }
        public string Link_foto_perfil { get; set; }
        public string Telefone { get; set; }
        public string Localizacao { get; set; }
        public string Ambiente_base { get; set; }


    }
}