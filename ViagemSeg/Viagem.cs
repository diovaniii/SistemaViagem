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
    
    public partial class viagem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public viagem()
        {
            this.hotelviagem = new HashSet<hotelviagem>();
            this.vendacliente = new HashSet<vendacliente>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public Nullable<System.DateTime> DataInicio { get; set; }
        public Nullable<System.DateTime> DataFim { get; set; }
        public Nullable<decimal> Valor { get; set; }
        public string Estado { get; set; }
        public string Descricao { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> Veiculo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hotelviagem> hotelviagem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<vendacliente> vendacliente { get; set; }
    }
}
