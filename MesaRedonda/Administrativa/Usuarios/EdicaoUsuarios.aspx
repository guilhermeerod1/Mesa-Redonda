<%@ Page Title="Edição de Usuários" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EdicaoUsuarios.aspx.cs" Inherits="Administrativa.Usuarios.EdicaoUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel panel-default">
        <div class="panel-body">
            <h3>Usuário</h3>
            <br />
            <label>Nome:</label><br />
            <asp:TextBox ID="txtNomeUsuario" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label>Tipo:</label><br />
            <asp:RadioButtonList ID="rbListTipo" runat="server">
                <asp:ListItem Text="Administrador" Value="A"></asp:ListItem>
                <asp:ListItem Text="Padrão" Value="P"></asp:ListItem>
            </asp:RadioButtonList>
            <label>Senha:</label><br />
            <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label>Email:</label><br />
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label>Telefone:</label><br />
            <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control"></asp:TextBox><br />
            <br />
            <asp:Label ID="lblMensagem" runat="server"></asp:Label><br />
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-success" OnClick="btnSalvar_Click" />
        </div>
    </div>
</asp:Content>
