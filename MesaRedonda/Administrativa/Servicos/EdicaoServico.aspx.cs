using DL;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace Administrativa.Servicos
{
    public partial class EdicaoServico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string idServico = Page.Request.QueryString["id"];
                if (!string.IsNullOrEmpty(idServico))
                {
                    if (!Page.IsPostBack)
                    {
                        Servico p = new ServicoBO()
                            .Buscar(Convert.ToInt32(idServico));
                        preencherCampos(p);
                    }
                }
            }
            catch (Exception ae)
            {
                lblMensagem.Text = ae.Message;
            }
        }

        private void preencherCampos(Servico p)
        {
            txtNomeServico.Text = p.Nome;
            txtPrecoServico.Text = p.Preco.ToString();
            txtDescricao.InnerHtml = p.Descricao;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            ServicoBO bo = new ServicoBO();

            try
            {

                Servico p = new Servico();

                string id = Page.Request.QueryString["id"];

                p.Nome = txtNomeServico.Text;
                p.Preco = Convert.ToInt32(txtPrecoServico.Text);
                p.Descricao = Server.HtmlDecode(txtDescricao.InnerHtml);

                if (fuFotoServico.HasFile)
                {
                    StringBuilder sb = new StringBuilder();

                    if (!checarUpload(fuFotoServico, sb))
                    {
                        lblMensagem.Text = sb.ToString();
                        return;
                    }

                    string caminho = "~/Imagens/" + fuFotoServico.FileName;
                    fuFotoServico.SaveAs(Server.MapPath(caminho));
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

                if (string.IsNullOrEmpty(id))
                    bo.Inserir(p);
                else
                {
                    p.IdServico = Convert.ToInt32(id);
                    bo.Atualizar(p);
                }

                Limpar();

                lblMensagem.Text = "Servico salvo com sucesso.";

            }
            catch (Exception ee)
            {
                lblMensagem.Text = ee.Message;
            }

        }

        private void Limpar()
        {
            txtNomeServico.Text = string.Empty;
            txtPrecoServico.Text = string.Empty;
            txtDescricao.InnerHtml = string.Empty;
        }

        private bool checarUpload(FileUpload fuFotoServico, StringBuilder sb)
        {
            bool imgValida = true;
            ServicoBO bo = new ServicoBO();
            string fileName = fuFotoServico.FileName;

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

            if (fuFotoServico.PostedFile.ContentLength > 3 * 1048576)
            {
                sb.Append("Arquivos maiores que 3MB não são aceitos.");
                imgValida = false;
            }
            return imgValida;
        }

    }
}