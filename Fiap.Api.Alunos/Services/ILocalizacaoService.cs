using Fiap.Web.Alunos.Models;

namespace Fiap.Web.Alunos.Services
{
    public interface ILocalizacaoService
    {
        IEnumerable<LocalizacaoModel> ObterTodasLocalizacoes();
        IEnumerable<LocalizacaoModel> ObterTodasLocalizacoesComDetalhes();
        LocalizacaoModel ObterLocalizacaoPorId(int id);
        LocalizacaoModel ObterLocalizacaoPorIdComDetalhes(int id);
        void AdicionarLocalizacao(LocalizacaoModel localizacao);
        void AtualizarLocalizacao(LocalizacaoModel localizacao);
        void DeletarLocalizacao(LocalizacaoModel localizacao);
    }
}
