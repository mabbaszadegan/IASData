//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class SegmentReconnaissanceDrugType
    {
        public int SegmentReconnaissanceDrugTypeId { get; set; }
        public int SegmentReconnaissanceId { get; set; }
        public int DrugTypeId { get; set; }
        public double DrugTypePercent { get; set; }
        public string DrugTypeDesc { get; set; }
        public string DrugTypeZiped { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    
        public virtual DrugType DrugType { get; set; }
        public virtual SegmentReconnaissance SegmentReconnaissance { get; set; }
    }
}
