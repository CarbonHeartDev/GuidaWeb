using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.SessionState;
using System.Configuration;
using System.Data.SqlClient;

namespace Guida_Web_RC
{
    public static class Auth
    {
        public static String DBString = System.Configuration.ConfigurationManager.ConnectionStrings["Test1"].ConnectionString;
        public static SqlDataReader riga = null;
        public static SqlConnection connessione = new SqlConnection(DBString);
        public static SqlCommand query = new SqlCommand(null, connessione);

        /*Questa funzione verifica se la password inserita corrisponde a quella nel database restituendo un elemento dell'enum
         LoginResult corrispondente all'esito dell'autenticazione.*/
        public static LoginResult login(String password)
        {
            try
            {
                query.CommandText = "select * from Env where K='MD5(password)' AND V='" + Hashing.ComputeHash(password) + "'";
                if (connessione.State != System.Data.ConnectionState.Open)
                {
                    connessione.Open();
                }
                riga = query.ExecuteReader();
                if (!riga.HasRows)
                {
                    connessione.Close();
                    return LoginResult.DB_ERROR;
                }
            }
            catch
            {
                connessione.Close();
                return LoginResult.PASS_FAIL;
            }
            connessione.Close();
                return LoginResult.PASS_OK;
        }

        /*Questa funzione aggiorna la password nel database.*/
        public static bool rePass(String nuovaPassword)
        {
            try
            {
                query.CommandText = "update Env SET V='" + Hashing.ComputeHash(nuovaPassword) + "' where K='MD5(password)'";
                if (connessione.State != System.Data.ConnectionState.Open)
                {
                    connessione.Open();
                }
                query.ExecuteNonQuery();
            }
            catch
            {
                connessione.Close();
                return false;
            }
            connessione.Close();
            return true;
        }
    public enum LoginResult{
        DB_ERROR,
        PASS_FAIL,
        PASS_OK,
    }
    }

}