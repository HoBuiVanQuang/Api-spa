//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APIsparn.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CHITIET_GIUONG
    {
        public int ID_GIUONG { get; set; }
        public int ID_DICHVU { get; set; }
        public Nullable<int> TNHTRANG { get; set; }
    
        public virtual DICHVU DICHVU { get; set; }
        public virtual GIUONG GIUONG { get; set; }
    }
}
