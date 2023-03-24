using TRANSPORTES.WEB.Context;
using TRANSPORTES.WEB.Models.Entidades;
using TRANSPORTES.WEB.Repositories.Interfaces;

namespace TRANSPORTES.WEB.Repositories
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly AppDbContext _context;

        public MovimentacaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movimentacao> GetAllMovimentacoes()
        {
            return _context.Movimentacoes.ToList();
        }

        public Movimentacao GetMovimentacaoId(string tipoMovimentacao)
        {
            return _context.Movimentacoes.FirstOrDefault(c => c.Tipo == tipoMovimentacao);
        }

        public bool AddMovimentacao(Movimentacao movimentacao)
        {
            try
            {
                _context.Movimentacoes.Add(movimentacao);
                _context.SaveChanges();

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateMovimentacao(Movimentacao movimentacao)
        {
            try
            {
                var movimentacaoExistente = _context.Movimentacoes.FirstOrDefault(c => c.MovimentacaoId == movimentacao.MovimentacaoId);

                if (movimentacaoExistente != null)
                {
                    movimentacaoExistente.Tipo = movimentacao.Tipo;
                    movimentacaoExistente.DataAtualizacao = movimentacao.DataAtualizacao;
                    movimentacaoExistente.Ativo = movimentacao.Ativo;
                    movimentacaoExistente.DataHoraFim = movimentacao.DataHoraFim;
                    movimentacaoExistente.DataHoraInicio = movimentacao.DataHoraInicio;
                    movimentacaoExistente.ConteinerId = movimentacao.ConteinerId;

                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public bool DeleteMovimentacao(decimal movimentacaoId)
        {
            try
            {
                var movimentacao = _context.Movimentacoes.FirstOrDefault(c => c.MovimentacaoId == movimentacaoId);

                if (movimentacao != null)
                {
                    _context.Movimentacoes.Remove(movimentacao);
                    _context.SaveChanges();
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
