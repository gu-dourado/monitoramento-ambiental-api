using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.ViewModel;

namespace Fiap.Api.Alunos.ViewModel
{
    public class AlertaPaginacaoReferenciaViewModel
    {

        public IEnumerable<AlertaViewModel> Alertas { get; set; }
        public int PageSize { get; set; }
        public int Ref { get; set; }
        public int NextRef { get; set; }
        public string PreviousPageUrl => $"/Alerta?referencia={Ref}&tamanho={PageSize}";
        public string NextPageUrl => (Ref < NextRef) ? $"/Alerta?referencia={NextRef}&tamanho={PageSize}" : "";



    }
}
