using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Guida_Web_RC
{
    public partial class Vai_a_scheda : System.Web.UI.Page
    {
        /*Preso un numero di scheda dall'apposita casella di testo questa funzione genera l'URL corretto e vi reindirizza l'utente.*/
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Schede.aspx?Id=" + TextBox1.Text);
        }
    }
}