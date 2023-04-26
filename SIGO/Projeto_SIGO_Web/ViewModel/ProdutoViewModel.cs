using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projeto_SIGO_Web.ViewModel
{
    public class ProdutoViewModel
    {
        public Int32 ID { get; set; }

        [Required(ErrorMessage = "O nome do produto é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; }

        [NotMapped]
        [DataType(DataType.Upload)]
        public HttpPostedFileBase File { get; set; }

        public string Descricao { get; set; }

        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        [DisplayName("Preço:")]
        public Nullable<decimal> Valor { get; set; }
        public Nullable<int> Estoque { get; set; }
        public Nullable<int> EstoqueMaximo { get; set; }
        public Nullable<int> EstoqueMinimo { get; set; }
        public Nullable<int> IDMarca { get; set; }
        public Nullable<int> IDFornecedor { get; set; }
        public byte[] Foto { get; set; }

    }
}