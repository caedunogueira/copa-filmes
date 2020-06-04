using CopaFilmes.WebAPI.Domain.Implementacoes;
using System.Collections.Generic;

namespace CopaFilmes.Tests.Domain.Implementacoes.TestBuilders
{
    internal class PartidaTestBuilder
    {
        private readonly CopaMundo _copaMundo;
        private Eliminatorias _eliminatorias;

        private List<Filme> _filmes;

        internal PartidaTestBuilder()
        {
            _filmes = new List<Filme>();
            _copaMundo = new CopaMundo();
            _eliminatorias = new Eliminatorias(_copaMundo);
        }

        internal Partida Build()
        {
            foreach (var filme in _filmes)
                _copaMundo.Adicionar(filme);

            return new Partida(_eliminatorias, _filmes[0], _filmes[1]);
        }

        internal PartidaTestBuilder ComFilme(Filme filme)
        {
            _filmes ??= new List<Filme>();

            _filmes.Add(filme);

            return this;
        }

        internal PartidaTestBuilder ComEliminatorias(Eliminatorias eliminatorias)
        {
            _eliminatorias = eliminatorias;

            return this;
        }
    }
}
