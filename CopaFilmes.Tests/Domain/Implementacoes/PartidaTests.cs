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
        public void PartidaTests_Dado_Dois_Filmes_Com_Notas_Diferentes_Quando_Disputarem_Uma_Partida_Retorna_Como_Vencedor_O_Filme_Com_Nota_Maior(Filme filmeA, Filme filmeB, int posicaoVencedor)
        {
            var partida = new Partida(filmeA, filmeB);
            var vencedorEsperado = posicaoVencedor == 1 ? filmeA : filmeB;

            partida.Disputar();

            Assert.AreEqual(expected: vencedorEsperado, actual: partida.Vencedor);
        }

        public static IEnumerable<object[]> FilmesComNotasDiferentes
        {
            get
            {
                yield return new object[] { new FilmeTestBuilder().ComNota(6.7m).Build(), new FilmeTestBuilder().ComNota(8.5m).Build(), 2 };
                yield return new object[] { new FilmeTestBuilder().ComNota(8.1m).Build(), new FilmeTestBuilder().ComNota(8.8m).Build(), 2 };
                yield return new object[] { new FilmeTestBuilder().ComNota(7.2m).Build(), new FilmeTestBuilder().ComNota(7.9m).Build(), 2 };
                yield return new object[] { new FilmeTestBuilder().ComNota(7.8m).Build(), new FilmeTestBuilder().ComNota(8.5m).Build(), 2 };
                yield return new object[] { new FilmeTestBuilder().ComNota(6.7m).Build(), new FilmeTestBuilder().ComNota(6.3m).Build(), 1 };
                yield return new object[] { new FilmeTestBuilder().ComNota(8.8m).Build(), new FilmeTestBuilder().ComNota(7.9m).Build(), 1 };
                yield return new object[] { new FilmeTestBuilder().ComNota(8.5m).Build(), new FilmeTestBuilder().ComNota(6.7m).Build(), 1 };
                yield return new object[] { new FilmeTestBuilder().ComNota(8.8m).Build(), new FilmeTestBuilder().ComNota(8.5m).Build(), 1 };
            }
        }

        [TestMethod]
        [DynamicData(nameof(FilmesComNotasIguais), DynamicDataSourceType.Property)]
        public void PartidaTests_Dado_Dois_Filmes_Com_Notas_Iguais_Quando_Disputarem_Uma_Partida_Retorna_Como_Vencedor_O_Filme_Em_Primeiro_Na_Ordem_Alfabetica_De_Titulo(Filme filmeA, Filme filmeB, int posicaoVencedor)
        {
            var partida = new Partida(filmeA, filmeB);
            var vencedorEsperado = posicaoVencedor == 1 ? filmeA : filmeB;

            partida.Disputar();

            Assert.AreEqual(expected: vencedorEsperado, actual: partida.Vencedor);
        }

        public static IEnumerable<object[]> FilmesComNotasIguais
        {
            get
            {
                yield return new object[] { 
                    new FilmeTestBuilder().ComTitulo("Filme A").ComNota(8.5m).Build(), 
                    new FilmeTestBuilder().ComTitulo("Filme B").ComNota(8.5m).Build(), 
                    1 
                };
                yield return new object[] { 
                    new FilmeTestBuilder().ComTitulo("Deadpool 2").ComNota(8.5m).Build(), 
                    new FilmeTestBuilder().ComTitulo("Vingadores: Guerra Finita").ComNota(8.5m).Build(), 
                    1 
                };
                yield return new object[] { 
                    new FilmeTestBuilder().ComTitulo("Han Solo: Uma História Star Wars").ComNota(8.5m).Build(), 
                    new FilmeTestBuilder().ComTitulo("Thor: Ragnarok").ComNota(8.5m).Build(), 
                    1 
                };
                yield return new object[] { 
                    new FilmeTestBuilder().ComTitulo("Hereditário").ComNota(8.5m).Build(), 
                    new FilmeTestBuilder().ComTitulo("Os Incríveis 2").ComNota(8.5m).Build(), 
                    1 
                };
                yield return new object[] { 
                    new FilmeTestBuilder().ComTitulo("Jurassic World: Reino Ameaçado").ComNota(8.5m).Build(), 
                    new FilmeTestBuilder().ComTitulo("Oito Mulheres e um Segredo").ComNota(8.5m).Build(), 
                    1
                };
            }
        }
    }
}
