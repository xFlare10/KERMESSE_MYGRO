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
    using System.ComponentModel.DataAnnotations;

    public partial class tbl_rol_opcion
    {
        public int id_rol_opcion { get; set; }
        [Display(Name = "Rol: ")]
        [Required(ErrorMessage = "Asigne un rol")]
        public int id_rol { get; set; }

        [Display(Name = "Opcion: ")]
        [Required(ErrorMessage = "Asigne una opci�n")]
        public int id_opcion { get; set; }

        public virtual tbl_opciones tbl_opciones { get; set; }
        public virtual tbl_rol tbl_rol { get; set; }
    }
}
