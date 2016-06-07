<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Administrativa.Login.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Autenticação</title>
    <link rel="stylesheet" href="../Content/bootstrap.min.css" type="text/css" />
    <script src="../Scripts/jquery-1.9.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
</head>
<body>
    <div class="container-fluid">
        <header class="container-fluid" style="text-align: center; padding: 10px;">
            <img src="../Imgs-Adm/logo.jpg" alt="Logo do sistema" width="180" height="155" />
        </header>
        <hr />
        <form id="formLogin" runat="server">
            <div class="container">
                <label>Nome de Usuário:</label><br />
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" /><br />
                <label>Senha:</label><br />
                <asp:TextBox ID="txtSenha" TextMode="Password" runat="server" CssClass="form-control" /><br />
                <div style="text-align:right;">
                    <asp:Button ID="btnSubmeter" Text="Logar" runat="server" OnClick="btnSubmeter_OnClick" CssClass="btn btn-success" />
                </div>
            </div>
        </form>
    </div>
</body>
</html>
