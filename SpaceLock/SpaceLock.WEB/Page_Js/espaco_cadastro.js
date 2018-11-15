function CadastrarEspaco() {
    $("#mensagem").html("Processando, por favor aguarde.");

    var model = {
        NomeEspaco: $("#txtNome").val(),
        Tamanho: $("#txtTamanho").val(),
        Capacidade: $("#txtCapacidade").val(),
        UnidadeMedida: $("#txtUnidadeMedida").val(),
        Endereco: $("#txtEndereco").val(),
        Numero: $("#txtNumero").val(),
        Complemento: $("#txtComplemento").val(),
        Bairro: $("#txtBairro").val(),
        Cidade: $("#txtCidade").val(),
        Uf: $("#txtUf").val(),
        Cep: $("#txtCep").val(),
        IdUsuario: 1
    };

    $.ajax({
        type: "POST",
        url: "/Espaco/CadastrarEspaco",
        data: model,
        success: function () { //requisição bem-sucedida..
            $("#mensagem").html("Espaço cadastrado com sucesso.");
        },
        error: function (e) { //requisição falhou..
            $("#mensagem").html("Ocorreu um erro: " + e.status);
        }
    });
}

function limpa_formulário_cep() {
    // Limpa valores do formulário de cep.
    $("#rua").val("");
    $("#bairro").val("");
    $("#cidade").val("");
    $("#uf").val("");
    $("#ibge").val("");
}