using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApiGeral.Models.Getlocation;
using ApiGeral.Netdb;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Mvc.HttpPutAttribute;

namespace ApiGeral.Controllers
{
    public class GetLocationController : ApiController
    {
        static readonly IGetLocation repositorio = new GetLocationRepositorio();

        public HttpResponseMessage GetAllLocationOn()
        {
            int opc = Global.opcGeral;
            

            if (opc == 0)
            {
                ConnEMT.ConsultarLocation();

                List<GetLocation> listaLocation = repositorio.GetAll().ToList();

                return Request.CreateResponse<List<GetLocation>>(HttpStatusCode.OK, listaLocation);
                // return repositorio.GetAll();
            }

            else
            {
                return null;
            }

        }

        public HttpResponseMessage GetLocationById(int id)
        {
            GetLocation getLocation = repositorio.Get(id);
            

            if (getLocation == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Dados não localizados pelo Id informado");
            }
            else
            {
                return Request.CreateResponse<GetLocation>(HttpStatusCode.OK, getLocation);
            }

        }


        public IEnumerable<GetLocation> GetLocationByDesc(string lc_descricao)
        {
            
            return repositorio.GetAll().Where(
                item => string.Equals(item.Lc_descricao, lc_descricao, StringComparison.OrdinalIgnoreCase)
                );
        }

        public IEnumerable<GetLocation> GetLocationByIdPol(int id_poligono) // categoria do link json fica nos atributos dos metodos controller
        {
            //Global.LimparListas();
            return repositorio.GetAll().Where(
                item => string.Equals(item.Id_poligono.ToString(), id_poligono.ToString(), StringComparison.OrdinalIgnoreCase)
                );
        }


        [HttpPost]
        public HttpResponseMessage PostLocation(GetLocation getLocation)
        {

            var response = Request.CreateResponse<GetLocation>(HttpStatusCode.Created, getLocation);
            string uri = Url.Link("DefaultApi", new { lc_id = getLocation.Lc_id });
            response.Headers.Location = new Uri(uri);
            return response;
        }
        [HttpPut]
        public HttpResponseMessage PutLocation(double lc_id, GetLocation getLocation)
        {
            getLocation.Lc_id = lc_id;

            if (!repositorio.Update(getLocation))
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