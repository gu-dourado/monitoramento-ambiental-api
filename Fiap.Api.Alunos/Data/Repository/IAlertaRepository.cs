using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Data.Repository
{
    public interface IAlertaRepository
    {
        IEnumerable<AlertaModel> GetAll();

        AlertaModel GetById(int id);
        void Add(AlertaModel alerta);
        void Update(AlertaModel alerta);
        void Delete(AlertaModel alerta);
    }
}
