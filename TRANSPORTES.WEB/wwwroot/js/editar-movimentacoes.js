$(document).ready(function () {

    $('#select-cliente').on('change', () => {

        let clienteSelect = $('#select-cliente').val();

        let clienteSelecionado = model.find(cliente => cliente.clienteNome == clienteSelect);

        let conteinerSelecionados = model.filter(conteiner => conteiner.movimentacoes.some(mov => mov.conteinerIdMovimentacao == clienteSelecionado.conteinerId));

        $('#input-conteiner-numero').val(clienteSelecionado.numeroConteiner);
        $('#input-conteiner-id').val(clienteSelecionado.conteinerId);
        $('#select-tipo').val(clienteSelecionado.tipo);
        $('#select-status').val(clienteSelecionado.status);
        $('#select-categoria').val(clienteSelecionado.categoria);

        let tiposMovimentacoes = [...new Set(conteinerSelecionados.flatMap(conteiner => conteiner.movimentacoes.map(mov => mov.tipoMovimentacao)))];

        var select = $('#select-tipo-movimentacao2');

        select.empty();

        select.append($('<option>', {
            value: '',
            text: 'Selecione'
        }));

        $.each(tiposMovimentacoes, function (i, tipoMovimentacao) {
            var option = $('<option>', {
                value: tipoMovimentacao,
                text: tipoMovimentacao
            });
            select.append(option);
        });
    });


    $('#select-tipo-movimentacao2').on('change', () => {

        let clienteSelect = $('#select-cliente').val();

        let tipoMovimentacaoSelect = $('#select-tipo-movimentacao2').val();

        if (tipoMovimentacaoSelect != "") {

            let clienteSelecionado = model.find(cliente => cliente.clienteNome == clienteSelect);

            let conteinerSelecionados = model.filter(conteiner => conteiner.movimentacoes.some(mov => mov.conteinerIdMovimentacao == clienteSelecionado.conteinerId));

            let conteinerSelecionado = conteinerSelecionados.find(conteiner => conteiner.movimentacoes.some(mov => mov.tipoMovimentacao === tipoMovimentacaoSelect));

            $('#select-tipo-movimentacao').val(conteinerSelecionado.movimentacoes.find(mov => mov.tipoMovimentacao === tipoMovimentacaoSelect).tipoMovimentacao)
            $('#input-data-hora-inicio').val(conteinerSelecionado.movimentacoes.find(mov => mov.tipoMovimentacao === tipoMovimentacaoSelect).dataHoraInicio);
            $('#input-data-hora-fim').val(conteinerSelecionado.movimentacoes.find(mov => mov.tipoMovimentacao === tipoMovimentacaoSelect).dataHoraFim);
        } else {

            $('#select-tipo-movimentacao').val("");
            $('#input-data-hora-inicio').val("");
            $('#input-data-hora-fim').val("");
        }

    });


    $('#btn-editar-movimentacao').click(function (e) {
        var dataHoraInicio = $('#input-data-hora-inicio').val();
        var dataHoraFim = $('#input-data-hora-fim').val();

        if (dataHoraInicio >= dataHoraFim) {
            e.preventDefault();
            alert('A data e hora de fim deve ser maior que a data e hora de início.');
        }
    });

    $('#btn-excluir-movimentacao').prop('disabled', true);

    $('input, select').on('change', function () {
        var empty = false;
        $('input, select').each(function () {
            if ($(this).val() == '') {
                empty = true;
            }
        });
        if (empty) {
            $('#btn-excluir-movimentacao').prop('disabled', true);
        } else {
            $('#btn-excluir-movimentacao').prop('disabled', false);
        }
    });

});