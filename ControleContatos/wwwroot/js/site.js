$('.close-alert').click(function () {
    $('.alert').hide('hide');
});

getDatatable('#myTableContatos');
getDatatable('#myTableUsuarios');

$(document).on('click', '.btn-total-contatos', function () {
    var usuarioId = $(this).data('usuario-id');

    $.ajax({
        type: 'GET',
        url: '/Usuario/ListarContatosPorUsuarioId?usuarioId=' + usuarioId,
        success: function (result) {
            $("#ListaContatosUsuario").html(result);
            getDatatable('#table-contatos-usuario');

            var modal = new bootstrap.Modal(
                document.getElementById('modalContatosUsuario')
            );
            modal.show();
        }
    });
});




function getDatatable(id) {
    new DataTable(id, {
        ordering: true,
        paging: true,
        searching: true,
        language: {
            emptyTable: "Nenhum registro encontrado na tabela",
            info: "Mostrar _START_ até _END_ de _TOTAL_ registros",
            infoEmpty: "Mostrar 0 até 0 de 0 Registros",
            infoFiltered: "(Filtrar de _MAX_ total registros)",
            thousands: ".",
            lengthMenu: "Mostrar _MENU_ registros por página",
            loadingRecords: "Carregando...",
            processing: "Processando...",
            zeroRecords: "Nenhum registro encontrado",
            search: "Pesquisar",
            paginate: {
                next: "Próximo",
                previous: "Anterior",
                first: "Primeiro",
                last: "Último"
            },
            aria: {
                sortAscending: ": Ordenar colunas de forma ascendente",
                sortDescending: ": Ordenar colunas de forma descendente"
            }
        }
    });
}