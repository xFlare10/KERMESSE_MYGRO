//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KERMESSE_MYGRO.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_denominacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_denominacion()
        {
            this.tbl_arqueocaja_det = new HashSet<tbl_arqueocaja_det>();
        }
    
        public int id_denominacion { get; set; }
        public int id_moneda { get; set; }
        public decimal valor { get; set; }
        public string valor_letras { get; set; }
        public int estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_arqueocaja_det> tbl_arqueocaja_det { get; set; }
        public virtual tbl_moneda tbl_moneda { get; set; }
    }
}
