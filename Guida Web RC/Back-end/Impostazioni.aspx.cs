using System;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Text;
using System.Security.Cryptography;


namespace Guida_Web_RC
{
    public partial class Impostazioni : System.Web.UI.Page
    {
        private Configuration config;
        private ConnectionStringsSection section;
        private bool reboot = false;
        /*Al caricamento della pagina il programma preleva tutti le impostazioni modificabili dal file Web.config e le
         mette nei relativi campi, salva inoltre una copia delle impostazioni di collegamento dal database in delle
         variabili per poter verificare in fase di salvataggio se l'utente ha apportato modifiche o meno aggiornando
         eventualmente i dati presenti nel file e riavviando l'applicazione per rendere effettive le modifiche.*/
        protected void Page_Load(object sender, EventArgs e)
        {
            config = WebConfigurationManager.OpenWebConfiguration("~");
            section = config.GetSection("connectionStrings") as ConnectionStringsSection;
            System.Data.Odbc.OdbcConnectionStringBuilder builder = new System.Data.Odbc.OdbcConnectionStringBuilder();
            builder.ConnectionString = section.ConnectionStrings["Test1"].ConnectionString;
            if (!IsPostBack) { 
            ns.Text= WebConfigurationManager.AppSettings["Titolo"];
            TextBox2.Text = builder["Data Source"].ToString();
            TextBox3.Text = builder["Initial Catalog"].ToString();
            TextBox4.Text = builder["User ID"].ToString();
            TextBox5.Text = builder["Password"].ToString();
        }
        }

        /*Questa funzione salva le impostazioni aggiornate.*/
        protected void Button1_Click(object sender, EventArgs e)
        {
            System.Data.Odbc.OdbcConnectionStringBuilder builder = new System.Data.Odbc.OdbcConnectionStringBuilder();
            builder.ConnectionString = section.ConnectionStrings["Test1"].ConnectionString;
            //Se è stata inserita una nuova password e la conferma è corretta la password nel database viene aggiornata.
            if (TextBox1.Text != "" && TextBox1.Text == TextBox6.Text)
            {
                Auth.rePass(TextBox1.Text);
                Label2.Text = "La password è stata modificata con successo";
            }
            //Se le impostazioni del database stato cambiate il programma le testa e in caso di esito positivo aggiorna il file e riavvia l'applicazione
            if (TextBox2.Text != builder["Data Source"].ToString() || TextBox3.Text != builder["Initial Catalog"].ToString() || TextBox4.Text != builder["User ID"].ToString() || TextBox5.Text != builder["Password"].ToString())
            {
                if (DBTest.stringTest("Data Source=" + TextBox3.Text + ";Initial Catalog=" + TextBox4.Text + ";Persist Security Info=True;User ID=" + TextBox5.Text + ";Password=" + TextBox6.Text))
                {
                    if (section != null)
                    {
                        section.ConnectionStrings["Test1"].ConnectionString = "Data Source=" + TextBox3.Text + ";Initial Catalog=" + TextBox4.Text + ";Persist Security Info=True;User ID=" + TextBox5.Text + ";Password=" + TextBox6.Text;
                        config.Save();
                        reboot = true;
                    }
                }
                else
                {
                    Label1.Text = "Connessione al database fallita, verranno ripristinate le impostazioni precedenti";
                }
            }
            //Se il titolo dell'installazione dell'applicazione è stato cambiato aggiorna il file e riavvia l'applicazione
            if (WebConfigurationManager.AppSettings["Titolo"] != ns.Text)
            {
                Configuration objConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
                AppSettingsSection objAppsettings = (AppSettingsSection)objConfig.GetSection("appSettings");

                if (objAppsettings != null)
                {
                    objAppsettings.Settings["Titolo"].Value = ns.Text;
                    objConfig.Save();
                    reboot = true;
                }
            }
            if (reboot)
            {
                HttpRuntime.UnloadAppDomain();
                Response.Redirect(Request.RawUrl);
            }
                }
        }
}
