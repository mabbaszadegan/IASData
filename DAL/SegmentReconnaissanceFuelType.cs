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
    
    public partial class SegmentReconnaissanceFuelType
    {
        public int SegmentReconnaissanceFuelTypeId { get; set; }
        public int SegmentReconnaissanceId { get; set; }
        public int FuelTypeId { get; set; }
        public double FuelTypePercent { get; set; }
        public string FuelTypeDesc { get; set; }
        public string FuelTypeZiped { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    
        public virtual FuelType FuelType { get; set; }
        public virtual SegmentReconnaissance SegmentReconnaissance { get; set; }
    }
}
