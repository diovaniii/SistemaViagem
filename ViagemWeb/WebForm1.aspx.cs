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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnSalvar_OnClick(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.ClienteNome = txbNome.Text;
            cliente.ClienteCpf = txbCpf.Text;
            cliente.ClienteEndereco = txbEndereco.Text;
            cliente.ClienteTelefone = txbTelefone.Text;
            cliente.ClienteDataNascimento = Convert.ToDateTime(Calendar1.SelectedDate).Date;
            cliente.ClienteStatus = 0;
            new SvcCliente().Salvar(cliente);



        }
    }
}