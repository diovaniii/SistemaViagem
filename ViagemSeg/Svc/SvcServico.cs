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
                var result = Mapeador.ListaServico(db.PestacaoServico.ToList().FindAll(a => a.Status == 0));
                return result;
            }
        }

        public static PestacaoServico AlteraSalvaServico(PestacaoServico servico)
        {
            using (var ContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    var existeServico = db.servico.Find(servico.Id);

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
            PestacaoServico servico = new PestacaoServico();
            using (var db = new BancoViagemEntities())
            {
                var y = db.PestacaoServico.Find(id);
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

        public static PestacaoServico BuscarServico(int pIdServico)
        {
            BancoViagemEntities db = new BancoViagemEntities();
            var servico = db.PestacaoServico.ToList().Find(a => a.Id == pIdServico);
            return servico;
        }
    }
}
