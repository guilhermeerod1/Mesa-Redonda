<%@ Page Title="Edição de Produtos" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EdicaoProduto.aspx.cs" Inherits="Administrativa.Produtos.EdicaoProduto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/produtosScript.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script>
        var descricaoProduto = "";
    </script>
    <br />    
    <div class="panel panel-default">
        <form runat="server" class="panel-body">
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <h3>Produto</h3>
            <asp:HiddenField ID="hdnIdProduto" runat="server" />
            <label>Nome:</label><br />
            <asp:TextBox ID="txtNomeProduto" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label>Foto do Produto:</label><br />
            <asp:FileUpload ID="fuFotoProduto" runat="server" /><br />
            <label>Preço:</label><br />
            <asp:TextBox ID="txtPrecoProduto" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label>Descrição:</label><br />
            <textarea id="txtDescricao" runat="server" ClientId="Predictable"></textarea>
            <br />
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-success" OnClick="btnSalvar_Click" />
            <asp:Label ID="lblMensagem" runat="server"></asp:Label>
        </form>
    </div>
</asp:Content>
