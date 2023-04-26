//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projeto_SIGO_Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Produto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Produto()
        {
            this.ItensOrdem = new HashSet<ItensOrdem>();
        }
    
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        
        public Nullable<decimal> Valor { get; set; }
        public Nullable<int> Estoque { get; set; }
        public Nullable<int> EstoqueMaximo { get; set; }
        public Nullable<int> EstoqueMinimo { get; set; }
        public Nullable<int> IDMarca { get; set; }
        public Nullable<int> IDFornecedor { get; set; }
        public byte[] Foto { get; set; }
    
        public virtual Fornecedor Fornecedor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItensOrdem> ItensOrdem { get; set; }
        public virtual Marca Marca { get; set; }
    }
}
