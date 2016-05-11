<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EdicaoProduto.aspx.cs" Inherits="Administrativa.Produtos.EdicaoProduto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        Produto
        <hr />
        Nome:<br />
        <asp:TextBox ID="txtNomeProduto" runat="server"></asp:TextBox><br />
        Preço:<br />
        <asp:TextBox ID="txtPrecoProduto" runat="server"></asp:TextBox><br />
        Descrição:<br />
        <div id="summernote"></div><br />
        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" />
        <asp:Label ID="lblMensagem" runat="server" ></asp:Label>
    </form>
    <script>
        $(document).ready(function() {
      $('#summernote').summernote();
        });
     </script>
</asp:Content>
