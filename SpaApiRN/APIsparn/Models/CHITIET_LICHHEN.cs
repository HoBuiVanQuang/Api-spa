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
    
    public partial class CHITIET_LICHHEN
    {
        public int ID_LH { get; set; }
        public Nullable<int> ID_HLV { get; set; }
        public int ID_DICHVU { get; set; }
        public Nullable<int> ID_GIUONG { get; set; }
        public Nullable<int> TRANGTHAI { get; set; }
        public string GHICHU { get; set; }
    
        public virtual DICHVU DICHVU { get; set; }
        public virtual GIUONG GIUONG { get; set; }
        public virtual USER USER { get; set; }
        public virtual LICHHEN LICHHEN { get; set; }
    }
}
