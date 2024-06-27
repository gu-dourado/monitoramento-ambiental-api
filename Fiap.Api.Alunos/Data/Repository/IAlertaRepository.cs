using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Data.Repository
{
    public interface IAlertaRepository
    {
        IEnumerable<AlertaModel> GetAll();

        IEnumerable<AlertaModel> GetAll(int page, int size);

        IEnumerable<AlertaModel> GetAllReference(int lastReference, int size);

        AlertaModel GetById(int id);
        void Add(AlertaModel alerta);
        void Update(AlertaModel alerta);
        void Delete(AlertaModel alerta);
    }
}
