using System;
using System.Diagnostics.CodeAnalysis;

namespace CopaFilmes.WebAPI.Domain.Implementacoes
{
    public class Filme : IComparable<Filme>
    {
        readonly string _id, _titulo;
        readonly int _ano;
        readonly decimal _nota;

        public Filme(string id, string titulo, int ano, decimal nota)
        {
            _id = id;
            _titulo = titulo;
            _ano = ano;
            _nota = nota;
        }

        public int CompareTo([AllowNull] Filme other) => _titulo.CompareTo(other._titulo);

        public bool PossuiNotaMaiorDoQue(Filme outroFilme)
        {
            if (_nota <= outroFilme._nota)
                return false;

            return true;
        }
    }
}
