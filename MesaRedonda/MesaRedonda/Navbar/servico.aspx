<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="servico.aspx.cs" Inherits="MesaRedonda.Navbar.servico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="section">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <h1>Nosso serviço</h1>
          </div>
        </div>
      </div>
    </div>
    <div class="section">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <p class="lead text-justify">- Você, cliente, através do celular poderá acessar o menu com as mais
              variadas pizzas, até consultar a conta.
              <br>
              <br>- Delivery, utilizando uma pequena caixa que pode ser recarregada energia
              e a cada três minutos dispara um choque a uma temperatura de 80ºC. A pizza
              chegará quentinha na sua casa com a mesma qualidade da pizzaria.
              <br>
              <br>- Fazemos pizza ao vivo na sua casa ou em festas.
              <br>
              <br>- Temos máquina de espalhar molho no disco da pizza.
              <br>
              <br>- Oferecemos o serviço de KIT aniversário, com pizzas em fatias, refrigerantes
              e copos descartáveis.</p>
          </div>
        </div>
      </div>
    </div>
    <div class="section">
      <div class="container">
        <div class="row">
          <div class="col-md-6">
             <img src="../Imgs/servico2.jpg" class="center-block img-responsive img-thumbnail" style="height: 200px; width: 250px">
          </div>
          <div class="col-md-6">
            <img src="../Imgs/servico1.jpg" class="center-block img-responsive img-thumbnail" style="height: 200px; width: 250px">
          </div>
        </div>
      </div>
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
