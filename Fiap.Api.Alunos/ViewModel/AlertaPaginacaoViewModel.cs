using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.ViewModel;

namespace Fiap.Api.Alunos.ViewModel
{
    public class AlertaPaginacaoViewModel
    {

        public IEnumerable<AlertaViewModel> Alertas { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => Alertas.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/Alerta?pagina={CurrentPage - 1}&tamanho={PageSize}" : "";
        public string NextPageUrl => HasNextPage ? $"/Alerta?pagina={CurrentPage + 1}&tamanho={PageSize}" : "";



    }
}
