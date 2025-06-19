let escopo = {
    campos: {
        status: $('#dropStatus'),
        cliente: $('#ClienteAutoComplete'),
    },
    botoes: {
        pesquisa: $('#btnPesquisar'),
    },
    tabela: $('#tablePesquisa')
}
$(function () {
    $(document).ready(function () {
        escopo.botoes.pesquisa.on('click', function () {
            Pesquisar();
        })
    })

})
function Pesquisar() {
    let filtro = MontarFiltro();
    $.ajax({
        url: caminhoControler + '/GetPesquisar',
        method: 'GET',
        dataType: 'json',
        data: filtro,
        success: function (data) {
            InicializarDataTable(data);
        },
        error: function (erro) {
        },
        complete: function () {
        }
    });
}
function MontarFiltro() {
    return {
        status: escopo.campos.status.val(),
        clienteId: escopo.campos.cliente.val(),
    };
}
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
                {
                    data: 'cliente', render: function (data, type, row) {
                        if (data) return data.nome;
                        return "";
                    },
                },
                { data: 'dataCadastro', },
                {
                    data: 'valorTotal', render: function (data, type, row) {
                        return parseFloat(data).toFixed(2).replace('.', ',');
                    }
                },
                { data: 'statusDesc', },
                {
                    data: '', render: function (data, type, row) {
                        return `<a href="${caminhoControler}/Visualizar/${row.id}" class="btn btn-sm btn-outline-primary me-1">
                                        <i class="fas fa-eye"></i>
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