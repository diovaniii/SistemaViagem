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
    
    public partial class EnderecoComercial
    {
        public int EnderecoId { get; set; }
        public string EnderecoEstado { get; set; }
        public string EnderecoCidade { get; set; }
        public string EnderecoBairro { get; set; }
        public string EnderecoRua { get; set; }
        public string EnderecoNumero { get; set; }
        public Nullable<int> ClienteIdEndereco { get; set; }
    
        public virtual Cliente Cliente { get; set; }
    }
}
