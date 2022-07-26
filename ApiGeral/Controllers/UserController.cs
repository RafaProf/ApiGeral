using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApiGeral.Models.User;
using ApiGeral.Netdb;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Mvc.HttpPutAttribute;

namespace ApiGeral.Controllers
{
    public class UserController : ApiController
    {
        static readonly IUser repositorio = new UserRepositorio();

        public HttpResponseMessage GetAllUser()
        {
            int opc = Global.opcGeral;


            if (opc == 0)
            {
                ConnHomolog.GetUsers();

                

                List<User> listaUser = repositorio.GetAll().ToList();

                return Request.CreateResponse<List<User>>(HttpStatusCode.OK, listaUser);
                // return repositorio.GetAll();
            }

            else
            {
                return null;
            }

        }

        public HttpResponseMessage GetUserById(int Id)
        {
            GetAllUser();
            User user = repositorio.Get(Id);


            if (user == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Dados não localizados pelo Id informado");
            }
            else
            {
                return Request.CreateResponse<User>(HttpStatusCode.OK, user);
            }

        }


        public IEnumerable<User> GetUserByUsuario(string Usuario)
        {
            GetAllUser();
            return repositorio.GetAll().Where(
                item => string.Equals(item.Usuario, Usuario, StringComparison.OrdinalIgnoreCase)
                );
        }

        public IEnumerable<User> GetUserByDescricao(string descricao) // categoria do link json fica nos atributos dos metodos controller
        {
            GetAllUser();
            return repositorio.GetAll().Where(
                item => string.Equals(item.Descricao, descricao.ToString(), StringComparison.OrdinalIgnoreCase)
                );
        }


        [HttpPost]
        public HttpResponseMessage PostLocation(User user)
        {
            
            bool result = repositorio.Add(user); //Chamada add banco de dados

            if (result)
            {
                var response = Request.CreateResponse<User>(HttpStatusCode.Created, user);
                string uri = Url.Link("DefaultApi", new { usuario = user.Usuario });
                response.Headers.Location = new Uri(uri); Console.Write(response.Content);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Estudante não foi incluído com sucesso");
            }
        }

        [HttpPut]
        public HttpResponseMessage PutLocation(string usuario, User user)
        {
            user.Usuario = usuario;

            if (!repositorio.Update(user))
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                    "Não foi possível atualizar os dados pelo id informado");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
    }
}