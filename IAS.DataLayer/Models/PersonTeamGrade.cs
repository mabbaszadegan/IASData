namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonTeamGrade")]
    public partial class PersonTeamGrade
    {
        public int PersonTeamGradeId { get; set; }

        public int PersonTeamId { get; set; }

        public int? ExpertiseId { get; set; }

        public int? BeltColorId { get; set; }

        public int DepartmentTeamCompetitionId { get; set; }

        public int? DepartmentTeamCompetitionDetailId { get; set; }

        public int GradeId { get; set; }

        public int? OpponentPersonId { get; set; }

        public double? PersonPoints { get; set; }

        public double? OpponentPersonPoints { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual BeltColor BeltColor { get; set; }

        public virtual DepartmentTeamCompetition DepartmentTeamCompetition { get; set; }

        public virtual DepartmentTeamCompetitionDetail DepartmentTeamCompetitionDetail { get; set; }

        public virtual Expertise Expertise { get; set; }

        public virtual PersonTeam PersonTeam { get; set; }

        public virtual PersonTeam PersonTeam1 { get; set; }
    }
}
