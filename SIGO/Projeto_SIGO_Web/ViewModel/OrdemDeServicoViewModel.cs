using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto_SIGO_Web.ViewModel
{
    public class OrdemDeServicoViewModel
    {
        /*-------------Ordem De Serviço-----------------*/
        public int ID { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public string TipoPagamento { get; set; }
        public Nullable<int> IDCarroAtual { get; set; }

        /*-------------Carro-----------------*/
        public Nullable<int> IDCliente { get; set; }
        public string Placa { get; set; }

        /*-------------Itens Da Ordem-----------------*/
        public int[] ID_Item { get; set; }
        public string[] Tipo { get; set; }
        public string Garantia { get; set; }
        public Nullable<int> Quantidade { get; set; }
        public Nullable<decimal> Desconto { get; set; }
        public Nullable<decimal> ValorTotal { get; set; }
        public string Obs { get; set; }
        public string Defeito { get; set; }
        public Nullable<int> IDProduto { get; set; }
        public Nullable<int> IDServico { get; set; }
        public Nullable<int> IDOrdemDeServico { get; set; }
        public int Prod_Serv { get; set; }

        /*-------------Produtos-----------------*/

        public Int32 ID_Produto { get; set; }        
        public string Nome_Produto { get; set; }
        public string Descricao_Produto { get; set; }
        public Nullable<decimal> Valor_Produto { get; set; }

        /*-------------Servicos-----------------*/

        public Int32 ID_Servico { get; set; }
        public string Descricao_Servico { get; set; }        
        public Nullable<decimal> Valor_Servico { get; set; }
    }
}