//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class PersonnelLog
    {
        public int PersonnelLogId { get; set; }
        public int PersonnelId { get; set; }
        public string PersonnelCode { get; set; }
        public string PersonnelFirstName { get; set; }
        public string PersonnelLastName { get; set; }
        public string PersonnelFatherName { get; set; }
        public string PersonnelNationalCode { get; set; }
        public string PersonnelZiped { get; set; }
        public string PersonnelIdentityNo { get; set; }
        public string PersonnelBirthDateSolar { get; set; }
        public Nullable<System.DateTime> PersonnelBirthDate { get; set; }
        public string PersonnelBirthPlace { get; set; }
        public string PersonnelPhone { get; set; }
        public string PersonnelCellPhone { get; set; }
        public Nullable<int> PersonnelRank { get; set; }
        public string PersonnelHireDateSolar { get; set; }
        public Nullable<System.DateTime> PersonnelHireDate { get; set; }
        public string PersonnelDesc { get; set; }
        public string PersonnelAddress { get; set; }
        public string PersonnelAddressZiped { get; set; }
        public string PersonnelCellPhone1 { get; set; }
        public string PersonnelCellPhone2 { get; set; }
        public string PersonnelHousePhone { get; set; }
        public string PersonnelWorkPhone { get; set; }
        public string PersonnelEmailAddress { get; set; }
        public string PersonnelWebAdderess { get; set; }
        public string PersonnelActivityInSosapoverty { get; set; }
        public string PersonnelActivityInNGO { get; set; }
        public string PersonnelJobDesc { get; set; }
        public string PersonnelSkillDesc { get; set; }
        public bool PersonnelHasInternetAccess { get; set; }
        public bool PersonnelIsActive { get; set; }
        public bool PersonnelHasEquipment { get; set; }
        public Nullable<int> ActivityTypeId { get; set; }
        public Nullable<int> EquipmentTypeId { get; set; }
        public int DepartmentId { get; set; }
        public Nullable<int> MaritalStatusId { get; set; }
        public Nullable<int> JobStatusId { get; set; }
        public Nullable<int> JobId { get; set; }
        public Nullable<int> EducationFieldId { get; set; }
        public Nullable<int> EducationTypeId { get; set; }
        public int GenderId { get; set; }
        public Nullable<int> TradingTypeId { get; set; }
        public Nullable<int> NationalityId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> ProvinceId { get; set; }
        public Nullable<int> CityId { get; set; }
        public int InsertUserId { get; set; }
        public System.DateTime InsertTime { get; set; }
        public Nullable<int> UpdateUserId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
    
        public virtual Personnel Personnel { get; set; }
    }
}
