<%@ Page Title="Usuários Cadastrados" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="Administrativa.Usuarios.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <div style="padding:10px;text-align:center;">
        <h1>Usuários</h1>
    </div>
    <hr />
    <div class="well">
        <asp:Label ID="lblNumeroUsuarios" runat="server" Text="Label"></asp:Label>
    </div>
    <asp:Repeater ID="rptUsuarios" runat="server" OnItemDataBound="rptUsuarios_ItemDataBound">
        <HeaderTemplate>
            <table class="table table-condensed">
                <thead>
                    <tr>
                        <th>Usuário</th>
                        <th>Email</th>
                        <th>Telefone</th>
                        <th>Opções</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label ID="lblUsuario" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblEmail" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTelefone" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:HyperLink ID="lnkEditar" runat="server">Editar</asp:HyperLink>
                    <asp:HyperLink ID="lnkRemover" runat="server">Remover</asp:HyperLink>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>
