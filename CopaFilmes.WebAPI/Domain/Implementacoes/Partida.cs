
using System.IO;
using System.Linq;

namespace CopaFilmes.WebAPI.Domain.Implementacoes
{
    internal class Partida
    {
        readonly Filme _primeiroFilme, _segundoFilme;

        internal Filme Vencedor { get; private set; }

        internal Partida(Filme primeiroFilme, Filme segundoFilme)
        {
            _primeiroFilme = primeiroFilme;
            _segundoFilme = segundoFilme;
        }

        internal void Disputar()
        {
            if (!_primeiroFilme.PossuiNotaMaior(_segundoFilme) && !_segundoFilme.PossuiNotaMaior(_primeiroFilme))
            {
                Vencedor = new Filme[] { _primeiroFilme, _segundoFilme }.OrderBy(f => f)
                                                                        .First();
                return;
            }

            Vencedor = _primeiroFilme.PossuiNotaMaior(_segundoFilme) ? _primeiroFilme : _segundoFilme;
        }
    }
}
