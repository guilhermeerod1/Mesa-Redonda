<%@ Page Title="Edição de Produtos" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EdicaoProduto.aspx.cs" Inherits="Administrativa.Produtos.EdicaoProduto" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="panel panel-default">    
    <form runat="server" class="panel-body">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <h3>Produto</h3>
        <label>Nome:</label><br />
        <asp:TextBox ID="txtNomeProduto" runat="server" CssClass="form-control"></asp:TextBox><br />
        <label>Foto do Produto:</label><br />
        <ajaxToolkit:AsyncFileUpload ID="AsyncFileUpload1" runat="server"  OnUploadedComplete="AsyncFileUpload1_UploadedComplete" />
        <asp:Button ID="Button1" runat="server" Text="Upload" />
        <div class="row">
            <div class="col-lg-8">
                <asp:DropDownList ID="ddlFotos" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>            
            <div class="col-lg-4" style="padding: 5px; max-height: 350px;max-width:350px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Image ID="Image1" runat="server" />
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger  ControlID="AsyncFileUpload1" EventName="UploadedComplete" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>            
        </div><br />
        <label>Preço:</label><br />        
        <asp:TextBox ID="txtPrecoProduto" runat="server" CssClass="form-control">
        </asp:TextBox><br />
        <label>Descrição:</label><br />
        <div id="summernote"></div><br />
        <asp:Button ID="btnSalvar" runat="server" Text="Salvar" CssClass="btn btn-success" />
        <asp:Label ID="lblMensagem" runat="server"></asp:Label>
    </form>
        </div>
    <script>
        $(document).ready(function() {
      $('#summernote').summernote();
        });
     </script>
</asp:Content>
