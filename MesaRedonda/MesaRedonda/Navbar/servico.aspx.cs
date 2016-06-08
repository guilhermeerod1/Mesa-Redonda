using BLL;
using DL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MesaRedonda.Navbar
{
    public partial class servico : System.Web.UI.Page
    {
        private string urlAdministrativo = ConfigurationManager.AppSettings["URL"];

        protected void Page_Load(object sender, EventArgs e)
        {            

            ServicoBO bo = new ServicoBO();
                        
            List<Servico> Servicos = bo.Listar();

            if (Servicos.Count > 0)
            {            
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
                    url = urlAdministrativo + p.Imagem.Caminho.Substring(1);
                else
                    url = urlAdministrativo + "/Imagens/padrao.png";

                ((Image)e.Item.FindControl("imgFotoServico"))
                    .ImageUrl = url;

                ((Label)e.Item.FindControl("lblDescricao"))
                    .Text = p.Descricao;                

            }
        }
    }
}