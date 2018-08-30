using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DepartmentsMetaData
    {
        public int DepartmentId { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentZiped { get; set; }
        public string DepartmentAddress { get; set; }
        public string DepartmentPostalCode { get; set; }
        public string DepartmentPhone1 { get; set; }
        public string DepartmentPhone2 { get; set; }
        public string DepartmentPhone3 { get; set; }
        public string DepartmentFax { get; set; }
        public Nullable<int> DepartmentRank { get; set; }
        public bool DepartmentIsActive { get; set; }
        public short DepartmentTypeId { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }


    }


    [MetadataType(typeof(DepartmentsMetaData))]
    public partial class Department
    {

    }
}
