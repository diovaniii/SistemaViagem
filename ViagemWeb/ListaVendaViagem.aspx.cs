using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViagemSeg;
using ViagemSeg.Comuns;
using ViagemSeg.Svc;
using ViagemSeg.Dto;

namespace ViagemWeb
{
    public partial class ListaVendaViagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                carregaNome();
                carregaViagem();
                CarregaListaViagem();
                lblNUmeroRegistro(SvcVendaCliente.ListarVendaCliente());
            }
        }

        protected void carregaNome()
        {
            ddlNome.DataSource = SvcCliente.ListarTodosClientes();
            ddlNome.DataBind();
            ddlNome.Items.Insert(0, new ListItem("--Select--", "0"));
            uppPainelVenda.Update();
        }

        protected void carregaViagem()
        {
            ddlViagem.DataSource = SvcViagem.ListarTodasViagens();
            ddlViagem.DataBind();
            ddlViagem.Items.Insert(0, new ListItem("--Select--", "0"));
            uppPainelVenda.Update();
        }

        private void CarregaListaViagem()
        {
            grpListaDeVenda.DataSource = SvcVendaCliente.ListarVendaCliente();
            grpListaDeVenda.DataBind();
            uppGridView.Update();
        }

        protected void lblNUmeroRegistro(List<DtoVendaCliente> viagem)
        {
            int rowCount = viagem.Count;
            lblQuantidade.Text = "Numero de registros: " + rowCount.ToString();
        }

        protected void btnBuscarVenda_Click(object sender, EventArgs e)
        {
            VendaCliente vendaCliente = new VendaCliente();
            vendaCliente.VendaIdCliente = Convert.ToInt32(ddlNome.SelectedValue);
            vendaCliente.VendaIdViagem = Convert.ToInt32(ddlViagem.SelectedValue);

            var vendaEncontrada = SvcVendaCliente.Pesquisa(vendaCliente);
            lblNUmeroRegistro(vendaEncontrada);

            grpListaDeVenda.DataSource = vendaEncontrada;
            grpListaDeVenda.DataBind();
            uppGridView.Update();
        }

        protected void btnVender_Click(object sender, EventArgs e)
        {
            Response.Redirect("VendaViagem.aspx");
        }

        protected void grpListaDeVenda_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grpListaDeVenda_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int VendaIdCliente = Convert.ToInt32( e.Row.Cells[1].Text);
                Cliente cliente = new Cliente();
                cliente = SvcCliente.BuscarCliente(VendaIdCliente);
                e.Row.Cells[1].Text = cliente.Nome;
            }
        }
    }
}