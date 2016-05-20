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
    public partial class Produtos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ProdutoDA dao = new ProdutoDA();

            if(Page.IsPostBack)
            {
                string idProdutoARemover = Request.QueryString["id"];
                int id = Convert.ToInt32(idProdutoARemover);
                dao.RemoverProduto(id);
            }

            List<Produto> produtos = dao.Listar();

            if (produtos != null && produtos.Count != 0)
            {

                lblNumeroProdutos.Text = "Número de produtos cadastrados: " + produtos.Count.ToString();
                rptProdutos.DataSource = produtos;
                rptProdutos.DataBind();

            } else
            {
                lblNumeroProdutos.Text = "Nenhum produto cadastrado. " + "<a href='EdicaoProduto.aspx'>Cadastrar Novo</a>";
            }

        }

        protected void rptProdutos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item)
            {

                Produto p = (Produto)e.Item.DataItem;

                ((Label)e.Item.FindControl("lblIdProduto")).Text = p.IdProduto.ToString();
                ((Label)e.Item.FindControl("lblNome")).Text = p.Nome;
                ((Label)e.Item.FindControl("lblPreco")).Text = p.Preco.ToString();
                ((Image)e.Item.FindControl("imgFotoProduto")).ImageUrl = p.Imagem.Caminho;
                ((Label)e.Item.FindControl("lblDescricao")).Text = p.Descricao;
                ((HyperLink)e.Item.FindControl("lnkRemover")).NavigateUrl = "~/Produtos.aspx?id=" + p.IdProduto;
                ((HyperLink)e.Item.FindControl("lnkEditar")).NavigateUrl = "~/EdicaoProduto.aspx?id=" + p.IdProduto;

            }
        }
    }
}