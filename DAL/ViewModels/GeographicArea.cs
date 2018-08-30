using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("GeographicArea")]
    public class GeographicArea 
    { 
        [Key]
        [Column("GeographicAreaId")]
        public int Id { get; set; }

        [Column("GeographicAreaTypeId")]
        public Int16 GeographicAreaTypeId { get; set; }

        [Column("ParentId")]
        public int ParentId { get; set; }

        public virtual GeographicAreaType GeographicAreaType { get; set; }
        public virtual GeographicArea Parent { get; set; }
        public virtual IEnumerable<GeographicArea> GeographicAreas { get; set; }

    }
}
