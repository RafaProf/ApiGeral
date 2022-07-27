
using ApiGeral.Models.DatasBase;
using System;
using System.Net.Http;
using ApiGeral.Netdb;
using System.Web.Http;
using System.Net;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;


namespace ApiGeral.Controllers
{
    public class DatasBaseController : ApiController
    {
        static readonly IDatasBase repositorio = new DatasBaseRepositorio();

        [HttpPost]
        public HttpResponseMessage PostDatasBase(DatasBase item)
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
                var response = Request.CreateResponse<DatasBase>(HttpStatusCode.Created, null);
                string uri = Url.Link("DefaultApi", new { usuario = item.Usuario });
                response.Headers.Location = new Uri(uri); Console.Write(response.Content);
                Global.GetMetodos(Global.OpcExterna);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "A informação não foi incluído com sucesso");
            }
        }
    }
}