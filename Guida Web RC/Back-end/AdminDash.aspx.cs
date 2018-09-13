using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using System.IO;


namespace WebApplication3.Upload.Immagine
{
    public partial class AdminDash : System.Web.UI.Page
    {
        private String pathImmagine;
        private String pathAudio;
        private static String DBString = System.Configuration.ConfigurationManager.ConnectionStrings["Test1"].ConnectionString;
        private String QueryText;
        private static SqlConnection connessione = new SqlConnection(DBString);
        private SqlCommand query = new SqlCommand(null, connessione);
        private int temp;


        /*Al caricamento dell'interfaccia di amministrazione il programma cerca tutti i file immagine e audio e li elenca nell'area
         adibita alla creazione di nuove schede.*/
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            { 
                string[] filePaths = Directory.GetFiles(Server.MapPath("~/Upload/Immagine"));
                foreach (string filePath in filePaths)
                {
                    FileComp.picComp("prova");
                    if (FileComp.picComp(Path.GetFileName(filePath)))
                    {
                        Immagine.Items.Add(Path.GetFileName(filePath));
                    }
                }
                filePaths = Directory.GetFiles(Server.MapPath("~/Upload/Audio"));
                foreach (string filePath in filePaths)
                {
                    if (FileComp.audioComp(Path.GetFileName(filePath)))
                    {
                        Audio.Items.Add(Path.GetFileName(filePath));
                    }
                }
            }
        }

        /*Quando viene cliccato il bottone "Aggiungi" della sezione "Schede Audioguida" il programma preleva i dati dal modulo di creazione di una nuova scheda 
         (ID scheda, Nome scheda, testo descrittivo, path immagine e path file audio descrizione) e li inserisce nel database per creare la scheda.*/
        protected void Upload_Click(object sender, EventArgs e)
        {
            Nome.Text = Nome.Text.Replace("'", "''");
            Descrizione.Text = Descrizione.Text.Replace("'", "''");
            if (int.TryParse(Id.Text, out temp))
                {
                    try
                    {
                        if (!String.IsNullOrEmpty(Immagine.Text))
                        {
                        pathImmagine = "Upload\\Immagine\\" + Immagine.Text;
                        }

                        if (!String.IsNullOrEmpty(Audio.Text))
                        {
                            pathAudio = "Upload\\Audio\\" + Audio.Text;
                        }
                        QueryText = "INSERT INTO Schede (Id, Nome, Descrizione, Immagine, Audio) VALUES (" + Id.Text + ",'" + Nome.Text + "','" + Descrizione.Text + "','" + pathImmagine + "','" + pathAudio + "')";
                        SqlConnection connessione = new SqlConnection(DBString);
                        if (connessione.State != System.Data.ConnectionState.Open)
                        {
                            connessione.Open();
                        }
                        SqlCommand query = new SqlCommand(QueryText, connessione);
                        query.ExecuteNonQuery();
                        connessione.Close();
                        Response.Redirect(Request.RawUrl, false);
                    }
                    catch (Exception)
                    {
                        Label1.Text = "Errore di trasferimento file";
                    }
                }
                else
                {
                    Label1.Text = "Il campo ID deve contenere un numero intero";
                }
            }
         
        /*Alla pressione del tasto elimina relativo a una scheda questa funzione effettua l'eliminazione 
         richiesta*/
         protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
         {
                 QueryText = "DELETE FROM Schede WHERE Id='" + e.CommandArgument + "'";
                 SqlConnection connessione = new SqlConnection(DBString);
                 try
                 {
                    if (connessione.State != System.Data.ConnectionState.Open)
                    {
                        connessione.Open();
                    }
                    SqlCommand query = new SqlCommand(QueryText, connessione);
                     query.ExecuteNonQuery();
                     connessione.Close();
                     Response.Redirect(Request.RawUrl);
                 }
                 catch (SqlException)
                 {
                    Label1.Text = "Errore SQL";
                 }
         }

        /*Quando viene cliccato il bottone "Aggiungi" della sezione "Pagine HTML" il programma preleva i dati dal modulo di creazione di una nuova pagina statica 
         (ID pagina, contenuto HTML) e li inserisce nel database per creare la pagina statica.*/
        protected void Button1_Click(object sender, EventArgs e)
         {
                 try
                 {
                     TextBox1.Text = TextBox1.Text.Replace("'", "''");
                     TextBox2.Text = TextBox2.Text.Replace("'", "''");
                     QueryText = "INSERT INTO PagineH (Id, Contenuto) VALUES ('" + TextBox2.Text + "','" + TextBox1.Text + "')";
                     SqlConnection connessione = new SqlConnection(DBString);
                    if (connessione.State != System.Data.ConnectionState.Open)
                    {
                        connessione.Open();
                    }
                    SqlCommand query = new SqlCommand(QueryText, connessione);
                     query.ExecuteNonQuery();
                     connessione.Close();
                     Response.Redirect(Request.RawUrl);
                 }
                 catch (SqlException)
                 {
                    Label1.Text = "Errore SQL";
                 }
         }

        /*La seguente funzione preleva una file HTML dal computer dell'utente e ne copia il contenuto nel campo destinato al codice HTML di una nuova pagina statica.*/
         protected void Button2_Click(object sender, EventArgs e)
         {
             if (FileUpload1.HasFile)
             {
                 String path;
                 path = Request.PhysicalApplicationPath + "Upload\\Temp\\" + FileUpload1.FileName;
                 FileUpload1.SaveAs(path);
                 TextBox1.Text = System.IO.File.ReadAllText(path);
                 System.IO.File.Delete(path);
             }
         }

        /*Alla pressione del tasto elimina relativo a una pagina statica questa funzione effettua l'eliminazione 
         richiesta*/
        protected void GridView3_RowDeleting(object sender, GridViewDeleteEventArgs e)
         {
                 try
                 {
                    if (connessione.State != System.Data.ConnectionState.Open)
                    {
                        connessione.Open();
                    }
                    query.CommandText = "Delete from Schede where Id='" + GridView3.Rows[e.RowIndex].Cells[0].Text + "'";
                    query.ExecuteNonQuery();
                    connessione.Close();
                    Response.Redirect(Request.RawUrl);
                }
                catch (SqlException)
                {
                    Label1.Text = "Errore SQL";
                }

        }

        /*protected void LinkButton1_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
        }*/

        /*Alla pressione del pulsante URL relativo a una scheda il programma mostra a video l'URL della scheda richiesta
         che potrà essere usato ad esempio in un codice QR o in un tag NFC.*/
        protected void GridView3_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "getUrlS")
            {
                URLs.Visible = true;
                URLs.Text = "URL Richiesto: " + UrlHelp.GetBaseUrl() + "/Schede.aspx?Id=" + GridView3.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text;
            }
        }

        /*Alla pressione del pulsante URL relativo a una pagina il programma mostra a video l'URL della pagina statica richiesta*/
        protected void GridView4_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "getURL")
            {
                URLs.Visible = true;
                URLs.Text = "URL Richiesto: " + UrlHelp.GetBaseUrl() + "/Page.aspx?Id=" + ((GridView4.Rows[Convert.ToInt32(e.CommandArgument)].Cells[0].Text).Trim()).Replace(" ","%20");
            }
        }
    }
}