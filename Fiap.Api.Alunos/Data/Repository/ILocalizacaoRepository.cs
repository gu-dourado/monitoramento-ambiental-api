using Fiap.Web.Alunos.Models;
using System.Collections.Generic;

namespace Fiap.Web.Alunos.Data.Repository
{
    public interface ILocalizacaoRepository
    {
        IEnumerable<LocalizacaoModel> GetAll();
        IEnumerable<LocalizacaoModel> GetAllWithDetails();
        LocalizacaoModel GetById(int id);
        LocalizacaoModel GetByIdWithDetails(int id);
        void Add(LocalizacaoModel localizacao);
        void Update(LocalizacaoModel localizacao);
        void Delete(LocalizacaoModel localizacao);
    }
}
