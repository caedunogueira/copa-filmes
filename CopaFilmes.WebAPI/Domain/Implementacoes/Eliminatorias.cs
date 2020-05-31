
using System.Collections.Generic;

namespace CopaFilmes.WebAPI.Domain.Implementacoes
{
    internal class Eliminatorias
    {
        private List<Filme> _filmes;

        internal Filme Campeao { get; private set; }

        internal Eliminatorias(List<Filme> filmes)
        {
            _filmes = filmes;
        }

        internal void MontarChaveamento()
        {

        }

        internal void JogarPartidas()
        {
            Campeao = _filmes[4];
        }
    }
}
