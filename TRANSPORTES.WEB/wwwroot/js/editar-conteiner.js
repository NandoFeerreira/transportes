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

    $('button[type="submit"]').click(function (e) {
        
        var clienteNome = $('#cliente-nome').val();
        if (clienteNome === '') {
            alert('Selecione um cliente antes de editar o contêiner.');
            e.preventDefault();
            return false;
        }

       
        var nomeClienteAtualizado = $('#nome-cliente').val();
        var numeroConteiner = $('#conteiner-numero').val();
        var tipo = $('#tipo').val();
        var status = $('#status').val();
        var categoria = $('#categoria').val();
        if (nomeClienteAtualizado === '' || numeroConteiner === '' || tipo === '' || status === '' || categoria === '') {
            alert('Preencha todos os campos antes de editar o contêiner.');
            e.preventDefault();
            return false;
        }
    });

    
});

function validarExclusao() {
    var clienteNome = $('#cliente-nome').val();
    if (clienteNome === '') {
        alert('Selecione um cliente antes de excluir o contêiner.');
        return false;
    }

    return confirm('Tem certeza que deseja excluir este contêiner?');
}