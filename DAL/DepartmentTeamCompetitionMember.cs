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
    
    public partial class DepartmentTeamCompetitionMember
    {
        public int DepartmentTeamCompetitionMemberId { get; set; }
        public int DepartmentTeamCompetitionId { get; set; }
        public int PersonId { get; set; }
        public Nullable<int> CompetitionMemberStatusId { get; set; }
        public string CompetitionMemberStatusDesc { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
    
        public virtual CompetitionMemberStatus CompetitionMemberStatus { get; set; }
        public virtual DepartmentTeamCompetition DepartmentTeamCompetition { get; set; }
        public virtual Person Person { get; set; }
    }
}
