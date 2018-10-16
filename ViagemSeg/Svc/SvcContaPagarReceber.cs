using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViagemSeg.Svc
{
    public static class SvcContaPagarReceber
    {
        private static bancoviagemEntities db = new bancoviagemEntities();

        public static contas AlteraSalva(contas conta)
        {
            using (var ContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    var existeContaPagarReceber = db.contas.Find(conta.Id);

                    using (var db = new bancoviagemEntities())
                    {

                        if (existeContaPagarReceber == null)
                        {
                            db.Entry(conta).State = EntityState.Added;
                        }
                        else
                        {
                            db.Entry(conta).State = EntityState.Modified;
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
            return conta;
        }
    }
}
