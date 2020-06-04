using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.WebAPI.Domain.Implementacoes
{
    public class CopaMundo
    {
        private bool _jogou;
        private List<Filme> _filmes;
        private Eliminatorias _eliminatorias;

        internal IReadOnlyCollection<Filme> Filmes => _filmes;

        public Filme Campeao 
        { 
            get 
            {
                if (!_jogou)
                    throw new InvalidOperationException("O campeão somente estará disponível quando a copa do mundo for jogada.");

                return _eliminatorias.Campeao; 
            } 
        }

        public Filme ViceCampeao 
        { 
            get 
            {
                if (!_jogou)
                    throw new InvalidOperationException("O vice-campeão somente estará disponível quando a copa do mundo for jogada.");

                return _eliminatorias.ViceCampeao; 
            } 
        }

        public CopaMundo() => _jogou = false;

        public void Adicionar(Filme filme)
        {
            _filmes ??= new List<Filme>();

            if (_filmes.Count == 8)
                throw new InvalidOperationException("Não é possível adicionar um novo filme pois a quantidade de filmes selecionados para jogar a copa já foi atingida.");

            _filmes.Add(filme);
        }

        public void OrdenarFilmes() => _filmes = _filmes.OrderBy(f => f).ToList();

        public void Jogar()
        {
            _jogou = false;

            if (_filmes?.Count != 8)
                throw new InvalidOperationException("É necessário conter 8 filmes selecionados para disputar a Copa do Mundo porém a quantidade de filmes " +
                                                    $"identificados para seleção foi {_filmes?.Count}");

            _eliminatorias = new Eliminatorias(this);
            
            _eliminatorias.MontarChaveamento();
            _eliminatorias.Jogar();

            _jogou = true;
        }
    }
}
