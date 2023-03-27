const config = {
    language: "../lib/jquery-datatable/v1.13.1/json/portugues-brasil.json",
    resultadoPorPagina: 10,
    entrada: [5, 10, 15, 20, 25],
    table: {
        simple_datatable: $('#movimentacoes-table')
    }
};


$(document).ready(function () {
    let width = $(window).width();
    config.table.simple_datatable.DataTable({
        responsive: {
            details: {
                renderer: function (api, rowIdx, columns) {
                    const data = $.map(columns, function (col, i) {
                        return col.hidden ?
                            '<div data-dt-row="' + col.rowIndex + '" data-dt-column="' + col.columnIndex + '">' +
                            '<span class="fw-bold">' + col.title + ':' + '</span> ' + '<span class="mx-2">' + col.data +
                            '</span>' + '</div>' : '';
                    }).join('');
                    return data ? $('<div/>').append(data) : false;
                }
            }
        },
        language: {
            url: config.language
        },
        processing: false,
        searching: false,
        pageLength: config.resultadoPorPagina,
        lengthMenu: config.entrada,
        ordering: false,
        lengthChange: false,
        autoWidth: true,
        paging: true,
        info: (width <= 1024) ? false : true,
        serverSide: false,
        destroy: true,
    });

    $('body').on('click', '.fa-info-circle', function () {
        let conteinerId = $(this).data('container-id');

        let conteinerSelecionados = model.filter(conteiner => conteiner.movimentacoes.some(mov => mov.conteinerIdMovimentacao == conteinerId));

        let movimentacoes = conteinerSelecionados[0].movimentacoes.filter(mov => mov.conteinerIdMovimentacao === conteinerId);
        let tbody = $('#movimentacoesTableBody');

        tbody.empty();

        movimentacoes.forEach(m => {
            let tr = $('<tr>');
            tr.append($('<td>').addClass('text-center').text(m.tipoMovimentacao));
            tr.append($('<td>').addClass('text-center').text(new Date(m.dataHoraInicio).toLocaleString('pt-BR').split(',')[0]));
            tr.append($('<td>').addClass('text-center').text(new Date(m.dataHoraInicio).toLocaleString('pt-BR').split(',')[1]));
            tbody.append(tr);
        });

        $('#movimentacoesModal').modal('show');
    });

    

    $('#cliente, #tipo').on('change', function () {
        var clienteSelecionado = $('#cliente').val();
        var tipoSelecionado = $('#tipo').val();

        $('#movimentacoes-table tbody tr').each(function () {
            var conteinerId = $(this).data('container-id');
            var movimentacoes = $(this).find('[data-movimentacao]');
            var mostrarLinha = false;

            if ((clienteSelecionado === '' || $(this).hasClass(clienteSelecionado)) &&
                (tipoSelecionado === '' || movimentacoes.filter('[data-movimentacao="' + tipoSelecionado + '"]').length > 0)) {
                mostrarLinha = true;
            }

            $(this).toggle(mostrarLinha);
        });
    });

});



