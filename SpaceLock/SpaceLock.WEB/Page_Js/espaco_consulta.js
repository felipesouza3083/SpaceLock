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
        type: "GET", //requisição HTTP GET..
        url: "/Espaco/ConsultarClientes?idUsuario=1",
        data: {},
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
                    conteudo += "<td><input type='button' class='btn btn-default btn-sm' value='Atualizar'/></td>";
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