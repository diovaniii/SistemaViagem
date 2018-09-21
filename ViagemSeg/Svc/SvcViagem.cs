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
    public static class SvcViagem
    {
        private static BancoViagemEntities db = new BancoViagemEntities();

        public static List<DtoViagem> ListarTodasViagens()
        {
            using (var db = new BancoViagemEntities())
            {
                var result = Mapeador.ListaViagens(db.Viagem.ToList().FindAll(a => a.Status == 0));
                return result;
            }
        }


        public static Viagem AlteraSalva(Viagem viagem)
        {
            using (var ContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    var existeViagem = db.Viagem.Find(viagem.Id);

                    using (var db = new BancoViagemEntities())
                    {

                        if (existeViagem == null)
                        {
                            db.Entry(viagem).State = EntityState.Added;
                        }
                        else
                        {
                            db.Entry(viagem).State = EntityState.Modified;
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
            return viagem;
        }

        //EXCLUI O CLIENTE FAZENDO APENAS A ALTERAÇÃO DO STATUS
        public static int Excluir(int id)
        {
            Viagem viagem = new Viagem();
            using (var db = new BancoViagemEntities())
            {
                var y = db.Viagem.Find(id);
                y.Status = 1;
                viagem = y;
            }
            using (var db = new BancoViagemEntities())
            {
                db.Entry(viagem).State = EntityState.Modified;
                db.SaveChanges();
            }
            return id;
        }

        public static Viagem BuscarViagem(int pIdViagem)
        {
            BancoViagemEntities db = new BancoViagemEntities();
            var viagem = db.Viagem.ToList().Find(a => a.Id == pIdViagem);
            return viagem;
        }
    }
}
