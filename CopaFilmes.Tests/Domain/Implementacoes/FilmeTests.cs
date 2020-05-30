using CopaFilmes.WebAPI.Domain.Implementacoes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CopaFilmes.Tests.Domain.Implementacoes
{
    [TestClass]
    public class FilmeTests
    {
        [TestMethod]
        public void FilmeTests_Dado_Que_Filme_Possui_Maior_Nota_Em_Relacao_Ao_Comparado_Quando_Consultar_Retorna_Verdadeiro()
        {
            var filmeA = new Filme(id: "tt1245748", titulo: "Filme A", ano: 2018, nota: 8.5m);
            var filmeB = new Filme(id: "tt2532658", titulo: "Filme B", ano: 2019, nota: 6.7m);

            Assert.IsTrue(filmeA.PossuiMaiorNota(filmeB));
        }
    }
}
