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
    
    public partial class hotelviagem
    {
        public int ViagemId { get; set; }
        public Nullable<int> ViagemIdViagem { get; set; }
        public Nullable<int> ViagemIdHotel { get; set; }
        public Nullable<System.DateTime> ViagemDias { get; set; }
        public Nullable<decimal> ViagemValorUnitario { get; set; }
    
        public virtual hotel hotel { get; set; }
        public virtual viagem viagem { get; set; }
    }
}
