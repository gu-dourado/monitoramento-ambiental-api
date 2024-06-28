using Fiap.Web.Alunos.ViewModel;
using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace Fiap.Web.Alunos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AlertaController : ControllerBase
    {
        private readonly IAlertaService _service;
        private readonly IMapper _mapper;

        public AlertaController(IAlertaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "operador,analista,gerente")]
        public ActionResult<IEnumerable<AlertaViewModel>> Get()
        {
            var alertas = _service.ListarAlertas();
            var viewModelList = _mapper.Map<IEnumerable<AlertaViewModel>>(alertas);
            return Ok(viewModelList);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "operador,analista,gerente")]
        public ActionResult<AlertaViewModel> Get(int id)
        {
            var alerta = _service.ObterAlertaPorId(id);
            if (alerta == null)
                return NotFound();

            var viewModel = _mapper.Map<AlertaViewModel>(alerta);
            return Ok(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "gerente,analista")]
        public ActionResult Post([FromBody] AlertaViewModel viewModel)
        {
            var alerta = _mapper.Map<AlertaModel > (viewModel);
            _service.CriarAlerta(alerta);
            return CreatedAtAction(nameof(Get), new { id = alerta.AlertaId }, viewModel);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Put(int id, [FromBody] AlertaViewModel viewModel)
        {
            var alertaExistente = _service.ObterAlertaPorId(id);
            if (alertaExistente == null)
                return NotFound();

            _mapper.Map(viewModel, alertaExistente);
            _service.AtualizarAlerta(alertaExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Delete(int id)
        {
            _service.DeletarAlerta(id);
            return NoContent();
        }
    }
}
