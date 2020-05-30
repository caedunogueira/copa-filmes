
using System;

namespace CopaFilmes.WebAPI.Domain.Implementacoes
{
    public class Filme
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

        public bool PossuiMaiorNota(Filme outroFilme)
        {
            return true;
        }
    }
}
