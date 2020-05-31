using CopaFilmes.Tests.Domain.Implementacoes.TestBuilders;
using CopaFilmes.WebAPI.Domain.Implementacoes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CopaFilmes.Tests.Domain.Implementacoes
{
    [TestClass]
    public class PartidaTests
    {
        [TestMethod]
        [DynamicData(nameof(FilmesComNotasDiferentes), DynamicDataSourceType.Property)]
        public void PartidaTests_Dado_Dois_Filmes_Com_Notas_Diferentes_Quando_Disputarem_Uma_Partida_Retorna_Como_Vencedor_O_Filme_Com_Nota_Maior(decimal notaFilmeA, decimal notaFilmeB, int posicaoVencedor)
        {
            var filmeA = new FilmeTestBuilder().ComNota(notaFilmeA).Build();
            var filmeB = new FilmeTestBuilder().ComNota(notaFilmeB).Build();
            var partida = new Partida(filmeA, filmeB);
            var vencedorEsperado = posicaoVencedor == 1 ? filmeA : filmeB;
            var nomeVariavelVencedorEsperado = posicaoVencedor == 1 ? nameof(filmeA) : nameof(filmeB);

            partida.Disputar();

            Assert.AreEqual(expected: vencedorEsperado, actual: partida.Vencedor, 
                $"O vencedor esperado é a instância de Filme da variável {nomeVariavelVencedorEsperado} porque a nota do Filme A é {notaFilmeA} e a nota do Filme B é {notaFilmeB}.");
        }

        /// <summary>
        /// Propriedade utilizada de entrada para cenários de testes.
        /// </summary>
        public static IEnumerable<object[]> FilmesComNotasDiferentes
        {
            get
            {
                yield return new object[] { 6.7m, 8.5m, 2 };
                yield return new object[] { 8.1m, 8.8m, 2 };
                yield return new object[] { 7.2m, 7.9m, 2 };
                yield return new object[] { 7.8m, 8.5m, 2 };
                yield return new object[] { 6.7m, 6.3m, 1 };
                yield return new object[] { 8.8m, 7.9m, 1 };
                yield return new object[] { 8.5m, 6.7m, 1 };
                yield return new object[] { 8.8m, 8.5m, 1 };
            }
        }

        [TestMethod]
        [DynamicData(nameof(FilmesComNotasIguais), DynamicDataSourceType.Property)]
        public void PartidaTests_Dado_Dois_Filmes_Com_Notas_Iguais_Quando_Disputarem_Uma_Partida_Retorna_Como_Vencedor_O_Filme_Em_Primeiro_Na_Ordem_Alfabetica_De_Titulo(string tituloFilmeA, decimal notaFilmeA, string tituloFilmeB, decimal notaFilmeB, int posicaoVencedor)
        {
            var filmeA = new FilmeTestBuilder().ComTitulo(tituloFilmeA).ComNota(notaFilmeA).Build();
            var filmeB = new FilmeTestBuilder().ComTitulo(tituloFilmeB).ComNota(notaFilmeB).Build();
            var partida = new Partida(filmeA, filmeB);
            var vencedorEsperado = posicaoVencedor == 1 ? filmeA : filmeB;
            var nomeVariavelVencedorEsperado = posicaoVencedor == 1 ? nameof(filmeA) : nameof(filmeB);

            partida.Disputar();

            Assert.AreEqual(expected: vencedorEsperado, actual: partida.Vencedor,
                $"O vencedor esperado é a instância de Filme da variável {nomeVariavelVencedorEsperado} porque o titulo do Filme A é {tituloFilmeA} e o titulo do Filme B é {tituloFilmeB}.");
        }

        /// <summary>
        /// Propriedade utilizada de entrada para cenários de testes.
        /// </summary>
        public static IEnumerable<object[]> FilmesComNotasIguais
        {
            get
            {
                yield return new object[] { "Filme A", 8.5m, "Filme B", 8.5m, 1 };
                yield return new object[] { "Deadpool 2", 8.5m, "Vingadores: Guerra Finita", 8.5m, 1 };
                yield return new object[] { "Han Solo: Uma História Star Wars", 8.5m, "Thor: Ragnarok", 8.5m, 1 };
                yield return new object[] { "Hereditário", 8.5m, "Os Incríveis 2", 8.5m, 1 };
                yield return new object[] { "Jurassic World: Reino Ameaçado", 8.5m, "Oito Mulheres e um Segredo", 8.5m, 1 };
            }
        }
    }
}
