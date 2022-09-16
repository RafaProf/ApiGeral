using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApiGeral.Models.InfoColeta;
using ApiGeral.Netdb;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Mvc.HttpPutAttribute;
using ApiGeral.Models.Getlocation;

namespace ApiGeral.Controllers
{
    public class InfoColetaController : ApiController
    {
        static readonly IInfoColeta repositorio = new InfoColetaRepositorio();

        public HttpResponseMessage GetAllInfoColeta()
        {
            int opc = Global.opcGeral;


            if (opc == 0)
            {
                //ConnEMT.GetInfoLote("8289");

                List<InfoColeta> listaColeta = repositorio.GetAll().ToList();

                return Request.CreateResponse<List<InfoColeta>>(HttpStatusCode.OK, listaColeta);
                // return repositorio.GetAll();
            }

            else
            {
                return null;
            }

        }


        public HttpResponseMessage GetInfoColetaByColeta(string Coleta)
        {
            GetAllInfoColeta();
            InfoColeta infoColeta = repositorio.Get(Coleta);


            if (infoColeta == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Dados não localizados pelo Id informado");
            }
            else
            {
                return Request.CreateResponse<InfoColeta>(HttpStatusCode.OK, infoColeta);
            }

        }

        public IEnumerable<InfoColeta> InfoColetaByDesc(string Coleta)
        {
            GetAllInfoColeta();
            return repositorio.GetAll().Where(
                item => string.Equals(item.Coleta, Coleta, StringComparison.OrdinalIgnoreCase)
                );
        }
    }
}