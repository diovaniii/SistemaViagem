using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViagemSeg;
using ViagemSeg.Svc;
using ViagemWeb.Form;

namespace ViagemWeb
{
    public partial class VendaViagem : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carregaNome();
                CarregarListaViagem();
                CarregarListaAssento();
            }

        }


        protected void salvarQuantidade_Click(object sender, EventArgs e)
        {
            if (quantidadeAdulto.Value == "")
                quantidadeAdulto.Value = "0";
            if (quantidadeAdolecente.Value == "")
                quantidadeAdolecente.Value = "0";
            if (quantidadeCrianca.Value == "")
                quantidadeCrianca.Value = "0";
            if (quantidadeBebe.Value == "")
                quantidadeBebe.Value = "0";

            var palavras = Convert.ToInt32(quantidadeAdulto.Value) + Convert.ToInt32(quantidadeAdolecente.Value) +
                           Convert.ToInt32(quantidadeCrianca.Value) + Convert.ToInt32(quantidadeBebe.Value);
            lblTeste.Text = palavras.ToString();
            lblTeste.Visible = true;
            uppPanel.Update();

            List<Viagem> viagems = SvcVendaCliente.ListarViagem();
            Viagem viagem = viagems.Where(a => a.Id == Convert.ToInt32(ddlViagem.SelectedValue)).FirstOrDefault();
            List<VendaCliente> listaVendaClientes = new List<VendaCliente>();
            Cliente cliente = new Cliente();
            
            for (int i = 0; i < Convert.ToInt32(quantidadeAdulto.Value); i++)
            {
                VendaCliente vendaCliente = new VendaCliente();
                cliente.Nome = ddlCliente.SelectedItem.Text;
                vendaCliente.Viagem = viagem;
                vendaCliente.Cliente = cliente;
                vendaCliente.FaixaEtaria = "Adulto";
                listaVendaClientes.Add(vendaCliente);
            }
            for (int i = 0; i < Convert.ToInt32(quantidadeAdolecente.Value); i++)
            {
                VendaCliente vendaCliente = new VendaCliente();
                cliente.Nome = ddlCliente.SelectedItem.Text;
                vendaCliente.Cliente = cliente;
                vendaCliente.FaixaEtaria = "Adolecente";
                listaVendaClientes.Add(vendaCliente);
            }
            for (int i = 0; i < Convert.ToInt32(quantidadeCrianca.Value); i++)
            {
                VendaCliente vendaCliente = new VendaCliente();
                cliente.Nome = ddlCliente.SelectedItem.Text;
                vendaCliente.Cliente = cliente;
                vendaCliente.FaixaEtaria = "Crianca";
                listaVendaClientes.Add(vendaCliente);
            }
            for (int i = 0; i < Convert.ToInt32(quantidadeBebe.Value); i++)
            {
                VendaCliente vendaCliente = new VendaCliente();
                cliente.Nome = ddlCliente.SelectedItem.Text;
                vendaCliente.Cliente = cliente;
                vendaCliente.FaixaEtaria = "Bebe";
                listaVendaClientes.Add(vendaCliente);
            }

            
            grpVendaCliente.DataSource = listaVendaClientes;
            grpVendaCliente.DataBind();
            uppGridView.Update();

            quantidadeAdulto.Value = "0";
            quantidadeAdolecente.Value = "0";
            quantidadeCrianca.Value = "0";
            quantidadeBebe.Value = "0";
        }

        protected void carregaNome()
        {
            ddlCliente.DataSource = SvcCliente.ListarTodosClientes();
            ddlCliente.DataBind();
            UpdatePanel.Update();
        }

        private void CarregarListaViagem()
        {
            ddlViagem.DataSource = SvcViagem.ListarTodasViagens();
            ddlViagem.DataBind();
            UpdatePanel.Update();
        }

        private void CarregarListaAssento()
        {
            List<Viagem> viagems = SvcVendaCliente.ListarViagem();
            Viagem viagem = viagems.Where(a => a.Id == Convert.ToInt32(ddlViagem.SelectedValue)).FirstOrDefault();

            List<VendaCliente> vendaClientes = new List<VendaCliente>();
            vendaClientes = SvcVendaCliente.PesquisaViagem(viagem.Id);
            int[] assento = new int[0];
            foreach (var item in vendaClientes)
            {
                int lugar = item.Assento;
                assento = assento.Concat(new int[] { lugar }).ToArray();

            }
            ListaAssento.Value = string.Join(", ", assento);
            Veiculo QuantAssento = new Veiculo();
            QuantAssento = SvcVeiculo.BuscarVeiculo(Convert.ToInt32( viagem.Veiculo));
            int t = QuantAssento.Lugares.Value;
            int i = 4;
            var total =  t / i ;
            QuantidadeAssento.Value = total.ToString();
        }

        protected void grpVendaCliente_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList ddlgrid = (e.Row.FindControl("ddlCliente1") as DropDownList);
                ddlgrid.DataSource = SvcCliente.ListarTodosClientes();
                ddlgrid.DataTextField = "ClienteNome";
                ddlgrid.DataValueField = "ClienteId";
                ddlgrid.DataBind();
            }
        }

        protected void btnAdicionarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroCliente.aspx");
        }

        protected void salvarVenda_Click(object sender, EventArgs e)
        {
            List<VendaCliente> listaVendaCliente = new List<VendaCliente>();
            foreach (GridViewRow item in grpVendaCliente.Rows)
            {

                VendaCliente vendaCliente = new VendaCliente();
                //SALVA ID DO CLIENTE
                TextBox nome = (TextBox)item.FindControl("txtNome");
                if (nome.Text == "")
                {
                    DropDownList idCliente = (DropDownList)item.FindControl("ddlCliente1");
                    string selectvalueCliente = idCliente.SelectedValue;
                    vendaCliente.VendaIdCliente = Convert.ToInt32(selectvalueCliente);
                }
                else
                {
                    Cliente cliente = new Cliente();
                    cliente.Nome = nome.Text;
                    TextBox cpf = (TextBox)item.FindControl("txtCpf");
                    cliente.Cpf = cpf.Text;
                    TextBox data = (TextBox)item.FindControl("txtDataNascimento");
                    cliente.DataNascimento = Convert.ToDateTime(data.Text);
                    Endereco enderecoPessoal = new Endereco();
                    Endereco enderecoComercial = new Endereco();
                    cliente.Status = 0;
                    cliente.Email = "semEmail@semEmail.com";
                    cliente.Telefone = "00000000000";
                    cliente = SvcCliente.AlteraSalva(cliente, enderecoPessoal, enderecoComercial);
                    vendaCliente.VendaIdCliente = cliente.Id;
                    
                }
                

                vendaCliente.VendaIdViagem = Convert.ToInt32(ddlViagem.SelectedValue);


                string faixaEtaria = item.Cells[2].Text;
                vendaCliente.FaixaEtaria = faixaEtaria.ToString();

                string valor = item.Cells[3].Text;
                vendaCliente.VendaValorViagem = Convert.ToDecimal(valor);

                TextBox desconto = (TextBox)item.FindControl("ValorDesconto");
                string valorDesconto = desconto.Text;
                if(valorDesconto != "")
                vendaCliente.VendaDesconto = Convert.ToDecimal(valorDesconto);

                TextBox pago = (TextBox)item.FindControl("ValorPago");
                string valorPago = pago.Text;
                vendaCliente.VendaValorPago = Convert.ToDecimal(valorPago);


                TextBox teste4 = (TextBox)item.FindControl("poltrona");
                vendaCliente.Assento = Convert.ToInt32(teste4.Text);

                //var assento = item.Cells[7].Text;
                //vendaCliente.Assento = Convert.ToInt32(assento);

                vendaCliente.Status = 0;
                SvcVendaCliente.AlteraSalva(vendaCliente);
                listaVendaCliente.Add(vendaCliente);
                
            }
            Response.Redirect("ListaVendaViagem.aspx");
        }

        protected void ddlViagem_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarListaAssento();
        }
    }
}