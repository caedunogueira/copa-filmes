using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopaFilmes.WebAPI.Domain.Implementacoes;
using CopaFilmes.WebAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CopaFilmes.WebAPI.Controllers
{
    [ApiController]
    public class CopaMundoController : ControllerBase
    {
        private readonly ICatalogoFilmes _catalogoFilmes;

        public CopaMundoController(ICatalogoFilmes catalogoFilmes) => _catalogoFilmes = catalogoFilmes;

        [HttpGet]
        [Route("api/[controller]/jogar/{idsFilmesSelecionados}")]
        public async Task<ActionResult<CopaMundo>> Get(string idsFilmesSelecionados)
        {
            var copaMundo = new CopaMundo();
            var ids = idsFilmesSelecionados.Split(',').ToList();
            var filmes = await _catalogoFilmes.ObterPorIds(ids);

            foreach (var filme in filmes)
                copaMundo.Adicionar(filme);

            copaMundo.Jogar();
            
            return copaMundo;
        }
    }
}
