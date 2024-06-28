using Fiap.Web.Alunos.Data.Contexts;
using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Data.Repository
{
    public class AlertaRepository : IAlertaRepository
    {

        private readonly DatabaseContext _context;

        public AlertaRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<AlertaModel> GetAll() => _context.Alertas.ToList();

        public AlertaModel GetById(int id) => _context.Alertas.Find(id);

        public void Add(AlertaModel alerta)
        {
            _context.Alertas.Add(alerta);
            _context.SaveChanges();
        }

        public void Update(AlertaModel alerta)
        {
            _context.Alertas.Update(alerta);
            _context.SaveChanges();
        }

        public void Delete(AlertaModel alerta)
        {
            _context.Alertas.Remove(alerta);
            _context.SaveChanges();
        }
    }
}
