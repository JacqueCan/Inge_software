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
    
    public partial class tbl_usuario
    {
        public int Id_Usuario { get; set; }
        public int Tipo_Persona { get; set; }
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
        public int Persona { get; set; }
    
        public virtual tbl_persona tbl_persona { get; set; }
        public virtual tbl_tipoPersona tbl_tipoPersona { get; set; }
    }
}
