using CopaFilmes.Tests.Domain.Implementacoes.TestBuilders;
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
            var filmeA = new FilmeTestBuilder().ComNota(8.5m).Build();
            var filmeB = new FilmeTestBuilder().ComNota(6.7m).Build();

            Assert.IsTrue(filmeA.PossuiMaiorNota(filmeB));
        }

        [TestMethod]
        public void FilmeTests_Dado_Que_Filme_Possui_Nota_Menor_Em_Relacao_Ao_Comparado_Quando_Consultar_Retorna_Falso()
        {
            var filmeA = new FilmeTestBuilder().ComNota(8.5m).Build();
            var filmeB = new FilmeTestBuilder().ComNota(6.7m).Build();

            Assert.IsFalse(filmeB.PossuiMaiorNota(filmeA));
        }

        [TestMethod]
        public void FilmeTests_Dado_Que_Filme_Possui_Nota_Igual_Em_Relacao_Ao_Comparado_Quando_Consultar_Retorna_Falso()
        {
            var filmeA = new FilmeTestBuilder().ComNota(8.5m).Build();
            var filmeB = new FilmeTestBuilder().ComNota(8.5m).Build();

            Assert.IsFalse(filmeA.PossuiMaiorNota(filmeB));
        }

        [TestMethod]
        public void FilmeTests_Dado_Que_Filme_Possui_Mesmo_Titulo_Em_Relacao_Ao_Comparado_Quando_Compara_Retorna_Zero()
        {
            var filme = new FilmeTestBuilder().ComTitulo("Filme A").Build();
            var outroFilme = new FilmeTestBuilder().ComTitulo("Filme A").Build();

            var resultado = filme.CompareTo(outroFilme);

            Assert.AreEqual(expected: 0, actual: resultado);
        }

        [TestMethod]
        public void FilmeTests_Dado_Que_Filme_Possui_Titulo_Que_Precede_Na_Ordenacao_Em_Relacao_Ao_Comparado_Quando_Compara_Retorna_Menos_Um()
        {
            var filmeA = new FilmeTestBuilder().ComTitulo("Filme A").Build();
            var filmeB = new FilmeTestBuilder().ComTitulo("Filme B").Build();

            var resultado = filmeA.CompareTo(filmeB);

            Assert.AreEqual(expected: -1, resultado);
        }

        [TestMethod]
        public void FilmeTests_Dado_Que_Filme_Possui_Titulo_Que_Deve_Vir_Apos_Em_Relacao_Ao_Comparado_Para_Ordenacao_Quando_Compara_Retorna_Um()
        {
            var filmeA = new FilmeTestBuilder().ComTitulo("Filme A").Build();
            var filmeB = new FilmeTestBuilder().ComTitulo("Filme B").Build();

            var resultado = filmeB.CompareTo(filmeA);

            Assert.AreEqual(expected: 1, resultado);
        }
    }
}
