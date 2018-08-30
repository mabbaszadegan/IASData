using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("GeographicAreaType")]
    public class GeographicAreaType
    {
        [Key]
        [Column("GeographicAreaTypeId")]
        public Int16 Id { get; set; }
        [Column("GeographicAreaTypeName")]
        public string Name { get; set; }
        public virtual IEnumerable<GeographicArea> GeographicAreas { get; set; }

    }
}
