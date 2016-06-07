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
    public partial class EdicaoProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            try
            {
                string idProduto = Page.Request.QueryString["id"];
                if(!string.IsNullOrEmpty(idProduto))
                {
                    if (!Page.IsPostBack)
                    {
                        Produto p = new ProdutoBO()
                            .Buscar(Convert.ToInt32(idProduto));
                        preencherCampos(p);
                    }
                }
            }
            catch (Exception ae)
            {
                lblMensagem.Text = ae.Message;
            }            
        }

        private void preencherCampos(Produto p)
        {
            txtNomeProduto.Text = p.Nome;
            txtPrecoProduto.Text = p.Preco.ToString();
            txtDescricao.InnerHtml = p.Descricao;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            ProdutoBO bo = new ProdutoBO();
            
            try {

                Produto p = new Produto();

                string id = Page.Request.QueryString["id"];

                p.Nome = txtNomeProduto.Text;
                p.Preco = Convert.ToInt32(txtPrecoProduto.Text);
                p.Descricao = Server.HtmlDecode(txtDescricao.InnerHtml);

                if(fuFotoProduto.HasFile)
                {
                    StringBuilder sb = new StringBuilder();
                    
                    if(!checarUpload(fuFotoProduto, sb))
                    {
                        lblMensagem.Text = sb.ToString();
                        return;
                    }
                    
                    string caminho = "~/Imagens/" + fuFotoProduto.FileName;
                    fuFotoProduto.SaveAs(Server.MapPath(caminho));
                    p.Imagem = bo.ImagemBO.Inserir(caminho);

                }
                else
                {
                    if (!string.IsNullOrEmpty(id))
                    {
                        p.Imagem = bo.ImagemBO
                            .Buscar(
                                    bo.Buscar(Convert.ToInt32(id))
                                        .Imagem.IdImagem
                                );
                    }
                }

                if(string.IsNullOrEmpty(id))
                    bo.Inserir(p);
                else
                {
                    p.IdProduto = Convert.ToInt32(id);
                    bo.Atualizar(p);
                }

                Limpar();

                lblMensagem.Text = "Produto salvo com sucesso.";

            }
            catch(Exception ee)
            {
                lblMensagem.Text = ee.Message;
            }     

        }
        
        private void Limpar()
        {
            txtNomeProduto.Text = string.Empty;
            txtPrecoProduto.Text = string.Empty;
            txtDescricao.InnerHtml = string.Empty;            
        }

        private bool checarUpload(FileUpload fuFotoProduto, StringBuilder sb)
        {
            bool imgValida = true;
            ProdutoBO bo = new ProdutoBO();
            string fileName = fuFotoProduto.FileName;

            if (!bo.ImagemBO.NomeValido(fileName))
            {
                sb.Append("Nome de imagem inválido.")
                    .Append("Deve possuir as seguintes extensões: ")
                    .Append(".jpg, .png ou .bmp")
                    .Append("Tamanho máximo do  nome: 245.");

                imgValida = false;
            }

            if (bo.ImagemBO.imagemExistente(fileName))
            {
                sb.Append("Nome já existente.");
                imgValida = false;
            }

            if (fuFotoProduto.PostedFile.ContentLength > 3 * 1048576)
            {
                sb.Append("Arquivos maiores que 3MB não são aceitos.");
                imgValida = false;
            }
            return imgValida;            
        }
                
    }
}