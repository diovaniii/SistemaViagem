<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ViagemWeb.WebForm1" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" class="row col-xs-12 col-md-4 col-md-offset-4">
    <h2><%: Title %></h2>
    <h3>Cadastro Cliente</h3>
        
    <div class="container-fluid ">
        <div>
            <asp:TextBox ID="txbNome" runat="server" placeholder="Nome" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <asp:TextBox ID="txbTelefone" runat="server" placeholder="Telefone" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <asp:TextBox ID="txbCpf" runat="server" placeholder="Cpf" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <asp:TextBox ID="txbEndereco" runat="server" placeholder="Endereço" CssClass="form-control"></asp:TextBox>
        </div>
        <div>
            <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
        </div>
    </div>
            <asp:Button runat="server" Text="Salvar" CssClass="form-control" BackColor="Green" Font-Bold="true" OnClick="BtnSalvar_OnClick"/>

</asp:Content>
