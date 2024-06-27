using Fiap.Web.Alunos.ViewModel;
using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Fiap.Web.Alunos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocalizacaoController : ControllerBase
    {
        private readonly ILocalizacaoService _localizacaoService;

        private readonly IMapper _mapper;

        public LocalizacaoController(ILocalizacaoService localizacaoService, IMapper mapper)
        {
            _localizacaoService = localizacaoService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult Post([FromBody] LocalizacaoCreateViewModel localizacaoCreateViewModel)
        {
            var localizacao = _mapper.Map<LocalizacaoModel>(localizacaoCreateViewModel);

            try
            {
                _localizacaoService.AdicionarLocalizacao(localizacao);
                return CreatedAtAction(nameof(GetLocalizacaoById), new { id = localizacao.LocalizacaoId }, localizacaoCreateViewModel);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public ActionResult<LocalizacaoViewModel> GetLocalizacaoById(int id)
        {
            var localizacao = _localizacaoService.ObterLocalizacaoPorIdComDetalhes(id);
            if (localizacao == null)
            {
                return NotFound();
            }

            var localizacaoViewModel = _mapper.Map<LocalizacaoViewModel>(localizacao);

            return Ok(localizacaoViewModel);
        }
    }
}
