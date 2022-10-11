
using ApiGeral.Models.Login;
using System;
using System.Net.Http;
using ApiGeral.Netdb;
using System.Web.Http;
using System.Net;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using System.Collections.Generic;
using System.Linq;

namespace ApiGeral.Controllers
{
    public class LoginController : ApiController
    {
        static readonly ILogin repositorio = new LoginRepositorio();


        public HttpResponseMessage GetAllLogin()
        {
            int opc = Global.opcGeral;


            if (opc == 0)
            {
                ConnHomolog.GetUsers();

                List<Login> listaLogin = repositorio.GetAll().ToList();

                return Request.CreateResponse<List<Login>>(HttpStatusCode.OK, listaLogin);
                // return repositorio.GetAll();
            }

            else
            {
                return null;
            }

        }

        [HttpPost]
        public HttpResponseMessage PostLogin(Login item)
        {
            bool result = false;

            try
            {
                repositorio.AddPadrao(item); //Chamada add banco de dados
                result = true;
            }
            catch (Exception)
            {

                throw;
            }

            if (item != null)
            {
                var response = Request.CreateResponse<Login>(HttpStatusCode.Created, null);
                string uri = Url.Link("DefaultApi", new { usuario = item.Usuario });
                response.Headers.Location = new Uri(uri); Console.Write(response.Content);
                

                if (ConnHomolog.GetLogin(Global.UsuarioAut, Global.SenhaAut ) == true)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Headers.Add("Resultado", "Sucesso");
                    response.Headers.Location = new Uri("http://solucoes-intellissis.com.br:8");
                    return response;
                }
                else
                {
                    response.Headers.Add("Resultado", "Falhou");
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "A informação não foi validada com sucesso: Tentativa por usuário = " + item.Usuario.ToString());

                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Falha na solicitação de dados: Sem dados");
            }
        }

        public IEnumerable<Login> GetLoginByUser(string usuario)
        {
            GetAllLogin();
            return repositorio.GetAll().Where(
                item => string.Equals(item.Usuario, usuario, StringComparison.OrdinalIgnoreCase)
                );
        }
    }
}