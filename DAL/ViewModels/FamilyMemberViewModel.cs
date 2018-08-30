using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FamilyMemberViewModel:PersonViewModel
    {
        public int FamilyMemberId { get; set; }
        public int FamilyId { get; set; }
        public string RelationTypeName { get; set; }

    }


}
