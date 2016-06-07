<%@ Page Title="Edição de Produtos" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EdicaoProduto.aspx.cs" Inherits="Administrativa.Produtos.EdicaoProduto" ValidateRequest="false" %>

<asp:Content ID="headEdicaoProdutos" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="conteudoEdicaoProduto" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="well">Produto</div>
    <div class="panel panel-default">
        <div class="panel-body">
            <label>Nome:</label><br />
            <asp:TextBox ID="txtNomeProduto" runat="server" CssClass="form-control">
            </asp:TextBox><br />
            <label>Preço:</label><br />
            <asp:TextBox ID="txtPrecoProduto" runat="server" CssClass="form-control">
            </asp:TextBox><br />
            <label>Imagem:</label><br />
            <asp:FileUpload ID="fuFotoProduto" runat="server" /><br />
            <label>Descrição:</label><br />
            <textarea id="txtDescricao" runat="server"></textarea>
            <br />
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-success" OnClick="btnSalvar_Click" />
            <asp:Label ID="lblMensagem" runat="server"></asp:Label>
        </div>
    </div>
    <script>
        function prepararEdicao() {
            var idTxtDescricao = '#' + '<%=txtDescricao.ClientID%>';
            $(idTxtDescricao).summernote();
            $(idTxtDescricao).on('summernote.blur', function () {
                $(idTxtDescricao).html($(idTxtDescricao).summernote('code'));
            })
            if (edicao) {
                $(idTxtDescricao)
                    .summernote('code', '<%=txtDescricao.InnerHtml%>');
            }
        }
        $(document).ready(prepararEdicao());
    </script>
</asp:Content>
