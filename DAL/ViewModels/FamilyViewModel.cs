using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FamilyViewModel : FamiliesMetaData
    {
        public string SupervisorName { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
        public int MembersCount { get; set; }
        public int? ProvinceId { get; set; }
        public int? CityId { get; set; }
        public int? RegionId { get; set; }
        public List<FamilyMemberViewModel> Members { get; set; }



    }


}
