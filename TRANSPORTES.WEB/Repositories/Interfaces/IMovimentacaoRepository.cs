using TRANSPORTES.WEB.Models.Entidades;

namespace TRANSPORTES.WEB.Repositories.Interfaces;

public interface IMovimentacaoRepository
{
    IEnumerable<Movimentacao> GetAllMovimentacoes();

    Movimentacao GetMovimentacaoId(decimal movimentacaoId);

    bool AddMovimentacao(Movimentacao movimentacao);

    bool UpdateMovimentacao(Movimentacao movimentacao);

    bool DeleteMovimentacao(decimal movimentacaoId);
}
