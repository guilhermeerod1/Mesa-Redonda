using BLL.Business;
using DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrativa.Usuarios
{
    public partial class EdicaoUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                rbListTipo.SelectedIndex = 1;
                string idUsuario = Page.Request.QueryString["id"];
                if (!string.IsNullOrEmpty(idUsuario))
                {
                    if (!Page.IsPostBack)
                    {
                        Usuario p = new UsuarioBO()
                            .Buscar(Convert.ToInt32(idUsuario));
                        preencherCampos(p);
                    }
                }
                
            }
            catch (Exception ae)
            {
                lblMensagem.Text = ae.Message;
            }
        }

        private void preencherCampos(Usuario p)
        {
            txtNomeUsuario.Text = p.Nome;
            txtSenha.Text = string.Empty;
            rbListTipo.SelectedIndex = p.Administrador ? 0 : 1;
            txtEmail.Text = p.Email;
            txtTelefone.Text = p.Telefone;
        }

        protected void btnSalvar_Click(object sender, EventArgs e)
        {
            UsuarioBO bo = new UsuarioBO();
            
            try
            {

                Usuario p = new Usuario();

                string id = Page.Request.QueryString["id"];

                p.Nome = txtNomeUsuario.Text;
                p.Senha = txtSenha.Text;
                p.Administrador = rbListTipo.SelectedIndex == 0;
                p.Email = txtEmail.Text;
                p.Telefone = txtTelefone.Text;

                if (string.IsNullOrEmpty(id))
                    bo.Inserir(p);
                else
                {
                    p.IdUsuario = Convert.ToInt32(id);
                    bo.Atualizar(p);
                }

                Limpar();

                lblMensagem.Text = "Usuario salvo com sucesso.";

            }
            catch (Exception ee)
            {
                lblMensagem.Text = ee.Message;
            }

        }

        private void Limpar()
        {
            txtNomeUsuario.Text = string.Empty;
            txtSenha.Text = string.Empty;
            rbListTipo.SelectedIndex = 0;
            txtEmail.Text = string.Empty;
            txtTelefone.Text = string.Empty;
        }
        
    }
}