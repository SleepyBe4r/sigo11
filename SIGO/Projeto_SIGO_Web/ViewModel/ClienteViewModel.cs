using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Projeto_SIGO_Web.ViewModel
{
    public class ClienteViewModel
    {
        public int ID { get; set; }
        public string Nome { get; set; }        
        public string Celular { get; set; }
        public string CPF_CNPJ { get; set; }
        public string Email { get; set; }
        public int IDEndereco { get; set; }


        public string Valor { get; set; }

        public string Tipo { get; set; }


        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public Nullable<int> IDCidade { get; set; }

    }
}