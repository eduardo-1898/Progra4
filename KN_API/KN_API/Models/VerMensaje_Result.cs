//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KN_API.Models
{
    using System;
    
    public partial class VerMensaje_Result
    {
        public int IdMensaje { get; set; }
        public string Mensaje { get; set; }
        public System.DateTime MensjFecha { get; set; }
        public int IdTiquete { get; set; }
        public Nullable<int> IdUsuario { get; set; }
        public string Usuario { get; set; }
    }
}