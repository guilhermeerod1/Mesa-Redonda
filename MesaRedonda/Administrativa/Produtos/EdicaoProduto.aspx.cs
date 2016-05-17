using DAL;
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
    public partial class EdicaoProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                //int id = Convert.ToInt32(Page.Request.QueryString["id"]);
                //Produto produtoRequisitado = new ProdutoDA().Buscar(id);
                Produto p = new Produto();
                p.Nome = "Teste";
                p.Preco = 12.12M;
                p.Descricao = "<b>Teste</b>";
                preencherCampos(p);
                configurar(true, p);

            }
        }

        private void preencherCampos(Produto p)
        {
            hdnIdProduto.Value = p.IdProduto.ToString();
            txtNomeProduto.Text = p.Nome;
            txtPrecoProduto.Text = p.Preco.ToString();
        }

        private void configurar(bool edi, Produto p)
        {

            string edicao = "edicao = false;", textoDescricao = "",
                idDescricao = "txtDescricao = '" + txtDescricao.ClientID + "';";

            if (edi)
            {
                edicao = "edicao = true;";
                textoDescricao = "txtDescricaoText = '" + p.Descricao + "';";
            }

            string scpt = edicao + textoDescricao + idDescricao;
            string scpt2 = "$(document).ready(prepararEdicao());";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "DefinirVariaveis", scpt, true);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "RodarPreparar", scpt2, true);

        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            string te = Request.Form["txtDescricao"];
        }
    }
}