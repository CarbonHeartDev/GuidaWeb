using System;
using System.Web.Security;

namespace Guida_Web_RC
{
    public partial class Accesso : System.Web.UI.Page
    {
        /*Se la pagina viene raggiunta da un utente autenticato questa funzione effettua il logout e lo renidirizza alla home.*/
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                Response.Redirect("Default.aspx");
            }
        }

        /*Alla pressione del tasto di login questa funzione appoggiandosi alla classe Auth verifica la password, se è corretta completa
         l'autenticazione e reindirizza l'utente alla pagina originariamente richiesta altrimenti visualizza un errore.*/
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Auth.login(TextBox1.Text)==Auth.LoginResult.PASS_OK)
            {
                FormsAuthentication.RedirectFromLoginPage
                   ("Admin", true);
            }
            else
            {
                TextBox1.Text = "Password Errata";
            }
        }
    }
}