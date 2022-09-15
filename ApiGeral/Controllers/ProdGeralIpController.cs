using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApiGeral.Models.ProduçãoIP;
using ApiGeral.Netdb;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Mvc.HttpPutAttribute;
using ApiGeral.Models.Produção;

namespace ApiGeral.Controllers
{
    public class ProdGeralIpController : ApiController
    {

        static readonly IProdGeralIp repositorio = new ProdGeralIpRepositorio();


        public HttpResponseMessage GetAllProdGeralIp()
        {
            int opc = Global.opcGeral;


            if (opc == 0)
            {
                //ConnEMT.GetProducaoGeral("01/07/2022", "31/07/2022");



                List<ProdGeralIp> listaProdGeral = repositorio.GetAll().ToList();

                return Request.CreateResponse<List<ProdGeralIp>>(HttpStatusCode.OK, listaProdGeral);
                // return repositorio.GetAll();
            }

            else
            {
                return null;
            }

        }

        public HttpResponseMessage GetProdGeralIpById(int Id)
        {
            GetAllProdGeralIp();
            ProdGeralIp prod = repositorio.Get(Id);


            if (prod == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Dados não localizados pelo Id informado");
            }
            else
            {
                return Request.CreateResponse<ProdGeralIp>(HttpStatusCode.OK, prod);
            }

        }

        public IEnumerable<ProdGeralIp> GetProdByDataInicial(string DataInicial)
        {
            GetAllProdGeralIp();
            return repositorio.GetAll().Where(
                item => string.Equals(item.DataInicial, DataInicial, StringComparison.OrdinalIgnoreCase)
                );
        }

        public IEnumerable<ProdGeralIp> GetProdByUsuario(string Usuario)
        {
            GetAllProdGeralIp();
            return repositorio.GetAll().Where(
                item => string.Equals(item.Usuario, Usuario, StringComparison.OrdinalIgnoreCase)
                );
        }

        public IEnumerable<ProdGeralIp> GetProdByDatas(string DataInicial, string DataFinal) // categoria do link json fica nos atributos dos metodos controller
        {
            GetAllProdGeralIp();
            return repositorio.GetAll().Where(
                item => string.Equals(item.DataInicial, DataInicial, StringComparison.OrdinalIgnoreCase)
                && string.Equals(item.DataFinal, DataFinal, StringComparison.OrdinalIgnoreCase)
                );
        }


        [HttpPost]
        public HttpResponseMessage PostProdGeralIp(ProdGeralIp prod)
        {

            //bool result = repositorio.Add(prod); //Chamada add banco de dados

            if (prod != null)
            {
                var response = Request.CreateResponse<ProdGeralIp>(HttpStatusCode.Created, null);
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
        public HttpResponseMessage PutLocation(string usuario, ProdGeralIp prod)
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