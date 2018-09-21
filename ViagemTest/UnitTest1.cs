using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ViagemSeg;
using ViagemSeg.Svc;

namespace ViagemTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var data = "06/03/1989";
            Cliente cliente = new Cliente();
            cliente.Cpf = "9999999999";
            cliente.DataNascimento = Convert.ToDateTime(data).Date;
            cliente.Email = "elesbao";
            cliente.Nome = "dio";
            cliente.Telefone = "77777777";
            cliente.Status = 0;

            SvcCliente.AlteraSalva(cliente, null, null);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var t = SvcCliente.ListarTodosClientes();
        }
    }
}
