using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto_SIGO_Web.Models;

namespace Projeto_SIGO_Web.Repositories
{
    public class ClienteRepository
    { 
        private Projeto_SIGOEntities db;

        public ClienteRepository()
        {
            db = new Projeto_SIGOEntities();
        }

        public void InserirEndereco(Endereco objdados)
        {
            Cliente objretorno = new Cliente();

            //var dados = db.Endereco.Add(cliente => cliente.Endereco.ID.Equals(IDEndereco)).FirstOrDefault();

            /*if (dados != null)
            {
                objretorno.ID = dados.ID;
                objretorno. = dados.Modelo;
                objretorno. = dados.Placa;
            }
            else
            {
                objretorno.ID = 0;
            }     */      

        }


    }
}