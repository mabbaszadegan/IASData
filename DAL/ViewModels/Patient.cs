using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class Patient
    {
        [Key]
        [Column("PatientId")]
        public Int64 PatientId { get; set; }


        [MaxLength(10)]
        [Column("PatientCode")]
        public string PatientCode { get; set; }

        //PersonFilingDate
        PersonFilingDateSolar
        PersonFilingName
        //PersonCoveredDate
        //PersonCoveredDateSolar
        //PersonCoveredDesc



        [MaxLength(4)]
        [Column("PersonBirthYear")]
        public string PersonBirthYear { get; set; }


        [MaxLength(2)]
        [Column("PersonBirthMonth")]
        public string PersonBirthMonth { get; set; }


        [MaxLength(2)]
        [Column("PersonBirthDay")]
        public string PersonBirthDay { get; set; }



        //PersonMonthlyIncome
        //PersonMonthlyExpense

        [MaxLength(2000)]
        [Column("PersonDesc")]
        public string PersonDesc { get; set; }


        //PersonCellPhone1
        //PersonCellPhone2
        //BankId
        //PersonBankAccount
        //PersonBankCard
        //PersonBankBranch
        //PersonShirtSize
        //PersonPantSize
        //PersonShoesSize
        //PersonHeight
        //PersonWeight
        //PersonBMIIndex
        //PersonZiped
        //PersonHasPassport
        //PersonHasCard
        //PersonLeavedFamily
        //PersonLeavedFamilyDateSolar
        //PersonLeavedFamilyDate
        //PersonLeavingHouseCauseId
        //PersonLeavingHouseCauseDesc
        //PersonLeavingHouseDesc
        //PersonAddress
        //PersonAddressZiped
        //PersonLeavedEducation
        //PersonIsWorkedChild
        //PersonHasInjectionCard
        //PersonGetBlueCard
        [Column("PersonCanTraveling")]
        public bool PersonCanTraveling { get; set; }

        [Column("PersonTravelingDesc")]
        public string PersonTravelingDesc { get; set; }


        //PersonSupportedByOtherNGO
        //PersonSupportedByOtherNGODesc
        //PersonSupportedByIAS
        //SupportingOrganId
        [Column("DepartmentId")]
        public int DepartmentId { get; set; }


        //PersonStatusId
       

        //EducationTypeId
        //EducationFieldId
        //EducationStatusId
        //EducationDesc
       


        //MigrateDuration
       
        //PersonLivelihood
        //JobStatusId
        //JobId
        //JobDesc
        //JobSalary
        //ChildMarriageCauseId
        //PersonHasChildMarriage
        //PersonChildMarriageDesc
       
        //HealthTypeId
        //DrugHistoryId
        //DrugWithdrawalHistoryId
        //DrugStatusId
        [Column("BloodTypeId")]
        public int? BloodTypeId { get; set; }

        
        //InsuranceTypeId
        //InsuranceDesc
        //SportTarget
        //InsertUserId
        //InsertTime
        //UpdateUserId
        //UpdateTime
    }
}
