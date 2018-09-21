using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using ViagemSeg.Mapping;
using ViagemSeg.Dto;

namespace ViagemSeg.Svc
{
    public static class SvcCliente
    {
        private static BancoViagemEntities db = new BancoViagemEntities();

        public static List<DtoCliente> ListarTodosClientes()
        {
            using (var db = new BancoViagemEntities())
            {
                var result = Mapeador.ListaDeCliente(db.Cliente.ToList().FindAll(a => a.Status == 0));
                return result;
            }
        }
        
        public static Cliente BuscarCliente(int pIdCliente)
        {
            BancoViagemEntities db = new BancoViagemEntities();
            var cliente = db.Cliente.ToList().Find(a => a.Id == pIdCliente);
            return cliente;
        }

        public static List<DtoCliente> Pesquisa(Cliente cliente)
        {
            using (var db = new BancoViagemEntities())
            {
                var clientes = db.Cliente.Where(a => a.Status == 0)
                                         .Where(a => cliente.Nome.Equals(string.Empty) ? true : a.Nome.ToUpper().Contains(cliente.Nome.ToUpper()))
                                         .Where(a => cliente.Cpf.Equals(string.Empty) ? true : a.Cpf.Contains(cliente.Cpf))
                                         .Where(a => cliente.Telefone.Equals(string.Empty) ? true : a.Telefone.Contains(cliente.Telefone))
                                         .Where(c => cliente.DataNascimento.Equals(DateTime.MinValue) ? true : c.DataNascimento.Equals(cliente.DataNascimento));

                return Mapeador.ListaDeCliente(clientes.ToList());
            }
        }

        //EXCLUI O CLIENTE FAZENDO APENAS A ALTERAÇÃO DO STATUS
        public static int Excluir(int id)
        {
            Cliente cliente = new Cliente();
            using (var db = new BancoViagemEntities())
            {
                var y = db.Cliente.Find(id);
                y.Status = 1;
                cliente = y;
            }
            using (var db = new BancoViagemEntities())
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
            }
            return id;
        }

        public static Cliente AlteraSalva(Cliente cliente, Endereco enderecoPessoal, Endereco enderecoComercial)
        {
            using (var ContextTransaction = db.Database.BeginTransaction())
            {
                try
                {
                    var existeCliente = db.Cliente.Find(cliente.Id);

                    if (cliente.Endereco.Count > 0)
                    {
                        enderecoPessoal.Id = cliente.Endereco.Where(a => a.Origem == 0).FirstOrDefault().Id;
                    }
                    if (cliente.Endereco.Count > 1)
                    {
                        enderecoComercial.Id = cliente.Endereco.Where(a => a.Origem == 1).FirstOrDefault().Id;
                    }

                    using (var db = new BancoViagemEntities())
                    {

                        if (existeCliente == null)
                        {
                            db.Entry(cliente).State = EntityState.Added;
                        }
                        else
                        {
                            db.Entry(cliente).State = EntityState.Modified;
                        }
                        db.SaveChanges();
                    }

                    if (!enderecoPessoal.IsEmpty)
                    {
                        enderecoPessoal.ClienteIdEndereco = cliente.Id;
                        using (var db = new BancoViagemEntities())
                        {
                            if (enderecoPessoal.Id == 0)
                            {
                                db.Entry(enderecoPessoal).State = EntityState.Added;
                            }
                            else
                            {
                                db.Entry(enderecoPessoal).State = EntityState.Modified;
                            }
                            db.SaveChanges();
                        }
                    }

                    if (!enderecoComercial.IsEmpty)
                    {
                        enderecoComercial.ClienteIdEndereco = cliente.Id;
                        using (var db = new BancoViagemEntities())
                        {
                            if (enderecoComercial.Id == 0)
                            {
                                db.Entry(enderecoComercial).State = EntityState.Added;
                            }
                            else
                            {
                                db.Entry(enderecoComercial).State = EntityState.Modified;
                            }
                            db.SaveChanges();
                        }
                    }
                    ContextTransaction.Commit();
                }
                catch (Exception ex)
                {

                    ContextTransaction.Rollback();
                    throw ex;
                }
            }
            return cliente;
        }
    }
}
