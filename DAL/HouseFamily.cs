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
    
    public partial class HouseFamily
    {
        public int HouseFamilyId { get; set; }
        public int HouseId { get; set; }
        public Nullable<int> FamilyId { get; set; }
        public string HouseLoginDateSolar { get; set; }
        public Nullable<System.DateTime> HouseLoginDate { get; set; }
        public string HouseLeaveDateSolar { get; set; }
        public Nullable<System.DateTime> HouseLeaveDate { get; set; }
        public Nullable<int> LeavingHouseCauseId { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    
        public virtual Family Family { get; set; }
        public virtual House House { get; set; }
        public virtual LeavingHouseCause LeavingHouseCause { get; set; }
    }
}
