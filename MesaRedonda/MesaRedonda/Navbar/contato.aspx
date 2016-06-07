<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="contato.aspx.cs" Inherits="MesaRedonda.Navbar.contato" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
        <label>Assunto</label><br />
        <asp:textbox ID="txtAssunto" runat="server" CssClass="form-control">
        </asp:textbox><br />
        <label>Conteúdo</label><br />
        <textarea runat="server" id="txtConteudo" class="form-control">
        </textarea><br />
        <asp:button runat="server" ID="btnEnviar" text="Enviar" OnClick="btnEnviar_OnCLick" />
    </form>    
</asp:Content>
