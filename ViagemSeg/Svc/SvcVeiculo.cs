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
    public static class SvcVeiculo
    {
        private static BancoViagemEntities db = new BancoViagemEntities();

        public static List<DtoVeiculo> ListarTodosVeiculos()
        {
            using (var db = new BancoViagemEntities())
            {
                var result = Mapeador.ListaVeiculos(db.Veiculo.ToList().FindAll(a => a.Status == 0));
                return result;
            }
        }

        public static Veiculo AlteraSalvaVeiculo(Veiculo veiculo)
        {
            using (var ContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    var existeVeiculo = db.Viagem.Find(veiculo.Id);

                    using (var db = new BancoViagemEntities())
                    {

                        if (existeVeiculo == null)
                        {
                            db.Entry(veiculo).State = EntityState.Added;
                        }
                        else
                        {
                            db.Entry(veiculo).State = EntityState.Modified;
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
            return veiculo;
        }

        public static int Excluir(int id)
        {
            Veiculo veiculo = new Veiculo();
            using (var db = new BancoViagemEntities())
            {
                var y = db.Veiculo.Find(id);
                y.Status = 1;
                veiculo = y;
            }
            using (var db = new BancoViagemEntities())
            {
                db.Entry(veiculo).State = EntityState.Modified;
                db.SaveChanges();
            }
            return id;
        }

        public static Veiculo BuscarVeiculo(int pIdVeiculo)
        {
            BancoViagemEntities db = new BancoViagemEntities();
            var veiculo = db.Veiculo.ToList().Find(a => a.Id == pIdVeiculo);
            return veiculo;
        }

    }
}
