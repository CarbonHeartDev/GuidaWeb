using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication3
{
    public partial class StaticPages : System.Web.UI.Page
    {
        public static String DBString = System.Configuration.ConfigurationManager.ConnectionStrings["Test1"].ConnectionString;
        public SqlDataReader riga = null;
        public static SqlConnection connessione = new SqlConnection(DBString);
        public SqlCommand query = new SqlCommand(null, connessione);
        /*Questa funzione estrae dal database il codice HTML relativo a una pagina statica con un determinato ID (passato come
         parametro URL e lo usa per generare la pagina che poi verrà mostrata all'utente.*/
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                String idURL = Request.QueryString["Id"];
                /*Lo spazio nei parametri URL viene rappresentato con "%20" mentre nel database con " " la sostituzione sottostante permette di 
                 avere lo spazio come rappresentato nel DB in modo da poter effettuare regolarmente la ricerca.*/
                query.CommandText = "Select * from PagineH where Id='" + idURL.Replace("%20", " ") + "'"; 
                try
                {
                    connessione.Open();
                    riga = query.ExecuteReader();
                    if (riga.HasRows)
                    {
                        riga.Read();
                        pagina.InnerHtml = riga["Contenuto"].ToString();
                    }
                    else
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
            else
            {
                Server.Transfer("Default.aspx");
            }
        }
    }
}