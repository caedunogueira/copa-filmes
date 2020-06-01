using CopaFilmes.Tests.Infra.Fakes;
using CopaFilmes.WebAPI.Domain.Implementacoes;
using CopaFilmes.WebAPI.Infra.Implementacoes;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CopaFilmes.Tests.Infra.Implementacoes
{
    [TestClass]
    public class CatalogoFilmesWebAPITests
    {
        [TestMethod]
        public async Task CatalogFilmesWebAPITests_Dado_Conjunto_De_Ids_De_Filmes_Quando_Consultar_API_Retorna_Filmes_Relacionados_Aos_Ids()
        {
            var messageHandler = new MockHttpMessageHandler(ObterExemploJsonResposta(), HttpStatusCode.OK);
            var httpClient = new HttpClient(messageHandler);
            var catalogo = new CatalogoFilmesWebAPI(httpClient, ObterOpcoesCatalogoFilmes());
            
            var idsFilmes = new List<string> { "tt3606756", "tt4881806", "tt5164214", "tt7784604", "tt4154756", "tt5463162", "tt3778644", "tt3501632" };
            var filmes = await catalogo.ObterPorIds(idsFilmes);

            Assert.AreEqual(expected: 8, actual: filmes.Count, $"Quantidade de filmes esperados é 8 e a quantidade de filmes obtidos com filtro foi {filmes.Count}.");

            foreach (var id in idsFilmes)
                Assert.IsTrue(filmes.Any(f => f.Id == id), $"O filme com Id {id} encontra-se entre os filmes retornados da busca.");
        }

        private IOptions<OpcoesCatalogoFilmes> ObterOpcoesCatalogoFilmes()
        {
            var opcoes = Substitute.For<IOptions<OpcoesCatalogoFilmes>>();

            _ = opcoes.Value.Returns(new OpcoesCatalogoFilmes { EnderecoAPI = "http://copafilmes.azurewebsites.net/api/filmes" });

            return opcoes;
        }

        private string ObterExemploJsonResposta()
        {
            var conteudoResposta = new StringBuilder();

            conteudoResposta.Append("[{\"id\":\"tt3606756\",\"titulo\":\"Os Incríveis 2\",\"ano\":2018,\"nota\":8.5},{\"id\":\"tt4881806\",\"titulo\":\"Jurassic World: Reino Ameaçado\",\"ano\":2018,\"nota\":6.7}");
            conteudoResposta.Append(",{\"id\":\"tt5164214\",\"titulo\":\"Oito Mulheres e um Segredo\",\"ano\":2018,\"nota\":6.3},{\"id\":\"tt7784604\",\"titulo\":\"Hereditário\",\"ano\":2018,\"nota\":7.8}");
            conteudoResposta.Append(",{\"id\":\"tt4154756\",\"titulo\":\"Vingadores: Guerra Infinita\",\"ano\":2018,\"nota\":8.8},{\"id\":\"tt5463162\",\"titulo\":\"Deadpool 2\",\"ano\":2018,\"nota\":8.1}");
            conteudoResposta.Append(",{\"id\":\"tt3778644\",\"titulo\":\"Han Solo: Uma História Star Wars\",\"ano\":2018,\"nota\":7.2},{\"id\":\"tt3501632\",\"titulo\":\"Thor: Ragnarok\",\"ano\":2017,\"nota\":7.9}");
            conteudoResposta.Append(",{\"id\":\"tt2854926\",\"titulo\":\"Te Peguei!\",\"ano\":2018,\"nota\":7.1},{\"id\":\"tt0317705\",\"titulo\":\"Os Incríveis\",\"ano\":2004,\"nota\":8.0}");
            conteudoResposta.Append(",{\"id\":\"tt3799232\",\"titulo\":\"A Barraca do Beijo\",\"ano\":2018,\"nota\":6.4},{\"id\":\"tt1365519\",\"titulo\":\"Tomb Raider: A Origem\",\"ano\":2018,\"nota\":6.5}");
            conteudoResposta.Append(",{\"id\":\"tt1825683\",\"titulo\":\"Pantera Negra\",\"ano\":2018,\"nota\":7.5},{\"id\":\"tt5834262\",\"titulo\":\"Hotel Artemis\",\"ano\":2018,\"nota\":6.3}");
            conteudoResposta.Append(",{\"id\":\"tt7690670\",\"titulo\":\"Superfly\",\"ano\":2018,\"nota\":5.1},{\"id\":\"tt6499752\",\"titulo\":\"Upgrade\",\"ano\":2018,\"nota\":7.8}]");

            return conteudoResposta.ToString();
        }
    }
}
