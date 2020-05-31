
using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.WebAPI.Domain.Implementacoes
{
    internal class Eliminatorias
    {
        private int _totalPartidas;
        private List<Filme> _filmes;
        private Partida[] _partidas;

        internal Filme Campeao { get; private set; }

        internal Eliminatorias(List<Filme> filmes)
        {
            _filmes = filmes;
            _totalPartidas = _filmes.Count / 2;
        }

        internal void MontarChaveamento()
        {
            _partidas = new Partida[_totalPartidas];

            _filmes = _filmes.OrderBy(f => f).ToList();

            for (int i = 0, j = _filmes.Count, p = 0; i < j; i++, j--, p++)
                _partidas[p] = new Partida(_filmes[i], _filmes[j - 1]);
        }

        internal void JogarPartidas()
        {
            var vencedores = new List<Filme>();

            while (_partidas.Length >= 1)
            {
                vencedores.Clear();

                foreach (var partida in _partidas)
                {
                    partida.Disputar();
                    vencedores.Add(partida.Vencedor);
                }

                if (_partidas.Length == 1)
                    break;

                _totalPartidas = _partidas.Length / 2;
                Array.Resize(ref _partidas, _totalPartidas);
                
                for (int i = 0, p = 0; p < _totalPartidas; i += 2, p++)
                    _partidas[p] = new Partida(vencedores[i], vencedores[i + 1]);
            }

            Campeao = vencedores[0];
        }
    }
}
