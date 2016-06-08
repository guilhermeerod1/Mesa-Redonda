<%@ Page Title="Página Inicial" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="MesaRedonda.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="section">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <h1>Promoções do dia</h1>
              <br />
          </div>
        </div>
      </div>
    </div>
    <div class="section text-center">
      <div class="container">
        <div class="row">
          <div class="col-md-4 text-center">
            <img src="Imgs/pizza4.jpg" class="center-block img-responsive img-thumbnail" style="height: 200px; width: 250px">
            <h2>Pizza vegetariana</h2>
            <p>Recheio: Azeitona, tomate e brócolis</p>
          </div>
          <div class="col-md-4 text-center">
            <img src="Imgs/pizza6.jpg" class="center-block img-responsive img-thumbnail" style="height: 200px; width: 250px">
            <h2>Pizza de calabresa</h2>
            <p>Recheio: Calabresa com queijo</p>
          </div>
          <div class="col-md-4 text-center">
            <img src="Imgs/pizza10.jpg" class="center-block img-responsive img-thumbnail" style="height: 200px; width: 250px">
            <h2>Pizza de chocolate</h2>
            <p>Recheio: Chocolate com cobertura de M&M</p>
              <br />
          </div>
        </div>
      </div>
    </div>
    <div class="section">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <h1>Chef</h1>
              <br />
          </div>
        </div>
      </div>
    </div>
    <div class="section">
      <div class="container">
        <div class="row">
          <div class="col-md-3">
            <img src="Imgs/pizzaiolo.png" class="img-responsive">
          </div>
          <div class="col-md-9">
            <h1>Enrico Baggio</h1>
            <p class="lead text-justify">Enrico Baggio é brasileiro apaixonado pela gastronomia italiana,
              e traz na sua formação todo o sincretismo cultural que existe no Velho
              Continente, inclusive na culinária. Nos anos 1990, Enrico viveu em Milano, Nova York e Miami.
              De volta ao Brasil, foi morar em São Paulo, onde trabalhou em locais característico
              da cidade como o Terraço Itália e o Margherita Pizzeria. Após estas ricas
              experiências, mudou-se para Ribeirão Preto, e decidiu trabalhar no Mesa
              Redonda, a pizzaria mais badalada da cidade.</p>
          </div>
        </div>
      </div>
    </div>
    <div class="section">
      <div class="container">
        <div class="row">
          <div class="col-md-12">
            <blockquote>
              <p>Verdadeiramente a pizza do Mesa Redonda é sensacional !</p>
              <footer>Matheus Calache</footer>
            </blockquote>
          </div>
        </div>
      </div>
    </div>
</asp:Content>
