$(document).ready(function () {

    $('#select-cliente').on('change', () => {

        let clienteSelect = $('#select-cliente').val();

        let clienteSelecionado = model.find(cliente => cliente.clienteNome == clienteSelect);

        $('#input-conteiner-numero').val(clienteSelecionado.numeroConteiner);
        $('#input-conteiner-id').val(clienteSelecionado.conteinerId);
        $('#select-tipo').val(clienteSelecionado.tipo);
        $('#select-status').val(clienteSelecionado.status);
        $('#select-categoria').val(clienteSelecionado.categoria);
    });


    let $submitBtn = $('button[type="submit"]');
    $submitBtn.prop('disabled', true);

    
    let $selectTipoMovimentacao = $('#select-tipo-movimentacao');
    let $inputDataHoraInicio = $('#input-data-hora-inicio');
    let $inputDataHoraFim = $('#input-data-hora-fim');
    let $selectCliente = $('#select-cliente');

    $selectTipoMovimentacao.change(validateFields);
    $inputDataHoraInicio.change(validateFields);
    $inputDataHoraFim.change(validateFields);
    $selectCliente.change(validateFields);

    function validateFields() {
        
        if ($selectTipoMovimentacao.val() && $inputDataHoraInicio.val() && $inputDataHoraFim.val() && $selectCliente.val()) {
            $submitBtn.prop('disabled', false);
        } else {
            $submitBtn.prop('disabled', true);
        }
    }


    $('#btn-adicionar-movimentacao').click(function (e) {
        var dataHoraInicio = $('#input-data-hora-inicio').val();
        var dataHoraFim = $('#input-data-hora-fim').val();

        if (dataHoraInicio >= dataHoraFim) {
            e.preventDefault();
            alert('A data e hora de fim deve ser maior que a data e hora de início.');
        }
    });

});