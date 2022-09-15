using Npgsql;
using System;


namespace ApiGeral.Netdb
{
    public class ConnRJ
    {
        static readonly string serverName = "192.168.0.6";
        static readonly string port = "5433";
        static readonly string userName = "postgres";
        static readonly string  password = "#intellissis--40";
        static readonly string databaseName = "enel_rj_um";


        static string ConnectionString = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                                                serverName, port, userName, password, databaseName);

        public static NpgsqlConnection connectionRJ = new NpgsqlConnection(ConnectionString);


        //Produção Geral 
        public static bool GetProducaoGeral(string date1, string date2)
        {
            Global.LimparListas();
            connectionRJ.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(@"select usuario , COUNT(*) QTDE from (
select distinct usuario, mslink_pg from historico_uso_mutuo hum where date(data_operacao) between '" + date1 + "' and '" + date2 + "' and " +
"tipo_operacao = 'INCLUSAO') TOT " +
"group by usuario", connectionRJ);

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

            connectionRJ.Close();
            return true;
        }

        //Produção Individual
        public static bool GetProducaoIndiv(string data, string usuario)
        {
            Global.LimparListas();
            connectionRJ.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(@"select usuario, data_operacao, COUNT(*) QTDE from (
	select distinct usuario, mslink_pg, date(data_operacao) as data_operacao 
	from historico_uso_mutuo hum 
	where date(data_operacao) between '" + data + "' and current_date " +
    " and tipo_operacao = 'INCLUSAO') TOT where usuario like '%" + usuario + "%' " +
    " group by data_operacao, usuario order by data_operacao asc;", connectionRJ);

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

                    connectionRJ.Close();
                    throw;
                }


            }

            dados.Close();

            connectionRJ.Close();
            return true;
        }

        //Informações Sobre Lotes
        public static bool GetInfoLote(string lote)
        {
            Global.LimparListas();
            connectionRJ.Open();

            NpgsqlCommand cmd = new NpgsqlCommand(@"select 	c.id_coleta, 
		date(c.data_criacao) as data_criacao , 
		c.us_criacao, 
		c.status,
		l.lc_descricao, 
		count(pg.mslink)
from coleta c
join ponto_geografico pg 
	on c.id_coleta = pg.id_coleta 
join localidade l 
	on pg.lc_id = l.lc_id 
where c.id_coleta = '"+ lote +
"' group by c.id_coleta, c.data_criacao, c.us_criacao, c.status, l.lc_descricao ", connectionRJ);

            NpgsqlDataReader dados = cmd.ExecuteReader();


            while (dados.Read())
            {
                //Criador das tabelas
                try
                {

                    Global.listaBase.Add(dados.GetString(0));
                    Global.listaBase2.Add(dados.GetDate(1).ToString());
                    Global.listaBase3.Add(dados.GetString(2));
                    Global.listaBase4.Add(dados.GetString(3));
                    Global.listaBase5.Add(dados.GetString(4));
                    Global.listaBase6.Add(dados.GetInt32(5).ToString());
                    // Global.listaBase7.Add(dados.GetString(6));

                    //Global.listaBase10.Add(dados.GetString(9).ToString());
                }
                catch (Exception)
                {

                    throw;
                }


            }

            dados.Close();

            connectionRJ.Close();
            return true;
        }
    }
}