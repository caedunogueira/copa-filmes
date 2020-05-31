using CopaFilmes.Tests.Domain.Implementacoes.TestBuilders;
using CopaFilmes.WebAPI.Domain.Implementacoes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CopaFilmes.Tests.Domain.Implementacoes
{
    [TestClass]
    public class CopaMundoTests
    {
        [TestMethod]
        [DataRow(1, 4, 0)]
        [DataRow(2, 6, 2)]
        public void CopaMundoTests_Dado_Filmes_Selecionados_Quando_Jogar_A_Copa_Obtem_O_Campeao_E_Vice(int cenario, int posicaoCampeao, int posicaoViceCampeao)
        {
            var copa = new CopaMundo();
            List<Filme> filmes = cenario switch
            {
                1 => ObterFilmesParaPrimeiroCenarioTestes(),
                2 => ObterFilmesParaSegundoCenarioTestes(),
                _ => null,
            };

            foreach (var filme in filmes)
                copa.AdicionarFilme(filme);

            copa.Jogar();

            Assert.AreEqual(expected: filmes[posicaoCampeao], actual: copa.Campeao);
            Assert.AreEqual(expected: filmes[posicaoViceCampeao], actual: copa.ViceCampeao);
        }

        private List<Filme> ObterFilmesParaPrimeiroCenarioTestes()
        {
            return new List<Filme>
            {
                new FilmeTestBuilder().ComTitulo("Os Incríveis 2").ComNota(8.5m).Build(),
                new FilmeTestBuilder().ComTitulo("Jurassic World: Reino Ameaçado").ComNota(6.7m).Build(),
                new FilmeTestBuilder().ComTitulo("Oito Mulheres e um Segredo").ComNota(6.3m).Build(),
                new FilmeTestBuilder().ComTitulo("Hereditário").ComNota(7.8m).Build(),
                new FilmeTestBuilder().ComTitulo("Vingadores: Guerra Infinita").ComNota(8.8m).Build(),
                new FilmeTestBuilder().ComTitulo("Deadpool 2").ComNota(8.1m).Build(),
                new FilmeTestBuilder().ComTitulo("Han Solo: Uma História Star Wars").ComNota(7.2m).Build(),
                new FilmeTestBuilder().ComTitulo("Thor: Ragnarok").ComNota(7.9m).Build()
            };
        }

        private List<Filme> ObterFilmesParaSegundoCenarioTestes()
        {
            return new List<Filme>
            {
                new FilmeTestBuilder().ComTitulo("Jurassic World: Reino Ameaçado").ComNota(6.7m).Build(),
                new FilmeTestBuilder().ComTitulo("Oito Mulheres e um Segredo").ComNota(6.3m).Build(),
                new FilmeTestBuilder().ComTitulo("Hereditário").ComNota(7.8m).Build(),
                new FilmeTestBuilder().ComTitulo("Han Solo: Uma História Star Wars").ComNota(7.2m).Build(),
                new FilmeTestBuilder().ComTitulo("A Barraca do Beijo").ComNota(6.4m).Build(),
                new FilmeTestBuilder().ComTitulo("Tomb Raider: A Origem").ComNota(6.5m).Build(),
                new FilmeTestBuilder().ComTitulo("Thor: Ragnarok").ComNota(7.9m).Build(),
                new FilmeTestBuilder().ComTitulo("Pantera Negra: A Origem").ComNota(7.5m).Build(),
            };
        }
    }
}
