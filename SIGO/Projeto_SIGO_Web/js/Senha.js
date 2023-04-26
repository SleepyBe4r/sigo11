function mostrarOcultarSenha()
{
    var senha = document.getElementById("password");
    if(senha.type=="password")
    {
        senha.type="text";
    }
    else
    {
        senha.type="password";
    }
}