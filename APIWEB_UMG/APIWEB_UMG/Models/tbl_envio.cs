//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APIWEB_UMG.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_envio
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_envio()
        {
            this.tbl_solicitudEntrega = new HashSet<tbl_solicitudEntrega>();
        }
    
        public int Id_Envio { get; set; }
        public int Persona { get; set; }
        public int Direccion { get; set; }
        public string municipio { get; set; }
        public string departamento { get; set; }
    
        public virtual tbl_direccion tbl_direccion { get; set; }
        public virtual tbl_persona tbl_persona { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_solicitudEntrega> tbl_solicitudEntrega { get; set; }
    }
}
