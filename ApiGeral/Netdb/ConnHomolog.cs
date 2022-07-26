using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using ApiGeral.Models.User;
using System.Text;

namespace ApiGeral.Netdb
{
    public class ConnHomolog
    {
        static string serverName = "192.168.0.9";
        static string port = "5432";
        static string userName = "postgres";
        static string password = "#intellissis--40";
        static string databaseName = "db_homologacao";

        static string ConnectionString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                                                serverName, port, userName, password, databaseName);

        public static NpgsqlConnection connectionHomol = new NpgsqlConnection(ConnectionString);
        public static HttpClient client = new HttpClient();

        public static void GetUsers() {

            Global.LimparListas();
            connectionHomol.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(@"select usuario, senha, descricao from test_user_api", connectionHomol);

            NpgsqlDataReader dados = cmd.ExecuteReader();


            while (dados.Read())
            {

                //Criador das tabelas

                try
                {

                    Global.listaBase.Add(dados.GetString(0));
                    Global.listaBase2.Add(dados.GetString(1));
                    Global.listaBase3.Add(dados.GetString(2));
                    
                }
                catch (Exception)
                {

                    throw;
                }


            }

            dados.Close();

            connectionHomol.Close();

        }


        public static void InserirNovoUsuario(string user, string pass, string nome)
        {
            connectionHomol.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(
                @"insert into test_user_api 
                (usuario, senha, descricao, email, telefone, link_foto_perfil )
                values
                ('"+user+"', '"+pass+"', '"+nome+"', null, null, null )", connectionHomol);

            NpgsqlDataReader dados = cmd.ExecuteReader();


            connectionHomol.Close();

        }



        public static void testAsync() //emulação de método externo
        {

            try
            {
                var novo = new User()
                {
                    Usuario = "testei",
                    Id = 500,
                    Senha = "123456",
                    Descricao = "aff rafa"
                };

                var response =  client.PostAsJsonAsync("https://localhost:44375/api/user", novo);
                //response.EnsureSuccessStatusCode();
               


            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public async void testlol()
        {
            string myJson = "{'Username': 'myusername','Password':'pass'}";
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(
                    "http://yourUrl",
                     new StringContent(myJson, Encoding.UTF8, "application/json"));
            }
        }
    }
}