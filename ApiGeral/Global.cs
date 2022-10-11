using System;
using System.Collections.Generic;
using ApiGeral.Netdb;

namespace ApiGeral
{
    public static class Global
    {
        public static int opcGeral = 0;

        public static List<Array> listaGeral = new List<Array>();

        //Data Externa e User Externo
        public static string DataInicialGeralExt = "01/10/2022";
        public static string DataFinalGeralExt = "31/10/2022";
        public static string LoteInformacao = "8279";
        public static string UsuarioGeralExt = "SALE";
        public static string UsuarioAut = "SALE";
        public static string SenhaAut = "SALE";
        public static string OpcExterna = "";

        //Lista base para os Datatable
        public static List<string> listaBase = new List<string>();
        public static List<string> listaBase2 = new List<string>();
        public static List<string> listaBase3 = new List<string>();
        public static List<string> listaBase4 = new List<string>();
        public static List<string> listaBase5 = new List<string>();
        public static List<string> listaBase6 = new List<string>();
        public static List<string> listaBase7 = new List<string>();
        public static List<string> listaBase8 = new List<string>();
        public static List<string> listaBase9 = new List<string>();
        public static List<string> listaBase10 = new List<string>();
        public static List<string> listaBase11 = new List<string>();

        public static int contador = 0;

        public static void LimparListas() {
            listaBase.Clear();
            listaBase2.Clear();
            listaBase3.Clear();
            listaBase4.Clear();
            listaBase5.Clear();
            listaBase6.Clear();
            listaBase7.Clear();
            listaBase8.Clear();
            listaBase9.Clear();
            listaBase10.Clear();
            listaBase11.Clear();
            
        }

        public static bool GetMetodos(string opc)
        {
            try
            {
                if (opc == "EMT_UM_I")
                {
                    try
                    {
                        ConnEMT.GetProducaoIndiv(DataInicialGeralExt, UsuarioGeralExt);
                    }
                    catch (Exception)
                    {
                        int i = 2;
                        while (i != 1)
                        {
                            Global.listaBase.Add(UsuarioGeralExt);
                            Global.listaBase2.Add(DateTime.Now.Date.ToString());
                            Global.listaBase3.Add("0");
                            i++;

                        }

                    }
                }
                else if (opc == "EMT_UM_I_IP")
                {
                    try
                    {
                        ConnEMT.GetProducaoIndivIp(DataInicialGeralExt, UsuarioGeralExt);
                    }
                    catch (Exception)
                    {
                        int i = 2;
                        while (i != 1)
                        {
                            Global.listaBase.Add(UsuarioGeralExt);
                            Global.listaBase2.Add(DateTime.Now.Date.ToString());
                            Global.listaBase3.Add("0");
                            i++;

                        }

                    }
                }
                else if (opc == "Datas")
                {
                    ConnHomolog.GetData(DataInicialGeralExt, DataFinalGeralExt);
                }
                else if (opc == "EMT_UM_G")
                {
                    ConnEMT.GetProducaoGeral(DataInicialGeralExt, DataFinalGeralExt);
                }
                else if (opc == "EMT_UM_G_IP")
                {
                    ConnEMT.GetProducaoGeralIP(DataInicialGeralExt, DataFinalGeralExt);
                }
                else if (opc == "RJ_UM_G")
                {
                    ConnRJ.GetProducaoGeral(DataInicialGeralExt, DataFinalGeralExt);
                }
                else if (opc == "RJ_UM_I")
                {
                    try
                    {
                        ConnRJ.GetProducaoIndiv(DataInicialGeralExt, UsuarioGeralExt);
                    }
                    catch (Exception)
                    {
                        int i = 2;
                        while (i != 1)
                        {
                            Global.listaBase.Add(UsuarioGeralExt);
                            Global.listaBase2.Add(DateTime.Now.Date.ToString());
                            Global.listaBase3.Add("0");
                            i++;

                        }

                    }
                }
                else if (opc == "LOTE_EMT")
                {
                    ConnEMT.GetInfoLote(DataInicialGeralExt);
                }
                else if (opc == "LOTE_RJ")
                {
                    ConnRJ.GetInfoLote(DataInicialGeralExt);
                }

                else { return false; }
                
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
   
}