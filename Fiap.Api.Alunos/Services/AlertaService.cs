using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public class AlertaService : IAlertaService
    {

        private readonly IAlertaRepository _repository;

        public AlertaService(IAlertaRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<AlertaModel> ListarAlertas() => _repository.GetAll();

        public AlertaModel ObterAlertasPorId(int id) => _repository.GetById(id);

        public void CriarAlerta(AlertaModel alerta) => _repository.Add(alerta);

        public void AtualizarAlerta(AlertaModel alerta) => _repository.Update(alerta);

        public void DeletarAlerta(int id)
        {
            var alerta = _repository.GetById(id);
            if (alerta != null)
            {
                _repository.Delete(alerta);
            }
        }

        public AlertaModel ObterAlertaPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
