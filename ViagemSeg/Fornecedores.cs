//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ViagemSeg
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fornecedores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fornecedores()
        {
            this.Servico1 = new HashSet<Servico>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Servico { get; set; }
        public string Telefone { get; set; }
        public Nullable<int> Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Servico> Servico1 { get; set; }
    }
}