using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagemSeg.Dto;
using ViagemSeg.Mapping;

namespace ViagemSeg.Svc
{
    public static class SvcVendaCliente
    {
        private static BancoViagemEntities db = new BancoViagemEntities();

        public static List<DtoVendaCliente> ListarVendaCliente()
        {
            using (var db = new BancoViagemEntities())
            {
                var result = Mapeador.ListaVenda(db.VendaCliente.ToList().FindAll(a => a.Status == 0));
                return result;
            }
        }

        public static List<Viagem> ListarViagem()
        {
            using (var db = new BancoViagemEntities())
            {
                var result = db.Viagem.ToList().FindAll(a => a.Status == 0);
                return result;
            }
        }
    }
}
