namespace Fiap.Web.Alunos.Models
{
    public class AlertaModel
     {
        public int AlertaId { get; set; }
        public string? Local { get; set; }
        public string? Status { get; set; }
        public string? TipoDesastre { get; set; }
        public DateTime DataHora { get; set; }
        public string? Gravidade { get; set; }
        

    }
}
