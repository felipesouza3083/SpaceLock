//executando o jquery quando a página é carregada..
$(document).ready(function () {
    //executando a função de consulta..
    consultar();
});

//função para executar a consulta de clientes..
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
                //exibir a quantidade de elementos da lista..
                $("#quantidade").html(obj.length);
                //imprimir os dados da tabela..
                var conteudo = "";
                for (var i = 0; i < obj.length; i++) {
                    conteudo += "<tr>";
                    conteudo += "<td>" + obj[i].IdEspaco + "</td>";
                    conteudo += "<td>" + obj[i].NomeEspaco + "</td>";
                    conteudo += "<td>" + obj[i].Capacidade + "</td>";
                    conteudo += "<td>" + obj[i].Tamanho + "</td>";
                    conteudo += "<td><input type='button' onclick='AtualizarEspaco(" + obj[i].IdEspaco +")' class='btn btn-default btn-sm' value='Atualizar Dados'/>&nbsp;&nbsp;";
                    conteudo += "<input type='button' onclick='LaunchModal(" + obj[i].IdEspaco +")' class='btn btn-danger btn-sm' value='Abrir Manutenção' data-toggle='modal' data-target='#myModal'/></td>";
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

function AtualizarEspaco(idEspaco) {
    
}

function LaunchModal(idEspaco) {
    var modal = "";

    modal += "<div class='modal-dialog'>";
    modal += "<div class='modal-content'>";
    modal += "<div class='modal-header'>";
    modal += "<button type='button' class='close' data-dismiss='modal' aria-hidden='true'>×</button>";
    modal += "<h2 class='modal-title'>Solicitação de Aluguel</h2>";
    modal += "</div>";
    modal += "<div class='modal-body'>";
    modal += "<p>Data de Inicio:<input type='date' id='txtdatainicio' class='form-control1'></p>";
    modal += "<p>Data Final:<input type='date' id='txtdatafim' class='form-control1'></p>";
    modal += "<p>Motivo:<input type='text' placeholder='Motivo' id='txtmotivo' class='form-control1'></p>";
    modal += "</div>";
    modal += "<div class='modal-footer'>";
    //modal += "<button type='button' class='btn btn-default' data-dismiss='modal'>Fe</button>";
    modal += "<button type='button' onclick='CadastrarManutencao(" + idEspaco + ")' class='btn btn-success'>Cadastrar</button>";
    modal += "</div>";
    modal += "</div>";
    modal += "</div>";


    $("#modal").html(modal);

}


function CadastrarManutencao(idEspaco){
    var model = {
        DataInicio: $("#txtdatainicio").val(),
        DataFim: $("#txtdatafim").val(),
        Motivo: $("#txtmotivo").val(),
        IdEspaco: idEspaco,
        IdUsuario: sessionStorage.getItem("IDUSUARIOLOGADO")
    };

    $.ajax({
        type: "POST",
        url: "/Manutencao/CadastraManutencao",
        data: model,
        success: function () { //requisição bem-sucedida..
            window.location.reload();
        },
        error: function (e) { //requisição falhou..
            alert("Ocorreu um erro: " + e.status);
        }
    });
}