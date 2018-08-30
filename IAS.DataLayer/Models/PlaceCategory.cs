namespace IAS.DataLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlaceCategory")]
    public partial class PlaceCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PlaceCategory()
        {
            PlaceType = new HashSet<PlaceType>();
        }

        public int PlaceCategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string PlaceCategoryName { get; set; }

        [StringLength(2000)]
        public string PlaceCategoryDesc { get; set; }

        [Required]
        [StringLength(2000)]
        public string PlaceCategoryZiped { get; set; }

        public int InsertUserId { get; set; }

        public DateTime InsertTime { get; set; }

        public int? UpdateUserId { get; set; }

        public DateTime? UpdateTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlaceType> PlaceType { get; set; }
    }
}
