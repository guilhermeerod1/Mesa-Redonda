<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EdicaoServicos.aspx.cs" Inherits="Administrativa.Servicos.EdicaoServicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div class="panel panel-default">
        <form runat="server" class="panel-body">
            <asp:ScriptManager runat="server"></asp:ScriptManager>
            <h3>Serviço</h3>
            <asp:HiddenField ID="hdnIdServico" runat="server" />
            <label>Nome:</label><br />
            <asp:TextBox ID="txtNomeServico" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label>Preço:</label><br />
            <asp:TextBox ID="txtPrecp" runat="server" CssClass="form-control"></asp:TextBox><br />
            <label>Descrição:</label><br />
            <textarea id="txtDescricao" runat="server" ClientId="Predictable"></textarea>
            <br />
            <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-success" OnClick="btnSalvar_Click" />
            <asp:Label ID="lblMensagem" runat="server"></asp:Label>
        </form>
    </div>
</body>
</html>
