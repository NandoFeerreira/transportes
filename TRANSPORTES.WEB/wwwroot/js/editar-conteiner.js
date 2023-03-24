$(document).ready(function () {

    $('#cliente-nome').on('change', () => {

        let clienteSelect = $('#cliente-nome').val();

        let clienteSelecionado = model.find(cliente => cliente.clienteNome == clienteSelect);        

        $('#conteiner-numero').val(clienteSelecionado.numeroConteiner);
        $('#id-cliente').val(clienteSelecionado.clienteId);
        $('#id-conteiner').val(clienteSelecionado.conteinerId);
        $('#nome-cliente').val(clienteSelecionado.clienteNome);
        $('#tipo').val(clienteSelecionado.tipo);
        $('#status').val(clienteSelecionado.status);
        $('#categoria').val(clienteSelecionado.categoria);
    });
});