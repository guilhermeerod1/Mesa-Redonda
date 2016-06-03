using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Security;
using BLL.Business;

namespace Administrativa.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmeter_OnClick(object sender, EventArgs e)
        {
            var submeter = new UsuarioBO().Submeter(usuarioTextBox.Text, senhaTextBox.Text);

            if (submeter)
            {
                FormsAuthentication.RedirectFromLoginPage(usuarioTextBox.Text, false);
                Response.Redirect("Default.aspx", true);
            }

            else
            {
                Response.Redirect("Login.aspx", true);
            }
        }
    }
}