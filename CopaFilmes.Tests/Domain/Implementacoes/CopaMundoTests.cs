using CopaFilmes.Tests.Domain.Implementacoes.TestBuilders;
using CopaFilmes.WebAPI.Domain.Implementacoes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CopaFilmes.Tests.Domain.Implementacoes
{
    [TestClass]
    public class CopaMundoTests
    {
        [TestMethod]
        [DataRow(1, 4, 0)]
        [DataRow(2, 6, 2)]
        [DataRow(3, 0, 5)]
        [DataRow(4, 0, 4)]
        [DataRow(5, 5, 3)]
        [DataRow(6, 7, 3)]
        public void CopaMundoTests_Dado_Filmes_Selecionados_Quando_Jogar_A_Copa_Define_O_Campeao_E_Vice(int cenario, int posicaoCampeao, int posicaoViceCampeao)
        {
            var copaMundo = new CopaMundo();
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

            copaMundo.Jogar();

            Assert.AreEqual(expected: filmes[posicaoCampeao], actual: copaMundo.Campeao,
                $"Para cenário de teste {cenario} o campeão esperado é {filmes[posicaoCampeao].Titulo} e o campeão da copa do mundo foi {copaMundo.Campeao.Titulo}.");

            Assert.AreEqual(expected: filmes[posicaoViceCampeao], actual: copaMundo.ViceCampeao,
                $"Para cenário de teste {cenario} o vice-campeão esperado é {filmes[posicaoViceCampeao].Titulo} e o vice-campeão da copa do mundo foi {copaMundo.ViceCampeao.Titulo}.");
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        [DataRow(5)]
        [DataRow(6)]
        [DataRow(7)]
        public void CopaMundoTests_Dado_Que_A_Quantidade_De_Filmes_Selecionados_Difere_De_Oito_Quando_Jogar_Lanca_Excecao(int quantidadeFilmes)
        {
            var copaMundo = new CopaMundo();

            for (var i = 1; i <= quantidadeFilmes; i++)
                copaMundo.Adicionar(new FilmeTestBuilder().Build());

            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                try
                {
                    copaMundo.Jogar();
                }
                catch (InvalidOperationException excecao)
                {
                    if (excecao.Message == "É necessário conter 8 filmes selecionados para disputar a Copa do Mundo porém a quantidade de filmes " +
                                           $"identificados para seleção foi {copaMundo.Filmes?.Count}")
                        throw;

                    Assert.Fail($"A exceção esperada {nameof(InvalidOperationException)} foi lançada mas com uma mensagem inesperada. A mensagem da exceção foi {excecao.Message}");
                }
                catch (Exception excecao)
                {
                    Assert.Fail($"A exceção esperada não foi lançada. O tipo da exceção esperada é {nameof(InvalidOperationException)} mas foi {excecao.GetType().FullName}.");
                }
            });
        }

        [TestMethod]
        public void CopaMundoTests_Dado_Quantidade_Maxima_De_Filmes_Atingida_Quando_Adicionar_Proximo_Filme_Lanca_Excecao()
        {
            var copaMundo = new CopaMundo();

            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                try
                {
                    for (var i = 1; i <= 9; i++)
                        copaMundo.Adicionar(new FilmeTestBuilder().Build());
                }
                catch (InvalidOperationException excecao)
                {
                    if (excecao.Message == $"Não é possível adicionar um novo filme pois a quantidade de filmes selecionados para jogar a copa já foi atingida.")
                        throw;

                    Assert.Fail($"A exceção esperada {nameof(InvalidOperationException)} foi lançada mas com uma mensagem inesperada. A mensagem da exceção foi {excecao.Message}");
                }
                catch (Exception excecao)
                {
                    Assert.Fail($"A exceção esperada não foi lançada. O tipo da exceção esperada é {nameof(InvalidOperationException)} mas foi {excecao.GetType().FullName}.");
                }
            });
        }

        [TestMethod]
        public void CopaMundoTests_Dado_Que_Nao_Foi_Jogada_A_Copa_Quando_Obter_Campeao_Lanca_Excecao()
        {
            var copaMundo = new CopaMundo();

            Assert.ThrowsException<InvalidOperationException>(() =>
            {
                try
                {
                    var campeao = copaMundo.Campeao;
                }
                catch (InvalidOperationException excecao)
                {
                    if (excecao.Message == $"O campeão somente estará disponível quando a copa do mundo for jogada.")
                        throw;

                    Assert.Fail($"A exceção esperada {nameof(InvalidOperationException)} foi lançada mas com uma mensagem inesperada. A mensagem da exceção foi {excecao.Message}");
                }
                catch (Exception excecao)
                {
                    Assert.Fail($"A exceção esperada não foi lançada. O tipo da exceção esperada é {nameof(InvalidOperationException)} mas foi {excecao.GetType().FullName}.");
                }
            });
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

        private List<Filme> ObterFilmesParaTerceiroCenarioTestes()
        {
            return new List<Filme>
            {
                new FilmeTestBuilder().ComTitulo("Os Incríveis").ComNota(8.5m).Build(),
                new FilmeTestBuilder().ComTitulo("Jurassic World: Reino Ameaçado").ComNota(6.7m).Build(),
                new FilmeTestBuilder().ComTitulo("Oito Mulheres e um Segredo").ComNota(6.3m).Build(),
                new FilmeTestBuilder().ComTitulo("Hereditário").ComNota(7.8m).Build(),
                new FilmeTestBuilder().ComTitulo("Han Solo: Uma História Star Wars").ComNota(7.2m).Build(),
                new FilmeTestBuilder().ComTitulo("Thor: Ragnarok").ComNota(7.9m).Build(),
                new FilmeTestBuilder().ComTitulo("Tomb Raider: A Origem").ComNota(6.5m).Build(),
                new FilmeTestBuilder().ComTitulo("Pantera Negra: A Origem").ComNota(7.5m).Build(),
            };
        }

        private List<Filme> ObterFilmesParaQuartoCenarioTestes()
        {
            return new List<Filme>
            {
                new FilmeTestBuilder().ComTitulo("Os Incríveis 2").ComNota(8.5m).Build(),
                new FilmeTestBuilder().ComTitulo("Jurassic World: Reino Ameaçado").ComNota(6.7m).Build(),
                new FilmeTestBuilder().ComTitulo("Oito Mulheres e um Segredo").ComNota(6.3m).Build(),
                new FilmeTestBuilder().ComTitulo("Hereditário").ComNota(7.8m).Build(),
                new FilmeTestBuilder().ComTitulo("Vingadores: Guerra Infinita").ComNota(8.5m).Build(),
                new FilmeTestBuilder().ComTitulo("Deadpool 2").ComNota(8.1m).Build(),
                new FilmeTestBuilder().ComTitulo("Han Solo: Uma História Star Wars").ComNota(7.2m).Build(),
                new FilmeTestBuilder().ComTitulo("Thor: Ragnarok").ComNota(7.9m).Build()
            };
        }

        private List<Filme> ObterFilmesParaQuintoCenarioTestes()
        {
            return new List<Filme>
            {
                new FilmeTestBuilder().ComTitulo("Os Incríveis 2").ComNota(8.5m).Build(),
                new FilmeTestBuilder().ComTitulo("Jurassic World: Reino Ameaçado").ComNota(6.7m).Build(),
                new FilmeTestBuilder().ComTitulo("Oito Mulheres e um Segredo").ComNota(6.7m).Build(),
                new FilmeTestBuilder().ComTitulo("Hereditário").ComNota(8.5m).Build(),
                new FilmeTestBuilder().ComTitulo("Vingadores: Guerra Infinita").ComNota(8.8m).Build(),
                new FilmeTestBuilder().ComTitulo("Deadpool 2").ComNota(8.8m).Build(),
                new FilmeTestBuilder().ComTitulo("Han Solo: Uma História Star Wars").ComNota(7.9m).Build(),
                new FilmeTestBuilder().ComTitulo("Thor: Ragnarok").ComNota(7.9m).Build()
            };
        }

        private List<Filme> ObterFilmesParaSextoCenarioTestes()
        {
            return new List<Filme>
            {
                new FilmeTestBuilder().ComTitulo("Os Incríveis 2").ComNota(10m).Build(),
                new FilmeTestBuilder().ComTitulo("Jurassic World: Reino Ameaçado").ComNota(10m).Build(),
                new FilmeTestBuilder().ComTitulo("Oito Mulheres e um Segredo").ComNota(10m).Build(),
                new FilmeTestBuilder().ComTitulo("Hereditário").ComNota(10m).Build(),
                new FilmeTestBuilder().ComTitulo("Vingadores: Guerra Infinita").ComNota(10m).Build(),
                new FilmeTestBuilder().ComTitulo("Han Solo: Uma História Star Wars").ComNota(10m).Build(),
                new FilmeTestBuilder().ComTitulo("Thor: Ragnarok").ComNota(10m).Build(),
                new FilmeTestBuilder().ComTitulo("A Barraca do Beijo").ComNota(10m).Build(),
            };
        }
    }
}
