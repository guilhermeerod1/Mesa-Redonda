using BLL;
using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MesaRedonda.Navbar
{
    public partial class servico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ServicoBO bo = new ServicoBO();

            string id = Request.QueryString["id"];

            if (!string.IsNullOrEmpty(id))
                bo.Remover(Convert.ToInt32(id));

            List<Servico> Servicos = bo.Listar();

            int numeroServicos = Servicos.Count;

            StringBuilder sb = new StringBuilder();

            if (numeroServicos > 0)
            {
                sb.Append("Servicos cadastrados: ").Append(numeroServicos);
                rptServicos.DataSource = Servicos;
                rptServicos.DataBind();
            }
        }

        protected void rptServicos_ItemDataBound
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

                Servico p = (Servico)e.Item.DataItem;

                ((Label)e.Item.FindControl("lblNome"))
                    .Text = p.Nome;

                ((Label)e.Item.FindControl("lblPreco"))
                    .Text = string.Format("{0:N}", p.Preco);

                string url;

                if (p.Imagem != null)
                    url = p.Imagem.Caminho;
                else
                    url = "~/Imagens/padrao.png";

                ((Image)e.Item.FindControl("imgFotoServico"))
                    .ImageUrl = url;

                ((Label)e.Item.FindControl("lblDescricao"))
                    .Text = p.Descricao;

                int id = p.IdServico;

                ((HyperLink)e.Item.FindControl("lnkRemover"))
                    .NavigateUrl = "~/Servicos/Servicos.aspx?id=" + id;

                ((HyperLink)e.Item.FindControl("lnkEditar"))
                    .NavigateUrl = "~/Servicos/EdicaoServico.aspx?id=" + id;

            }
        }
    }
}