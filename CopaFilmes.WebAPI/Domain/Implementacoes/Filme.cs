using System;
using System.Diagnostics.CodeAnalysis;

namespace CopaFilmes.WebAPI.Domain.Implementacoes
{
    public class Filme : IComparable<Filme>
    {
        private readonly string _id, _titulo;
        private readonly int _ano;
        private readonly decimal _nota;

        public Filme(string id, string titulo, int ano, decimal nota)
        {
            _id = id;
            _titulo = titulo;
            _ano = ano;
            _nota = nota;
        }

        public int CompareTo([AllowNull] Filme other) => _titulo.CompareTo(other._titulo);

        public bool PossuiNotaMaior(Filme outroFilme) => _nota > outroFilme._nota;

        public bool PossuiNotaIgual(Filme outroFilme) => _nota == outroFilme._nota;
    }
}
