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
    
    public partial class TBLANTRENORLER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLANTRENORLER()
        {
            this.TBLGRUPDERSLER = new HashSet<TBLGRUPDERSLER>();
            this.TBLOZELDERSLER = new HashSet<TBLOZELDERSLER>();
        }
    
        public int antrenor_id { get; set; }
        public string antrenor_ad { get; set; }
        public string antrenor_soyad { get; set; }
        public string antrenor_telefon { get; set; }
        public string antrenor_email { get; set; }
        public string antrenor_adres { get; set; }
        public System.DateTime antrenor_dogumTarihi { get; set; }
        public System.DateTime antrenor_baslangicTarihi { get; set; }
        public string antrenor_foto { get; set; }
        public string antrenor_aktif { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLGRUPDERSLER> TBLGRUPDERSLER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLOZELDERSLER> TBLOZELDERSLER { get; set; }
    }
}
