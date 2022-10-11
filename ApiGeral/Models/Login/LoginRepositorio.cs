using ApiGeral.Models.Getlocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGeral.Models.Login
{
    public class LoginRepositorio : ILogin
    {
        private List<Login> listaLogin = new List<Login>();
        private int _nextId = 0;


        public LoginRepositorio()
        {

            while (0 > _nextId)
            {
                Add(new Login
                {
                    Id = _nextId,
                    Usuario = Global.listaBase[_nextId],
                    //Senha = int.Parse(Global.listaBase2[_nextId]),
                    Descricao = Global.listaBase3[_nextId],
                    Email = Global.listaBase4[_nextId],
                    Telefone = Global.listaBase5[_nextId],
                    Link_foto_perfil = Global.listaBase6[_nextId],
                    Localizacao = Global.listaBase7[_nextId],
                    Ambiente_base = Global.listaBase8[_nextId],
                });
            }
        }

        public bool Add(Login item)
        {
            bool addResult = false;

            if (item == null)
            {
                return addResult;
            }
            int index = listaLogin.FindIndex(s => s.Id == item.Id);

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

        public Login AddPadrao(Login item)
        {  //Lista OFF do json
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            item.Id = _nextId++;
            //listaLogin.Clear(); adicionar usuario

            listaLogin.Add(item);

            try
            {
                Global.UsuarioAut = item.Usuario;
                Global.SenhaAut = item.Senha;

                //metodo auth

            }
            catch (Exception)
            {

                throw;
            }

            return item;
        }

        public Login AddPadrao2(Login item)
        {  //Lista OFF do json
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            item.Id = _nextId++;
            listaLogin.Clear(); //adicionar usuario

            listaLogin.Add(item);

            try
            {
                Global.UsuarioAut = item.Usuario;
                Global.SenhaAut = item.Senha;

                //metodo auth

            }
            catch (Exception)
            {

                throw;
            }

            return item;
        }


        public Login Get(string usuario)
        {
            //GetAll();
            return listaLogin.Find(p => p.Usuario == usuario);
        }

        public IEnumerable<Login> GetAll()
        {

            _nextId = 0;
            listaLogin.Clear();


            int opc = Global.opcGeral;


            if (opc == 0)
            {
                while (Global.listaBase.Count > _nextId)
                {
                    AddPadrao(new Login
                    {
                        Id = _nextId,
                        Usuario = Global.listaBase[_nextId],
                        //Senha = int.Parse(Global.listaBase2[_nextId]),
                        Descricao = Global.listaBase3[_nextId],
                        Email = Global.listaBase4[_nextId],
                        Telefone = Global.listaBase5[_nextId],
                        Link_foto_perfil = Global.listaBase6[_nextId],
                        Localizacao = Global.listaBase7[_nextId],
                        Ambiente_base = Global.listaBase8[_nextId],
                    }); 
                }

            }

            else
            {
                return null;
            }

            return listaLogin;
        }
    }

}