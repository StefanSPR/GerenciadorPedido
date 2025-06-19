function MensagemErro() {
    toastr.error("Ocorreu um erro ao realizar opração, contate o administrador!");
}


function ProdutoObterPorId(id, callback) {
    if (id != null) {
        $.ajax({
            type: 'GET',
            url: caminhoWebSite + 'Produto/GetId?Id=' + id,
            async: false,
            success: callback
        });
    } 
}
function PedidoObterPorId(id, callback) {
    if (id != null) {
        $.ajax({
            type: 'GET',
            url: caminhoWebSite + 'Pedido/GetId?Id=' + id,
            async: false,
            success: callback
        });
    }
}