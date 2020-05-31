using CopaFilmes.WebAPI.Domain.Implementacoes;
using System.Collections.Generic;

namespace CopaFilmes.Tests.Domain.Implementacoes.TestBuilders
{
    internal class PartidaTestBuilder
    {
        List<Filme> filmes;
        Eliminatorias eliminatorias;

        internal PartidaTestBuilder()
        {
            filmes = new List<Filme>();
            eliminatorias = new Eliminatorias(filmes);
        }

        internal Partida Build() => new Partida(eliminatorias, filmes[0], filmes[1]);

        internal PartidaTestBuilder ComFilme(Filme filme)
        {
            filmes.Add(filme);

            return this;
        }
    }
}
