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
    public static class SvcContaPagarReceber
    {
        private static bancoviagemEntities db = new bancoviagemEntities();

        public static List<DtoConta> ListarContas()
        {
            using (var db = new bancoviagemEntities())
            {
                var result = Mapeador.ListaConta(db.contas.ToList().FindAll(a => a.Status == 0));
                return result;
            }
        }
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

        public static List<contas> PesquisaDespesaViagem(int pId)
        {
            using (var db = new bancoviagemEntities())
            {
                var contas = db.contas.Where(a => a.Status == 0)
                                         .Where(a => a.Indentificador == 0)
                                         .Where(a => a.Viagem == pId);

                return contas.ToList();
            }
        }

        public static List<DtoConta> Pesquisa(contas conta)
        {
            using (var db = new bancoviagemEntities())
            {
                var contas1 = db.contas.Where(a => a.Status == 0)
                                         .Where(a => conta.Indentificador.Equals(a.Indentificador))
                                         .Where(a => conta.Cliente.Value.Equals(0) ? true : a.Cliente.Value.Equals(conta.Cliente.Value));
                                         

                return Mapeador.ListaConta(contas1.ToList());
            }
        }
    }
}
