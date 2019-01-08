$(document).ready(function () {

    consultar();
});

function parseJsonDate(jsonDate) {

    var fullDate = new Date(parseInt(jsonDate.substr(6)));
    var twoDigitMonth = (fullDate.getMonth() + 1) + ""; if (twoDigitMonth.length === 1) twoDigitMonth = "0" + twoDigitMonth;

    var twoDigitDate = fullDate.getDate() + ""; if (twoDigitDate.length === 1) twoDigitDate = "0" + twoDigitDate;
    var currentDate = twoDigitDate + "/" + twoDigitMonth + "/" + fullDate.getFullYear();

    return currentDate;
}

function ObjectToTime(obj) {

    var horas = obj.Hours.toString();
    var minutos = obj.Minutes.toString();

    if (obj != null) {
        if (horas.length == 1) {
            horas = "0" + horas.toString();
        }

        if (minutos.length == 1) {
            minutos = "0" + minutos.toString();
        }

        return horas + ":" + minutos;
    }
    else {
        return "00:00";
    }
}

function consultar() {
    //função AJAX..
    $.ajax({
        url: '/Aluguel/ConsultarAlgueisDoUsuario?idUsuario=' + sessionStorage.getItem("IDUSUARIOLOGADO") + '',
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
                $("#quantidade").html(obj.length);

                var conteudo = "";

                for (var i = 0; i < obj.length; i++) {
                    conteudo += "<tr>";
                    conteudo += "<td>" + obj[i].IdAluguel + "</td>";
                    conteudo += "<td>" + parseJsonDate(obj[i].DataAluguel) + "</td>";
                    conteudo += "<td>" + obj[i].HoraInicio + "</td>";
                    conteudo += "<td>" + obj[i].HoraFim + "</td>";
                    conteudo += "<td>" + obj[i].Descricao + "</td>";
                    conteudo += "<td>" + obj[i].NomeEspaco + "</td>";
                    if (obj[i].FlCancelado === 1) {
                        conteudo += "<td>Cancelado</td>";
                    }
                    else {
                        if (obj[i].FlConfirmado === 1) {
                            conteudo += "<td><input type='button' onclick='GeraRelatorio(" + obj[i].IdAluguel + ")' class='btn btn-default btn-sm' value='Gerar Relatório'></td>";
                        }
                        else {
                            conteudo += "<td><input type='button' onclick='LaunchModal(" + obj[i].IdAluguel + ", " + obj[i].IdEspaco + ")' class='btn btn-success btn-sm' value='Atualizar Dados' data-toggle='modal' data-target='#myModal'/>";
                            conteudo += "&nbsp;&nbsp;<input type='button' class='btn btn-danger btn-sm' value='Cancelar Aluguel' onclick='CancelarAluguel(" + obj[i].IdAluguel + ")'/></td>";
                        }
                    }
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

function LaunchModal(idAluguel, idEspaco) {
    var modal = "";

    modal += "<div class='modal-dialog'>";
    modal += "<div class='modal-content'>";
    modal += "<div class='modal-header'>";
    modal += "<button type='button' class='close' data-dismiss='modal' aria-hidden='true'>×</button>";
    modal += "<h2 class='modal-title'>Solicitação de Aluguel</h2>";
    modal += "</div>";
    modal += "<div class='modal-body'>";
    modal += "<p>Data do Aluguel:<input type='text' placeholder='dd/MM/yyyy' id='txtdata' class='form-control1'></p>";
    modal += "<p>Hora Inicio:<input type='text' placeholder='HH:mm' id='txtinicio' class='form-control1'></p>";
    modal += "<p>Hora Final:<input type='text' placeholder='HH:mm' id='txtfinal' class='form-control1'></p>";
    modal += "<p>Descrição do Evento:<input type='text' id='txtdescricao' placeholder='Descrição do Evento' class='form-control1'></p>";
    modal += "</div>";
    modal += "<div class='modal-footer'>";
    //modal += "<button type='button' class='btn btn-default' data-dismiss='modal'>Fe</button>";
    modal += "<button type='button' onclick='AtualizarAluguel(" + idAluguel + ", " + idEspaco + ")' class='btn btn-success'>Solicitar</button>";
    modal += "</div>";
    modal += "</div>";
    modal += "</div>";


    $("#modal").html(modal);

    $('#txtdata').mask('00/00/0000');

    $('#txtinicio').mask('00:00');

    $('#txtfinal').mask('00:00');

    $.ajax({
        url: '/Aluguel/ListaAluguelPorId?idAluguel=' + idAluguel + '',
        dataType: "json",
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        async: true,
        processData: false,
        cache: false,
        success: function (obj) {
            debugger;
            $("#txtdata").val(parseJsonDate(obj.DataAluguel));
            $("#txtinicio").val(obj.HoraInicio);
            $("#txtfinal").val(obj.HoraFim);
            $("#txtdescricao").val(obj.Descricao);
        },
        error: function (e) {
            $("#mensagem").html("Erro: " + e.status);
        }
    });
}

function AtualizarAluguel(idAluguel, idEspaco) {

    var model = {
        IdAluguel: idAluguel,
        DataAluguel: $("#txtdata").val(),
        HorInicio: $("#txtinicio").val(),
        HoraFim: $("#txtfinal").val(),
        DescricaoEvento: $("#txtdescricao").val(),
        IdEspaco: idEspaco,
        IdUsuario: sessionStorage.getItem("IDUSUARIOLOGADO")
    };

    $.ajax({
        type: "PUT",
        url: "/Aluguel/AtualizarAluguel",
        data: model,
        success: function () { //requisição bem-sucedida..
            window.location.reload();
        },
        error: function (e) { //requisição falhou..
            alert("Ocorreu um erro: " + e.status);
        }
    });

}

function GeraRelatorio(id) {
    $.ajax({
        url: '/Aluguel/GerarRelatorioAluguel?idAluguel=' + id + '',
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
