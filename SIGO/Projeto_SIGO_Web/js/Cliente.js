
$(".btn-danger").click(function () {
    var id = $(this).attr('data-item');

    var tr = $(this).closest("tr");
    if (confirm("Você tem certeza que gostaria de excluir este registro?")) {
        $.ajax({
            method: "POST",
            url: "/Clientes/Delete/" + id,
            success: function (data) {
                tr.fadeOut(400, function () {
                    tr.remove();
                });
            },
            error: function (data) {
                alert("Houve um erro na exclusão.");
            }
        });
    }
});




