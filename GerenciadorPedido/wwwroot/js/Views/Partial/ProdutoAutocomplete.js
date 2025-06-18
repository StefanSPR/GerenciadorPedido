// inicialização
function ProdutoAutoCompleteInicializar(idSelect, idErro, id) {
    $('#' + idSelect).change(function () { $('#' + idErro).addClass("d-none"); });

    ProdutoAutoComplete($('#' + idSelect), null);

    if (id != undefined && id != "0") {
        ProdutoAutoCompleteSetValue($('#' + idSelect), id);
    }
}

// configuração padrão para os campos select2 - autocomplete de Produto
function ProdutoAutoComplete(select) {
    //Configuração necessária para fazer o AutoComplete
    var url = caminhoWebSite + 'Produto/GetPesquisar';
    var mensagemErro = "Erro ao obter os Produtos";
    var mapeamento = function (item) {
        return {
            text: item.nome,
            slug: item.nome,
            id: item.id,
        }
    };

    $(select).select2({
        language: "pt-BR",
        minimumInputLength: 3,
        allowClear: true,
        placeholder: "Pesquisar por Nome do Produto",
        ajax: {
            url: url,
            dataType: 'json',
            type: "GET",
            delay: 300,
            data: function (params) {
                $(select).text('');
                return {
                    Descricao: params.term,
                    Tipo: 1,
                    MaxRetorno: 30,
                    Page: params.page
                };
            },
            processResults: function (data, params) {
                params.page = params.page || 1;
                return { results: $.map(data, mapeamento) };
            },
            error: function (error) {
                if (error.status > 0)
                    $(".loading-results").html("<b style='color: red'>" + mensagemErro + "</b>");
            }
        },
    });
}

// inicializa um valor
function ProdutoAutoCompleteSetValue(select, id) {
    if (id != null) {
        $.ajax({
            type: 'GET',
            url: caminhoWebSite + 'Produto/GetId?Id=' + id,
            async: false,
            success: function (data) {
                // create the option and append to Select2
                var option = new Option(data, data.id, true, true);
                select.append(option).trigger('change');
                // manually trigger the `select2:select` event
                select.trigger({
                    type: 'select2:select',
                    params: {
                        data: data
                    }
                });
            }
        });
    } else {
        $(select).text(null).val(null).trigger('change');
    }
}
