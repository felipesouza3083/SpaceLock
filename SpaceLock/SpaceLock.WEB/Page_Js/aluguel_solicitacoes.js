$(document).ready(function () {
    consultar();

    $('#sltEspaco').change(function () {
        ListarAlugueisPorEspaco($(this).val());
    });

});

function consultar() {
    //função AJAX..
    $.ajax({
        url: '/Espaco/ConsultarEspaco?idUsuario=' + sessionStorage.getItem("IDUSUARIOLOGADO") + '',
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
                conteudo += "<option value='0'>::SELECIONE::</option>"
                for (var i = 0; i < obj.length; i++) {
                    conteudo += "<option value='" + obj[i].IdEspaco + "'>" + obj[i].NomeEspaco + "</option>";
                }
                $("#sltEspaco").html(conteudo);
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

function parseJsonDate(jsonDate) {

    var fullDate = new Date(parseInt(jsonDate.substr(6)));
    var twoDigitMonth = (fullDate.getMonth() + 1) + ""; if (twoDigitMonth.length === 1) twoDigitMonth = "0" + twoDigitMonth;

    var twoDigitDate = fullDate.getDate() + ""; if (twoDigitDate.length === 1) twoDigitDate = "0" + twoDigitDate;
    var currentDate = twoDigitDate + "/" + twoDigitMonth + "/" + fullDate.getFullYear();

    return currentDate;
}

function ListarAlugueisPorEspaco(id) {
    $.ajax({
        url: '/Aluguel/ConsultarAlgueisDoEspaco?idEspaco=' + id + '',
        dataType: "json",
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        async: true,
        processData: false,
        cache: false,
        success: function (obj) {
            //verificar se o controller retornou uma lista..
            if (obj instanceof Array) {
                //exibir a quantidade de elementos da lista..
                $("#quantidade").html(obj.length);
                debugger;
                //imprimir os dados da tabela..
                var conteudo = "";
                for (var i = 0; i < obj.length; i++) {
                    conteudo += "<tr>";
                    conteudo += "<td>" + obj[i].IdAluguel + "</td>";
                    conteudo += "<td>" + parseJsonDate(obj[i].DataAluguel) + "</td>";
                    conteudo += "<td>" + obj[i].HoraInicio + "</td>";
                    conteudo += "<td>" + obj[i].HoraFim + "</td>";
                    conteudo += "<td>" + obj[i].Descricao + "</td>";
                    conteudo += "<td>" + obj[i].NomeUsuario + "</td>";
                    conteudo += "<td><input type='button' class='btn btn-default btn-sm' onclick='ConfirmarAluguel(" + obj[i].IdAluguel+")' value='Confirmar Aluguel' data-toggle='modal' data-target='#myModal'/>";
                    conteudo += "&nbsp;&nbsp;<input type='button' onclick='CancelarAluguel(" + obj[i].IdAluguel+")' class='btn btn-danger btn-sm' value='Excluir Aluguel'/></td>";
                    conteudo += "</tr>";
                }
                $("#tabela tbody").html(conteudo);
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

function ConfirmarAluguel(idAluguel) {
    debugger;
    var modal = "";

    modal += "<div class='modal-dialog'>";
    modal += "<div class='modal-content'>";
    modal += "<div class='modal-header'>";
    modal += "<button type='button' class='close' data-dismiss='modal' aria-hidden='true'>×</button>";
    modal += "<h2 class='modal-title'>Solicitação de Aluguel</h2>";
    modal += "</div>";
    modal += "<div class='modal-body'>";
    modal += "<p>Valor do Aluguel:<input type='text' id='txtvalor' placeholder='R$' class='form-control1'></p>";
    modal += "</div>";
    modal += "<div class='modal-footer'>";
    //modal += "<button type='button' class='btn btn-default' data-dismiss='modal'>Fe</button>";
    modal += "<button type='button' onclick='AtualizarAluguel(" + idAluguel + ")' class='btn btn-success'>Solicitar</button>";
    modal += "</div>";
    modal += "</div>";
    modal += "</div>";


    $("#modal").html(modal);

    $("#txtvalor").maskMoney({ prefix: 'R$ ', allowNegative: true, thousands: '.', decimal: ',', affixesStay: false });

}

function AtualizarAluguel(idAluguel) {
    var model = {
        IdAluguel: idAluguel,
        ValorAluguel: $("#txtvalor").val()
    };
    debugger;
    $.ajax({
        type: "PUT",
        url: "/Aluguel/AtualizarValorAluguel",
        data: model,
        success: function () { //requisição bem-sucedida..
            window.location.reload();
        },
        error: function (e) { //requisição falhou..
            alert("Ocorreu um erro: " + e.status);
        }
    });

}

function CancelarAluguel(id) {
    var confirmacao = confirm("Deseja cancelar esse aluguel?");

    if (confirmacao) {
        $.ajax({
            url: '/Aluguel/CancelaAluguel?idAluguel=' + id + '',
            dataType: "json",
            type: "GET",
            contentType: 'application/json; charset=utf-8',
            async: true,
            processData: false,
            cache: false,
            success: function (obj) {
                window.location.reload();
            },
            error: function (e) {
                $("#mensagem").html("Erro: " + e.status);
            }
        });
    }

}