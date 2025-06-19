var listaItems = [];
let escopo = {
    campos: {
        cliente: $('#ClienteAutoComplete'),
        produto: $('#ProdutoAutoComplete'),
        quantidade: $('#inpQuantidade'),
        idPedido: $('#idPedido'),
    },
    botoes: {
        adicionar: $('#btnAdicionar'),
        salvar: $('#btnSalvar')
    },
    tabela: {
        itens: $('#tableItem'),
    },
};
(function () {
    $(document).ready(function () {
        if (escopo.campos.idPedido.val() != "0") {
            escopo.campos.cliente.attr('disabled', true);
            PedidoObterPorId(escopo.campos.idPedido.val(), InicializarCampos)
        }
        escopo.botoes.adicionar.on('click', function () {
            if (!ValidarAdicionar()) return;
            ProdutoObterPorId(escopo.campos.produto.val(), IncluirProduto);
        });

        escopo.botoes.salvar.on('click', function () {
            if (!ValidarSalvar()) return;
            Salvar();
        })
    })
})();


// ----------------------------------------------------
// Actions add
// ----------------------------------------------------
function IncluirProduto(data) {
    const quantidade = parseInt(escopo.campos.quantidade.val());
    listaItems.push({
        produtoId: data.id,
        nome: data.nome,
        quantidade: quantidade,
        precoUnitario: parseFloat(data.preco).toFixed(2).replace('.',','),
    });
    InicializarDataTable(listaItems);
    LimparCamposProduto();
}
function InicializarDataTable(data) {
    let elmTable = escopo.tabela.itens;
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
                { data: 'quantidade', },
                {
                    data: 'precoUnitario',
                },
                {
                    data: null,
                    orderable: false,
                    className: 'text-center',
                    render: function (data, type, row, meta) {
                        return `<button class="btn btn-sm btn-outline-danger" title="Remover"
                                        onclick="javascript:ApagarItem(${meta.row})">
                                    <i class="fas fa-trash"></i>
                                </button>`;
                    }
                }
            ],

        })
    }
}
function ApagarItem(index) {
    listaItems.splice(index, 1);
    InicializarDataTable(listaItems);
};
function LimparCamposProduto() {
    escopo.campos.produto.val(null).trigger('change');
    escopo.campos.quantidade.val('');
}
function ValidarAdicionar() {

    const idProduto = escopo.campos.produto.val();
    const quantidade = parseInt(escopo.campos.quantidade.val());

    if (!idProduto || isNaN(quantidade) || quantidade <= 0) {
        toastr.warning("Informe um produto válido e quantidade maior que zero.");
        return false;
    }
    if (listaItems.filter(x => idProduto == x.produtoId).length > 0) {
        toastr.warning("Informe o produto já existe na lista.");
        return false;
    }
    return true;
}
// ----------------------------------------------------
// Actions Save
// ----------------------------------------------------

function ValidarSalvar() {
    if (!escopo.campos.cliente.val()) {
        toastr.warning("Selecione um cliente.");
        return false;
    }

    if (listaItems.length === 0) {
        toastr.warning("Adicione ao menos um item ao pedido.");
        return false;
    }
    return true;
}
function Salvar() {
    const idPedido = escopo.campos.idPedido.val();
    const url = idPedido != "0" ? `${caminhoControler}/Editar` : `${caminhoControler}/Inserir`;

    const data = {
        Id: idPedido || 0,
        ClienteId: escopo.campos.cliente.val(),
        ItensPedido: listaItems
    };

    $.ajax({
        url: url,
        method: 'POST',
        dataType: 'json',
        data: data,
        success: function () {
            toastr.success("Pedido salvo com sucesso!");
            window.location.href = `${caminhoControler}/Index`;
        },
        error: function (err) {
            toastr.error("Erro ao salvar pedido.");
        }
    });
}

// ----------------------------------------------------
// Actions Load
// ----------------------------------------------------
function InicializarCampos(data) {
    ClienteAutoCompleteSetValue(escopo.campos.cliente, data.clienteId);
    for (var i = 0; i < data.ItensPedido.length; i++) {
        let item = data.ItensPedido[i]
        listaItems.push({
            produtoId: item.produto.id,
            nome: item.produto.nome,
            quantidade: item.quantidade,
            precoUnitario: parseFloat(item.precoUnitario).toFixed(2).replace('.', ',') ,
        });
    }

}
