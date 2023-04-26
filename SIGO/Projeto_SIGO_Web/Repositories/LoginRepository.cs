using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto_SIGO_Web.Models;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace Projeto_SIGO_Web.Repositories
{
    public class LoginRepository
    {
        private Projeto_SIGOEntities db;

        public LoginRepository()
        {
            db = new Projeto_SIGOEntities();
        }       

        public Login Login(Login objdados)
        {
            Login objretorno = new Login();

            var dados = db.Login.Where(login => login.Usuario.Equals(objdados.Usuario)
            && login.Senha.Equals(objdados.Senha)).FirstOrDefault();

            if (dados != null)
            {
                objretorno.ID = dados.ID;
                objretorno.Usuario = dados.Usuario;
                objretorno.Senha = dados.Senha;
                objretorno.Tipo = dados.Tipo;
            }
            else
            {
                objretorno.ID = 0;
            }
            return objretorno;

        }        

        public string GerarHashMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Converter a String para array de bytes, que é como a biblioteca trabalha.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Cria-se um StringBuilder para recompôr a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

    }
}