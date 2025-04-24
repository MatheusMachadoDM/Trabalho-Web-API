$(document).ready(function () {
    // Filtro
    $('#filter').on('keyup', function () {
        const value = $(this).val().toLowerCase();
        $('#dataTable tbody tr').filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
        });
    });

    // Ordenação
    $('th').on('click', function () {
        const column = $(this).data('column');
        const order = $(this).data('order');
        const rows = $('#dataTable tbody tr').toArray();
        let columnIndex;

        if (column === 'id') {
            columnIndex = 0;
        } else if (column === 'nome') {
            columnIndex = 1;
        } else if (column === 'idade') {
            columnIndex = 2;
        }

        if (columnIndex !== undefined) {
            rows.sort(function (a, b) {
                const A = $(a).find(`td:eq(${columnIndex})`).text();
                const B = $(b).find(`td:eq(${columnIndex})`).text();

                return order === 'desc'
                    ? A.localeCompare(B, undefined, { numeric: true })
                    : B.localeCompare(A, undefined, { numeric: true });
            });

            $(this).data('order', order === 'desc' ? 'asc' : 'desc');
            $('#dataTable tbody').html(rows);
        }
    });

    // A LÓGICA DE ADICIONAR LINHA LOCAL FOI REMOVIDA

    // A LÓGICA DE EXCLUIR LINHA LOCAL FOI REMOVIDA
});