//executando o jquery quando a página é carregada..
$(document).ready(function () {
    //executando a função de consulta..
    consultar();
});

//função para executar a consulta de clientes..
function consultar() {
    debugger;
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
                    conteudo += "<td><input type='button' class='btn btn-default btn-sm' value='Atualizar Dados'/></td>";
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