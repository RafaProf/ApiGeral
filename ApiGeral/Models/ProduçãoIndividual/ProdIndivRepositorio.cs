using ApiGeral.Models.ProduçãoIndividual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGeral.Models.ProduçãoIndividual
{
    public class ProdIndivRepositorio : IProdIndiv
    {
        private List<ProdIndiv> listaProdIndiv = new List<ProdIndiv>();
        private int _nextId = 0;


        public ProdIndivRepositorio()
        {
            
            while (0 > _nextId)
            {
                Add(new ProdIndiv
                {
                    Id = _nextId,
                    Usuario = Global.listaBase[_nextId],
                    Data = Global.listaBase2[_nextId],
                    Quantidade = int.Parse(Global.listaBase3[_nextId]),



                });
            }

        }

        public bool Add(ProdIndiv item)
        {
            bool addResult = false;

            if (item == null)
            {
                return addResult;
            }
            int index = listaProdIndiv.FindIndex(s => s.Id == item.Id);

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

        public ProdIndiv AddPadrao(ProdIndiv item)
        {  //Lista OFF do json
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            listaProdIndiv.Add(item);
            return item;
        }

        public ProdIndiv Get(int id)
        {
            GetAll();
            return listaProdIndiv.Find(p => p.Id == id);
        } //Id genérico

        public ProdIndiv Get(string usuario)
        {
            return listaProdIndiv.Find(p => p.Usuario == usuario);
        }

        public IEnumerable<ProdIndiv> GetAll()  //Getall de tudo, implementa a lista de novo
        {

            _nextId = 0;
            listaProdIndiv.Clear();


            int opc = Global.opcGeral;


            if (opc == 0)
            {
                while (Global.listaBase.Count > _nextId)
                {
                    AddPadrao(new ProdIndiv
                    {
                        Id = _nextId,
                        Usuario = Global.listaBase[_nextId],
                        Data = Global.listaBase2[_nextId],
                        Quantidade = int.Parse(Global.listaBase3[_nextId]),
                        
                        
                    });
                }

            }

            else
            {
                return null;
            }

            return listaProdIndiv;
        }


        public bool Update(ProdIndiv prod) // Em implementação
        {
            if (prod == null)
            {
                throw new ArgumentNullException("Usuário");
            }
            int index = listaProdIndiv.FindIndex(s => s.Usuario == prod.Usuario);
            if (index == -1)
            {
                return false;
            }
            listaProdIndiv.RemoveAt(index);
            listaProdIndiv.Add(prod);
            return true;
        }
    }
}