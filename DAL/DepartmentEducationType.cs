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
    
    public partial class DepartmentEducationType
    {
        public int DepartmentEducationTypeId { get; set; }
        public int DepartmentId { get; set; }
        public int EducationTypeId { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual EducationType EducationType { get; set; }
    }
}
