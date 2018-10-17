using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViagemSeg.Svc;

namespace ViagemWeb
{
    public partial class ListaContaPagarReceber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListaConta();
        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            Response.Redirect("ContaPagarReceber.aspx");
        }

        protected void grpListaContas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void Editar(object sender, CommandEventArgs e)
        {
            //var valor = Convert.ToInt32(e.CommandArgument);
            //var script = string.Format("window.open('CadastroCliente.aspx?clienteId={0}')", valor);
            //ScriptManager.RegisterStartupScript(this, GetType(), Guid.NewGuid().ToString(), script, true);
        }
        protected void Excluir(object sender, CommandEventArgs e)
        {
            //var valor = Convert.ToInt32(e.CommandArgument);
            //SvcCliente.Excluir(valor);
            //CarregaListaCliente();
        }

        protected void ListaConta()
        {
            grpListaContas.DataSource = SvcContaPagarReceber.ListarContas();
            grpListaContas.DataBind();
            uppGridView.Update();
        }
    }
}