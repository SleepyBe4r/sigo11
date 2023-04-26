
const Div_Login = document.getElementsByClassName("login");
const Div_Cliente = document.getElementsByClassName("cliente");
const Div_Endereco = document.getElementsByClassName("endereco");
const Div_Carro = document.getElementsByClassName("carro");



$(document).ready(function (){

    //Quando o campo cep perde o foco.
    $("#EnderecoCEP").blur(function () {

        //Nova variável "cep" somente com dígitos.
        var cep = $(this).val().replace(/\D/g, '');

        //Verifica se campo cep possui valor informado.
        if (cep != "") {

            //Expressão regular para validar o CEP.
            var validacep = /^[0-9]{8}$/;

            //Valida o formato do CEP.
            if (validacep.test(cep)) {

                //Preenche os campos com "..." enquanto consulta webservice.


                /*console.log($("#EstadoUF")) */               
                $("#EnderecoCidade").val("...");
                $("#EnderecoRua").val("...");


                //Consulta o webservice viacep.com.br/
                $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                    if (!("erro" in dados)) {
                        //Atualiza os campos com os valores da consulta.
                        
                        var Estado = document.getElementById("EstadoUF");                                                
                        for (let index = 0; index < Estado.length; index++) {
                            console.log(Estado.options[index].text)
                            if (Estado.options[index].text == dados.uf) {                                
                                Estado.options[index].selected = true;                                
                            }
                        }

                        selecionaCidade();
                        setTimeout(function () {
                            var Cidade = document.getElementById("IDCidade");
                            for (let index = 0; index < Cidade.length; index++) {                            
                                if (Cidade.options[index].text == dados.localidade) {                                
                                    Cidade.options[index].selected = true;
                                }
                            }                        
                        }, 500);

                        $("#EnderecoRua").val(dados.logradouro);

                    } //end if.
                    else {
                        //CEP pesquisado não foi encontrado.
                        limpa_formulário_cep();
                        alert("CEP não encontrado.");
                    }
                });
            } //end if.
            else {
                //cep é inválido.
                limpa_formulário_cep();
                alert("Formato de CEP inválido.");
            }
        } //end if.
        else {
            //cep sem valor, limpa formulário.
            limpa_formulário_cep();
        }
    });

    $('form#cadastra').bind("keypress", function (e) {
        if ((e.keyCode == 10) || (e.keyCode == 13)) {
            e.preventDefault();
        }
    });

    $("#EstadoUF").change(function () {
        selecionaCidade();
    })
});


function selecionaCidade() {

    var UF = $("#EstadoUF option:selected").val();    
    $.ajax({
        type: "GET",
        data: { UF: UF },
        url: "/Login/SelecionaCidade",
        dataType: "json",
        success: function (dados) {
            console.log(dados);
            if (dados != null) {

                var selectbox = $('#IDCidade');
                $("#IDCidade").empty()

                $('<option>').val("0").text("Selecione a Cidade").appendTo(selectbox);
                $.each(dados, function (i, d) {
                    //console.log(d);
                    $('<option>').val(d.CidadeId).text(d.Nome_Cidade).appendTo(selectbox);
                })

            }
        },
        error: function (dados) {
            console.log("Erro: " + dados);
        }

    });
}

function VerificaLogin(a) {

    let Usuario = document.getElementById("userName").value;
    let Senha = document.getElementById("password").value;
    let ConfirmaSenha = document.getElementById("passwordConfirm").value;


    if ((Usuario.trim() != "") && (Senha.trim() != "") && (ConfirmaSenha.trim() != "") && (Senha == ConfirmaSenha)) {
        showView(a)
    }
    else {
        alert("Login invalidos");
    }
}


function VerificaCliente(a) {

    let Nome = document.getElementById("clienteName").value;
    let Celular = document.getElementById("Fone").value;
    let Tipo = document.getElementById("tipoPessoa").value;
    let CPFCNPJ = document.getElementById("CPFCNPJ").value;



    if ((Nome.trim() != "") && (Celular.trim() != "") && (CPFCNPJ.trim() != "")){
        showView(a);
    }
    else
    {
        alert("Cliente invalido");
    }

}


function VerificaEndereco(a) {

    let Cep = document.getElementById("EnderecoCEP").value;
    let Rua = document.getElementById("EnderecoRua").value;
    let Numero = document.getElementById("EnderecoNumero").value;
    let Complemento = document.getElementById("EnderecoComplemento").value;



    if ((Cep.trim() != "") && (Rua.trim() != "") && (Numero.trim() != "") && (Complemento.trim() != "")){
        showView(a);
    }
    else {
        alert("Endereco invalido");
    }

}


function VerificaCarro(a) {

    let Marca = document.getElementById("CarroMarca").value;
    let Modelo = document.getElementById("CarroNome").value;
    let Ano = document.getElementById("CarroAno").value;
    let Placa = document.getElementById("CarroPlaca").value;



    if ((Marca.trim() != "") && (Modelo.trim() != "") && (Ano.trim() != "") && (Placa.trim() != "")){
        showView(a);
    }
    else {
        alert("Carro invalido");
    }

}








function showView(a) {
    switch (a) {
        case "login":
            ResetFade();
            FadeOutAll();
            setTimeout(function () {
                console.log("teste");
                HideAll();
                document.documentElement.style.setProperty("--Vlogin", "visible");
                ResetFade();
                Div_Login[0].classList.add("fadeIn");
            }, 500);
            break;

        case "cliente":
            ResetFade();
            FadeOutAll();
            setTimeout(function () {
                HideAll();
                document.documentElement.style.setProperty("--Vcliente", "visible");
                ResetFade();
                Div_Cliente[0].classList.add("fadeIn");
            }, 500);

            break;

        case "endereco":
            ResetFade();
            FadeOutAll();
            setTimeout(function () {
                HideAll();
                document.documentElement.style.setProperty("--Vendereco", "visible");
                ResetFade();
                Div_Endereco[0].classList.add("fadeIn");
            }, 500);
            break;

        case "carro":
            ResetFade();
            FadeOutAll();
            setTimeout(function () {
                HideAll();
                document.documentElement.style.setProperty("--Vcarro", "visible");
                ResetFade();
                Div_Carro[0].classList.add("fadeIn");
            }, 500);
            break;

        default:

            break;
    }
}

function ResetFade() {
    Div_Login[0].classList.remove("fadeIn");
    Div_Login[0].classList.remove("fadeOut");

    Div_Cliente[0].classList.remove("fadeIn");
    Div_Cliente[0].classList.remove("fadeOut");

    Div_Endereco[0].classList.remove("fadeIn");
    Div_Endereco[0].classList.remove("fadeOut");

    Div_Carro[0].classList.remove("fadeIn");
    Div_Carro[0].classList.remove("fadeOut");
}

function FadeOutAll() {
    Div_Login[0].classList.add("fadeOut");
    Div_Cliente[0].classList.add("fadeOut");
    Div_Endereco[0].classList.add("fadeOut");
    Div_Carro[0].classList.add("fadeOut");
}

function HideAll() {
    document.documentElement.style.setProperty("--Vlogin", "hidden");
    document.documentElement.style.setProperty("--Vcliente", "hidden");
    document.documentElement.style.setProperty("--Vendereco", "hidden");
    document.documentElement.style.setProperty("--Vcarro", "hidden");
}