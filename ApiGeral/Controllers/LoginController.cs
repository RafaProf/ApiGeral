﻿
using ApiGeral.Models.Login;
using System;
using System.Net.Http;
using ApiGeral.Netdb;
using System.Web.Http;
using System.Net;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;


namespace ApiGeral.Controllers
{
    public class LoginController : ApiController
    {
        static readonly ILogin repositorio = new LoginRepositorio();

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
                    return response;
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "A informação não foi validada com sucesso");

                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "A informação não foi incluído com sucesso");
            }
        }
    }
}