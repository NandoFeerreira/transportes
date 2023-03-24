namespace TRANSPORTES.WEB.ViewModels
{
    public class MovimentacaoViewModel
    {
        public int? MovimentacaoId { get; set; }

        public string TipoMovimentacao { get; set; }

        public DateTime? DataHoraInicio { get; set; }

        public DateTime? DataHoraFim { get; set; }

        public int? ConteinerIdMovimentacao { get; set; }

    }
}
