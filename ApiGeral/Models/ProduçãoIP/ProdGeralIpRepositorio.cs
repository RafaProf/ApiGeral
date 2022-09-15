using ApiGeral.Models.Produção;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGeral.Models.ProduçãoIP
{
    public class ProdGeralIpRepositorio : IProdGeralIp
    {
        private List<ProdGeralIp> listaProdGeral = new List<ProdGeralIp>();
        private int _nextId = 0;

        public ProdGeralIpRepositorio()
        {
            while (0 > _nextId)
            {
                Add(new ProdGeralIp
                {
                    Id = _nextId,
                    Usuario = Global.listaBase[_nextId],
                    Quantidade = int.Parse(Global.listaBase2[_nextId]),
                    //DataInicial = Global.listaBase3[_nextId],
                    //DataFinal = Global.listaBase3[_nextId],

                });
            }

        }


        public bool Add(ProdGeralIp item)
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

        public ProdGeralIp AddPadrao(ProdGeralIp item)
        {  //Lista OFF do json
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            listaProdGeral.Add(item);
            return item;
        }

        public ProdGeralIp Get(int id)
        {
            GetAll();
            return listaProdGeral.Find(p => p.Id == id);
        } //Id genérico

        public ProdGeralIp Get(string usuario)
        {
            return listaProdGeral.Find(p => p.Usuario == usuario);
        }

        public IEnumerable<ProdGeralIp> GetAll()  //Getall de tudo, implementa a lista de novo
        {

            _nextId = 0;
            listaProdGeral.Clear();


            int opc = Global.opcGeral;


            if (opc == 0)
            {
                while (Global.listaBase.Count > _nextId)
                {
                    AddPadrao(new ProdGeralIp
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

        public bool Update(ProdGeralIp prod) // Em implementação
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