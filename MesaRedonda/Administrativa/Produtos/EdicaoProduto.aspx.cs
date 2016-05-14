using DAL;
using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrativa.Produtos
{
    public partial class EdicaoProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void AsyncFileUpload1_UploadedComplete(object sender, AjaxControlToolkit.AsyncFileUploadEventArgs e)
        {
            string nome = "~/Imagens/" + AsyncFileUpload1.FileName;
            AsyncFileUpload1.SaveAs(Server.MapPath(nome));
            Image1.ImageUrl = nome;
            Image1.DataBind();
        }
    }
}