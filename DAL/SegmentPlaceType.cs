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
    
    public partial class SegmentPlaceType
    {
        public int SegmentPlaceTypeId { get; set; }
        public int SegmentId { get; set; }
        public int PlaceTypeId { get; set; }
        public string PlaceTypeDesc { get; set; }
        public string PlaceTypeZiped { get; set; }
        public bool ExistInSegment { get; set; }
        public Nullable<double> NearlyDistance { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    
        public virtual PlaceType PlaceType { get; set; }
        public virtual Segment Segment { get; set; }
    }
}
