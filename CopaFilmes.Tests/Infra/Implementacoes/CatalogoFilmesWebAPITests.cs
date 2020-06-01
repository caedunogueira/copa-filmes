
using CopaFilmes.WebAPI.Infra.Implementacoes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.Tests.Infra.Implementacoes
{
    [TestClass]
    public class CatalogoFilmesWebAPITests
    {
        [TestMethod]
        public void CatalogFilmesWebAPITests_Dado_Conjunto_De_Ids_De_Filmes_Quando_Consultar_API_Retorna_Filmes_Relacionados_Aos_Ids()
        {
            var catalogo = new CatalogoFilmesWebAPI("http://copafilmes.azurewebsites.net/api/filmes");
            var idsFilmes = new List<string> { "tt3606756", "tt4881806", "tt5164214", "tt7784604", "tt4154756", "tt5463162", "tt3778644", "tt3501632" };

            var filmes = catalogo.ObterPorIds(idsFilmes);

            Assert.AreEqual(expected: 8, filmes.Count);

            foreach (var id in idsFilmes)
                Assert.IsTrue(filmes.Any(f => f.Id == id));
        }
    }
}
