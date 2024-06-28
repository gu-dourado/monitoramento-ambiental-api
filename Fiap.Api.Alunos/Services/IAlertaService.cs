using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public interface IAlertaService
    {
        IEnumerable<AlertaModel> ListarAlertas();
        AlertaModel ObterAlertaPorId(int id);
        void CriarAlerta(AlertaModel alerta);
        void AtualizarAlerta(AlertaModel alerta);
        void DeletarAlerta(int id);

    }
}
