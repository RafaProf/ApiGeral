﻿using Npgsql;
using System;



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

        public static bool GetProducaoGeral(string date1, string date2) 
        {
            Global.LimparListas();
            connectionEmt.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(@"select usuario , COUNT(*) QTDE from (
select distinct usuario, mslink_pg from historico_uso_mutuo hum where date(data_operacao) between '" + date1 + "' and '" + date2 + "' and " +
"tipo_operacao = 'INCLUSAO') TOT " +
"group by usuario", connectionEmt);

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
            return true;
        }

        public static bool GetProducaoIndiv(string data, string usuario)
        {
            Global.LimparListas();
            connectionEmt.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(@"select usuario, data_operacao, COUNT(*) QTDE from (
	select distinct usuario, mslink_pg, date(data_operacao) as data_operacao 
	from historico_uso_mutuo hum 
	where date(data_operacao) between '"+ data + "' and current_date " +
    " and tipo_operacao = 'INCLUSAO') TOT where usuario like '%" + usuario + "%' " +
    " group by data_operacao, usuario order by data_operacao asc;", connectionEmt);

            NpgsqlDataReader dados = cmd.ExecuteReader();


            try
            {

                if (dados.HasRows)
                {
                    Console.WriteLine("aff");
                }
                else
                {
                    int i = 0;
                    while (i != 3)
                    {
                        Global.listaBase.Add(usuario);
                        Global.listaBase2.Add(DateTime.Now.ToString("dd/MM/yyyy"));
                        Global.listaBase3.Add("0");
                        i++;

                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine("vazio");
            }

            while (dados.Read())
            {

                //Criador das tabelas

                try
                {

                    Global.listaBase.Add(dados.GetString(0));
                    Global.listaBase2.Add(dados.GetDate(1).ToString());
                    Global.listaBase3.Add(dados.GetInt32(2).ToString());


                }
                catch (Exception)
                {
                    dados.Close();

                    connectionEmt.Close();
                    throw;
                }
                

            }
            
            dados.Close();

            connectionEmt.Close();
            return true;
        }
    }
}
