
const Div_Produtos = document.getElementsByClassName("produtos");
const Div_Back_Produtos = document.getElementsByClassName("back_Produtos");
const Div_Ordem_Finish = document.getElementsByClassName("Ordem_Finish");
const Div_back_Ordem_Finish = document.getElementsByClassName("back_Ordem_Finish");
let valorTotal = 0;

$(document).ready(function () {

    $("#cbCliente").change(function () {

        var IDCliente = $("#cbCliente option:selected").val();                    
        $.ajax({
            type: "GET",
            data: { IDCliente: IDCliente },
            url: "/OrdemDeServicoes/CarregaCarro",
            dataType: "json",                                    
            success: function (dados)
            {
                //console.log(dados);
                if (dados != null)
                {
                    var selectbox = $('#cbPlaca');
                    $("#cbPlaca").empty()
                    $('<option>').val("0").text("Selecione a Placa").appendTo(selectbox);
                    $.each(dados, function (i, d) {
                        //console.log(d);
                        $('<option>').val(d.ID).text(d.Placa).appendTo(selectbox);
                    })
                }
            }            

        });
    });

    $("#cbTipo").change(function () {

        var Tipo = $("#cbTipo option:selected").val();
        $.ajax({
            type: "GET",
            data: { Tipo: Tipo },
            url: "/OrdemDeServicoes/CarregaProdServ",
            dataType: "json",
            success: function (dados) {
                //console.log(dados);
                if (dados != null) {
                    var selectbox = $('#cbPS');
                    $("#cbPS").empty()
                    if (Tipo == "P") {
                        $('<option>').val("0").text("Selecione o Produto").appendTo(selectbox);
                        $.each(dados, function (i, d) {
                            //console.log(d);
                            $('<option>').val(d.ID_Produto).text(d.Nome_Produto).appendTo(selectbox);
                        })

                        document.getElementById("Quantidade").value = "1";
                        document.getElementById("Quantidade").disabled = false;
                    }
                    else if (Tipo == "S") {
                        $('<option>').val("0").text("Selecione o Servico").appendTo(selectbox);
                        $.each(dados, function (i, d) {
                            //console.log(d);
                            $('<option>').val(d.ID).text(d.Descricao).appendTo(selectbox);
                        })
                        document.getElementById("Quantidade").value = "1";
                        document.getElementById("Quantidade").disabled = true;
                    }
                    
                }
            },
            error: function (dados) {
                console.log("Erro: "+dados);
            }

        });
    });


})

function Finalizar_Ordem(a) {
    document.getElementById("Valor_Total").value = "R$ " + valorTotal;
    document.getElementById("Valor_Total").disabled = true;
    ShowView(a);

}

function AdicionarProd_Serv(){

    var Tipo = $("#cbTipo").val();
    var valor = $("#cbPS option:selected").val();    

    $.ajax({
        type: "GET",
        data: { Tipo: Tipo, ID: valor },
        url: "/OrdemDeServicoes/SelecionaProdServ",
        dataType: "json",
        success: function (dados) {
            //console.log(dados);
            if (dados != null) {
                var table = document.getElementById("table");
                ShowView();

                let tableLength = table.rows.length;
                let line = table.insertRow(tableLength);
                line.id = "item";
                let cell1 = line.insertCell(0);// ID;
                let cell2 = line.insertCell(1);// Tipo;
                let cell3 = line.insertCell(2);// Descrição;
                let cell4 = line.insertCell(3);// Quantidade;
                let cell5 = line.insertCell(4);// Desconto;
                let cell6 = line.insertCell(5);// Valor Uni;
                let cell7 = line.insertCell(6);// Valor Total;

                if (Tipo == "P") {
                    var quantidade = $("#Quantidade").val();
                    var valor = dados[0].Valor_Produto;
                    var desconto = $("#Desconto").val();                    
                    cell1.innerHTML = dados[0].ID_Produto;
                    cell2.innerHTML = "Produto";
                    cell3.innerHTML = dados[0].Nome_Produto;
                    cell4.innerHTML = quantidade;
                    cell5.innerHTML = desconto;
                    cell6.innerHTML = "R$ " + dados[0].Valor_Produto;
                    cell7.innerHTML = "R$ " + ((quantidade * valor) - desconto);
                    valorTotal = valorTotal + ((quantidade * valor) - desconto);
                    document.getElementById("Quantidade").value = "1";     
                    $("itens_ID").val() = dados[0].ID_Produto;
                }
                else if (Tipo == "S") {                                                  
                    var quantidade = $("#Quantidade").val();
                    var valor = dados[0].Valor;
                    var desconto = $("#Desconto").val();
                    cell1.innerHTML = dados[0].ID;                    
                    cell2.innerHTML = "Servico";
                    cell3.innerHTML = dados[0].Descricao;
                    cell4.innerHTML = quantidade;
                    cell5.innerHTML = desconto;
                    cell6.innerHTML = "R$ " + dados[0].Valor;
                    cell7.innerHTML = "R$ " + ((quantidade * valor) - desconto);
                    valorTotal = valorTotal + ((quantidade * valor) - desconto);
                }                
                var ComboBox = document.getElementById("cbPS");
                ComboBox.options[0].selected = true
            }
        },
        error: function (dados) {            
            var ex = JSON.parse(dados.responseText);
            alert(ex);
        }

    });
}

