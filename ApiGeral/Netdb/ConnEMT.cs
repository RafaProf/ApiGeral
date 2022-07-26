using Npgsql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;


namespace ApiGeral.Netdb
{
    public class ConnEMT
    {

        static string serverName = "192.168.0.6";
        static string port = "5433";
        static string userName = "postgres";
        static string password = "#intellissis--40";
        static string databaseName = "emt_ip_um";


        static string ConnectionString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                                                serverName, port, userName, password, databaseName);

        public static NpgsqlConnection connectionEmt = new NpgsqlConnection(ConnectionString);



        //IP Location
        public static void ConsultarLocation()
        {
            Global.LimparListas();
            connectionEmt.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(@"select * from localidade", connectionEmt);

            NpgsqlDataReader dados = cmd.ExecuteReader();


            

            while (dados.Read())
            {

                //Criador das tabelas

                try
                {

                    Global.listaBase.Add(dados.GetDouble(0).ToString());
                    Global.listaBase2.Add(dados.GetInt32(1).ToString());
                    Global.listaBase3.Add(dados.GetString(2));
                    //Global.listaBase4.Add(dados.GetString(3));
                    // Global.listaBase5.Add(dados.GetString(4));
                    // Global.listaBase6.Add(dados.GetString(5));
                    // Global.listaBase7.Add(dados.GetString(6));


                    try
                    {
                        Global.listaBase8.Add(dados.GetDouble(7).ToString());
                    }
                    catch (Exception)
                    {

                        Global.listaBase8.Add("0");
                    }


                    try
                    {
                        Global.listaBase9.Add(dados.GetInt32(8).ToString());
                    }
                    catch (Exception)
                    {

                        Global.listaBase9.Add("0");
                    }


                    //Global.listaBase10.Add(dados.GetString(9).ToString());
                }
                catch (Exception)
                {

                    throw;
                }


            }

            dados.Close();
                     
            connectionEmt.Close();
        }

        public static void GetProducaoGeral(string date1, string date2) 
        {
            Global.LimparListas();
            connectionEmt.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(@"select usuario , COUNT(*) QTDE from (
select distinct usuario, mslink_pg from historico_uso_mutuo hum where date(data_operacao) between '01/07/2022' and '31/07/2022' and 
tipo_operacao = 'INCLUSAO') TOT
group by usuario", connectionEmt);

            NpgsqlDataReader dados = cmd.ExecuteReader();




            while (dados.Read())
            {

                //Criador das tabelas

                try
                {

                    Global.listaBase.Add(dados.GetString(0));
                    Global.listaBase2.Add(dados.GetInt32(1).ToString());
                    //Global.listaBase3.Add(dados.GetString(2));
                    //Global.listaBase4.Add(dados.GetString(3));
                    // Global.listaBase5.Add(dados.GetString(4));
                    // Global.listaBase6.Add(dados.GetString(5));
                    // Global.listaBase7.Add(dados.GetString(6));


                    


                    //Global.listaBase10.Add(dados.GetString(9).ToString());
                }
                catch (Exception)
                {

                    throw;
                }


            }

            dados.Close();

            connectionEmt.Close();
        }
    }
}
