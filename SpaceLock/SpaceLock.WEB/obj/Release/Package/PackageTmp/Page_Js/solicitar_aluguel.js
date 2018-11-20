$(document).ready(function () {
    ListarTipoEventos();

    $('#sltTipoEvento').change(function () {
        ListarEspacos($(this).val());
    });
});

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
                conteudo += "<option>::SELECIONE::</option>"
                for (var i = 0; i < obj.length; i++) {
                    conteudo += "<option value='" + obj[i].IdTipoEvento + "'>" + obj[i].Descricao + "</option>";
                }
                $("#sltTipoEvento").html(conteudo);
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

function ListarEspacos(id) {
    $.ajax({
        url: '/Espaco/ListaEspacoPorEvento?idTipoEvento=' + id + '',
        dataType: "json",
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        async: true,
        processData: false,
        cache: false,
        success: function (obj) {
            //verificar se o controller retornou uma lista..
            if (obj instanceof Array) {
                debugger;
                //exibir a quantidade de elementos da lista..
                $("#quantidade").html(obj.length);
                //imprimir os dados da tabela..
                var conteudo = "";
                for (var i = 0; i < obj.length; i++) {
                    conteudo += "<tr>";
                    conteudo += "<td id='foto" + obj[i].IdEspaco + "'></td>";
                    ListarFotos(obj[i].IdEspaco);
                    conteudo += "<td>" + obj[i].NomeEspaco + "</td>";
                    conteudo += "<td><input type='button' onclick='LaunchModal(" + obj[i].IdEspaco + ")' class='btn btn-success btn-sm' value='Solicitar Aluguel' data-toggle='modal' data-target='#myModal'/></td>";
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

function ListarFotos(id) {

    $.ajax({
        url: '/EspacoFoto/ListaFotoPorEspaco?idEspaco=' + id + '',
        dataType: "json",
        type: "GET",
        contentType: 'application/json; charset=utf-8',
        async: true,
        processData: false,
        cache: false,
        success: function (obj) {
            //verificar se o controller retornou uma lista..
            if (obj instanceof Array) {
                var conteudo = "";
                for (var i = 0; i < obj.length; i++) {
                    //conteudo += "<img src='/Imagens/Espaco/" + id + "/" + obj[i].Foto + "' width='60' height='60'>";
                    //conteudo += "<div class='col-md'>";
                    conteudo += "<div class='gallery-img'>";
                    conteudo += "<a href='/Imagens/Espaco/" + id + "/" + obj[i].Foto + "' class='b-link-stripe b-animate-go swipebox' title='" + obj[i].Foto + "'>";
                    conteudo += "<img class='img-responsive' src='/Imagens/Espaco/" + id + "/" + obj[i].Foto + "' alt=''/>";
                    conteudo += "<span class='zoom-icon'></span>";
                    conteudo += "</a>";
                    conteudo += "</div>";
                    //conteudo += "</div>";
                }
                $("#foto" + id + "").html(conteudo)
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

function LaunchModal(idEspaco) {
    debugger;
    var modal = "";

    modal += "<div class='modal-dialog'>";
    modal += "<div class='modal-content'>";
    modal += "<div class='modal-header'>";
    modal += "<button type='button' class='close' data-dismiss='modal' aria-hidden='true'>×</button>";
    modal += "<h2 class='modal-title'>Solicitação de Aluguel</h2>";
    modal += "</div>";
    modal += "<div class='modal-body'>";
    modal += "<p>Data do Aluguel:<input type='date' id='txtdata' class='form-control1'></p>";
    modal += "<p>Hora Inicio:<input type='text' placeholder='HH:mm' id='txtinicio' class='form-control1'></p>";
    modal += "<p>Hora Final:<input type='text' placeholder='HH:mm' id='txtfinal' class='form-control1'></p>";
    modal += "<p>Descrição do Evento:<input type='text' id='txtdescricao' placeholder='Descrição do Evento' class='form-control1'></p>";
    modal += "</div>";
    modal += "<div class='modal-footer'>";
    //modal += "<button type='button' class='btn btn-default' data-dismiss='modal'>Fe</button>";
    modal += "<button type='button' onclick='InserirSolicitacao(" + idEspaco + ")' class='btn btn-success'>Solicitar</button>";
    modal += "</div>";
    modal += "</div>";
    modal += "</div>";


    $("#modal").html(modal);

    $('#txtinicio').mask('00:00');

    $('#txtfinal').mask('00:00');
}

function InserirSolicitacao(idEspaco) {
    var model = {
        DataAluguel: $("#txtdata").val(),
        HorInicio: $("#txtinicio").val(),
        HoraFim: $("#txtfinal").val(),
        DescricaoEvento: $("#txtdescricao").val(),
        IdEspaco: idEspaco,
        IdUsuario: sessionStorage.getItem("IDUSUARIOLOGADO")
    };

    $.ajax({
        type: "POST",
        url: "/Aluguel/SolicitarAluguel",
        data: model,
        success: function () { //requisição bem-sucedida..
            window.location.reload();
        },
        error: function (e) { //requisição falhou..
           alert("Ocorreu um erro: " + e.status);
        }
    });
}