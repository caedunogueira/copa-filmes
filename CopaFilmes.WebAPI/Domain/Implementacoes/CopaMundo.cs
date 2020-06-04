using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.WebAPI.Domain.Implementacoes
{
    public class CopaMundo
    {
        List<Filme> _filmes;
        Eliminatorias _eliminatorias;

        internal IReadOnlyCollection<Filme> Filmes => _filmes;

        public Filme Campeao => _eliminatorias.Campeao;

        public Filme ViceCampeao => _eliminatorias.ViceCampeao;

        public void Adicionar(Filme filme)
        {
            _filmes ??= new List<Filme>();

            _filmes.Add(filme);
        }

        public void OrdenarFilmes() => _filmes = _filmes.OrderBy(f => f).ToList();

        public void Jogar()
        {
            if (_filmes?.Count != 8)
                throw new InvalidOperationException("É necessário conter 8 filmes selecionados para disputar a Copa do Mundo porém a quantidade de filmes " +
                                                    $"identificados para seleção foi {_filmes?.Count}");

            _eliminatorias = new Eliminatorias(this);
            
            _eliminatorias.MontarChaveamento();
            _eliminatorias.Jogar();
        }
    }
}
