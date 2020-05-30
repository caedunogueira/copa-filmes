
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
            if (!_primeiroFilme.PossuiNotaMaiorDoQue(_segundoFilme) && !_segundoFilme.PossuiNotaMaiorDoQue(_primeiroFilme))
            {
                Vencedor = new Filme[] { _primeiroFilme, _segundoFilme }.OrderBy(f => f)
                                                                        .First();
                return;
            }

            Vencedor = _primeiroFilme.PossuiNotaMaiorDoQue(_segundoFilme) ? _primeiroFilme : _segundoFilme;
        }
    }
}
