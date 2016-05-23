<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EdicaoUsuarios.aspx.cs" Inherits="Administrativa.Usuarios.EdicaoUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div class="panel panel-default">
        <form runat="server" class="panel-body">
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <h3>Usuário</h3>
            <asp:HiddenField ID="hdnIdUsuario" runat="server" />
            <label>Nome:</label><br />
            <asp:TextBox ID="txtNomeUsuario" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label>Tipo:</label><br />
            <asp:TextBox ID="txtTipo" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label>Senha:</label><br />
            <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label>Telefone:</label><br />
            <asp:TextBox ID="txtTelefone" runat="server" CssClass="form-control"></asp:TextBox><br />
            <br />
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-success" OnClick="btnSalvar_Click" />
            <asp:Label ID="lblMensagem" runat="server"></asp:Label>
        </form>
    </div>
</body>
</html>
