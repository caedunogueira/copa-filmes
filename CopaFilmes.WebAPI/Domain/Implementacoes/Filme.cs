using System;
using System.Diagnostics.CodeAnalysis;

namespace CopaFilmes.WebAPI.Domain.Implementacoes
{
    public class Filme : IComparable<Filme>
    {
        private readonly decimal _nota;

        public string Id { get; private set; }

        public string Titulo { get; private set; }

        public int Ano { get; private set; }

        public Filme(string id, string titulo, int ano, decimal nota)
        {
            _nota = nota;

            Id = id;
            Titulo = titulo;
            Ano = ano;
        }

        public int CompareTo([AllowNull] Filme other) => Titulo.CompareTo(other.Titulo);

        internal bool PossuiNotaMaior(Filme outroFilme)
        {
            if (outroFilme == null)
                throw new ArgumentNullException(nameof(outroFilme), "Argumento inválido. Deve-se fornecer uma instância da classe Filme.");

            return _nota > outroFilme._nota;
        }

        internal bool PossuiNotaIgual(Filme outroFilme)
        {
            if (outroFilme == null)
                throw new ArgumentNullException(nameof(outroFilme), "Argumento inválido. Deve-se fornecer uma instância da classe Filme.");

            return _nota == outroFilme._nota;
        }
    }
}
