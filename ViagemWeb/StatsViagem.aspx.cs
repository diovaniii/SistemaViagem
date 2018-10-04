using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViagemSeg.Svc;

namespace ViagemWeb
{
    public partial class StatsViagem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //very first load//
                string id = Request.QueryString["ViagemId"];
                if (!string.IsNullOrEmpty(id))
                {

                    PorcentagemVenda(Convert.ToInt32(id));
                }
                else
                {
                    //_viagem = new Viagem();
                }
            }
            else
            {
                //not first load//
            }
        }

        protected void PorcentagemVenda(int id)
        {
            var passagemVendida = SvcVendaCliente.PesquisaViagem(id);
            var quantidadePassagem = SvcViagem.BuscarViagem(id);
            //if (passagemVendida == null)
            //    return;
            var t = quantidadePassagem.Veiculo;
            var assento = SvcVeiculo.BuscarVeiculo(t.Value);
            var r = assento.Lugares.Value;
            var y = passagemVendida.Count();
            var total = (100 / r) * y;
            //Porcentagem.ParseControl(total.ToString());

            Porcentagem.CalculateActiveUsersAngle(total);

            //int quantidadePassagem;


            //foreach (var item in passagemVendida)
            //{
            //    quantidadePassagem += item.Assento.
            //}

        }

        
    }
}