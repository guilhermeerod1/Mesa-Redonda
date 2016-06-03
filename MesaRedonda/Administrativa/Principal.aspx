<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="Administrativa.Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Administrativo</h2>
    <hr />
    <iframe src="Produtos/EdicaoProduto.aspx" style="width:100%; min-height:800px;">

    </iframe>
</asp:Content>
