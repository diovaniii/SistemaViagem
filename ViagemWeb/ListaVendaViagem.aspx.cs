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
        decimal soma = 0;

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
            decimal ValorTotal = 0;
            foreach (var item in vendaEncontrada)
            {
                ValorTotal += item.VendaValorPago;
            }
            valorTotal.Text = ValorTotal.ToString();
            uppGridView.Update();
        }

        protected void btnVender_Click(object sender, EventArgs e)
        {
            Response.Redirect("VendaViagem.aspx");
        }

        protected void grpListaDeVenda_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CarregaListaViagem();
            grpListaDeVenda.PageIndex = e.NewPageIndex;
            grpListaDeVenda.DataBind();
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

        protected void GerarPDF_Click(object sender, EventArgs e)
        {
            VendaCliente vendaCliente = new VendaCliente();
            vendaCliente.VendaIdCliente = Convert.ToInt32(ddlNome.SelectedValue);
            vendaCliente.VendaIdViagem = Convert.ToInt32(ddlViagem.SelectedValue);

            var vendaEncontrada = SvcVendaCliente.Pesquisa(vendaCliente);

            var document = new PdfSharp.Pdf.PdfDocument();
            var page = document.AddPage();
            var graphics = PdfSharp.Drawing.XGraphics.FromPdfPage(page);
            var textFormatter = new PdfSharp.Drawing.Layout.XTextFormatter(graphics);
            var font = new PdfSharp.Drawing.XFont("Calibri", 12);
            var fontColuna = new PdfSharp.Drawing.XFont("Calibri", 14);



            // Textos.
            textFormatter.Alignment = PdfSharp.Drawing.Layout.XParagraphAlignment.Left;
            textFormatter.DrawString("Destino: " + ddlViagem.SelectedItem.ToString(), font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, 30, page.Width - 60, page.Height - 60));
            textFormatter.DrawString("Cliente: " + ddlNome.SelectedItem.ToString(), font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(200, 30, page.Width - 60, page.Height - 60));
            int colunas = 85;
            textFormatter.DrawString("Cliente", fontColuna, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, colunas, page.Width - 60, page.Height - 60));
            textFormatter.DrawString("Faixa Etaria", fontColuna, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(200, colunas, page.Width - 60, page.Height - 60));
            textFormatter.DrawString("Assento", fontColuna, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(300, colunas, page.Width - 60, page.Height - 60));
            textFormatter.DrawString("Valor Pago", fontColuna, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(370, colunas, page.Width - 60, page.Height - 60));
            int y = 90;
            decimal ValorTotal = 0;
            foreach (var item in vendaEncontrada)
            {
                ValorTotal += item.VendaValorPago;
                y = y + 30;
                textFormatter.DrawString(SvcCliente.BuscarCliente(item.VendaIdCliente).Nome, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(30, y, page.Width - 60, page.Height - 60));
                textFormatter.DrawString(item.FaixaEtaria, font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(200, y, page.Width - 60, page.Height - 60));
                textFormatter.DrawString(item.Assento.ToString(), font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(300, y, page.Width - 60, page.Height - 60));
                textFormatter.DrawString(item.VendaValorPago.ToString(), font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(370, y, page.Width - 60, page.Height - 60));
            }
            //textFormatter.DrawString(ValorTotal.ToString(), font, PdfSharp.Drawing.XBrushes.Black, new PdfSharp.Drawing.XRect(370, y, page.Width - 60, page.Height - 60));

            PdfSharp.Drawing.XRect layoutRectangle = new PdfSharp.Drawing.XRect(0/*X*/, page.Height - font.Height/*Y*/, page.Width/*Width*/, font.Height/*Height*/);
            PdfSharp.Drawing.XBrush brush = PdfSharp.Drawing.XBrushes.Black;
            string noPages = document.Pages.Count.ToString();
            for (int i = 0; i < document.Pages.Count; ++i)
            {
                graphics.DrawString(
               "Page " + (i + 1).ToString() + " of " + noPages,
            font,
            brush,
            layoutRectangle,
            PdfSharp.Drawing.XStringFormats.Center);

            //    graphics.DrawString(
            //   "Page " + ValorTotal.ToString(),
            //font,
            //brush,
            //layoutRectangle,
            //PdfSharp.Drawing.XStringFormats.);
            }

            document.Save("Vendas.pdf");
            System.Diagnostics.Process.Start("chrome.exe", "Vendas.pdf");
        }
    }
}