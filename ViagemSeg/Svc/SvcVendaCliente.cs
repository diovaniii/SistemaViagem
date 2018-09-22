﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public static VendaCliente AlteraSalva(VendaCliente vendaCliente)
        {
            using (var ContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    var existeVendaCliente = db.VendaCliente.Find(vendaCliente.VendaId);


                    using (var db = new BancoViagemEntities())
                    {

                        if (existeVendaCliente == null)
                        {
                            db.Entry(vendaCliente).State = EntityState.Added;
                        }
                        else
                        {
                            db.Entry(vendaCliente).State = EntityState.Modified;
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
            return vendaCliente;
        }

        public static List<VendaCliente> PesquisaViagem(int idViagem)
        {
            using (var db = new BancoViagemEntities())
            {
                var viagens = db.VendaCliente.Where(a => a.Status == 0)
                                         .Where(a => a.VendaIdViagem == idViagem);

                return viagens.ToList();
            }
        }
    }
}
