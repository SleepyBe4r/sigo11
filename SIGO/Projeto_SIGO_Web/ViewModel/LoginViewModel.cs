using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_SIGO_Web.ViewModel
{
    public class LoginViewModel
    {
        //<!----------------------------------------------- Seção Login ----------------------------------------------->

        public string Usuario { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }


        //<!----------------------------------------------- Seção Clientes ----------------------------------------------->

        public string Nome_Cliente { get; set; }
        public string Celular { get; set; }
        public string Tipo { get; set; }
        public string CPF_CNPJ { get; set; }

        //<----------------------------------------------- Seção Endereço ----------------------------------------------->

        public int CidadeId { get; set; }
        public string Nome_Cidade { get; set; }
        public int EstadoId { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }


        //<----------------------------------------------- Seção Carro ----------------------------------------------->

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public string Placa { get; set; }
        public string Valvulas { get; set; }
        public string Versao { get; set; }

    }
}