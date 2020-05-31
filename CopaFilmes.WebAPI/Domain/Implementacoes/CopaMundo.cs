using System.Collections.Generic;

namespace CopaFilmes.WebAPI.Domain.Implementacoes
{
    public class CopaMundo
    {
        Eliminatorias _eliminatorias;
        List<Filme> _filmes;

        public Filme Campeao => _eliminatorias.Campeao;

        public Filme ViceCampeao => _eliminatorias.ViceCampeao;

        public void AdicionarFilme(Filme filme)
        {
            _filmes ??= new List<Filme>();

            _filmes.Add(filme);
        }

        public void Jogar()
        {
            _eliminatorias = new Eliminatorias(_filmes);

            _eliminatorias.MontarChaveamento();
            _eliminatorias.Jogar();
        }
    }
}
