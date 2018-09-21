using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViagemSeg.Svc;

namespace ViagemWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            grpListaDeClientes.DataSource = SvcCliente.ListarTodosClientes();
            grpListaDeClientes.DataBind();
        }
    }
}