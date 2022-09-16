using ApiGeral.Models.InfoColeta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiGeral.Netdb;
using ApiGeral.Models.Getlocation;

namespace ApiGeral.Models.InfoColeta
{
    public class InfoColetaRepositorio : IInfoColeta
    {
        private List<InfoColeta> listaInfoColeta = new List<InfoColeta>();
        private int _nextId = 0;

        public InfoColetaRepositorio()
        {

            //Criar metodo para adicionar os itens na lista

            while (0 > _nextId)
            {
                Add(new InfoColeta
                {
                    Id = _nextId,
                    Coleta = Global.listaBase[_nextId],
                    Data_criacao = Global.listaBase2[_nextId],
                    Usuario_Criacao = Global.listaBase3[_nextId],
                    Status = Global.listaBase4[_nextId],
                    Lc_descricao = Global.listaBase5[_nextId],
                    Pontos_previstos = int.Parse(Global.listaBase6[_nextId]),
                });
            }

        }

        public InfoColeta Add(InfoColeta item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            listaInfoColeta.Add(item);
            return item;
        }


        public InfoColeta Get(string coleta)
        {
            //GetAll();
            return listaInfoColeta.Find(p => p.Coleta == coleta);
        }

        public IEnumerable<InfoColeta> GetAll()
        {

            _nextId = 0;
            listaInfoColeta.Clear();


            int opc = Global.opcGeral;


            if (opc == 0)
            {
                while (Global.listaBase.Count > _nextId)
                {
                    Add(new InfoColeta
                    {
                        Id = _nextId,
                        Coleta = Global.listaBase[_nextId],
                        Data_criacao = Global.listaBase2[_nextId],
                        Usuario_Criacao = Global.listaBase3[_nextId],
                        Status = Global.listaBase4[_nextId],
                        Lc_descricao = Global.listaBase5[_nextId],
                        Pontos_previstos = int.Parse(Global.listaBase6[_nextId]),
                    });
                }

            }

            else
            {
                return null;
            }

            return listaInfoColeta;
        }



    }
}