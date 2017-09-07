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
    public class CidadeREPTests
    {
        CidadeREP _repositorio = new CidadeREP();

        [TestMethod()]
        public void SelecionarTest()
        {
            Assert.IsTrue(_repositorio.Selecionar().Any());
        }

        [TestMethod()]
        public void SelecionarComIDTest()
        {
            Assert.IsNotNull(_repositorio.SelecionarComID(2));
            Assert.IsNull(_repositorio.SelecionarComID(3546));
        }

        [TestMethod()]
        public void InserirTest()
        {
            var cidade = new Cidade()
            {
                UF = "AA",
                Nome = "Alemanha",
                Distancia = 1
            };
            _repositorio.Inserir(cidade);
            Assert.IsNotNull(_repositorio.SelecionarComID(28));
        }

        [TestMethod()]
        public void AtualizarTest()
        {
            var cidade = new Cidade()
            {
                IDCidade = 26,
                UF = "CC",
                Nome = "Croácia",
                Distancia = 3
            };
            _repositorio.Atualizar(cidade);
            Assert.AreEqual(_repositorio.SelecionarComID(26).Nome, cidade.Nome);
        }

        [TestMethod()]
        public void ExcluirTest()
        {
            _repositorio.Excluir(28);
            Assert.IsNull(_repositorio.SelecionarComID(28));
        }
    }
}