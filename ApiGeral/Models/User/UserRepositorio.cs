using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiGeral.Models.User;
using ApiGeral.Netdb;

namespace ApiGeral.Models.User
{
    public class UserRepositorio : IUser
    {
        private List<User> listaUser = new List<User>();
        private int _nextId = 0;

        public UserRepositorio()
        {
            while (Global.listaBase.Count > _nextId)
            {
                Add(new User
                {
                    Id = _nextId,
                    Usuario = Global.listaBase[_nextId],
                    Senha = (Global.listaBase2[_nextId]),
                    Descricao = Global.listaBase3[_nextId],

                });
            }
        }

        public bool Add(User item)
        {
            bool addResult = false;

            if (item == null)
            {
                return addResult;
            }
            int index = listaUser.FindIndex(s => s.Id == item.Id);

            if (index == -1)
            {               

                try
                {
                    //listaUser.Add(item); //Chamar metodo db pra inserir no banco
                    ConnHomolog.InserirNovoUsuario(item.Usuario, item.Senha, item.Descricao);
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
        } //Inserir no Banco de Dados

        public User AddPadrao(User item) {  //Lista OFF do json
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            listaUser.Add(item);
            return item;
        }

        public User Get(int id)
        {
            //GetAll();
            return listaUser.Find(p => p.Id == id);
        } //Id genérico


        public IEnumerable<User> GetAll()  //Getall de tudo, implementa a lista de novo
        {

            _nextId = 0;
            listaUser.Clear();


            int opc = Global.opcGeral;


            if (opc == 0)
            {
                while (Global.listaBase.Count > _nextId)
                {
                    AddPadrao(new User
                    {
                        Id = _nextId,
                        Usuario = Global.listaBase[_nextId],
                        Senha = (Global.listaBase2[_nextId]),
                        Descricao = Global.listaBase3[_nextId],
                    });
                }

            }

            else
            {
                return null;
            }

            return listaUser;
        }


        public bool Update(User user) // Em implementação
        {
            if (user == null)
            {
                throw new ArgumentNullException("Usuário");
            }
            int index = listaUser.FindIndex(s => s.Usuario == user.Usuario);
            if (index == -1)
            {
                return false;
            }
            listaUser.RemoveAt(index);
            listaUser.Add(user);
            return true;
        }
    }
}