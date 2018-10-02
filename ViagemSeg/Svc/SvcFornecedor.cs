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
    public static class SvcFornecedor
    {
        private static BancoViagemEntities db = new BancoViagemEntities();

        public static List<DtoFornecedor> ListarFornecedor()
        {
            using (var db = new BancoViagemEntities())
            {
                var result = Mapeador.ListaFornecedor(db.Fornecedores.ToList().FindAll(a => a.Status == 0));
                return result;
            }
        }

        public static Fornecedores AlteraSalvaFornecedor(Fornecedores fornecedor)
        {
            using (var ContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    var existeFornecedor = db.Viagem.Find(fornecedor.Id);

                    using (var db = new BancoViagemEntities())
                    {

                        if (existeFornecedor == null)
                        {
                            db.Entry(fornecedor).State = EntityState.Added;
                        }
                        else
                        {
                            db.Entry(fornecedor).State = EntityState.Modified;
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
            return fornecedor;
        }

        public static int Excluir(int id)
        {
            Fornecedores fornecedor = new Fornecedores();
            using (var db = new BancoViagemEntities())
            {
                var y = db.Fornecedores.Find(id);
                y.Status = 1;
                fornecedor = y;
            }
            using (var db = new BancoViagemEntities())
            {
                db.Entry(fornecedor).State = EntityState.Modified;
                db.SaveChanges();
            }
            return id;
        }

        public static Fornecedores BuscarFornecedores(int pIdFornecedores)
        {
            BancoViagemEntities db = new BancoViagemEntities();
            var fornecedor = db.Fornecedores.ToList().Find(a => a.Id == pIdFornecedores);
            return fornecedor;
        }
    }
}
