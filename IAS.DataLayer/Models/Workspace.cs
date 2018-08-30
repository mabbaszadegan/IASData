namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Workspace")]
    public partial class Workspace
    {
        public int WorkspaceId { get; set; }

        [Required]
        [StringLength(300)]
        public string WorkspaceName { get; set; }

        [Required]
        [StringLength(300)]
        public string WorkspaceSummaryName { get; set; }

        [StringLength(300)]
        public string WorkspaceZiped { get; set; }

        [StringLength(300)]
        public string WorkspaceUsername { get; set; }

        [StringLength(300)]
        public string WorkspacePassword { get; set; }

        [StringLength(300)]
        public string WorkspaceCompany { get; set; }

        [StringLength(300)]
        public string WorkspaceUrl { get; set; }

        [StringLength(300)]
        public string WorkspaceNumber { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }
    }
}
