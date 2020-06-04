using CopaFilmes.Tests.Domain.Implementacoes.TestBuilders;
using CopaFilmes.WebAPI.Controllers;
using CopaFilmes.WebAPI.Domain.Implementacoes;
using CopaFilmes.WebAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
        public async Task CopaMundoControllerTests_Dado_Request_Oito_Ids_De_Filmes_Para_Jogar_A_Copa_Quando_Consumir_Endpoint_Jogar_Retorna_Campeao_E_Vice()
        {
            var oitoFilmes = ObterFilmesParaCenarioTestes();
            var catalogo = Substitute.For<ICatalogoFilmes>();
            var controller = new CopaMundoController(catalogo);
            var ids = "tt3606756,tt4881806,tt5164214,tt7784604,tt4154756,tt5463162,tt3778644,tt3501632";

            _ = catalogo.ObterPorIds(Arg.Any<List<string>>()).Returns(oitoFilmes);

            var resultadoAcao = await controller.Get(ids);
            var resultadoOk = resultadoAcao as OkObjectResult;
            var resultadoCopa = resultadoOk?.Value as CopaMundo;

            _ = catalogo.Received().ObterPorIds(Arg.Any<List<string>>());

            Assert.IsNotNull(resultadoOk, "há uma instância da classe OkObjectResult.");
            Assert.AreEqual(expected: 200, actual: resultadoOk.StatusCode, "o código de status de resposta é 200.");
            Assert.IsNotNull(resultadoCopa, "há uma instância no corpo da resposta da classe CopaMundo.");
            Assert.IsNotNull(resultadoCopa.Campeao, "há uma instância da classe Filme como campeão do objeto CopaMundo.");
            Assert.IsNotNull(resultadoCopa.ViceCampeao, "há uma instância da classe Filme como vice-campeão do objeto CopaMundo.");
        }

        [TestMethod]
        public async Task CopaMundoControllerTests_Dado_Request_Nao_Possua_Oito_Ids_de_Filmes_Para_Jogar_A_Copa_Quando_Consumir_Endpoint_Retorna_Bad_Request()
        {
            var catalogo = Substitute.For<ICatalogoFilmes>();
            var controller = new CopaMundoController(catalogo);

            var resultadoAcao = await controller.Get(string.Empty);
            var resultadoBadRequest = resultadoAcao as BadRequestObjectResult;
            var resultadoMensagem = resultadoBadRequest?.Value as string;

            _ = catalogo.DidNotReceive().ObterPorIds(Arg.Any<List<string>>());

            Assert.IsNotNull(resultadoBadRequest, "há uma instância da classe BadRequestObjectResult.");
            Assert.AreEqual(expected: 400, actual: resultadoBadRequest.StatusCode, "o código de status de resposta é 400.");
            Assert.AreEqual(expected: "Requisição incorreta pois não foi identificado 8 ids de filmes para o torneio.", actual: resultadoMensagem, "a mensagem de resposta do Bad Request está correta.");
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
