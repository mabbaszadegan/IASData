using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class PersonViewModel : Person
    {
        public int? FamilyId { get; set; }
        public int? RelationTypeId { get; set; }
        public string RelationTypeName { get; set; }
        public bool IsParent { get; set; }
        public int? RegionId { get; set; }
        public int? SegmentId { get; set; }
        public string FamilyMemberExpireTimeSolar { get; set; }
        public int? ExpireCauseId { get; set; }
        public string ExpireCauseName { get; set; }

        private string _PersonFullName { get; set; }
        public string PersonFullName
        {
            get
            {
                return PersonFirstName + " " + PersonLastName + ((!string.IsNullOrEmpty(PersonFatherName) ? " فرزند " + PersonFatherName : ""));
            }
        }


        private List<IASData.Enumerable.DataStatus> _SportDataStatus;
        public List<IASData.Enumerable.DataStatus> SportDataStatus
        {
            get
            {
                _SportDataStatus = new List<IASData.Enumerable.DataStatus>();
                if (!string.IsNullOrEmpty(this.PersonProfilePic) && !PersonProfilePic.Contains("nopic"))
                {
                    _SportDataStatus.Add(IASData.Enumerable.DataStatus.HasProfiePic);
                }
                else
                {
                    _SportDataStatus.Add(IASData.Enumerable.DataStatus.NoneProfiePic);
                }

                if (!string.IsNullOrEmpty(this.PersonBirthYear))
                {
                    _SportDataStatus.Add(IASData.Enumerable.DataStatus.HasBirthYear);
                }
                else
                {
                    _SportDataStatus.Add(IASData.Enumerable.DataStatus.NoneBirthYear);
                }

                if (this.PersonIdentityDocument.Any(q => !string.IsNullOrEmpty(q.IdentityDocumentPic)))
                {
                    _SportDataStatus.Add(IASData.Enumerable.DataStatus.HasIdentityDocument);
                }
                else
                {
                    _SportDataStatus.Add(IASData.Enumerable.DataStatus.NoneIdentityDocument);
                }

                return _SportDataStatus;
            }
        }

    }
}
