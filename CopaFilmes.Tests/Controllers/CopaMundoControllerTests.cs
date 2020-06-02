using CopaFilmes.Tests.Domain.Implementacoes.TestBuilders;
using CopaFilmes.WebAPI.Controllers;
using CopaFilmes.WebAPI.Domain.Implementacoes;
using CopaFilmes.WebAPI.Domain.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CopaFilmes.Tests.Controllers
{
    [TestClass]
    public class CopaMundoControllerTests
    {
        [TestMethod]
        public async Task CopaMundoControllerTests_Dado_Oito_Ids_De_Filmes_Para_Jogar_A_Copa_Quando_Consumir_Endpoint_Jogar_Retorna_Campeao_E_Vice()
        {
            var filmes = ObterFilmesParaCenarioTestes();
            var catalogo = Substitute.For<ICatalogoFilmes>();
            var controller = new CopaMundoController(catalogo);
            
            catalogo.ObterPorIds(Arg.Any<List<string>>()).Returns(filmes);

            var resultadoAcao = await controller.Get(string.Empty);
            var resultadoCopa = resultadoAcao.Value;

            _ = catalogo.Received().ObterPorIds(Arg.Any<List<string>>());

            Assert.IsNotNull(resultadoCopa?.Campeao, "existe informação de campeão pois não é nulo.");
            Assert.IsNotNull(resultadoCopa?.ViceCampeao, "existe informação de vice-campeão pois não é nulo.");
        }

        [TestMethod]
        public async Task CopaMundoControllerTests_Dado_Solicitacao_Para_Obter_Filmes_Disponiveis_Para_Disputa_Quando_Consumir_Endpoint_Filmes_Retorna_Lista_Filmes()
        {
            var catalogo = Substitute.For<ICatalogoFilmes>();
            var controller = new CopaMundoController(catalogo);

            catalogo.ObterTodos().Returns(new List<Filme>());

            var resultado = await controller.Get();

            _ = catalogo.Received().ObterTodos();

            Assert.IsInstanceOfType(value: resultado, expectedType: typeof(IReadOnlyCollection<Filme>));
        }

        private List<Filme> ObterFilmesParaCenarioTestes()
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
    }
}
