$(document).ready(function () {
    PartialListaClientes();
});
function PartialListaClientes() {
    $.ajax({
        type: "GET",
        url: '/ListaClientes/_PartialListaClientes',
        success: function (result) {
            $("#painel").html(result);
        },
        error: function (xhr, status, error) {
            console.error("Erro:", error);
        }
    });
}

function ExcluirCliente(cpf) {
    $.ajax({
        type: "POST",
        url: '/ListaClientes/ExcluirCliente',
        data: { cpf: cpf },
        success: function (retorno) {
            if (retorno == "1") {
                alert("Cliente excluído com sucesso");
                PartialListaClientes();
            }
            else {
                alert("Não foi possível excluir o cliente")
            }
        },
        error: function (xhr, status, error) {
            alert("Não foi fazer a requisição de exclusão")
            console.error(error);
        }
    });

}

function ModalEdicao(id) {
    $.ajax({
        type: "GET",
        url: '/ListaClientes/ModalEdicao',
        data: { id: id },
        success: function (result) {
            $("#modalBody").html(result);
            $("#modalEditar").modal('show');
        },
        error: function (xhr, status, error) {
            console.error("Erro:", error);
        }
    });
}

function SalvarEdicao() {
    $.ajax({
        url: '/ListaClientes/EditarCliente',
        type: 'POST',
        data: {
            Id: $("#Id").val(),
            Nome: $("#Nome").val(),
            Email: $("#Email").val(),
            Telefone: $("#Telefone").val(),
            CPF: $("#CPF").val()
        },
        success: function () {
            alert("Cliente editado com sucesso");
            $("#modalEditar").modal('hide');
            PartialListaClientes();
        }
    });
}
