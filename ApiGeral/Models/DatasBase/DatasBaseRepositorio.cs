using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGeral.Models.DatasBase
{
    public class DatasBaseRepositorio : IDatasBase
    {
        private List<DatasBase> listaDatasBase = new List<DatasBase>();
        private int _nextId = 0;

        public DatasBaseRepositorio() {

            while (0 > _nextId)
            {
                Add(new DatasBase
                {
                    Id = _nextId,
                    Usuario = Global.listaBase[_nextId],                  
                    DataInicial = Global.listaBase2[_nextId],
                    DataFinal = Global.listaBase3[_nextId],


                });
            }
        }

        public bool Add(DatasBase item)
        {
            bool addResult = false;

            if (item == null)
            {
                return addResult;
            }
            int index = listaDatasBase.FindIndex(s => s.Id == item.Id);

            if (index == -1)
            {

                try
                {
                    //listaUser.Add(item); //Chamar metodo db pra inserir no banco
                    //ConnHomolog.InserirNovoUsuario(item.Usuario, item.Senha, item.Descricao);
                    addResult = true;
                    return addResult;
                }
                catch (Exception)
                {
                    return addResult;
                    throw;
                }
            }

            else
            {
                return addResult;
            }
        }

        public DatasBase AddPadrao(DatasBase item)
        {  //Lista OFF do json
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            item.Id = _nextId++;
            listaDatasBase.Clear();

            listaDatasBase.Add(item);

            try
            {
                Global.DataInicialGeralExt = item.DataInicial;
                Global.DataFinalGeralExt = item.DataFinal;
                Global.UsuarioGeralExt = item.Usuario;
                Global.OpcExterna = item.Opc;
                Global.GetMetodos(item.Opc);
                
            }
            catch (Exception)
            {

                throw;
            }

            return item;
        }

        
    }
}