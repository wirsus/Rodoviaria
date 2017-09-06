using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rodoviaria.Models;
using RodoviariaADO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RodoviariaADO.Tests
{
    [TestClass()]
    public class PassageiroREPTests
    {
        PassageiroREP _repositorio = new PassageiroREP();

        [TestMethod()]
        public void SelecionarTest()
        {
            Assert.IsTrue(_repositorio.Selecionar().Any());
        }

        [TestMethod()]
        public void SelecionarComIDTest()
        {
            Assert.IsNotNull(_repositorio.SelecionarComID(1));
            Assert.IsNull(_repositorio.SelecionarComID(4371));
        }

        [TestMethod()]
        public void InserirTest()
        {
            var passageiro = new Passageiro()
            {
                Nome = "Carlos Drummond",
                Nascimento = DateTime.Now,
                Dinheiro = 327.55M
            };

            _repositorio.Inserir(passageiro);
            Assert.AreNotEqual(0, passageiro.IDPassageiro);
        }

        [TestMethod()]
        public void AtualizarTest()
        {
            var passageiro = new Passageiro()
            {
                IDPassageiro = 4,
                Nome = "Drummond Carlos",
                Nascimento = DateTime.Now.AddMonths(-3),
                Dinheiro = 327.55M
            };

            _repositorio.Atualizar(passageiro);
            Assert.AreEqual(_repositorio.SelecionarComID(passageiro.IDPassageiro).Nome, passageiro.Nome);
        }

        [TestMethod()]
        public void ExcluirTest()
        {
            _repositorio.Excluir(5);
            Assert.IsNull(_repositorio.SelecionarComID(5));
        }
    }
}