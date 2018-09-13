using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication3
{
    /*Questa funzione prende dal database i dati relativi a una scheda con un certo ID (passato come parametro URL) e li usa per
     comporre la scheda che poi verrà mostrata all'utente.*/
    public partial class VisualizzazioneUtente : System.Web.UI.Page
    {
        public static String DBString = System.Configuration.ConfigurationManager.ConnectionStrings["Test1"].ConnectionString;
        public SqlDataReader riga = null;
        public static SqlConnection connessione = new SqlConnection(DBString);
        public SqlCommand query = new SqlCommand(null, connessione);
        protected void update(String Id)
        {
            query.CommandText = "Select * from Schede where Id='" + Id + "'";
            try
            {
                connessione.Open();
                riga = query.ExecuteReader();
                if (riga.HasRows)
                {
                    riga.Read();
                    Nome.Text = riga["Nome"].ToString();
                    if (!string.IsNullOrEmpty(riga["Descrizione"].ToString()))
                    {
                        Descrizione.Text = riga["Descrizione"].ToString();
                        Descrizione.Visible = true;
                    }
                    else
                    {
                        Descrizione.Visible = false;
                    }
                    if (!string.IsNullOrEmpty(riga["Immagine"].ToString()))
                    {
                        Foto.Src = "~\\" + riga["Immagine"].ToString();
                        Foto.Visible = true;
                    }
                    else
                    {
                        Foto.Visible = false;
                    }
                    if(!string.IsNullOrEmpty(riga["Audio"].ToString()))
                    {
                        audioplayer.Src = "~\\" + riga["Audio"].ToString();
                    audioplayer.Visible = true;
                    }
                    else
                    {
                        audioplayer.Visible = false;
                    }
                }
                else
                {
                    Nome.Text = "La scheda richiesta non esiste";
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
                    Descrizione.Text = SQLException.ToString();
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Request.QueryString["Id"] != null)
            {
                update(Request.QueryString["Id"]);
            }
        }
    }
}