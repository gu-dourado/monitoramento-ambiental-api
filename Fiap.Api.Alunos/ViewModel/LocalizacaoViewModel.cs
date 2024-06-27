namespace Fiap.Web.Alunos.ViewModel
{
    public class LocalizacaoViewModel
    {
        public int LocalizacaoId { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? Nome { get; set; }
        public int AlertaId { get; set; }
        public AlertaViewModel Alerta { get; set; }
    }
}
