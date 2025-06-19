const escopo = {
    campos: {
        id: $('#inpId'),
        nome: $('#inpNome'),
        descricao: $('#inpDescricao'),
        preco: $('#inpPreco'),
        quantidade: $('#inpQuantidade')
    },
    botoes: {
        salvar: $('#btnSalvar')
    },
    form: $('#formProduto')
};

$(document).ready(function () {
    escopo.campos.preco.mask('####,##', { reverse: true });

    escopo.botoes.salvar.on('click', function (e) {
        if (!ValidarFormulario()) {
            return;
        }
        Salvar();
    });

});

function Salvar() {
    const produto = {
        id: parseInt(escopo.campos.id.val()) || 0,
        nome: escopo.campos.nome.val(),
        descricao: escopo.campos.descricao.val(),
        preco: escopo.campos.preco.val(),
        quantidadeEstoque: parseInt(escopo.campos.quantidade.val())
    };

    const isEdicao = produto.id > 0;
    const url = isEdicao ? `/Edit` : '/Create';
    const metodo = isEdicao ? 'PUT' : 'POST';

    $.ajax({
        url: caminhoControler + url,
        method: metodo,
        dataType: 'json',
        data: produto,
        success: function () {
            toastr.success("Produto salvo com sucesso!");
            window.location.href = `${caminhoControler}/Index`;
        },
        error: MensagemErro,
    });

}
function ValidarFormulario() {
    let valido = true;
    escopo.campos.nome.removeClass('is-invalid');
    escopo.campos.descricao.removeClass('is-invalid');
    escopo.campos.preco.removeClass('is-invalid');
    escopo.campos.quantidade.removeClass('is-invalid');

    if (!escopo.campos.nome.val().trim()) {
        escopo.campos.nome.addClass('is-invalid');
        MensagemCampoObrigatorio(escopo.campos.nome);
        valido = false;
    } else if (escopo.campos.nome.val().trim().length > 255) {
        escopo.campos.nome.addClass('is-invalid');
        MensagemMaximoCaracter(escopo.campos.nome, 255);
        valido = false;
    }

    if (!escopo.campos.descricao.val().trim()) {
        escopo.campos.descricao.addClass('is-invalid');
        MensagemCampoObrigatorio(escopo.campos.descricao);
        valido = false;
    } else if (escopo.campos.descricao.val().trim().length > 1000) {
        escopo.campos.descricao.addClass('is-invalid');
        MensagemMaximoCaracter(escopo.campos.descricao, 1000)
        valido = false;
    }

    let precoStr = escopo.campos.preco.val().replace(',', '.');
    let precoVal = parseFloat(precoStr);
    if (isNaN(precoVal) || precoVal <= 0) {
        escopo.campos.preco.addClass('is-invalid');
        valido = false;
    }

    let qtdVal = parseInt(escopo.campos.quantidade.val());
    if (isNaN(qtdVal) || qtdVal < 0) {
        escopo.campos.quantidade.addClass('is-invalid');
        valido = false;
    } 

    return valido;
}
function MensagemMaximoCaracter(input, lenght) {

    input.siblings('.invalid-feedback').text(`Máximo de ${lenght} caracteres.`);
}
function MensagemCampoObrigatorio(input) {
    input.siblings('.invalid-feedback').text('Campo é obrigatório.');
}