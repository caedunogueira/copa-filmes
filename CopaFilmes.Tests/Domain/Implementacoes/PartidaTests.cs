using CopaFilmes.Tests.Domain.Implementacoes.TestBuilders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CopaFilmes.Tests.Domain.Implementacoes
{
    [TestClass]
    public class PartidaTests
    {
        [TestMethod]
        [DynamicData(nameof(FilmesComNotasDiferentesParaVencedor), DynamicDataSourceType.Property)]
        public void PartidaTests_Dado_Dois_Filmes_Com_Notas_Diferentes_Quando_Disputarem_Uma_Partida_Retorna_Como_Vencedor_O_Filme_Com_Nota_Maior(decimal notaFilmeA, decimal notaFilmeB, int posicaoVencedor, int posicaoDerrotado)
        {
            var filmeA = new FilmeTestBuilder().ComNota(notaFilmeA).Build();
            var filmeB = new FilmeTestBuilder().ComNota(notaFilmeB).Build();
            var partida = new PartidaTestBuilder().ComFilme(filmeA).ComFilme(filmeB).Build();
            var vencedorEsperado = posicaoVencedor == 1 ? filmeA : filmeB;
            var derrotadoEsperado = posicaoDerrotado == 1 ? filmeA : filmeB;
            var nomeVariavelVencedorEsperado = posicaoVencedor == 1 ? nameof(filmeA) : nameof(filmeB);
            var nomeVariavelDerrotadoEsperado = posicaoDerrotado == 1 ? nameof(filmeA) : nameof(filmeB);

            partida.Disputar();

            Assert.AreEqual(expected: vencedorEsperado, actual: partida.Vencedor, 
                $"O vencedor esperado é a instância de Filme da variável {nomeVariavelVencedorEsperado} porque a nota do Filme A é {notaFilmeA} e a nota do Filme B é {notaFilmeB}.");

            Assert.AreEqual(expected: derrotadoEsperado, actual: partida.Derrotado,
                $"O derrotado esperado é a instância de Filme da variável {nomeVariavelDerrotadoEsperado} porque a nota do Filme A é {notaFilmeA} e a nota do Filme B é {notaFilmeB}.");

        }

        /// <summary>
        /// Propriedade utilizada de entrada para cenários de testes.
        /// </summary>
        public static IEnumerable<object[]> FilmesComNotasDiferentesParaVencedor
        {
            get
            {
                yield return new object[] { 6.7m, 8.5m, 2, 1 };
                yield return new object[] { 8.1m, 8.8m, 2, 1 };
                yield return new object[] { 7.2m, 7.9m, 2, 1 };
                yield return new object[] { 7.8m, 8.5m, 2, 1 };
                yield return new object[] { 6.7m, 6.3m, 1, 2 };
                yield return new object[] { 8.8m, 7.9m, 1, 2 };
                yield return new object[] { 8.5m, 6.7m, 1, 2 };
                yield return new object[] { 8.8m, 8.5m, 1, 2 };
            }
        }

        [TestMethod]
        [DynamicData(nameof(FilmesComNotasIguais), DynamicDataSourceType.Property)]
        public void PartidaTests_Dado_Dois_Filmes_Com_Notas_Iguais_Quando_Disputarem_Uma_Partida_Retorna_Como_Vencedor_O_Filme_Em_Primeiro_Na_Ordem_Alfabetica_De_Titulo(string tituloFilmeA, decimal notaFilmeA, string tituloFilmeB, decimal notaFilmeB, int posicaoVencedor, int posicaoDerrotado)
        {
            var filmeA = new FilmeTestBuilder().ComTitulo(tituloFilmeA).ComNota(notaFilmeA).Build();
            var filmeB = new FilmeTestBuilder().ComTitulo(tituloFilmeB).ComNota(notaFilmeB).Build();
            var partida = new PartidaTestBuilder().ComFilme(filmeA).ComFilme(filmeB).Build();
            var vencedorEsperado = posicaoVencedor == 1 ? filmeA : filmeB;
            var derrotadoEsperado = posicaoDerrotado == 1 ? filmeA : filmeB;
            var nomeVariavelVencedorEsperado = posicaoVencedor == 1 ? nameof(filmeA) : nameof(filmeB);
            var nomeVariavelDerrotadoEsperado = posicaoDerrotado == 1 ? nameof(filmeA) : nameof(filmeB);

            partida.Disputar();

            Assert.AreEqual(expected: vencedorEsperado, actual: partida.Vencedor,
                $"O vencedor esperado é a instância de Filme da variável {nomeVariavelVencedorEsperado} porque o titulo do Filme A é \"{tituloFilmeA}\" e o titulo do Filme B é \"{tituloFilmeB}\".");

            Assert.AreEqual(expected: derrotadoEsperado, actual: partida.Derrotado,
                $"O derrotado esperado é a instância de Filme da variável {nomeVariavelDerrotadoEsperado} porque o titulo do Filme A é \"{tituloFilmeA}\" e o titulo do Filme B é \"{tituloFilmeB}\".");
        }

        /// <summary>
        /// Propriedade utilizada de entrada para cenários de testes.
        /// </summary>
        public static IEnumerable<object[]> FilmesComNotasIguais
        {
            get
            {
                yield return new object[] { "Filme A", 8.5m, "Filme B", 8.5m, 1, 2 };
                yield return new object[] { "Deadpool 2", 8.5m, "Vingadores: Guerra Finita", 8.5m, 1, 2 };
                yield return new object[] { "Thor: Ragnarok", 8.5m, "Han Solo: Uma História Star Wars", 8.5m, 2, 1 };
                yield return new object[] { "Os Incríveis 2", 8.5m, "Hereditário", 8.5m, 2, 1 };
                yield return new object[] { "Jurassic World: Reino Ameaçado", 8.5m, "Oito Mulheres e um Segredo", 8.5m, 1, 2 };
            }
        }

        [TestMethod]
        public void PartidaTests_Dado_Partida_Sem_Disputa_Quando_Consultar_Pelo_Vencedor_Lanca_Excecao()
        {
            var filmeA = new FilmeTestBuilder().ComTitulo("Filme A").ComNota(8.5m).Build();
            var filmeB = new FilmeTestBuilder().ComTitulo("Filme B").ComNota(8.5m).Build();
            var partida = new PartidaTestBuilder().ComFilme(filmeA).ComFilme(filmeB).Build();

            _ = Assert.ThrowsException<InvalidOperationException>(() =>
            {
                try
                {
                    _ = partida.Vencedor;
                }
                catch (InvalidOperationException excecao)
                {
                    if (excecao.Message == "Operação inválida. O vencedor somente estará disponível quando a partida for jogada.")
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
        public void PartidaTests_Dado_Partida_Sem_Disputa_Quando_Consultar_Pelo_Derrotado_Lanca_Excecao()
        {
            var filmeA = new FilmeTestBuilder().ComTitulo("Filme A").ComNota(8.5m).Build();
            var filmeB = new FilmeTestBuilder().ComTitulo("Filme B").ComNota(8.5m).Build();
            var partida = new PartidaTestBuilder().ComFilme(filmeA).ComFilme(filmeB).Build();

            _ = Assert.ThrowsException<InvalidOperationException>(() =>
            {
                try
                {
                    _ = partida.Derrotado;
                }
                catch (InvalidOperationException excecao)
                {
                    if (excecao.Message == "Operação inválida. O derrotado somente estará disponível quando a partida for jogada.")
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
        public void PartidaTests_Dado_Nulo_Argumento_Eliminatorias_Quando_Instanciar_Lanca_Excecao()
        {
            var filmeA = new FilmeTestBuilder().ComTitulo("Filme A").ComNota(8.5m).Build();
            var filmeB = new FilmeTestBuilder().ComTitulo("Filme B").ComNota(8.5m).Build();
            var partidaBuilder = new PartidaTestBuilder().ComEliminatorias(null).ComFilme(filmeA).ComFilme(filmeB);

            _ = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                try
                {
                    _ = partidaBuilder.Build();
                }
                catch (ArgumentNullException excecao)
                {
                    if (excecao.ParamName == "eliminatorias")
                        throw;

                    Assert.Fail($"A exceção esperada {nameof(ArgumentNullException)} foi lançada mas com uma mensagem inesperada. A mensagem da exceção foi {excecao.Message}");
                }
                catch (Exception excecao)
                {
                    Assert.Fail($"A exceção esperada não foi lançada. O tipo da exceção esperada é {nameof(ArgumentNullException)} mas foi {excecao.GetType().FullName}.");
                }
            });
        }

        [TestMethod]
        public void PartidaTests_Dado_Nulo_Argumento_Primeiro_Participante_Quando_Instanciar_Lanca_Excecao()
        {
            var filme = new FilmeTestBuilder().ComTitulo("Filme B").ComNota(8.5m).Build();
            var partidaBuilder = new PartidaTestBuilder().ComFilme(null).ComFilme(filme);

            _ = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                try
                {
                    _ = partidaBuilder.Build();
                }
                catch (ArgumentNullException excecao)
                {
                    if (excecao.ParamName == "primeiroFilme")
                        throw;

                    Assert.Fail($"A exceção esperada {nameof(ArgumentNullException)} foi lançada mas com uma mensagem inesperada. A mensagem da exceção foi {excecao.Message}");
                }
                catch (Exception excecao)
                {
                    Assert.Fail($"A exceção esperada não foi lançada. O tipo da exceção esperada é {nameof(ArgumentNullException)} mas foi {excecao.GetType().FullName}.");
                }
            });
        }

        [TestMethod]
        public void PartidaTests_Dado_Nulo_Argumento_Segundo_Participante_Quando_Instanciar_Lanca_Excecao()
        {
            var filme = new FilmeTestBuilder().ComTitulo("Filme B").ComNota(8.5m).Build();
            var partidaBuilder = new PartidaTestBuilder().ComFilme(filme).ComFilme(null);

            _ = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                try
                {
                    _ = partidaBuilder.Build();
                }
                catch (ArgumentNullException excecao)
                {
                    if (excecao.ParamName == "segundoFilme")
                        throw;

                    Assert.Fail($"A exceção esperada {nameof(ArgumentNullException)} foi lançada mas com uma mensagem inesperada. A mensagem da exceção foi {excecao.Message}");
                }
                catch (Exception excecao)
                {
                    Assert.Fail($"A exceção esperada não foi lançada. O tipo da exceção esperada é {nameof(ArgumentNullException)} mas foi {excecao.GetType().FullName}.");
                }
            });
        }
    }
}
