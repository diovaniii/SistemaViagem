using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViagemSeg;
using ViagemSeg.Svc;

namespace ViagemWeb
{
    public partial class VendaFretamento : System.Web.UI.Page
    {
        private Fretamento _Fretamento
        {
            get { return (Fretamento)ViewState[typeof(Fretamento).FullName]; }
            set { ViewState[typeof(Fretamento).FullName] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //very first load//
            string id = Request.QueryString["FretamentoId"];
            if (!string.IsNullOrEmpty(id))
            {

                //MontarCadastroVeiculo(Convert.ToInt32(id));
            }
            else
            {

                _Fretamento = new Fretamento();
            }
        }

        protected void salvar_Click(object sender, EventArgs e)
        {
            if (_Fretamento.Id == 0)
            {
                _Fretamento.Nome = txtNome.Text;
                _Fretamento.Km = Convert.ToDecimal(txtKm.Text);
                _Fretamento.Valor = Convert.ToDecimal(txtValor.Text);
                _Fretamento.Descricao = txtDescricao.Text;
                _Fretamento.Cliente = txtCliente.Text;
                _Fretamento.Status = 0;


                SvcFretamento.AlteraSalvaFretamento(_Fretamento);
                Response.Redirect("ListaFretamento.aspx");
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "AlertBox", "alert('Cadastrado com sucesso');", true);
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "AlertBox", "alert('Cadastrado com sucesso');", false);
            }
            else
            {
                _Fretamento.Nome = txtNome.Text;
                _Fretamento.Km = Convert.ToDecimal(txtKm.Text);
                _Fretamento.Valor = Convert.ToInt32(txtValor.Text);
                _Fretamento.Descricao = txtDescricao.Text;
                _Fretamento.Cliente = txtCliente.Text;
                _Fretamento.Status = 0;


                SvcFretamento.AlteraSalvaFretamento(_Fretamento);
                Response.Redirect("ListaFretamento.aspx");
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "AlertBox", "alert('Cadastrado com sucesso');", true);
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "AlertBox", "alert('Cadastrado com sucesso');", false);
            }
        }

        protected void limpar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CadastroFretamento.aspx");
        }
    }
}