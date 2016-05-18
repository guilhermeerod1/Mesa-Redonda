<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Produtos.aspx.cs" Inherits="Administrativa.Produtos.Produtos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Produtos cadastrados</h3>
    <hr />
    <div>
        <asp:Label ID="lblNumeroProdutos" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Repeater ID="rptProdutos" runat="server" OnItemDataBound="rptProdutos_ItemDataBound">
            <ItemTemplate>
                <div>
                    <div><asp:Label ID="lblIdProduto" runat="server"></asp:Label></div>
                    <div><asp:Label ID="lblNome" runat="server"></asp:Label></div>
                    <div><asp:Label ID="lblPreco" runat="server"></asp:Label></div>
                    <div><asp:Image ID="imgFotoProduto" runat="server" /></div>
                    <div><asp:Label ID="lblDescricao" runat="server"></asp:Label></div>
                    <div>
                        <asp:HyperLink ID="lnkRemover" runat="server" Text="Remover" />
                        <asp:HyperLink ID="lnkEditar" runat="server" Text="Editar" />
                    </div>                    
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
