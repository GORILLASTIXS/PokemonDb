//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PokemonDb
{
    using System;
    using System.Collections.Generic;
    
    public partial class pokemon
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Type_1 { get; set; }
        public string Type_2 { get; set; }
        public Nullable<short> Total { get; set; }
        public Nullable<byte> HP { get; set; }
        public Nullable<byte> Attack { get; set; }
        public Nullable<byte> Defense { get; set; }
        public Nullable<byte> Sp_Atk { get; set; }
        public Nullable<byte> Sp_Def { get; set; }
        public Nullable<byte> Speed { get; set; }
        public Nullable<byte> Generation { get; set; }
        public Nullable<bool> Legendary { get; set; }
    }
}
