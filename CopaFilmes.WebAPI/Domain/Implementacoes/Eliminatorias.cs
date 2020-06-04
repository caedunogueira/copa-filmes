using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.WebAPI.Domain.Implementacoes
{
    internal class Eliminatorias
    {
        private readonly CopaMundo _copaMundo;

        protected bool _montouChaveamento;

        private int _totalPartidas;
        private Partida[] _partidas;

        internal Filme Campeao { get; private set; }

        internal Filme ViceCampeao { get; private set; }

        internal Eliminatorias(CopaMundo copaMundo)
        {
            _copaMundo = copaMundo;
            _montouChaveamento = false;
        }

        internal void MontarChaveamento()
        {
            _montouChaveamento = false;
            _copaMundo.OrdenarFilmes();
            _montouChaveamento = true;
        }

        internal void Jogar()
        {
            const int ULTIMA = 0;

            var vencedores = new List<Filme>();

            if (!_montouChaveamento)
                throw new InvalidOperationException("Operação inválida. É necessário primeiro montar o chaveamento para, somente então, realizar as partidas das eliminatórias.");

            DefinirPartidas(_copaMundo.Filmes, ObterPosicaoPrimeiroParticipantePartidaPrimeiraFase, ObterPosicaoSegundoParticipantePartidaPrimeiraFase);

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

        private void DefinirPartidas(IReadOnlyCollection<Filme> participantes, Func<int, int> posicaoPrimeiroParticipantePartida, Func<int, IReadOnlyCollection<Filme>, int> posicaoSegundoParticipantePartida)
        {
            _totalPartidas = participantes.Count / 2;

            Array.Resize(ref _partidas, _totalPartidas);

            for (int i = 0, p = 0; p < _totalPartidas; i = posicaoPrimeiroParticipantePartida(i), p++)
                _partidas[p] = new Partida(this, participantes.ElementAt(i), participantes.ElementAt(posicaoSegundoParticipantePartida(i, participantes)));
        }

        private int ObterPosicaoPrimeiroParticipantePartidaPrimeiraFase(int i) => ++i;

        private int ObterPosicaoPrimeiroParticipantePartidaDemaisFases(int i) => i += 2;

        private int ObterPosicaoSegundoParticipantePartidaPrimeiraFase(int i, IReadOnlyCollection<Filme> participantes) => participantes.Count - (i + 1);

        private int ObterPosicaoSegundoParticipantePartidaDemaisFases(int i, IReadOnlyCollection<Filme> participantes) => i + 1;
    }
}
