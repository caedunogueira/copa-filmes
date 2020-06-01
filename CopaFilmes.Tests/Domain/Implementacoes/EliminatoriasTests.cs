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
        [DataRow(1, 7, 5)]
        [DataRow(2, 6, 2)]
        [DataRow(3, 4, 6)]
        [DataRow(4, 5, 7)]
        [DataRow(5, 0, 2)]
        [DataRow(6, 0, 2)]
        public void EliminatoriasTests_Dado_Filmes_Selecionados_Apos_Montar_Chaveamento_Quando_Jogar_As_Eliminatorias_Define_Campeao_E_Vice(int cenario, int posicaoCampeao, int posicaoViceCampeao)
        {
            var copaMundo = new CopaMundo();
            var eliminatorias = new Eliminatorias(copaMundo);
            var filmes = cenario switch
            {
                1 => ObterFilmesParaPrimeiroCenarioTestes(),
                2 => ObterFilmesParaSegundoCenarioTestes(),
                3 => ObterFilmesParaTerceiroCenarioTestes(),
                4 => ObterFilmesParaQuartoCenarioTestes(),
                5 => ObterFilmesParaQuintoCenarioTestes(),
                6 => ObterFilmesParaSextoCenarioTestes(),
                _ => null,
            };

            foreach (var filme in filmes)
                copaMundo.Adicionar(filme);

            eliminatorias.Jogar();

            Assert.AreEqual(expected: filmes[posicaoCampeao], actual: eliminatorias.Campeao,
                $"Para cenário de teste {cenario} o campeão esperado é {filmes[posicaoCampeao].Titulo} e o campeão das eliminatórias foi {eliminatorias.Campeao.Titulo}.");

            Assert.AreEqual(expected: filmes[posicaoViceCampeao], actual: eliminatorias.ViceCampeao,
                $"Para cenário de teste {cenario} o vice-campeão esperado é {filmes[posicaoViceCampeao].Titulo} e o vice-campeão das eliminatórias foi {eliminatorias.ViceCampeao.Titulo}.");
        }

        private List<Filme> ObterFilmesParaPrimeiroCenarioTestes()
        {
            return new List<Filme>
            {
                new FilmeTestBuilder().ComTitulo("Deadpool 2").ComNota(8.1m).Build(),
                new FilmeTestBuilder().ComTitulo("Han Solo: Uma História Star Wars").ComNota(7.2m).Build(),
                new FilmeTestBuilder().ComTitulo("Hereditário").ComNota(7.8m).Build(),
                new FilmeTestBuilder().ComTitulo("Jurassic World: Reino Ameaçado").ComNota(6.7m).Build(),
                new FilmeTestBuilder().ComTitulo("Oito Mulheres e um Segredo").ComNota(6.3m).Build(),
                new FilmeTestBuilder().ComTitulo("Os Incríveis 2").ComNota(8.5m).Build(),
                new FilmeTestBuilder().ComTitulo("Thor: Ragnarok").ComNota(7.9m).Build(),
                new FilmeTestBuilder().ComTitulo("Vingadores: Guerra Infinita").ComNota(8.8m).Build()
            };
        }

        private List<Filme> ObterFilmesParaSegundoCenarioTestes()
        {
            return new List<Filme>
            {
                new FilmeTestBuilder().ComTitulo("A Barraca do Beijo").ComNota(6.4m).Build(),
                new FilmeTestBuilder().ComTitulo("Han Solo: Uma História Star Wars").ComNota(7.2m).Build(),
                new FilmeTestBuilder().ComTitulo("Hereditário").ComNota(7.8m).Build(),
                new FilmeTestBuilder().ComTitulo("Jurassic World: Reino Ameaçado").ComNota(6.7m).Build(),
                new FilmeTestBuilder().ComTitulo("Oito Mulheres e um Segredo").ComNota(6.3m).Build(),
                new FilmeTestBuilder().ComTitulo("Pantera Negra: A Origem").ComNota(7.5m).Build(),
                new FilmeTestBuilder().ComTitulo("Thor: Ragnarok").ComNota(7.9m).Build(),
                new FilmeTestBuilder().ComTitulo("Tomb Raider: A Origem").ComNota(6.5m).Build()
            };
        }

        private List<Filme> ObterFilmesParaTerceiroCenarioTestes()
        {
            return new List<Filme>
            {
                new FilmeTestBuilder().ComTitulo("Han Solo: Uma História Star Wars").ComNota(7.2m).Build(),
                new FilmeTestBuilder().ComTitulo("Hereditário").ComNota(7.8m).Build(),
                new FilmeTestBuilder().ComTitulo("Jurassic World: Reino Ameaçado").ComNota(6.7m).Build(),
                new FilmeTestBuilder().ComTitulo("Oito Mulheres e um Segredo").ComNota(6.3m).Build(),
                new FilmeTestBuilder().ComTitulo("Os Incríveis").ComNota(8.5m).Build(),
                new FilmeTestBuilder().ComTitulo("Pantera Negra: A Origem").ComNota(7.5m).Build(),
                new FilmeTestBuilder().ComTitulo("Thor: Ragnarok").ComNota(7.9m).Build(),
                new FilmeTestBuilder().ComTitulo("Tomb Raider: A Origem").ComNota(6.5m).Build()
                
            };
        }

        private List<Filme> ObterFilmesParaQuartoCenarioTestes()
        {
            return new List<Filme>
            {
                new FilmeTestBuilder().ComTitulo("Deadpool 2").ComNota(8.1m).Build(),
                new FilmeTestBuilder().ComTitulo("Han Solo: Uma História Star Wars").ComNota(7.2m).Build(),
                new FilmeTestBuilder().ComTitulo("Hereditário").ComNota(7.8m).Build(),
                new FilmeTestBuilder().ComTitulo("Jurassic World: Reino Ameaçado").ComNota(6.7m).Build(),
                new FilmeTestBuilder().ComTitulo("Oito Mulheres e um Segredo").ComNota(6.3m).Build(),
                new FilmeTestBuilder().ComTitulo("Os Incríveis 2").ComNota(8.5m).Build(),
                new FilmeTestBuilder().ComTitulo("Thor: Ragnarok").ComNota(7.9m).Build(),
                new FilmeTestBuilder().ComTitulo("Vingadores: Guerra Infinita").ComNota(8.5m).Build()
            };
        }

        private List<Filme> ObterFilmesParaQuintoCenarioTestes()
        {
            return new List<Filme>
            {
                new FilmeTestBuilder().ComTitulo("Deadpool 2").ComNota(8.8m).Build(),
                new FilmeTestBuilder().ComTitulo("Han Solo: Uma História Star Wars").ComNota(7.9m).Build(),
                new FilmeTestBuilder().ComTitulo("Hereditário").ComNota(8.5m).Build(),
                new FilmeTestBuilder().ComTitulo("Jurassic World: Reino Ameaçado").ComNota(6.7m).Build(),
                new FilmeTestBuilder().ComTitulo("Oito Mulheres e um Segredo").ComNota(6.7m).Build(),
                new FilmeTestBuilder().ComTitulo("Os Incríveis 2").ComNota(8.5m).Build(),
                new FilmeTestBuilder().ComTitulo("Thor: Ragnarok").ComNota(7.9m).Build(),
                new FilmeTestBuilder().ComTitulo("Vingadores: Guerra Infinita").ComNota(8.8m).Build()
            };
        }

        private List<Filme> ObterFilmesParaSextoCenarioTestes()
        {
            return new List<Filme>
            {
                new FilmeTestBuilder().ComTitulo("A Barraca do Beijo").ComNota(10m).Build(),
                new FilmeTestBuilder().ComTitulo("Han Solo: Uma História Star Wars").ComNota(10m).Build(),
                new FilmeTestBuilder().ComTitulo("Hereditário").ComNota(10m).Build(),
                new FilmeTestBuilder().ComTitulo("Jurassic World: Reino Ameaçado").ComNota(10m).Build(),
                new FilmeTestBuilder().ComTitulo("Oito Mulheres e um Segredo").ComNota(10m).Build(),
                new FilmeTestBuilder().ComTitulo("Os Incríveis 2").ComNota(10m).Build(),
                new FilmeTestBuilder().ComTitulo("Thor: Ragnarok").ComNota(10m).Build(),
                new FilmeTestBuilder().ComTitulo("Vingadores: Guerra Infinita").ComNota(10m).Build()
            };
        }
    }
}
