﻿namespace Fiap.Web.Alunos.ViewModel
{
    public class AlertaViewModel
    {
        public int AlertaId { get; set; }
        public string? Localizacao { get; set; }
        public string? Status { get; set; }
        public string? TipoDesastre { get; set; }
        public DateTime DataHora { get; set; }
        public string? Gravidade { get; set; }
        public int RepresentanteId { get; set; }
        public RepresentanteViewModel Representante { get; set; }
    }
}
