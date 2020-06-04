using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.WebAPI.Domain.Implementacoes
{
    internal class Eliminatorias
    {
        private readonly CopaMundo _copaMundo;

        protected bool _montouChaveamento;
        private bool _jogou;

        private int _totalPartidas;
        private Partida[] _partidas;
        
        private Filme _campeao;
        private Filme _viceCampeao;

        internal Filme Campeao 
        { 
            get 
            {
                if (!_jogou)
                    throw new InvalidOperationException("Operação inválida. O campeão somente estará disponível quando as eliminatórias forem jogadas.");
                
                return _campeao;
            }
        }

        internal Filme ViceCampeao 
        {
            get
            {
                if (!_jogou)
                    throw new InvalidOperationException("Operação inválida. O vice-campeão somente estará disponível quando as eliminatórias forem jogadas.");
                
                return _viceCampeao;
            }
        }

        internal Eliminatorias(CopaMundo copaMundo)
        {
            if (copaMundo == null)
                throw new ArgumentNullException(nameof(copaMundo), "Argumento inválido. Deve-se fornecer uma instância da classe CopaMundo.");

            _copaMundo = copaMundo;
            _montouChaveamento = false;
            _jogou = false;

            
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

            _jogou = false;

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

            _campeao = _partidas[ULTIMA].Vencedor;
            _viceCampeao = _partidas[ULTIMA].Derrotado;
            _jogou = true;
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
