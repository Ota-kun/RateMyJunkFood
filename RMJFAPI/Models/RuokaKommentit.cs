//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RMJFAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class RuokaKommentit
    {
        public int ruoKommenttiId { get; set; }
        public int kayttajaId { get; set; }
        public int ruokaId { get; set; }
        public string kommentti { get; set; }
        public byte[] kuva { get; set; }
    
        public virtual Ruoka Ruoka { get; set; }
    }
}