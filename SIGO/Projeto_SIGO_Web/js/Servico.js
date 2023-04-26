
$(".btn-danger").click(function () {
    var id = $(this).attr('data-item');
    if (confirm("Você tem certeza que gostaria de excluir este registro?")) {
        $.ajax({
            method: "POST",
            url: "/Servicoes/Delete/" + id,
            success: function (data) {

            },
            error: function (data) {
                alert("Houve um erro na pesquisa.");
            }
        });
    }
});


