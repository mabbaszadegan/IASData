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
    
    public partial class PersonSkillType
    {
        public int PersonSkillTypeId { get; set; }
        public int PersonId { get; set; }
        public int SkillTypeId { get; set; }
        public int SkillTypeLevelId { get; set; }
        public string SkillTypeName { get; set; }
        public string PersonSkillTypeDesc { get; set; }
        public string PersonSkillTypeZiped { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual SkillType SkillType { get; set; }
        public virtual SkillTypeLevel SkillTypeLevel { get; set; }
    }
}
