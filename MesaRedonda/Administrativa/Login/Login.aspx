<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Administrativa.Login.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p>Entre com um e-mail</p>
        <asp:TextBox ID="usuarioTextBox" Text="Insira o email neste campo" runat="server" />
        <p>Entre com uma senha</p>
        <asp:TextBox ID="senhaTextBox" Text="Insira a senha neste campo" runat="server" />

        <asp:Button ID="btnSubmeter" Text="Logar" runat="server" OnClick="btnSubmeter_OnClick" />

    </div>
    </form>
</body>
</html>
