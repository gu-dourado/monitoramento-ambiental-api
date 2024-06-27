using Fiap.Web.Alunos.Data.Contexts;
using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;
using Microsoft.EntityFrameworkCore;

public class AlertaRepository : IAlertaRepository
{
    private readonly DatabaseContext _context;

    public AlertaRepository(DatabaseContext context)
    {
        _context = context;
    }

    public IEnumerable<AlertaModel> GetAll() => _context.Alertas.Include(c => c.Representante).ToList();

    public IEnumerable<AlertaModel> GetAll(int page, int size)
    {
        return _context.Alertas.Include(c => c.Representante)
                        .Skip( (page - 1) * page  )
                        .Take( size )
                        .AsNoTracking()
                        .ToList();  
    }

    public IEnumerable<AlertaModel> GetAllReference(int lastReference, int size)
    {
        var alertas = _context.Alertas.Include(_ => _.Representante)
                            .Where(c => c.AlertaId > lastReference)
                            .OrderBy( c => c.AlertaId) 
                            .Take(size)
                            .AsNoTracking()
                            .ToList();


        return alertas;
    }

    public AlertaModel GetById(int id) => _context.Alertas.Find(id);

    public void Add(AlertaModel alerta)
    {
        _context.Alertas.Add(alerta);
        _context.SaveChanges();
    }

    public void Update(AlertaModel alerta)
    {
        _context.Update(alerta);
        _context.SaveChanges();
    }

    public void Delete(AlertaModel alerta)
    {
        _context.Alertas.Remove(alerta);
        _context.SaveChanges();
    }

    
}