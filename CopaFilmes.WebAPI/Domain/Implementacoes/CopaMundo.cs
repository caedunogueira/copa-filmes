using System;
using System.Collections.Generic;
using System.Linq;

namespace CopaFilmes.WebAPI.Domain.Implementacoes
{
    public class CopaMundo
    {
        public const int TOTAL_FILMES_OBRIGATORIO = 8;

        private bool _jogou;
        private List<Filme> _filmes;
        private Eliminatorias _eliminatorias;

        internal IReadOnlyCollection<Filme> Filmes => _filmes;

        public Filme Campeao 
        {
            get
            {
                if (!_jogou)
                    throw new InvalidOperationException("Operação inválida. O campeão somente estará disponível quando a copa do mundo for jogada.");

                return _eliminatorias.Campeao;
            } 
        }

        public Filme ViceCampeao
        {
            get
            {
                if (!_jogou)
                    throw new InvalidOperationException("Operação inválida. O vice-campeão somente estará disponível quando a copa do mundo for jogada.");

                return _eliminatorias.ViceCampeao;
            } 
        }

        public CopaMundo() => _jogou = false;

        public void Adicionar(Filme filme)
        {
            _filmes ??= new List<Filme>();

            if (_filmes.Count == TOTAL_FILMES_OBRIGATORIO)
                throw new InvalidOperationException("Operação inválida. Somente é possível adicionar até 8 filmes para etapa de seleção da copa do mundo.");

            _filmes.Add(filme);
        }

        public void OrdenarFilmes() => _filmes = _filmes.OrderBy(f => f).ToList();

        public void Jogar()
        {
            _jogou = false;

            if (_filmes?.Count != TOTAL_FILMES_OBRIGATORIO)
                throw new InvalidOperationException("Operação inválida. É necessário adicionar 8 filmes para jogar a copa do mundo.");

            _eliminatorias = new Eliminatorias(this);
            _eliminatorias.MontarChaveamento();
            _eliminatorias.Jogar();

            _jogou = true;
        }
    }
}