using BLL;
using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrativa.Produtos
{
    public partial class Produtos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ProdutoBO bo = new ProdutoBO();

            string id = Request.QueryString["id"];

            if (!string.IsNullOrEmpty(id))
                bo.Remover(Convert.ToInt32(id));

            List<Produto> produtos = bo.Listar();

            int numeroProdutos = produtos.Count;

            StringBuilder sb = new StringBuilder();

            if (numeroProdutos > 0)
            {
                sb.Append("Produtos cadastrados: ").Append(numeroProdutos);
                rptProdutos.DataSource = produtos;
                rptProdutos.DataBind();
            }
            else
                sb.Append("Nenhum produto cadastrado.");

            sb.Append(" <a href='EdicaoProduto.aspx'>Cadastrar Novo</a>");
            lblNumeroProdutos.Text = sb.ToString();

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
                    url = p.Imagem.Caminho;
                else
                    url = "~/Imagens/padrao.png";

                ((Image)e.Item.FindControl("imgFotoProduto"))
                    .ImageUrl = url;                

                ((Label)e.Item.FindControl("lblDescricao"))
                    .Text = p.Descricao;

                int id = p.IdProduto;

                ((HyperLink)e.Item.FindControl("lnkRemover"))
                    .NavigateUrl = "~/Produtos/Produtos.aspx?id=" + id;

                ((HyperLink)e.Item.FindControl("lnkEditar"))
                    .NavigateUrl = "~/Produtos/EdicaoProduto.aspx?id=" + id;

            }
        }
    }
}