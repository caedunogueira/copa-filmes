
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.WebAPI.Domain.Implementacoes
{
    internal class Eliminatorias
    {
        private List<Filme> _filmes;
        private Partida[] _partidas;

        internal Filme Campeao { get; private set; }

        internal Eliminatorias(List<Filme> filmes)
        {
            _filmes = filmes;
        }

        internal void MontarChaveamento()
        {
            _partidas = new Partida[4];
            
            _filmes = _filmes.OrderBy(f => f).ToList();

            _partidas[0] = new Partida(_filmes[0], _filmes[7]);
            _partidas[1] = new Partida(_filmes[1], _filmes[6]);
            _partidas[2] = new Partida(_filmes[2], _filmes[5]);
            _partidas[3] = new Partida(_filmes[3], _filmes[4]);
        }

        internal void JogarPartidas()
        {
            foreach (var partida in _partidas)
                partida.Disputar();

            var novasPartidas = new Partida[2];
            novasPartidas[0] = new Partida(_partidas[0].Vencedor, _partidas[1].Vencedor);
            novasPartidas[1] = new Partida(_partidas[2].Vencedor, _partidas[3].Vencedor);

            foreach (var partida in novasPartidas)
                partida.Disputar();

            var ultimaPartida = new Partida(novasPartidas[0].Vencedor, novasPartidas[1].Vencedor);
            ultimaPartida.Disputar();

            Campeao = ultimaPartida.Vencedor;
        }
    }
}
