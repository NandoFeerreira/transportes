using System.Globalization;

namespace TRANSPORTES.WEB.ViewModels
{
    public class TransportesViewModel
    {

        public string ClienteNome { get; set; }

        public string NomeClienteAtualiado { get; set; }

        public string NumeroConteiner { get; set; }

        public decimal Tipo { get; set; }

        public string Status { get; set; }

        public string Categoria { get ; set; }  

        public decimal? ClienteId { get; set; }

        public decimal? ConteinerId { get; set; }

        public bool? Ativo {  get; set; }        

        public int? MovimentacaoId { get; set; }

        public string MovimentacaoTipo { get; set; }
        public List<MovimentacaoViewModel> Movimentacoes { get; set; }
        public MovimentacaoViewModel Movimentacao { get; set; }

        public string Mensagem { get; set; }

    }
}
