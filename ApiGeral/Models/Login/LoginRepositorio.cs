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
                Console.WriteLine("test");
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
            listaLogin.Clear();

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
    }

}