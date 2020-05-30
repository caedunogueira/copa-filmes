
using CopaFilmes.WebAPI.Domain.Implementacoes;

namespace CopaFilmes.Tests.Domain.Implementacoes.TestBuilders
{
    internal class FilmeTestBuilder
    {
        string _id = "tt1245748";
        string _titulo = "Filme A";
        int _ano = 2020;
        decimal _nota = 0.0m;

        internal Filme Build() => new Filme(_id, _titulo, _ano, _nota);

        internal FilmeTestBuilder ComNota(decimal nota)
        {
            _nota = nota;

            return this;
        }

        internal FilmeTestBuilder ComTitulo(string titulo)
        {
            _titulo = titulo;

            return this;
        }
    }
}
