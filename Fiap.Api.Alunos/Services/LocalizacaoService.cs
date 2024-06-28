using Fiap.Web.Alunos.Data.Repository;
using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public class LocalizacaoService : ILocalizacaoService
    {
        private readonly ILocalizacaoRepository _localizacaoRepository;

        public LocalizacaoService(ILocalizacaoRepository localizacaoRepository)
        {
            _localizacaoRepository = localizacaoRepository;
        }

        public IEnumerable<LocalizacaoModel> ObterTodasLocalizacoes()
        {
            return _localizacaoRepository.GetAll();
        }

        public IEnumerable<LocalizacaoModel> ObterTodasLocalizacoesComDetalhes()
        {
            return _localizacaoRepository.GetAllWithDetails();
        }

        public LocalizacaoModel ObterLocalizacaoPorId(int id)
        {
            return _localizacaoRepository.GetById(id);
        }

        public LocalizacaoModel ObterLocalizacaoPorIdComDetalhes(int id)
        {
            return _localizacaoRepository.GetByIdWithDetails(id);
        }

        public void AdicionarLocalizacao(LocalizacaoModel localizacao)
        {
            
            _localizacaoRepository.Add(localizacao);
        }

        public void AtualizarLocalizacao(LocalizacaoModel localizacao)
        {
            _localizacaoRepository.Update(localizacao);
        }

        public void DeletarLocalizacao(LocalizacaoModel localizacao)
        {
            _localizacaoRepository.Delete(localizacao);
        }
    }
}
