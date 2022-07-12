using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiGeral.Models.Getlocation;
using ApiGeral.Netdb;

namespace ApiGeral.Models.Getlocation
{
    public class GetLocationRepositorio : IGetLocation
    {
        private List<GetLocation> listaGetLocation = new List<GetLocation>();
        private int _nextId = 0;

        public GetLocationRepositorio()
        {

            //Criar metodo para adicionar os itens na lista
            //Add(new GetLocation { id = 01, lc_id = 01, id_regiao = 01, lc_descricao = "rafa", lc_coef_a = "a", lc_coef_b = "b", lc_coef_c = "c", lc_coef_d = "d", numeric = 20, id_poligono = 01, codigo_uen = "aff" });


            while (Global.listaBase.Count > _nextId)
            {
                Add(new GetLocation
                {
                    Id = _nextId,
                    Lc_id = double.Parse(Global.listaBase[_nextId]),
                    Id_regiao = int.Parse(Global.listaBase2[_nextId]),
                    Lc_descricao = Global.listaBase3[_nextId],
                    // lc_coef_a = Global.listaBase4[_nextId],
                    //...
                    Numeric = double.Parse(Global.listaBase8[_nextId]),
                    Id_poligono = int.Parse(Global.listaBase9[_nextId]),
                });
            }

        }

        public GetLocation Add(GetLocation item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            listaGetLocation.Add(item);
            return item;
        }

        public GetLocation Get(double lc_id)
        {

            return listaGetLocation.Find(p => p.Lc_id == lc_id);
        }
        

        public IEnumerable<GetLocation> GetAll()
        {
            
            _nextId = 0;
            listaGetLocation.Clear();


            int opc = Global.opcGeral;


            if (opc == 0)
            {
                while (Global.listaBase.Count > _nextId)
                {
                    Add(new GetLocation
                    {
                        Id = _nextId,
                        Lc_id = double.Parse(Global.listaBase[_nextId]),
                        Id_regiao = int.Parse(Global.listaBase2[_nextId]),
                        Lc_descricao = Global.listaBase3[_nextId],
                        // lc_coef_a = Global.listaBase4[_nextId],
                        //...
                        Numeric = double.Parse(Global.listaBase8[_nextId]),
                        Id_poligono = int.Parse(Global.listaBase9[_nextId]),
                    });
                }
                //Global.LimparListas();
            }

            else
            {
                return null;
            }

            return listaGetLocation;
        }

        public bool Update(GetLocation location)
        {
            if (location == null)
            {
                throw new ArgumentNullException("Localidade");
            }
            int index = listaGetLocation.FindIndex(s => s.Lc_id == location.Lc_id);
            if (index == -1)
            {
                return false;
            }
            listaGetLocation.RemoveAt(index);
            listaGetLocation.Add(location);
            return true;
        }
    }
}