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
    
    public partial class vw_gastos
    {
        public int id_gasto { get; set; }
        public string Kermesse { get; set; }
        public string Categoria_gasto { get; set; }
        public System.DateTime fecha_gasto { get; set; }
        public string concepto { get; set; }
        public decimal monto { get; set; }
    }
}
