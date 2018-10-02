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
    public static class SvcFretamento
    {
        private static BancoViagemEntities db = new BancoViagemEntities();

        public static List<DtoFretamento> ListarFretamento()
        {
            using (var db = new BancoViagemEntities())
            {
                var result = Mapeador.ListaFretamento(db.Fretamento.ToList().FindAll(a => a.Status == 0));
                return result;
            }
        }

        public static Fretamento AlteraSalvaFretamento(Fretamento fretamento)
        {
            using (var ContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    var existeFretamento = db.fretamento.Find(fretamento.Id);

                    using (var db = new BancoViagemEntities())
                    {

                        if (existeFretamento == null)
                        {
                            db.Entry(fretamento).State = EntityState.Added;
                        }
                        else
                        {
                            db.Entry(fretamento).State = EntityState.Modified;
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
            return fretamento;
        }

        public static int Excluir(int id)
        {
            Fretamento fretamento = new Fretamento();
            using (var db = new BancoViagemEntities())
            {
                var y = db.Fretamento.Find(id);
                y.Status = 1;
                fretamento = y;
            }
            using (var db = new BancoViagemEntities())
            {
                db.Entry(fretamento).State = EntityState.Modified;
                db.SaveChanges();
            }
            return id;
        }

        public static Fretamento BuscarFretamento(int pIdFretamento)
        {
            BancoViagemEntities db = new BancoViagemEntities();
            var fretamento = db.Fretamento.ToList().Find(a => a.Id == pIdFretamento);
            return fretamento;
        }
    }
}
