namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonMedicalMonitoring")]
    public partial class PersonMedicalMonitoring
    {
        public int PersonMedicalMonitoringId { get; set; }

        public DateTime PersonMedicalMonitoringDate { get; set; }

        [Required]
        [StringLength(50)]
        public string PersonMedicalMonitoringDateSolar { get; set; }

        public int PersonId { get; set; }

        public double? PersonHeight { get; set; }

        public double? PersonWeight { get; set; }

        public double? BloodPressure_Systolic { get; set; }

        public double? BloodPressure_Diastolic { get; set; }

        public double? HeadCircumference { get; set; }

        public double? AxillaryTemperature { get; set; }

        public double? OralTemperature { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        public virtual Person Person { get; set; }
    }
}
