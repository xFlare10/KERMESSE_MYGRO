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
    
    public partial class vw_kermesse
    {
        public int id_kermesse { get; set; }
        public string Parroquia { get; set; }
        public string Kermesse { get; set; }
        public System.DateTime fecha_inicio { get; set; }
        public System.DateTime fecha_fin { get; set; }
        public string desc_general { get; set; }
        public int estado { get; set; }
    }
}
