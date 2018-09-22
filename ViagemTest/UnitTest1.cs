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
            
            var data = "06/03/1989 00:00:00";
            new SvcCliente().Salvar(new Cliente
            {
                ClienteCpf = "9999999999",
                ClienteDataNascimento = Convert.ToDateTime(data).Date,
                ClienteEndereco = "elesbao",
                ClienteNome = "dio",
                ClienteTelefone = "77777777",
                ClienteStatus = 0
            });
        }

        [TestMethod]
        public void TestMethod2()
        {
            var t = new SvcCliente().ListarTodosClientes();
        }
    }
}
