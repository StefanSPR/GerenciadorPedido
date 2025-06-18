
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