function CadastrarCliente() {
    var formData = new FormData(document.getElementById("formCadastro"));
    $.ajax({
        type: "POST",
        url: "/CadastroCliente/CadastrarCliente",
        data: formData,
        processData: false,
        contentType: false,
        success: function (retorno) {

            if (retorno == 1) {
                alert("Cliente cadastrado com sucesso!");
            } else if (retorno == 0) {
                alert("Não foi possível cadastrar o cliente.")
            }

        },
        error: function (xhr, status, error) {
            console.error("Erro:", error);
        }
    });
}