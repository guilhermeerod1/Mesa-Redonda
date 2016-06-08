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
    public partial class cardapio : System.Web.UI.Page
    {

        private string administrativoUrl = ConfigurationManager.AppSettings["URL"];

        protected void Page_Load(object sender, EventArgs e)
        {

            ProdutoBO bo = new ProdutoBO();
            
            List<Produto> produtos = bo.Listar();
            
            if (produtos.Count > 0)
            {
                rptProdutos.DataSource = produtos;
                rptProdutos.DataBind();
            }

        }

        protected void rptProdutos_ItemDataBound
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

                Produto p = (Produto)e.Item.DataItem;

                ((Label)e.Item.FindControl("lblNome"))
                    .Text = p.Nome;

                ((Label)e.Item.FindControl("lblPreco"))
                    .Text = string.Format("{0:N}", p.Preco);

                string url;

                if (p.Imagem != null)
                    url = administrativoUrl + p.Imagem.Caminho.Substring(1);
                else
                    url = administrativoUrl + "/Imagens/padrao.png";

                ((Image)e.Item.FindControl("imgFotoProduto"))
                    .ImageUrl = url;

                ((Label)e.Item.FindControl("lblDescricao"))
                    .Text = p.Descricao;                

            }
        }
    }
}