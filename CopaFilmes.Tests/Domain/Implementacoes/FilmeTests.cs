using CopaFilmes.WebAPI.Domain.Implementacoes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CopaFilmes.Tests.Domain.Implementacoes
{
    [TestClass]
    public class FilmeTests
    {
        [TestMethod]
        public void FilmeTests_Dado_Que_Filme_Possui_Maior_Nota_Em_Relacao_Ao_Comparado_Quando_Consultar_Retorna_Verdadeiro()
        {
            var filmeA = new Filme(id: "tt1245748", titulo: "Filme A", ano: 2018, nota: 8.5m);
            var filmeB = new Filme(id: "tt2532658", titulo: "Filme B", ano: 2019, nota: 6.7m);

            Assert.IsTrue(filmeA.PossuiMaiorNota(filmeB));
        }

        [TestMethod]
        public void FilmeTests_Dado_Que_Filme_Possui_Nota_Menor_Em_Relacao_Ao_Comparado_Quando_Consultar_Retorna_Falso()
        {
            var filmeA = new Filme(id: "tt1245748", titulo: "Filme A", ano: 2018, nota: 8.5m);
            var filmeB = new Filme(id: "tt2532658", titulo: "Filme B", ano: 2019, nota: 6.7m);

            Assert.IsFalse(filmeB.PossuiMaiorNota(filmeA));
        }

        [TestMethod]
        public void FilmeTests_Dado_Que_Filme_Possui_Nota_Igual_Em_Relacao_Ao_Comparado_Quando_Consultar_Retorna_Falso()
        {
            var filmeA = new Filme(id: "tt1245748", titulo: "Filme A", ano: 2018, nota: 8.5m);
            var filmeB = new Filme(id: "tt2532658", titulo: "Filme B", ano: 2019, nota: 8.5m);

            Assert.IsFalse(filmeA.PossuiMaiorNota(filmeB));
        }

        [TestMethod]
        public void FilmeTests_Dado_Que_Filme_Possui_Mesmo_Titulo_Em_Relacao_Ao_Comparado_Quando_Compara_Retorna_Zero()
        {
            var filme = new Filme(id: "tt1245748", titulo: "Filme A", ano: 2018, nota: 8.5m);
            var outroFilme = new Filme(id: "tt2532658", titulo: "Filme A", ano: 2019, nota: 6.7m);

            var resultado = filme.CompareTo(outroFilme);

            Assert.AreEqual(expected: 0, actual: resultado);
        }

        [TestMethod]
        public void FilmeTests_Dado_Que_Filme_Possui_Titulo_Que_Precede_Na_Ordenacao_Em_Relacao_Ao_Comparado_Quando_Compara_Retorna_Menos_Um()
        {
            var filmeA = new Filme(id: "tt1245748", titulo: "Filme A", ano: 2018, nota: 8.5m);
            var filmeB = new Filme(id: "tt2532658", titulo: "Filme B", ano: 2019, nota: 6.7m);

            var resultado = filmeA.CompareTo(filmeB);

            Assert.AreEqual(expected: -1, resultado);
        }

        [TestMethod]
        public void FilmeTests_Dado_Que_Filme_Possui_Titulo_Que_Deve_Vir_Apos_Em_Relacao_Ao_Comparado_Para_Ordenacao_Quando_Compara_Retorna_Um()
        {
            var filmeA = new Filme(id: "tt1245748", titulo: "Filme A", ano: 2018, nota: 8.5m);
            var filmeB = new Filme(id: "tt2532658", titulo: "Filme B", ano: 2019, nota: 6.7m);

            var resultado = filmeB.CompareTo(filmeA);

            Assert.AreEqual(expected: 1, resultado);
        }
    }
}
