using Fiap.Web.Alunos.ViewModel;
using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Fiap.Web.Alunos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        private readonly IMapper _mapper;

        public PedidoController(IPedidoService pedidoService, IMapper mapper)
        {
            _pedidoService = pedidoService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult Post([FromBody] CreatePedidoViewModel createPedidoViewModel)
        {
            var pedido = _mapper.Map<LocalizacaoModel>(createPedidoViewModel);

            try
            {
                _pedidoService.AdicionarPedido(pedido);
                return CreatedAtAction(nameof(GetPedidoById), new { id = pedido.LocalizacaoId }, createPedidoViewModel);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public ActionResult<PedidoViewModel> GetPedidoById(int id)
        {
            var pedido = _pedidoService.ObterPedidoPorIdComDetalhes(id);
            if (pedido == null)
            {
                return NotFound();
            }

            var pedidoViewModel = _mapper.Map<PedidoViewModel>(pedido);
            pedidoViewModel.Produtos = 
                    _mapper.Map<IEnumerable<ProdutoViewModel>>(
                        pedido.PedidoProdutos.Select(p => p.Produto).ToList()
                    );

            return Ok(pedidoViewModel);
        }
    }
}
