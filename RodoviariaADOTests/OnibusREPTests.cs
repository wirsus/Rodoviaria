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
    public class OnibusREPTests

    {
        OnibusREP _repositorio = new OnibusREP();

        [TestMethod()]
        public void SelecionarTest()
        {
            Assert.IsTrue(_repositorio.Selecionar().Any());
        }

        [TestMethod()]
        public void SelecionarComIDTest()
        {
            Assert.IsNotNull(_repositorio.SelecionarComID(1));
            Assert.IsNull(_repositorio.SelecionarComID(4561));
        }

        [TestMethod()]
        public void InserirTest()
        {
            var onibus = new Onibus()
            {
                Cor = "ROXO",
                CustoPorKm = 2.46M
            };

            _repositorio.Inserir(onibus);

            Assert.AreNotEqual(0, onibus.IDOnibus);
        }

        [TestMethod()]
        public void AtualizarTest()
        {
            var onibus = new Onibus()
            {
                IDOnibus = 5,
                Cor = "PRETO",
                CustoPorKm = 3.91M
            };

            _repositorio.Atualizar(onibus);
            Assert.AreEqual(_repositorio.SelecionarComID(onibus.IDOnibus).Cor, onibus.Cor);
        }

        [TestMethod()]
        public void ExcluirTest()
        {
            _repositorio.Excluir(5);
            Assert.IsNull(_repositorio.SelecionarComID(5));
        }
    }
}