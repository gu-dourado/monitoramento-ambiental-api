namespace Fiap.Web.Alunos.Data.Repository
{
    using Fiap.Web.Alunos.Data.Contexts;
    using Fiap.Web.Alunos.Data.Repository;
    using Fiap.Web.Alunos.Models;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;

    public class LocalizacaoRepository : ILocalizacaoRepository
    {
        private readonly DatabaseContext _context;

        public LocalizacaoRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<LocalizacaoModel> GetAll()
        {
            return _context.Localizacoes
                .ToList();
        }

        // Método para obter todos os pedidos com detalhes completos
        public IEnumerable<LocalizacaoModel> GetAllWithDetails()
        {
            return _context.Localizacoes
                
                .ToList();
        }

        public LocalizacaoModel GetById(int id)
        {
            return _context.Localizacoes.Find(id);
        }

        public LocalizacaoModel GetByIdWithDetails(int id)
        {
            return _context.Localizacoes
                .Where(p => p.LocalizacaoId == id)
                .FirstOrDefault();
        }

        public void Add(LocalizacaoModel localizacao)
        {
            _context.Localizacoes.Add(localizacao);
            _context.SaveChanges();
        }

        public void Update(LocalizacaoModel localizacao)
        {
            _context.Update(localizacao);
            _context.SaveChanges();
        }

        public void Delete(LocalizacaoModel localizacao)
        {
            _context.Localizacoes.Remove(localizacao);
            _context.SaveChanges();
        }
    }

}
