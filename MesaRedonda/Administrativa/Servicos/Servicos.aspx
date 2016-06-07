<%@ Page Title="Serviços Cadastrados" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Servicos.aspx.cs" Inherits="Administrativa.Servicos.Servicos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <div style="padding:5px; text-align:center"><h1>Serviços</h1></div>
    <hr />
    <div class="well">
        <asp:Label ID="lblNumeroServicos" runat="server"></asp:Label>
    </div>
    <div>
        <asp:Repeater ID="rptServicos" runat="server" OnItemDataBound="rptServicos_ItemDataBound">
            <ItemTemplate>
                <div class="panel panel-default">
                    <div style="padding: 30px; overflow: auto;">
                        <div style="text-align: center">
                            <h1>
                                <asp:Label ID="lblNome" runat="server"></asp:Label>
                            </h1>
                        </div>
                        <div style="text-align: center; padding-top: 10px;">
                            <asp:Image ID="imgFotoServico" runat="server" CssClass="img-thumbnail" />
                        </div>
                        <div style="padding: 50px; clear: both;">
                            <asp:Label ID="lblDescricao" runat="server"></asp:Label>
                        </div>
                        <div style="float: right">
                            <h1>R$: 
                                <asp:Label ID="lblPreco" runat="server"></asp:Label>
                            </h1>
                        </div>
                        <div style="clear: both;"></div>
                        <div style="float: right;">
                            <asp:HyperLink ID="lnkRemover" runat="server" Text="Remover" />
                            |  
                            <asp:HyperLink ID="lnkEditar" runat="server" Text="Editar" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
