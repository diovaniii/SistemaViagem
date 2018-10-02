using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViagemSeg.Dto;
using ViagemSeg.Mapping;

namespace ViagemSeg.Svc
{
    public static class SvcServico
    {
        private static BancoViagemEntities db = new BancoViagemEntities();

        public static List<DtoServico> ListarServico()
        {
            using (var db = new BancoViagemEntities())
            {
                var result = Mapeador.ListaServico(db.Servico.ToList().FindAll(a => a.Status == 0));
                return result;
            }
        }

        public static Servico AlteraSalvaServico(Servico servico)
        {
            using (var ContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    var existeServico = db.Viagem.Find(servico.Id);

                    using (var db = new BancoViagemEntities())
                    {

                        if (existeServico == null)
                        {
                            db.Entry(servico).State = EntityState.Added;
                        }
                        else
                        {
                            db.Entry(servico).State = EntityState.Modified;
                        }
                        db.SaveChanges();
                    }

                    ContextTransaction.Commit();
                }
                catch (Exception ex)
                {

                    ContextTransaction.Rollback();
                    throw ex;
                }
            }
            return servico;
        }

        public static int Excluir(int id)
        {
            Servico servico = new Servico();
            using (var db = new BancoViagemEntities())
            {
                var y = db.Servico.Find(id);
                y.Status = 1;
                servico = y;
            }
            using (var db = new BancoViagemEntities())
            {
                db.Entry(servico).State = EntityState.Modified;
                db.SaveChanges();
            }
            return id;
        }

        public static Servico BuscarServico(int pIdServico)
        {
            BancoViagemEntities db = new BancoViagemEntities();
            var servico = db.Servico.ToList().Find(a => a.Id == pIdServico);
            return servico;
        }
    }
}
