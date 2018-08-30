using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DepartmentViewModel : DepartmentsMetaData
    {
        public string SupervisorName { get; set; }
        public string Phone { get; set; }
        public int PersonsCount { get; set; }
        public int FamiliesCount { get; set; }
    }


}
