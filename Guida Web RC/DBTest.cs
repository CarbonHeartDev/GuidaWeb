using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Guida_Web_RC
{
    public static class DBTest
    {
        public static String DBString = System.Configuration.ConfigurationManager.ConnectionStrings["Test1"].ConnectionString;
        public static SqlConnection connessione = new SqlConnection(DBString);
        public static SqlCommand query = new SqlCommand(null, connessione);
        public static bool stringTest(String cString)
        {
            /*Questa funzione testa il database inserito nelle impostazioni per assicurarsi che esiste 
             * e contiene le giuste tabelle.*/
            try
            {
                query.CommandText = "select * from Env";
                if (connessione.State != System.Data.ConnectionState.Open)
                {
                    connessione.Open();
                }
                query.ExecuteReader();
                query.CommandText = "select * from PagineH";
                if (connessione.State != System.Data.ConnectionState.Open)
                {
                    connessione.Open();
                }
                query.ExecuteReader();
                query.CommandText = "select * from Schede";
                if (connessione.State != System.Data.ConnectionState.Open)
                {
                    connessione.Open();
                }
                query.ExecuteReader();
                connessione.Close();
                return true;
            }
            catch
            {
                connessione.Close();
                return false;
            }
        }
    }
}