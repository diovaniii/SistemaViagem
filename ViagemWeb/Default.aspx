<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ViagemWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <p />
        <div class="panel panel-default">
            <div class="panel-body">
                <h3>Lista de clientes</h3>
                <asp:GridView
                    ID="grpListaDeClientes"
                    runat="server"
                    AutoGenerateColumns="False"
                    CssClass="table"
                    GridLines="None"
                    DataKeyNames="ClienteId">
                    <Columns>
                        <asp:BoundField
                            DataField="ClienteNome"
                            HeaderText="Nome"
                            SortExpression="ClienteNome" />
                        <asp:BoundField
                            DataField="ClienteTelefone"
                            HeaderText="Telefone"
                            SortExpression="ClienteTelefone" />
                        <asp:BoundField
                            DataField="ClienteCpf"
                            HeaderText="Cpf"
                            SortExpression="ClienteCpf" />
                        <asp:BoundField
                            DataField="ClienteDataNascimento"
                            HeaderText="Data Nascimento"
                            SortExpression="ClienteDataNascimento" />

                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
