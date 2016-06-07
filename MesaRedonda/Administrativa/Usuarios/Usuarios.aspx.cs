using BLL.Business;
using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrativa.Usuarios
{
    public partial class Usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            UsuarioBO bo = new UsuarioBO();

            string id = Request.QueryString["id"];

            if (!string.IsNullOrEmpty(id))
                bo.Remover(Convert.ToInt32(id));

            List<Usuario> Usuarios = bo.Listar();

            int numeroUsuarios = Usuarios.Count;

            StringBuilder sb = new StringBuilder();

            if (numeroUsuarios > 0)
            {
                sb.Append("Usuarios cadastrados: ").Append(numeroUsuarios);
                rptUsuarios.DataSource = Usuarios;
                rptUsuarios.DataBind();
            }
            else
                sb.Append("Nenhum Usuario cadastrado.");

            sb.Append(" <a href='EdicaoUsuario.aspx'>Cadastrar Novo</a>");
            lblNumeroUsuarios.Text = sb.ToString();

        }

        protected void rptUsuarios_ItemDataBound
            (
                object sender,
                RepeaterItemEventArgs e
            )
        {
            if (
                    e.Item.ItemType == ListItemType.Item ||
                    e.Item.ItemType == ListItemType.AlternatingItem
                )
            {

                Usuario p = (Usuario)e.Item.DataItem;

                ((Label)e.Item.FindControl("lblUsuario"))
                    .Text = p.Nome;

                ((Label)e.Item.FindControl("lblEmail"))
                    .Text = p.Email;
                
                ((Label)e.Item.FindControl("lblTelefone"))
                    .Text = p.Telefone;

                int id = p.IdUsuario;

                ((HyperLink)e.Item.FindControl("lnkRemover"))
                    .NavigateUrl = "~/Usuarios/Usuarios.aspx?id=" + id;

                ((HyperLink)e.Item.FindControl("lnkEditar"))
                    .NavigateUrl = "~/Usuarios/EdicaoUsuarios.aspx?id=" + id;

            }
        }
    }
}