<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaFretamento.aspx.cs" Inherits="ViagemWeb.ListaFretamento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:UpdatePanel ID="uppGridViewFretamento" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div>
                <p />
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="panel panel-centralizar">
                            <div>
                                <%--<asp:Button ID="btnCadastro" runat="server" Text="+ Cadastrar" Class=" btn btn-cadastro-lista" OnClick="btnCadastro_Click" />--%>
                                <asp:LinkButton runat="server" ID="btnCadastroFretamento"
                                    CssClass="btn-cadastro-lista btn btn-default"
                                    OnClick="btnCadastroFretamento_Click">
                                <i class="glyphicon glyphicon-plus sat-icon-with-text" style="margin-right: 3px;"></i>
                                Cadastrar
                                </asp:LinkButton>
                                <h3>Lista de Fretamento</h3>
                            </div>
                        </div>
                        <asp:GridView
                            ID="grpListaDeFretamento"
                            runat="server"
                            AutoGenerateColumns="False"
                            CssClass="table table-hover"
                            GridLines="None"
                            AllowPaging="True"
                            DataKeyNames="FretamentoId"
                            PageSize="10">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField
                                    DataField="FretamentoNome"
                                    HeaderText="Nome"
                                    SortExpression="FretamentoNome" />
                                <asp:BoundField
                                    DataField="FretamentoKm"
                                    HeaderText="Km"
                                    SortExpression="FretamentoKm" />
                                <asp:BoundField
                                    DataField="FretamentoValor"
                                    HeaderText="Valor"
                                    SortExpression="FretamentoValor" />
                                <asp:BoundField
                                    DataField="FretamentoDescricao"
                                    HeaderText="Descricao"
                                    SortExpression="FretamentoDescricao" />
                                <asp:BoundField
                                    DataField="FretamentoCliente"
                                    HeaderText="Cliente"
                                    SortExpression="FretamentoCliente" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkExluir" runat="server" CssClass="btn btn-Lista" OnCommand="Excluir" CommandArgument='<%# Eval("FretamentoId")%>' ToolTip="Excluir">
                                <i aria-hidden="true" class="glyphicon glyphicon-trash"></i>
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="LinkEditar" runat="server" CssClass="btn btn-Lista" OnCommand="Editar" CommandArgument='<%# Eval("FretamentoId")%>' ToolTip="Editar">
                                <i aria-hidden="true" class="glyphicon glyphicon-edit"></i>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <PagerStyle HorizontalAlign="Left" />
                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" />
                        </asp:GridView>
                        <div>
                            <asp:Label ID="lblQuantidade" runat="server" CssClass="label label-f" />
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
