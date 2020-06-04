using System;
using System.Linq;

namespace CopaFilmes.WebAPI.Domain.Implementacoes
{
    internal class Partida
    {
        private readonly Eliminatorias _eliminatorias;
        private readonly Filme _primeiroFilme, _segundoFilme;

        private bool _disputou;
        
        private Filme _vencedor;
        private Filme _derrotado;

        internal Filme Vencedor 
        {
            get 
            {
                if (!_disputou)
                    throw new InvalidOperationException("Operação inválida. O vencedor somente estará disponível quando a partida for jogada.");

                return _vencedor;
            }
        }

        internal Filme Derrotado 
        {
            get 
            {
                if (!_disputou)
                    throw new InvalidOperationException("Operação inválida. O derrotado somente estará disponível quando a partida for jogada.");

                return _derrotado;
            }
        }

        internal Partida(Eliminatorias eliminatorias, Filme primeiroFilme, Filme segundoFilme)
        {
            _eliminatorias = eliminatorias ?? throw new ArgumentNullException(nameof(eliminatorias), "Argumento inválido. Deve-se fornecer uma instância da classe Eliminatorias.");
            _primeiroFilme = primeiroFilme ?? throw new ArgumentNullException(nameof(primeiroFilme), "Argumento inválido. Deve-se fornecer uma instância da classe Filme.");
            _segundoFilme = segundoFilme ?? throw new ArgumentNullException(nameof(segundoFilme), "Argumento inválido. Deve-se fornecer uma instância da classe Filme.");
            _disputou = false;
        }

        internal void Disputar()
        {
            _disputou = false;

            if (_primeiroFilme.PossuiNotaIgual(_segundoFilme))
            {
                var filmes = new Filme[] { _primeiroFilme, _segundoFilme };

                _vencedor = filmes.OrderBy(f => f).First();
                _derrotado = filmes.OrderBy(f => f).Last();
            }
            else
            {
                _vencedor = _primeiroFilme.PossuiNotaMaior(_segundoFilme) ? _primeiroFilme : _segundoFilme;
                _derrotado = _primeiroFilme.PossuiNotaMaior(_segundoFilme) ? _segundoFilme : _primeiroFilme;
            }

            _disputou = true;
        }
    }
}
