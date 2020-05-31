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

        internal Filme ViceCampeao { get; private set; }

        internal Eliminatorias(List<Filme> filmes) => _filmes = filmes;

        internal void MontarChaveamento()
        {
            _filmes = _filmes.OrderBy(f => f).ToList();

            DefinirPartidas(_filmes, ObterPosicaoPrimeiroParticipantePartidaPrimeiraFase, ObterPosicaoSegundoParticipantePartidaPrimeiraFase);
        }

        internal void Jogar()
        {
            const int ULTIMA = 0;

            var vencedores = new List<Filme>();

            do
            {
                vencedores.Clear();

                foreach (var partida in _partidas)
                {
                    partida.Disputar();
                    vencedores.Add(partida.Vencedor);
                }

                if (_partidas.Length == 1) break;

                DefinirPartidas(vencedores, ObterPosicaoPrimeiroParticipantePartidaDemaisFases, ObterPosicaoSegundoParticipantePartidaDemaisFases);

            } while (_partidas.Length >= 1);

            Campeao = _partidas[ULTIMA].Vencedor;
            ViceCampeao = _partidas[ULTIMA].Derrotado;
        }

        private void DefinirPartidas(List<Filme> participantes, Func<int, int> posicaoPrimeiroParticipantePartida, Func<int, List<Filme>, int> posicaoSegundoParticipantePartida)
        {
            _totalPartidas = participantes.Count / 2;

            Array.Resize(ref _partidas, _totalPartidas);

            for (int i = 0, p = 0; p < _totalPartidas; i = posicaoPrimeiroParticipantePartida(i), p++)
                _partidas[p] = new Partida(this, participantes[i], participantes[posicaoSegundoParticipantePartida(i, participantes)]);
        }

        private int ObterPosicaoPrimeiroParticipantePartidaPrimeiraFase(int i) => ++i;

        private int ObterPosicaoPrimeiroParticipantePartidaDemaisFases(int i) => i += 2;

        private int ObterPosicaoSegundoParticipantePartidaPrimeiraFase(int i, List<Filme> participantes) => participantes.Count - (i + 1);

        private int ObterPosicaoSegundoParticipantePartidaDemaisFases(int i, List<Filme> participantes) => i + 1;
    }
}
