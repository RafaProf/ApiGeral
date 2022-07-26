using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGeral.Models.Produção
{
    public class ProdGeralRepositorio : IProdGeral
    {
        private List<ProdGeral> listaProdGeral = new List<ProdGeral>();
        private int _nextId = 0;


        public ProdGeralRepositorio() {
            while (Global.listaBase.Count > _nextId)
            {
                Add(new ProdGeral
                {
                    Id = _nextId,
                    Usuario = Global.listaBase[_nextId],
                    Quantidade = int.Parse(Global.listaBase2[_nextId]),
                    //DataInicial = Global.listaBase3[_nextId],
                    //DataFinal = Global.listaBase3[_nextId],

                });
            }

        }

        public bool Add(ProdGeral item)
        {
            bool addResult = false;

            if (item == null)
            {
                return addResult;
            }
            int index = listaProdGeral.FindIndex(s => s.Id == item.Id);

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

        public ProdGeral AddPadrao(ProdGeral item)
        {  //Lista OFF do json
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            listaProdGeral.Add(item);
            return item;
        }

        public ProdGeral Get(int id)
        {
            GetAll();
            return listaProdGeral.Find(p => p.Id == id);
        } //Id genérico

        public ProdGeral Get(string usuario)
        {
            return listaProdGeral.Find(p =>p.Usuario == usuario);
        }

        public IEnumerable<ProdGeral> GetAll()  //Getall de tudo, implementa a lista de novo
        {

            _nextId = 0;
            listaProdGeral.Clear();


            int opc = Global.opcGeral;


            if (opc == 0)
            {
                while (Global.listaBase.Count > _nextId)
                {
                    AddPadrao(new ProdGeral
                    {
                        Id = _nextId,
                        Usuario = Global.listaBase[_nextId],
                        Quantidade = int.Parse(Global.listaBase2[_nextId]),
                        //DataInicial = Global.listaBase3[_nextId],
                        //DataFinal = Global.listaBase3[_nextId],
                    });
                }

            }

            else
            {
                return null;
            }

            return listaProdGeral;
        }


        public bool Update(ProdGeral prod) // Em implementação
        {
            if (prod == null)
            {
                throw new ArgumentNullException("Usuário");
            }
            int index = listaProdGeral.FindIndex(s => s.Usuario == prod.Usuario);
            if (index == -1)
            {
                return false;
            }
            listaProdGeral.RemoveAt(index);
            listaProdGeral.Add(prod);
            return true;
        }
    }
}