//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GymApp.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLBEDENBILGILERI
    {
        public int beden_id { get; set; }
        public int beden_uyeID { get; set; }
        public System.DateTime beden_tarih { get; set; }
        public decimal boy { get; set; }
        public decimal kilo { get; set; }
        public decimal yagOrani { get; set; }
        public decimal bel { get; set; }
        public decimal kalca { get; set; }
        public decimal gogus { get; set; }
        public decimal kol { get; set; }
    
        public virtual TBLUYELER TBLUYELER { get; set; }
    }
}
