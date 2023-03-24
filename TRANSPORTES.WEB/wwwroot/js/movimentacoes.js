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

});