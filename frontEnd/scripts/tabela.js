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

        rows.sort(function (a, b) {
            const A = $(a).find(`td:eq(${column === 'name' ? 0 : 1})`).text();
            const B = $(b).find(`td:eq(${column === 'name' ? 0 : 1})`).text();

            return order === 'desc'
                ? A.localeCompare(B, undefined, { numeric: true })
                : B.localeCompare(A, undefined, { numeric: true });
        });

        $(this).data('order', order === 'desc' ? 'asc' : 'desc');
        $('#dataTable tbody').html(rows);
    });

    // Adicionar linha
    $('#addRow').on('click', function () {
        const newRow = `
            <tr>
                <td contenteditable="true">Novo Nome</td>
                <td contenteditable="true">0</td>
                <td><button class="delete">Excluir</button></td>
            </tr>`;
        $('#dataTable tbody').append(newRow);
    });

    // Excluir linha
    $('#dataTable').on('click', '.delete', function () {
        $(this).closest('tr').remove();
    });
});