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
    
    public partial class tbl_listaprecio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_listaprecio()
        {
            this.tbl_listaprecio_det = new HashSet<tbl_listaprecio_det>();
        }
    
        public int id_listaprecio { get; set; }
        public int id_kermesse { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int estado { get; set; }
    
        public virtual tbl_kermesse tbl_kermesse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_listaprecio_det> tbl_listaprecio_det { get; set; }
    }
}