function ShowView(a) {

    switch (a) {
        case "prod_Serv_Add":
            HideAll();
            ResetFade();
            document.documentElement.style.setProperty("--VBack_Produtos", "visible");
            document.documentElement.style.setProperty("--VProdutos", "visible");
            FadeInAll();
        break;

        case "Itens_Open":
            document.getElementsByClassName("itens")[0].classList.add("itens_open")
            document.documentElement.style.setProperty("--Itens_Height", "500px");
        break;

         case "Ordem_Finish":
            HideAll();
            ResetFade();
            document.documentElement.style.setProperty("--Vback_Ordem_Finish", "visible");
            document.documentElement.style.setProperty("--VOrdem_Finish", "visible");
            FadeInAll();
         break;

        // case "carro":                     
        //     ResetFade();
        //     FadeOutAll();  
        //     setTimeout(function(){ 
        //         HideAll();
        //         document.documentElement.style.setProperty("--Vcarro", "visible"); 
        //         ResetFade();
        //         Div_Carro[0].classList.add("fadeIn");
        //     }, 500);  
        // break;    

        default:
            ResetFade();
            FadeOutAll();
            setTimeout(function () {
                HideAll();
                ResetFade();
            }, 500);            
            var ComboBox = document.getElementById("cbPS");
            ComboBox.options[0].selected = true
            break;
    }
}

function ResetFade() {
    Div_Back_Produtos[0].classList.remove("fadeIn");
    Div_Back_Produtos[0].classList.remove("fadeOut");

    Div_Produtos[0].classList.remove("fadeIn");
    Div_Produtos[0].classList.remove("fadeOut");

    Div_back_Ordem_Finish[0].classList.remove("fadeIn");
    Div_back_Ordem_Finish[0].classList.remove("fadeOut");

    Div_Ordem_Finish[0].classList.remove("fadeIn");
    Div_Ordem_Finish[0].classList.remove("fadeOut");
}

function FadeOutAll() {
    Div_Back_Produtos[0].classList.add("fadeOut");
    Div_Produtos[0].classList.add("fadeOut");
    Div_back_Ordem_Finish[0].classList.add("fadeOut");
    Div_Ordem_Finish[0].classList.add("fadeOut");
}

function FadeInAll() {
    Div_Back_Produtos[0].classList.add("fadeIn");
    Div_Produtos[0].classList.add("fadeIn");
    Div_back_Ordem_Finish[0].classList.add("fadeIn");
    Div_Ordem_Finish[0].classList.add("fadeIn");
}

function HideAll() {
    document.documentElement.style.setProperty("--VBack_Produtos", "hidden");
    document.documentElement.style.setProperty("--VProdutos", "hidden");
    document.documentElement.style.setProperty("--Vback_Ordem_Finish", "hidden");
    document.documentElement.style.setProperty("--VOrdem_Finish", "hidden");
}

