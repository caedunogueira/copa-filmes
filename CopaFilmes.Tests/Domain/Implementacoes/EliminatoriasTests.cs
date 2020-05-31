using CopaFilmes.Tests.Domain.Implementacoes.TestBuilders;
using CopaFilmes.WebAPI.Domain.Implementacoes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CopaFilmes.Tests.Domain.Implementacoes
{
    [TestClass]
    public class EliminatoriasTests
    {
        [TestMethod]
        [DynamicData(nameof(FilmesSelecionadosParaEliminatorias), DynamicDataSourceType.Property)]
        public void EliminatoriasTests_Dado_Filmes_Selecionados_Quando_Jogarem_As_Partidas_Define_Campeao(List<Filme> filmes, int indiceFilmeVencedor)
        {
            var eliminatorias = new Eliminatorias(filmes);

            eliminatorias.MontarChaveamento();
            eliminatorias.JogarPartidas();

            Assert.AreEqual(expected: filmes[indiceFilmeVencedor], actual: eliminatorias.Campeao);
        }

        public static IEnumerable<object[]> FilmesSelecionadosParaEliminatorias
        {
            get
            {
                yield return new object[]
                {
                    new List<Filme>
                    {
                        new FilmeTestBuilder().ComTitulo("Os Incríveis 2").ComNota(8.5m).Build(),
                        new FilmeTestBuilder().ComTitulo("Jurassic World: Reino Ameaçado").ComNota(6.7m).Build(),
                        new FilmeTestBuilder().ComTitulo("Oito Mulheres e um Segredo").ComNota(6.3m).Build(),
                        new FilmeTestBuilder().ComTitulo("Hereditário").ComNota(7.8m).Build(),
                        new FilmeTestBuilder().ComTitulo("Vingadores: Guerra Infinita").ComNota(8.8m).Build(),
                        new FilmeTestBuilder().ComTitulo("Deadpool 2").ComNota(8.1m).Build(),
                        new FilmeTestBuilder().ComTitulo("Han Solo: Uma História Star Wars").ComNota(7.2m).Build(),
                        new FilmeTestBuilder().ComTitulo("Thor: Ragnarok").ComNota(7.9m).Build()
                    },
                    4
                };
                yield return new object[]
                {
                    new List<Filme>
                    {
                        new FilmeTestBuilder().ComTitulo("Jurassic World: Reino Ameaçado").ComNota(6.7m).Build(),
                        new FilmeTestBuilder().ComTitulo("Oito Mulheres e um Segredo").ComNota(6.3m).Build(),
                        new FilmeTestBuilder().ComTitulo("Hereditário").ComNota(7.8m).Build(),
                        new FilmeTestBuilder().ComTitulo("Han Solo: Uma História Star Wars").ComNota(7.2m).Build(),
                        new FilmeTestBuilder().ComTitulo("A Barraca do Beijo").ComNota(6.4m).Build(),
                        new FilmeTestBuilder().ComTitulo("Tomb Raider: A Origem").ComNota(6.5m).Build(),
                        new FilmeTestBuilder().ComTitulo("Thor: Ragnarok").ComNota(7.9m).Build(),
                        new FilmeTestBuilder().ComTitulo("Pantera Negra: A Origem").ComNota(7.5m).Build(),
                    },
                    6
                };
            }
        }
    }
}
