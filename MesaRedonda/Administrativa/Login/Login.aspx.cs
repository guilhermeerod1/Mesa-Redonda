using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Administrativa.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmeter(object sender, EventArgs e)
        {
            var submeter = new UsuarioBO().Submeter(txtUsuario.Text, txtSenha.Text);

            if (submeter)
            {
                FormsAuthentication.RedirectFormLoginPage(txtUsuario.Text, false);
                Response.Redirect("Default.aspx", true);
            }

            else
            {
                Response.Redirect("Login.aspx", true);
            }
        }
    }
}