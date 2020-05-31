using System.Linq;

namespace CopaFilmes.WebAPI.Domain.Implementacoes
{
    internal class Partida
    {
        private readonly Filme _primeiroFilme, _segundoFilme;

        internal Filme Vencedor { get; private set; }

        internal Filme Derrotado { get; private set; }

        internal Partida(Filme primeiroFilme, Filme segundoFilme)
        {
            _primeiroFilme = primeiroFilme;
            _segundoFilme = segundoFilme;
        }

        internal void Disputar()
        {
            if (_primeiroFilme.PossuiNotaIgual(_segundoFilme))
            {
                Vencedor = new Filme[] { _primeiroFilme, _segundoFilme }
                    .OrderBy(f => f)
                    .First();
            }
            else
            {
                Vencedor = _primeiroFilme.PossuiNotaMaior(_segundoFilme)
                    ? _primeiroFilme
                    : _segundoFilme;

                Derrotado = _primeiroFilme.PossuiNotaMaior(_segundoFilme)
                    ? _segundoFilme
                    : _primeiroFilme;
            }
                
        }
    }
}
