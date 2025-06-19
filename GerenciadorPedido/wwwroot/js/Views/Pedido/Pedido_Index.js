var filtro;
let escopo = {
    campos: {
        status: $('#dropStatus'),
        cliente: $('#ClienteAutoComplete'),
        pedido: $('#inpPedidoId'),
        modalTexto: $('#txtModal'),
    },
    botoes: {
        pesquisa: $('#btnPesquisar'),
        confirmar: $('#btnConfirmar')
    },
    tabela: $('#tablePesquisa'),
    modals: {
        processar: $('#modalProcessar'),
    }
}
$(function () {
    $(document).ready(function () {
        escopo.botoes.pesquisa.on('click', function () {
            filtro = MontarFiltro();
            Pesquisar();
        })
    })

})
function Pesquisar() {
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
                { data: 'dataCadastroDesc', },
                {
                    data: 'valorTotal', render: function (data, type, row) {
                        return parseFloat(data).toFixed(2).replace('.', ',');
                    }
                },
                { data: 'statusDesc', },
                {
                    data: '', class:'text-center', render: function(data, type, row) {
                        let statusIcone = row.pedidoStatus == 0 ? "check" : "check-double";
                        let statusClass = row.pedidoStatus == 0 ? "btnProcessar" : "btnFinalizar";
                        let buttonAvancar = '';
                        if (row.pedidoStatus < 2) {
                            buttonAvancar = `<button class="btn btn-sm btn-outline-success ${statusClass}" title="Avançar Status">
                                        <i class="fas fa-${statusIcone}"></i>
                                    </button>`
                        }

                        return `<a href="${caminhoControler}/Visualizar/${row.id}" class="btn btn-sm btn-outline-primary me-1">
                                        <i class="fas fa-eye"></i>
                                    </a>
                                    ${buttonAvancar}`;
                    },
                },
            ],

        })
    }

    $('#tablePesquisa tbody').on('click', '.btnProcessar', function () {
        let model = escopo.tabela.DataTable().row($(this).parents('tr')).data();
        escopo.campos.modalTexto.text('Deseja realmente processar o pedido?')
        escopo.modals.processar.modal('show');
        escopo.campos.pedido.val(model.id);

        escopo.botoes.confirmar.off();
        escopo.botoes.confirmar.on('click', function () {
            Avancar(model.id, Finalizar);
        });
    });
    $('#tablePesquisa tbody').on('click', '.btnFinalizar', function () {
        let model = escopo.tabela.DataTable().row($(this).parents('tr')).data();
        escopo.campos.modalTexto.text('Deseja realmente finalizar o pedido?')
        //escopo.campos.pedido.val(model.id);
        escopo.modals.processar.modal('show');

        escopo.botoes.confirmar.off();
        escopo.botoes.confirmar.on('click', function () {
            Avancar(model.id, function () {
                Pesquisar();
                escopo.modals.processar.modal('hide');
                toastr.success("Pedido finalizado com sucesso!");
            });
        });
    });
}
function Finalizar() {
    Pesquisar();
    escopo.campos.modalTexto.text('Pedido processado com sucesso, deseja finaliza-lo?');
    escopo.botoes.confirmar.off();
    escopo.botoes.confirmar.on('click', function () {
        Avancar(escopo.campos.pedido.val(), function () {
            escopo.modals.processar.modal('hide');
            toastr.success("Pedido finalizado com sucesso!");
        });
        Pesquisar();
    });
}

function Avancar(id, callback) {
    $.ajax({
        url: caminhoControler + '/Avancar/' + id,
        method: 'PUT',
        dataType: 'json',
        success: callback,
        error: function (err) {
        },
        complete: function () {

        }
    });

}

function FecharModal() {
    escopo.modals.processar.modal('hide');
}