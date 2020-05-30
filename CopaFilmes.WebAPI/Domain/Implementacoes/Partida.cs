
using System.IO;

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
            Vencedor = _primeiroFilme.PossuiNotaMaiorDoQue(_segundoFilme) ? _primeiroFilme : _segundoFilme;
        }
    }
}
