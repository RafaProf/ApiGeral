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
        public static string DataInicialGeralExt = "01/07/2022";
        public static string DataFinalGeralExt = "27/07/2022";
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
                    ConnEMT.GetProducaoIndiv(DataInicialGeralExt, UsuarioGeralExt);
                }
                if (opc == "Datas")
                {
                    ConnHomolog.GetData(DataInicialGeralExt, DataFinalGeralExt);
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