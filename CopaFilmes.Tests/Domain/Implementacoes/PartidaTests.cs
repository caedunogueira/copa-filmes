using CopaFilmes.Tests.Domain.Implementacoes.TestBuilders;
using CopaFilmes.WebAPI.Domain.Implementacoes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CopaFilmes.Tests.Domain.Implementacoes
{
    [TestClass]
    public class PartidaTests
    {
        [TestMethod]
        public void PartidaTests_Dado_Dois_Filmes_Com_Notas_Diferentes_Quando_Disputarem_Uma_Partida_Retorna_Como_Vencedor_O_Filme_Com_Nota_Maior()
        {
            var filmeA = new FilmeTestBuilder().ComNota(8.5m).Build();
            var filmeB = new FilmeTestBuilder().ComNota(6.7m).Build();
            var partida = new Partida(filmeA, filmeB);

            partida.Disputar();

            Assert.AreEqual(partida.Vencedor, filmeA);
        }
    }
}
