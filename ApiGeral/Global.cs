using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiGeral
{
    public static class Global
    {
        public static int opcGeral = 0;

        public static List<Array> listaGeral = new List<Array>();



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
    }

}