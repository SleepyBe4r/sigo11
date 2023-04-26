using Projeto_SIGO_Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_SIGO_Web.Repositories
{
    public class FornecedorRepository
    {
        private Projeto_SIGOEntities db;

        public FornecedorRepository()
        {
            db = new Projeto_SIGOEntities();
        }

        public bool VerificarCNPJ(Fornecedor objdados)
        {
            Fornecedor objretorno = new Fornecedor();

            //var dados = db.Login.Where(login => login.Usuario.Equals(objdados.Usuario)
            //&& login.Senha.Equals(objdados.Senha)).FirstOrDefault();
                
            var dados = db.Fornecedor.Where(fornecedor => fornecedor.CNPJ.Equals(objdados.CNPJ)).FirstOrDefault(); 

            if (dados != null)
            {
                return false;
            }
            else
            {
                return true;
            }            
        }

    }
}