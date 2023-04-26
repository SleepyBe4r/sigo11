$(document).ready(function () {
    $("#telefone").inputmask("mask", { "mask": "(99) 99999-9999" });
    $("#cep").inputmask("mask", { "mask": "99999-999" });
    $("#nascimento").inputmask("mask", { "mask": "99/99/9999" });
    $("#preco").inputmask("mask", { "mask": "999.99,99" }, { reverse: true });
    $("#valor").inputmask("mask", { "mask": "#.##9,99" }, { reverse: true });
    $("#ip").inputmask("mask", { "mask": "999.999.999.999" });
    $("#data").inputmask("mask", { "mask": "99/99/9999" });
    $("#desconto").inputmask("mask", { "mask": "99%" }, { reverse: true });

    $("#CNPJ").keydown(function () {
        try {
            $("#CNPJ").unmask();
        } catch (e) { }

        var campo = $("#CNPJ").val();
        campo = campo.replace('.', '');
        campo = campo.replace('.', '');
        campo = campo.replace('-', '');
        campo = campo.replace('/', '');
        campo = campo.replace('_', '');
        campo = campo.replace('_', '');
        campo = campo.replace('_', '');

        //var tamanho = $("#CNPJ").val().length;
        var tamanho = campo.length;


        if (tamanho < 11) {
            $("#CNPJ").inputmask("mask", { "mask": "999.999.999-99" });
        }
        else {
            $("#CNPJ").inputmask("mask", { "mask": "99.999.999/9999-99" });
        }
    });

});

$(function () {
    $("input[data-tipo=''moeda'']").mask("000.000.000,00", { reverse: true });
});

function formatarMoeda() {
    var elemento = document.getElementById('valor'); var valor = elemento.value;

    valor = valor + '';
    valor = parseInt(valor.replace(/[\D]+/g, ''));
    valor = valor + '';
    valor = valor.replace(/([0-9]{2})$/g, ",$1");

    if (valor.length > 6)
    {
        valor = valor.replace(/([0-9]{3}),([0-9]{2}$)/g, ".$1,$2");
    }

    elemento.value = valor;
    if (valor == 'NaN') elemento.value = '';

}



function formatarMoeda() {
    var elemento = document.getElementById('valor');
    var valor = elemento.value;


    valor = valor + '';
    valor = parseInt(valor.replace(/[\D]+/g, ''));
    valor = valor + '';
    valor = valor.replace(/([0-9]{2})$/g, ",$1");

    if (valor.length > 6) {
        valor = valor.replace(/([0-9]{3}),([0-9]{2}$)/g, ".$1,$2");
    }

    elemento.value = valor;
    if (valor == 'NaN') elemento.value = '';

}

function moeda(a, e, r, t) {
    let n = ""
        , h = j = 0
        , u = tamanho2 = 0
        , l = ajd2 = ""
        , o = window.Event ? t.which : t.keyCode;
    if (13 == o || 8 == o)
        return !0;
    if (n = String.fromCharCode(o),
        -1 == "0123456789".indexOf(n))
        return !1;
    for (u = a.value.length,
        h = 0; h < u && ("0" == a.value.charAt(h) || a.value.charAt(h) == r); h++)
        ;
    for (l = ""; h < u; h++)
        -1 != "0123456789".indexOf(a.value.charAt(h)) && (l += a.value.charAt(h));
    if (l += n,
        0 == (u = l.length) && (a.value = ""),
        1 == u && (a.value = "0" + r + "0" + l),
        2 == u && (a.value = "0" + r + l),
        u > 2) {
        for (ajd2 = "",
            j = 0,
            h = u - 3; h >= 0; h--)
            3 == j && (ajd2 += e,
                j = 0),
                ajd2 += l.charAt(h),
                j++;
        for (a.value = "",
            tamanho2 = ajd2.length,
            h = tamanho2 - 1; h >= 0; h--)
            a.value += ajd2.charAt(h);
        a.value += r + l.substr(u - 2, u)
    }
    return !1
}
