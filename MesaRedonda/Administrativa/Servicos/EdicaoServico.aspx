<%@ Page Title="Edição de Serviços" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EdicaoServico.aspx.cs" Inherits="Administrativa.Servicos.EdicaoServico" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="well">Serviço</div>
    <div class="panel panel-default">
        <div class="panel-body">
            <label>Nome:</label><br />
            <asp:TextBox ID="txtNomeServico" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label>Imagem</label><br />
            <asp:FileUpload ID="fuFotoServico" runat="server" />
            <label>Preço:</label><br />
            <asp:TextBox ID="txtPrecoServico" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label>Descrição:</label><br />
            <textarea id="txtDescricao" runat="server"></textarea>
            <br />
            <asp:Label ID="lblMensagem" runat="server"></asp:Label><br />
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-success" OnClick="btnSalvar_Click" />
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
