namespace Fiap.Web.Alunos.Models
{
    public class LocalizacaoModel
    {
        public int LocalizacaoId { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? Nome { get; set; }

        
        // Relacionamento com Cliente
        public int AlertaId { get; set; }
        public AlertaModel Alerta { get; set; }

    }
}
