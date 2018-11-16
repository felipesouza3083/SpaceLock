$(document).ready(function () {
    //Quando o campo cep perde o foco.
    ListarTipoEventos();

    $("#txtCep").blur(function () {

        //Nova variável "cep" somente com dígitos.
        var cep = $(this).val().replace(/\D/g, '');

        //Verifica se campo cep possui valor informado.
        if (cep !== "") {

            //Expressão regular para validar o CEP.
            var validacep = /^[0-9]{8}$/;

            //Valida o formato do CEP.
            if (validacep.test(cep)) {

                //Preenche os campos com "..." enquanto consulta webservice.
                $("#txtEndereco").val("...");
                $("#txtBairro").val("...");
                $("#txtCidade").val("...");
                $("#txtUf").val("...");
                //$("#ibge").val("...");

                //Consulta o webservice viacep.com.br/
                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                    if (!("erro" in dados)) {
                        //Atualiza os campos com os valores da consulta.
                        $("#txtEndereco").val(dados.logradouro);
                        $("#txtBairro").val(dados.bairro);
                        $("#txtCidade").val(dados.localidade);
                        $("#txtUf").val(dados.uf);
                        //$("#ibge").val(dados.ibge);
                    } //end if.
                    else {
                        //CEP pesquisado não foi encontrado.
                        limpa_formulário_cep();
                        alert("CEP não encontrado.");
                    }
                });
            } //end if.
            else {
                //cep é inválido.
                limpa_formulário_cep();
                alert("Formato de CEP inválido.");
            }
        } //end if.
        else {
            //cep sem valor, limpa formulário.
            limpa_formulário_cep();
        }
    });

    $("#btncadastro").click(function () {
        CadastrarEspaco();
    });
});

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

function ListarTipoEventos() {
    $.ajax({
        url: '/TipoEvento/ConsultarTipoEvento',
        dataType: "json",
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        async: true,
        processData: false,
        cache: false,
        success: function (obj) {
            //verificar se o controller retornou uma lista..
            if (obj instanceof Array) {
                //imprimir os dados da tabela..
                var conteudo = "";
                for (var i = 0; i < obj.length; i++) {
                    conteudo += "<option id='" + obj[i].IdTipoEvento + "'>" + obj[i].Descricao + "</option>";
                }
                $("#sltTipo").html(conteudo);
            }
            else {
                //imprimir mensagem..
                $("#mensagem").html(obj);
            }
        },
        error: function (e) {
            $("#mensagem").html("Erro: " + e.status);
        }
    });
}