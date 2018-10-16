using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViagemSeg;
using ViagemSeg.Svc;

namespace ViagemWeb
{
    public partial class ContaPagarReceber : System.Web.UI.Page
    {
        public List<contas> contaList
        {
            get { return (List<contas>)ViewState[typeof(contas).FullName]; }
            set { ViewState[typeof(contas).FullName] = value; }
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {

                CarregarTipo();
                HabilitarTipo();
                carregaNome();
                CarregaFornecedor();
                CarregarViagem();
                
                    contaList = new List<contas>();
                
            }
            HabilitarTipo();
        }

        protected void ddlViagem_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void Ok_Click(object sender, EventArgs e)
        {
            
            var parcelar = Convert.ToInt32(txtParcelar.Text);
            for (int i = 0; i < parcelar; i++)
            {
                contas conta = new contas();
                if (txtValorTotal.Text != "")
                    conta.Valor = Convert.ToInt32(txtValorTotal.Text) / parcelar;

                if (ddlTípo.SelectedValue == "1")
                {
                    conta.Cliente = Convert.ToInt32(ddlCliente.SelectedValue);
                }
                else
                {
                    conta.Cliente = Convert.ToInt32(ddlFornecedor.SelectedValue);
                }
                conta.Viagem = Convert.ToInt32(ddlViagem.SelectedValue);
                conta.Indentificador = Convert.ToInt32(ddlTípo.SelectedValue);
                conta.DataRecebimento = Convert.ToDateTime(txtDataRecebido.Text);
                conta.Parcelas = i + 1;
                conta.Status = 0;
                contaList.Add(conta);
            }
            grpConta.DataSource = contaList;
            grpConta.DataBind();
            uppGridView.Update();
        }
        //protected void Editar(object sender, CommandEventArgs e)
        //{
        //    int index = Convert.ToInt32(e.CommandArgument);
        //    GridViewRow row = grpConta.Rows[index];


        //    if (e.CommandName.Equals("Editar"))
        //    {
        //        txtCodParcela.Text = row.Cells[1].Text;
        //        txtDataParcela.Text = row.Cells[2].Text;

        //    }
        //}



        protected void limpar_Click(object sender, EventArgs e)
        {

        }

        protected void ddlTípo_SelectedIndexChanged(object sender, EventArgs e)
        {
            HabilitarTipo();
            UpdatePanel.Update();
        }

        protected void CarregarTipo()
        {
            ddlTípo.Items.Add(new ListItem("Pagar", "0"));
            ddlTípo.Items.Add(new ListItem("Receber", "1"));
        }

        protected void HabilitarTipo()
        {
            if (ddlTípo.SelectedValue == "0")
            {
                ddlCliente.Visible = false;
                ddlFornecedor.Visible = true;
            }
            else
            {
                ddlFornecedor.Visible = false;
                ddlCliente.Visible = true;
            }
            
        }
        protected void carregaNome()
        {
            ddlCliente.DataSource = SvcCliente.ListarTodosClientes();
            ddlCliente.DataBind();
            UpdatePanel.Update();
        }
        protected void CarregaFornecedor()
        {
            ddlFornecedor.DataSource = SvcFornecedor.ListarFornecedor();
            ddlFornecedor.DataBind();
            UpdatePanel.Update();
        }
        protected void CarregarViagem()
        {
            ddlViagem.DataSource = SvcViagem.ListarTodasViagens();
            ddlViagem.DataBind();
            UpdatePanel.Update();
        }

        protected void Salvar_Click(object sender, EventArgs e)
        {
            //grpConta.DataBind();
            //uppGridView.Update();
            foreach (var item in contaList)
            {
                foreach (GridViewRow item1 in grpConta.Rows)
                {
                    var numero = item1.Cells[1];

                    if (item.Parcelas == Convert.ToInt32(numero.Text))
                    {
                        TextBox vencimento = (TextBox)item1.FindControl("txtDataVencimento");
                        item.DataVencimento = Convert.ToDateTime( vencimento.Text);
                        TextBox valor = (TextBox)item1.FindControl("txtValor");
                        item.Valor = Convert.ToDecimal(valor.Text);
                    }
                }
                SvcContaPagarReceber.AlteraSalva(item);
            }

            
        }
    }
}