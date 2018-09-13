using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication3
{
    public partial class DefaultPage : System.Web.UI.Page
    {
        public static String DBString = System.Configuration.ConfigurationManager.ConnectionStrings["Test1"].ConnectionString;
        public SqlDataReader riga = null;
        public static SqlConnection connessione = new SqlConnection(DBString);
        public SqlCommand query = new SqlCommand(null, connessione);
        /*Questa funzione compone la home prelevando dalla tabella del database contenente le pagine statiche la pagina con Id "Home".*/
        protected void Page_Load(object sender, EventArgs e)
        {
                String idURL = Request.QueryString["Id"];
                query.CommandText = "Select * from PagineH where Id='Home'";
                try
                {
                    connessione.Open();
                    riga = query.ExecuteReader();
                    if (riga.HasRows)
                    {
                        riga.Read();
                        pagina.InnerHtml = riga["Contenuto"].ToString();
                    }
                    else //Se la pagine di ID richiesto non viene trovata viene restituito un errore 404
                    {
                        pagina.InnerHtml = "Errore 404: pagina non trovata";
                    }
                    connessione.Close();
                }
                catch (Exception SQLException)
                {
                    try
                    {
                        connessione.Close();
                    }
                    finally
                    {
                        pagina.InnerHtml = SQLException.ToString();
                    }
                }
        }
    }
}