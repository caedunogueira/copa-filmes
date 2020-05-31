using CopaFilmes.Tests.Domain.Implementacoes.TestBuilders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CopaFilmes.Tests.Domain.Implementacoes
{
    [TestClass]
    public class FilmeTests
    {
        [TestMethod]
        [DynamicData(nameof(NotasEntreDoisFilmes), DynamicDataSourceType.Property)]
        public void FilmeTests_Dado_Que_Filme_Possui_Nota_Maior_Em_Relacao_Ao_Filme_Comparado_Quando_Consultar_Se_Possui_Nota_Maior_Retorna_Verdadeiro(decimal notaFilmeA, decimal notaFilmeB)
        {
            var filmeA = new FilmeTestBuilder().ComNota(notaFilmeA).Build();
            var filmeB = new FilmeTestBuilder().ComNota(notaFilmeB).Build();

            Assert.IsTrue(filmeA.PossuiNotaMaior(filmeB));
        }

        [TestMethod]
        [DynamicData(nameof(NotasEntreDoisFilmes), DynamicDataSourceType.Property)]
        public void FilmeTests_Dado_Que_Filme_Possui_Nota_Menor_Em_Relacao_Ao_Filme_Comparado_Quando_Consultar_Se_Possui_Nota_Maior_Retorna_Falso(decimal notaFilmeA, decimal notaFilmeB)
        {
            var filmeA = new FilmeTestBuilder().ComNota(notaFilmeA).Build();
            var filmeB = new FilmeTestBuilder().ComNota(notaFilmeB).Build();

            Assert.IsFalse(filmeB.PossuiNotaMaior(filmeA));
        }

        [TestMethod]
        public void FilmeTests_Dado_Que_Filme_Possui_Nota_Igual_Em_Relacao_Ao_Filme_Comparado_Quando_Consultar_Se_Possui_Nota_Maior_Retorna_Falso()
        {
            var filmeA = new FilmeTestBuilder().ComNota(8.5m).Build();
            var filmeB = new FilmeTestBuilder().ComNota(8.5m).Build();

            Assert.IsFalse(filmeA.PossuiNotaMaior(filmeB));
        }


        [TestMethod]
        public void FilmeTests_Dado_Que_Filme_Possui_Nota_Igual_Em_Relacao_Ao_Filme_Comparado_Quando_Consultar_Se_Possui_Nota_Igual_Retorna_True()
        {
            var filmeA = new FilmeTestBuilder().ComNota(8.5m).Build();
            var filmeB = new FilmeTestBuilder().ComNota(8.5m).Build();

            Assert.IsTrue(filmeA.PossuiNotaIgual(filmeB));
        }

        [TestMethod]
        public void FilmeTests_Dado_Que_Filme_Possui_Nota_Diferente_Em_Relacao_Ao_Filme_Comparado_Quando_Consultar_Se_Possui_Nota_Igual_Retorna_Falso()
        {
            var filmeA = new FilmeTestBuilder().ComNota(8.4m).Build();
            var filmeB = new FilmeTestBuilder().ComNota(8.5m).Build();

            Assert.IsFalse(filmeA.PossuiNotaIgual(filmeB));
        }

        public static IEnumerable<object[]> NotasEntreDoisFilmes
        {
            get
            {
                yield return new object[] { 8.8m, 8.1m };
                yield return new object[] { 7.9m, 7.2m };
                yield return new object[] { 8.5m, 7.8m };
                yield return new object[] { 6.7m, 6.3m };
                yield return new object[] { 8.8m, 7.9m };
                yield return new object[] { 8.5m, 6.7m };
                yield return new object[] { 8.8m, 8.5m };
            }
        }

        [TestMethod]
        public void FilmeTests_Dado_Ordenacao_Ascendente_Que_Filme_Possui_Titulo_Igual_Em_Relacao_Ao_Filme_Comparado_Quando_Sao_Comparados_Retorna_Zero()
        {
            var filme = new FilmeTestBuilder().ComTitulo("Filme A").Build();
            var outroFilme = new FilmeTestBuilder().ComTitulo("Filme A").Build();

            var resultado = filme.CompareTo(outroFilme);

            Assert.AreEqual(expected: 0, actual: resultado);
        }

        [TestMethod]
        [DataRow("Filme A", "Filme B")]
        [DataRow("Jurassic World: Reino Ameaçado", "Os Incríveis 2")]
        [DataRow("Hereditário", "Oito Mulheres e um Segredo")]
        [DataRow("Deadpool 2", "Vingadores: Guerra Infinita")]
        [DataRow("Han Solo: Uma História Star Wars", "Thor: Ragnarok")]
        public void FilmeTests_Dado_Ordenacao_Ascendente_Que_Filme_Possui_Titulo_Que_Precede_Em_Relacao_Ao_Filme_Comparado_Quando_Sao_Comparados_Retorna_Menos_Um(string tituloFilmeA, string tituloFilmeB)
        {
            var filmeA = new FilmeTestBuilder().ComTitulo(tituloFilmeA).Build();
            var filmeB = new FilmeTestBuilder().ComTitulo(tituloFilmeB).Build();

            var resultado = filmeA.CompareTo(filmeB);

            Assert.AreEqual(expected: -1, resultado);
        }

        [TestMethod]
        [DataRow("Filme A", "Filme B")]
        [DataRow("Jurassic World: Reino Ameaçado", "Os Incríveis 2")]
        [DataRow("Hereditário", "Oito Mulheres e um Segredo")]
        [DataRow("Deadpool 2", "Vingadores: Guerra Infinita")]
        [DataRow("Han Solo: Uma História Star Wars", "Thor: Ragnarok")]
        public void FilmeTests_Dado_Ordenacao_Ascendente_Que_Filme_Possui_Titulo_Que_Sucede_Em_Relacao_Ao_Filme_Comparado_Quando_Sao_Comparados_Retorna_Um(string tituloFilmeA, string tituloFilmeB)
        {
            var filmeA = new FilmeTestBuilder().ComTitulo("Filme A").Build();
            var filmeB = new FilmeTestBuilder().ComTitulo("Filme B").Build();

            var resultado = filmeB.CompareTo(filmeA);

            Assert.AreEqual(expected: 1, resultado);
        }
    }
}
