using System.Linq;

namespace CopaFilmes.WebAPI.Domain.Implementacoes
{
    internal class Partida
    {
        private readonly Eliminatorias _eliminatorias;
        private readonly Filme _primeiroFilme, _segundoFilme;

        internal Filme Vencedor { get; private set; }

        internal Filme Derrotado { get; private set; }

        internal Partida(Eliminatorias eliminatorias, Filme primeiroFilme, Filme segundoFilme)
        {
            _eliminatorias = eliminatorias;
            _primeiroFilme = primeiroFilme;
            _segundoFilme = segundoFilme;
        }

        internal void Disputar()
        {
            if (_primeiroFilme.PossuiNotaIgual(_segundoFilme))
            {
                var filmes = new Filme[] { _primeiroFilme, _segundoFilme };

                Vencedor = filmes.OrderBy(f => f).First();
                Derrotado = filmes.OrderBy(f => f).Last();
            }
            else
            {
                Vencedor = _primeiroFilme.PossuiNotaMaior(_segundoFilme) ? _primeiroFilme : _segundoFilme;
                Derrotado = _primeiroFilme.PossuiNotaMaior(_segundoFilme) ? _segundoFilme : _primeiroFilme;
            }
        }
    }
}
