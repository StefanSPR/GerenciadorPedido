// inicialização
function ClienteAutoCompleteInicializar(idSelect, idErro, id) {
    $('#' + idSelect).change(function () { $('#' + idErro).addClass("d-none"); });

    ClienteAutoComplete($('#' + idSelect), null);

    //if (id != undefined && id != "") {
    //    ClienteAutoCompleteSetValue($('#' + idSelect), id);
    //}
}

// configuração padrão para os campos select2 - autocomplete de Cliente
function ClienteAutoComplete(select) {
    //Configuração necessária para fazer o AutoComplete
    var url = caminhoWebSite + 'Cliente/GetPesquisar';
    var mensagemErro = "Erro ao obter os clientes";
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
        placeholder: "Pesquisar por Nome ou Email do Cliente",
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
function ClienteAutoCompleteSetValue(select, id) {
    if (id != null) {
        $.ajax({
            type: 'GET',
            url: caminhoWebSite + 'Cliente/GetId?Id=' + id,
            async: false,
            success: function (data) {
                // create the option and append to Select2
                var option = new Option((data.nome), (data.id), true, true);
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
