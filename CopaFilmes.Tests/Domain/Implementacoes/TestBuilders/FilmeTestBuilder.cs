using CopaFilmes.WebAPI.Domain.Implementacoes;

namespace CopaFilmes.Tests.Domain.Implementacoes.TestBuilders
{
    internal class FilmeTestBuilder
    {
        private string _id = "tt1245748";
        private string _titulo = "Filme A";
        private int _ano = 2020;
        private decimal _nota = 0.0m;

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
