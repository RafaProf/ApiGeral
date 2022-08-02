using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApiGeral.Netdb;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Mvc.HttpPutAttribute;
using ApiGeral.Models.ProduçãoIndividual;

namespace ApiGeral.Controllers
{
    public class ProdIndivController : ApiController
    {
        static readonly IProdIndiv repositorio = new ProdIndivRepositorio();

        public HttpResponseMessage GetAllProdIndiv()
        {
            int opc = Global.opcGeral;


            if (opc == 0)
            {
                //ConnEMT.GetProducaoIndiv(Global.DataInicialGeralExt, Global.UsuarioGeralExt); //Método principal do banco de dados
                //Global.GetMetodos(Global.OpcExterna); vai fazer tudo duas vezes


                List<ProdIndiv> listaProdIndiv = repositorio.GetAll().ToList();

                return Request.CreateResponse<List<ProdIndiv>>(HttpStatusCode.OK, listaProdIndiv);
                // return repositorio.GetAll();
            }

            else
            {
                return null;
            }

        }

        public HttpResponseMessage GetProdIndivById(int Id)
        {
            GetAllProdIndiv();
            ProdIndiv prod = repositorio.Get(Id);


            if (prod == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Dados não localizados pelo Id informado");
            }
            else
            {
                return Request.CreateResponse<ProdIndiv>(HttpStatusCode.OK, prod);
            }

        }


        public IEnumerable<ProdIndiv> GetProdByData(string Data)
        {
            GetAllProdIndiv();
            return repositorio.GetAll().Where(
                item => string.Equals(item.Data, Data, StringComparison.OrdinalIgnoreCase)
                );
        }

        public IEnumerable<ProdIndiv> GetProdByUsuario(string Usuario)
        {
            GetAllProdIndiv();
            return repositorio.GetAll().Where(
                item => string.Equals(item.Usuario, Usuario, StringComparison.OrdinalIgnoreCase)
                );
        }


        [HttpPost]
        public HttpResponseMessage PostProdIndiv(ProdIndiv prod)
        {

            //bool result = repositorio.Add(prod); //Chamada add banco de dados

            if (prod != null)
            {
                var response = Request.CreateResponse<ProdIndiv>(HttpStatusCode.Created, null);
                string uri = Url.Link("DefaultApi", new { usuario = prod.Usuario });
                response.Headers.Location = new Uri(uri); Console.Write(response.Content);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Estudante não foi incluído com sucesso");
            }
        }

        [HttpPut]
        public HttpResponseMessage PutProdIndiv(string usuario, ProdIndiv prod)
        {
            prod.Usuario = usuario;

            if (!repositorio.Update(prod))
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