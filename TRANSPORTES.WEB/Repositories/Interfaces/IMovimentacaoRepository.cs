using TRANSPORTES.WEB.Models.Entidades;

namespace TRANSPORTES.WEB.Repositories.Interfaces;

public interface IMovimentacaoRepository
{
    IEnumerable<Movimentacao> GetAllMovimentacoes();

    Movimentacao GetMovimentacaoId(string tipoMovimentacao);

    bool AddMovimentacao(Movimentacao movimentacao);

    bool UpdateMovimentacao(Movimentacao movimentacao);

    bool DeleteMovimentacao(decimal movimentacaoId);
}
