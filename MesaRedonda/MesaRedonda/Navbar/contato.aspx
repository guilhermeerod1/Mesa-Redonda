<%@ Page Title="Contato" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="contato.aspx.cs" Inherits="MesaRedonda.Navbar.contato" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <form runat="server" class="panel panel-default">
            <div class="panel-body">
                <h2 style="text-align:center;">Contato</h2>
                <label>Assunto:</label><br />
                <asp:TextBox ID="txtAssunto" runat="server" CssClass="form-control">
                </asp:TextBox><br />
                <label>Conteúdo:</label><br />
                <textarea runat="server" id="txtConteudo" class="form-control" rows="10" style="resize:none;" >
                </textarea><br />
                <div style="text-align:right;">
                    <asp:Button runat="server" ID="btnEnviar" Text="Enviar" OnClick="btnEnviar_OnCLick" CssClass="btn btn-success" />
                </div>
            </div>
        </form>
    </div>
</asp:Content>
