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
    
    public partial class BaseInfoHistory
    {
        public int BaseInfoId { get; set; }
        public string BaseInfoCode { get; set; }
        public string BaseInfoName { get; set; }
        public string BaseInfoSummaryName { get; set; }
        public int BaseInfoIndex { get; set; }
        public string BaseInfoDesc { get; set; }
        public string BaseInfoValue { get; set; }
        public string BaseInfoZiped { get; set; }
        public bool BaseInfoIsActive { get; set; }
        public int BaseInfoGroupId { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
    }
}
