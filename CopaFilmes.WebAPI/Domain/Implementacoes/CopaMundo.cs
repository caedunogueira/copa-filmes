using System.Collections.Generic;

namespace CopaFilmes.WebAPI.Domain.Implementacoes
{
    public class CopaMundo
    {
        List<Filme> _filmes;

        public Filme Campeao { get; private set; }

        public Filme ViceCampeao { get; private set; }

        public void AdicionarFilme(Filme filme)
        {
            _filmes ??= new List<Filme>();

            _filmes.Add(filme);
        }

        public void Jogar()
        {
            Campeao = _filmes[4];
            ViceCampeao = _filmes[0];
        }
    }
}
