using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.ViewModel
{
    public class AlertaCreateViewModel
    {

        public string? Localizacao { get; set; }
        public string? Status { get; set; }
        public string? TipoDesastre { get; set; }
        public DateTime DataHora { get; set; }
        public string? Gravidade { get; set; }
        public int RepresentanteId { get; set; }

    }
}
