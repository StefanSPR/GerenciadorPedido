$(function () {
    let escopo = {
        campo: $('#inpDescricao'),
        botoes: {
            pesquisa: $('#btnPesquisar'),
        },
        tabela: $('#tablePesquisa')
    }
    $(document).ready(function () {


        escopo.botoes.pesquisa.on('click', function () {
            $.ajax({
                url: caminhoControler + '/GetPesquisar?descricao=' + escopo.campo.val(),
                method: 'GET',
                dataType: 'json',
                success: function (data) {
                    InicializarDataTable(data);
                },
                error: function (erro) {
                },
                complete: function () {

                }
            });
        })
    })

    function InicializarDataTable(data) {
        let elmTable = escopo.tabela;
        let table;
        let id = '#' + elmTable.attr('id');
        if ($.fn.dataTable.isDataTable(id)) {
            table = elmTable.DataTable();
            table.clear();
            table.rows.add(data).draw();
        } else {
            elmTable.DataTable({
                searching: true,
                paging: true,
                processing: false,
                serverSide: false,
                responsive: true,
                data: data,
                order: [[1, 'asc']],
                lengthMenu: [[10, 25, 50, 100, -1], [10, 25, 50, 100, "Todos"]],
                language: {
                    emptyTable: "Nenhuma foi encontrado nenhum cliente!"
                },
                columns: [
                    { data: 'nome', },
                    { data: 'email', },
                    { data: 'telefone', },
                    { data: 'dataCadastroDesc', },
                    {
                        data: '', render: function (data, type, row) {
                            return `<a href="${caminhoControler}/Edit/${row.id}" class="btn btn-sm btn-outline-primary me-1">
                                        <i class="fas fa-edit"></i>
                                    </a>
                                    <button class="btn btn-sm btn-outline-danger" title="Excluir"
                                       onclick="javascript:Apagar(${row.id})">
                                        <i class="fas fa-trash"></i>
                                    </button>
                                    `;
                        },
                    },
                ],

            })
        }
    }
    
})

function Apagar(id) {
    $.ajax({
        url: caminhoControler + '/Delete/' + id,
        method: 'DELETE',
        dataType: 'json',
        success: function () {
            escopo.botoes.pesquisa.click();
        },
        error: function (err) {
        },
        complete: function () {

        }
    });

}