using Fiap.Web.Alunos.ViewModel;
using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Fiap.Api.Alunos.ViewModel;
using Asp.Versioning;

namespace Fiap.Web.Alunos.Controllers
{
    [ApiVersion(1, Deprecated = true)]
    [ApiVersion(2)]
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class AlertaController : ControllerBase
    {
        private readonly IAlertaService _service;
        private readonly IMapper _mapper;

        public AlertaController(IAlertaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [MapToApiVersion(1)]
        [HttpGet]
        public ActionResult<IEnumerable<AlertaViewModel>> Get()
        {
            var alertas = _service.ListarAlertas();
            var viewModelList = _mapper.Map<IEnumerable<AlertaViewModel>>(alertas);
            return Ok(viewModelList);
        }


        [MapToApiVersion(2)]
        [HttpGet]
        public ActionResult<IEnumerable<AlertaPaginacaoViewModel>> Get([FromQuery] int pagina = 1, [FromQuery] int tamanho = 10)
        {
            var alertas = _service.ListarAlertas(pagina, tamanho);
            var viewModelList = _mapper.Map<IEnumerable<AlertaViewModel>>(alertas);

            var viewModel = new AlertaPaginacaoViewModel
            {
                Alertas = viewModelList,
                CurrentPage = pagina,
                PageSize = tamanho
            };


            return Ok(viewModel);
        }


        //[HttpGet]
        //public ActionResult<IEnumerable<ClientePaginacaoReferenciaViewModel>> Get([FromQuery] int referencia = 0, [FromQuery] int tamanho = 10)
        //{
        //    var clientes = _service.ListarClientesUltimaReferencia(referencia, tamanho);
        //    var viewModelList = _mapper.Map<IEnumerable<ClienteViewModel>>(clientes);

        //    var viewModel = new ClientePaginacaoReferenciaViewModel
        //    {
        //        Clientes = viewModelList,
        //        PageSize = tamanho,
        //        Ref = referencia,
        //        NextRef = viewModelList.Last().ClienteId
        //    };


        //    return Ok(viewModel);
        //}

        [MapToApiVersion(2)]
        [HttpGet("{id}")]
        public ActionResult<AlertaViewModel> Get(int id)
        {
            var alerta = _service.ObterAlertaPorId(id);
            if (alerta == null)
                return NotFound();

            var viewModel = _mapper.Map<AlertaViewModel>(alerta);
            return Ok(viewModel);
        }

        [MapToApiVersion(1)]
        [MapToApiVersion(2)]
        [HttpPost]
        public ActionResult Post([FromBody] AlertaCreateViewModel viewModel)
        {
            var alerta = _mapper.Map<AlertaModel>(viewModel);
            _service.CriarAlerta(alerta);
            return CreatedAtAction(nameof(Get), new { id = alerta.AlertaId }, alerta);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] AlertaUpdateViewModel viewModel)
        {
            var alertaExistente = _service.ObterAlertaPorId(id);
            if (alertaExistente == null)
                return NotFound();

            _mapper.Map(viewModel, alertaExistente);
            _service.AtualizarAlerta(alertaExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.DeletarAlerta(id);
            return NoContent();
        }
    }
}