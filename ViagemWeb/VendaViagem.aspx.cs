using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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

        protected void salvar_Click(object sender, EventArgs e)
        {
            uppGridView.Update();
            List<VendaViagem> lista = new List<VendaViagem>();
            foreach (GridViewRow item in grpVendaCliente.Rows)
            {
                TextBox teste4 = (TextBox)item.FindControl("poltrona");
                var poltrona = Convert.ToInt32(teste4.Text);

                var teste = item.Cells[7];
                // //var teste2 = item.TemplateControl.
            }

            
        }
    }
}