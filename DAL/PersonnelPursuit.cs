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
    
    public partial class PersonnelPursuit
    {
        public int PersonnelPursuitId { get; set; }
        public string PersonnelPursuitTimeSolar { get; set; }
        public System.DateTime PersonnelPursuitTime { get; set; }
        public string PersonnelPursuitDesc { get; set; }
        public string PersonnelPursuitZiped { get; set; }
        public int PersonnelPursuitResultId { get; set; }
        public int PersonnelId { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    
        public virtual Personnel Personnel { get; set; }
        public virtual PersonnelPursuitResult PersonnelPursuitResult { get; set; }
    }
}
