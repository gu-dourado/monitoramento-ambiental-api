﻿namespace Fiap.Web.Alunos.Models
{
    public class PedidoProdutoModel
    {

        public int PedidoId { get; set; }
        public LocalizacaoModel Pedido { get; set; }

        public int ProdutoId { get; set; }
        public ProdutoModel Produto { get; set; }

    }
}
