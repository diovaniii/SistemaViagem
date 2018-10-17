<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StatsViagem.aspx.cs" Inherits="ViagemWeb.StatsViagem" %>

<%@ Register Src="~/Form/Porcentagem.ascx" TagPrefix="sis" TagName="Porcentagem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">
        <div class="panel-body">
            <div class="panel panel-centralizar">
                <fieldset style="float: left; height: 70%; width: 70%;">
                    <legend>Dados do Cliente</legend>
                    <div class="row">
                        <div class="col-md-4">
                            <label>
                                Viagem:
                        <br>
                                <asp:TextBox ID="txtViagem" runat="server" Class="form-control"></asp:TextBox>
                            </label>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Local:
                        <br>
                                <asp:TextBox ID="txtLocal" runat="server" Class="form-control" MaxLength="15"></asp:TextBox>
                            </label>
                        </div>

                        <div class="col-md-4">
                            <label>
                                Estado:
                        <br>
                                <select id="txtEstado" runat="server" class="form-control" font-bold="false">
                                    <option value=""></option>
                                    <option value="IN">INTERNACIONAL</option>
                                    <option value="AC">Acre</option>
                                    <option value="AL">Alagoas</option>
                                    <option value="AP">Amapá</option>
                                    <option value="AM">Amazonas</option>
                                    <option value="BA">Bahia</option>
                                    <option value="CE">Ceará</option>
                                    <option value="DF">Distrito Federal</option>
                                    <option value="ES">Espírito Santo</option>
                                    <option value="GO">Goiás</option>
                                    <option value="MA">Maranhão</option>
                                    <option value="MT">Mato Grosso</option>
                                    <option value="MS">Mato Grosso do Sul</option>
                                    <option value="MG">Minas Gerais</option>
                                    <option value="PA">Pará</option>
                                    <option value="PB">Paraíba</option>
                                    <option value="PR">Paraná</option>
                                    <option value="PE">Pernambuco</option>
                                    <option value="PI">Piauí</option>
                                    <option value="RJ">Rio de Janeiro</option>
                                    <option value="RN">Rio Grande do Norte</option>
                                    <option value="RS">Rio Grande do Sul</option>
                                    <option value="RO">Rondônia</option>
                                    <option value="RR">Roraima</option>
                                    <option value="SC">Santa Catarina</option>
                                    <option value="SP">São Paulo</option>
                                    <option value="SE">Sergipe</option>
                                    <option value="TO">Tocantins</option>
                                </select>
                            </label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label>
                                Valor:
                        <br>
                                <asp:TextBox ID="txtValor" runat="server" Class="form-control"></asp:TextBox>
                            </label>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Data Inicio:
                                <br>
                                <asp:TextBox ID="txtDataInicio" runat="server" Class="form-control" TextMode="Date"></asp:TextBox>
                            </label>
                        </div>

                        <div class="col-md-4">
                            <label>
                                Data Fim:
                                <br>
                                <asp:TextBox ID="txtDataFim" runat="server" Class="form-control" TextMode="Date"></asp:TextBox>
                            </label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label>
                                Veiculo:
                        <br>
                                <asp:DropDownList ID="ddlVeiculo" runat="server" DataTextField="VeiculoIdentificacao" DataValueField="VeiculoId" Class="form-control" />
                            </label>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Assentos:
                        <br>
                                <asp:TextBox ID="txtAssento" runat="server" Class="form-control"></asp:TextBox>
                            </label>
                        </div>

                        <div class="col-md-6">
                            <label>
                                Descrição:
                        <br>
                                <asp:TextBox ID="txtDescricao" runat="server" Class="form-control descricao " Rows="8" TextMode="MultiLine"></asp:TextBox>
                            </label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-4">
                            <label>
                                Valor Total:
                        <br>
                                <asp:TextBox ID="txbValorTotal" runat="server" Class="form-control"></asp:TextBox>
                            </label>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Valor Pago:
                        <br>
                                <asp:TextBox ID="txbValorPago" runat="server" Class="form-control"></asp:TextBox>
                            </label>
                        </div>

                        <div class="col-md-4">
                            <label>
                                Valor Despesa:
                        <br>
                                <asp:TextBox ID="txbValorDespesa" runat="server" Class="form-control"></asp:TextBox>
                            </label>
                        </div>
                        <div class="col-md-4">
                            <label>
                                Valor Lucro:
                        <br>
                                <asp:TextBox ID="txbValorLucro" runat="server" Class="form-control"></asp:TextBox>
                            </label>
                        </div>
                    </div>
                </fieldset>
                <fieldset style="float: right; height: 30%; width: 30%;">
                    <legend>Porcentagem</legend>
                    <div class="row">
                        <sis:Porcentagem runat="server" ID="Porcentagem" />
                    </div>
                    <div class="row">
                        <div id="chartContainer" style="height: 300px; width: 100%;"></div>
                        <script src="https://canvasjs.com/assets/script/jquery-1.11.1.min.js"></script>
                        <script src="https://canvasjs.com/assets/script/jquery.canvasjs.min.js"></script>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
    <input type="hidden" id="ChartLucro" runat="server" clientidmode="static" />
    <input type="hidden" id="ChartDespesa" runat="server" clientidmode="static" />
    <input type="hidden" id="ChartTotal" runat="server" clientidmode="static" />




    <script>
        window.onload = function () {

            //Better to construct options first and then pass it as a parameter
            var options = {
                title: {
                    text: "Meta de vendas da viagem"
                },
                animationEnabled: true,
                exportEnabled: true,
                data: [
                    {
                        name: "Lucro",
                        type: "spline", //change it to line, area, column, pie, etc, spline
                        showInLegend: true,
                        dataPoints: [
                            { x: 0, y: 0 },
                            { x: 100, y: parseFloat(document.getElementById("ChartLucro").value) }
                        ]
                    },
                    {
                        name: "Total",
                        type: "spline", //change it to line, area, column, pie, etc, spline
                        showInLegend: true,
                        dataPoints: [
                            { x: 0, y: 0 },
                            { x: 100, y: parseFloat(document.getElementById("ChartTotal").value) }
                        ]
                    },
                    {
                        name: "Despesa",
                        type: "spline", //change it to line, area, column, pie, etc, spline
                        showInLegend: true,
                        dataPoints: [
                            { x: 0, y: 0 },
                            { x: 100, y: parseFloat(document.getElementById("ChartDespesa").value) }
                        ]
                    }
                ]

            };
            $("#chartContainer").CanvasJSChart(options);

        }
    </script>
</asp:Content>
