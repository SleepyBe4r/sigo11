using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto_SIGO_Web.Models;

namespace Projeto_SIGO_Web.Repositories
{
    public class OrdemDeServicoRepository
    {
        private Projeto_SIGOEntities db;

        public OrdemDeServicoRepository()
        {
            db = new Projeto_SIGOEntities();
        }        

        public CarroAtual CarregaCarro(int IDCliente)
        {
            CarroAtual objretorno = new CarroAtual();

            var dados = db.CarroAtual.Where(carro => carro.Cliente.ID.Equals(IDCliente)).FirstOrDefault();

            if (dados != null)
            {
                objretorno.ID = dados.ID;
                objretorno.Modelo = dados.Modelo;
                objretorno.Placa = dados.Placa;                
            }
            else
            {
                objretorno.ID = 0;
            }
            return objretorno;

        }


    }
}