using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class SalaryDTO
    {
        private string strEmployeeId;
        private string strEmployeeName;
        private string strCardNo;

        private string strWorkingDay;
        private string strAllowenceAmount;
        private string strAdvanceFee;
        private string strArrearFee;
        private string strOverTimeAmount;
        private string strAttendenceFee;
        private string strTaxFee;
        private string strLeaveDay;

        private string strDesignationId;
        private string strDesignationName;
        private string strSalaryProcessTypeId;
        private string strConvenceFee;
        private string strDeductDate;
        private string strDeductYn;
        private string strOverTimeHour;
        private string strAdvanceDeductFee;
        private string strHoldYn;

        private string strTiffinTypeId;
        private string strIncrementTypeId;
        private string strBonusTypeId;
        private string strRecivedDate;



        private string strUnitId;
        private string strCatagoryId;
        private string strSectionId;
        private string strYear;
        private string strMonth;
        private string strCount;
        private string strHeadOfficeId;
        private string strBranchOfficeId;
        private string strUpdateBy;
        private string strTotalTaxFee;
        private string strTaxDeductFee;
        private string strFromYear;
        private string strToYear;
        private string strFoodAllowance;
        private string strFoodDeductFee;
        private string strFromMonth;
        private string strToMonth;
        private string strArrearFeeCash;
        private string strFoodFeeCash;
        private string strAdvanceFeeCash;
        private string strFoodFeeBank;
        private string strApprovedById;
        private string strFirstSalary;
        private string strAdjustmentFee;
        private string strLeaveAmount;
        private string strFromDate;
        private string strToDate;
        private string strBonus;
        private string strEidTypeId;
        private string strSecondBonus;
        private string strIncrementAmount;
        private string strManualIncrement;
        private string strSecondSalary;



        private string strUnitIdFrom;
        private string strUnitIdTo;
        private string strSectionIdFrom;
        private string strSectionIdTo;
        private string strEffectiveDate;
        private string strFileName;
        private string strGrossSalary;
        private string strJoiningDate;
        private string strLoanAmount;
        private string strLedgerPageNo;

        private string strFileSize;
        private string strFileType;
        private string strBranchOfficeTo;
        private string strTranId;
        
        private string strTotalLeave;
        private string strTotalLate;
        private string strGradeId;
        private string strLimitDate;
        private string strPunchingCode;


        private string strLunchDay;
        private string strAbsentDay;
        private string strMonthDay;
        private string strSalaryPercentage;
        private string strChkFivePercent;

        
        private string strPreviousFirstSalary;
        private string strPreviousGrossSalary;

        private string strWithoutArrearYes;
        private string strYearlyIncYesOrNot;

        public string AllowGeneralIncrement { get; set; }
        public string ProposedGrossSalary { get; set; }

        public string Date { get; set; }
        public string LoginEmployee { get; set; }
        public string RoamingId { get; set; }
        public string RoamingTypeId { get; set; }
        public string TimeId { get; set; }
        public string ShiftId { get; set; }
        public string FloorId { get; set; }
        public string SuspensionId { get; set; }
        public string Remarks { get; set; }
        public string TransferId { get; set; }
        public string HomeOfficeId { get; set; }
        public string HomeUnitId { get; set; }
        public string HomeSectionId { get; set; }

        public string VirtualOfficeId { get; set; }
        public string VirtualUnitId { get; set; }
        public string VirtualSectionId { get; set; }
        
        //Asad Added
        public string EarlyDptHour { get; set; }
        public string MediaTypeId { get; set; }
        public string FirstSalaryCurrent { get; set; }
        public int OccurrenceTypeId { get; set; }
        public string GazetteId { get; set; }
        public string ScheduleId { get; set; }
        public string ChkActive { get; set; }
        public string MedicalFee { get; set; }
        public string ExtraFoodFee { get; set; }
        public string BatchNo { get; set; }
        public string Finalized_Yn { get; set; }
        public string IncrementAmount2ndTerm { get; set; }
        public Int32 ManualIncrementAmount { get; set; }
        public bool IsChecked { get; set; }
        public Int32 DetailId { get; set; }
        public Int32 OtAdvanceAmount { get; set; }
        public string MonthlyIncrementYn;
        public string AutoIncrementYn { get; set; }

        public string GradeNo { get; set; }
        public string UnitName { get; set; }
        public string SectionName { get; set; }

        public string UnitGroupId { get; set; }


        public string GradeIdFrom { get; set; }
        public string GradeIdTo { get; set; }

        //public string UnitIdFrom { get; set; }
        //public string UnitIdTo { get; set; }

        //public string SectionIdFrom { get; set; }
        //public string SectionIdTo { get; set; }

        public string DesignationIdFrom { get; set; }
        public string DesignationIdTo { get; set; }

        public string FirstSalaryFrom { get; set; }
        public string FirstSalaryTo { get; set; }

        public string GrossSalaryFrom { get; set; }
        public string GrossSalaryTo { get; set; }
        public string EmployeeTypeId { get; set; }
        public string PartialWorkingDay { get; set; }
        public string BkashYn { get; set; }
        public string IndividualAutoIncrYn { get; set; }

        public string YearlyIncYesOrNot
        {
            get { return strYearlyIncYesOrNot; }
            set { strYearlyIncYesOrNot = value; }
        }
        public string WithoutArrearYes
        {
            get { return strWithoutArrearYes; }
            set { strWithoutArrearYes = value; }
        }
        public string PreviousFirstSalary
        {
            get { return strPreviousFirstSalary; }
            set { strPreviousFirstSalary = value; }
        }

        public string PreviousGrossSalary
        {
            get { return strPreviousGrossSalary; }
            set { strPreviousGrossSalary = value; }
        }

        public string ChkFivePercent
        {
            get { return strChkFivePercent; }
            set { strChkFivePercent = value; }
        }

        public string SalaryPercentage
        {
            get { return strSalaryPercentage; }
            set { strSalaryPercentage = value; }
        }
        public string MonthDay
        {
            get { return strMonthDay; }
            set { strMonthDay = value; }
        }

        public string LunchDay
        {
            get { return strLunchDay; }
            set { strLunchDay = value; }
        }

        public string AbsentDay
        {
            get { return strAbsentDay; }
            set { strAbsentDay = value; }
        }


        public string PunchingCode
        {
            get { return strPunchingCode; }
            set { strPunchingCode = value; }
        }

        public string LimitDate
        {
            get { return strLimitDate; }
            set { strLimitDate = value; }
        }

        public string GradeId
        {
            get { return strGradeId; }
            set { strGradeId = value; }
        }

        private byte[] strbyteFileDocuments;


        public string TotalLeave
        {
            get { return strTotalLeave; }
            set { strTotalLeave = value; }
        }

        public string TotalLate
        {
            get { return strTotalLate; }
            set { strTotalLate = value; }
        }


        public byte[] FileDocuments
        {
            get { return strbyteFileDocuments; }
            set { strbyteFileDocuments = value; }
        }

        public string TranId
        {
            get { return strTranId; }
            set { strTranId = value; }


        }

        public string FileType
        {
            get { return strFileType; }
            set { strFileType = value; }


        }
        public string FileSize
        {
            get { return strFileSize; }
            set { strFileSize = value; }


        }

        public string LedgerPageNo
        {
            get { return strLedgerPageNo; }
            set { strLedgerPageNo = value; }


        }
        public string LoanAmount
        {
            get { return strLoanAmount; }
            set { strLoanAmount = value; }


        }

        public string BranchOfficeTo
        {
            get { return strBranchOfficeTo; }
            set { strBranchOfficeTo = value; }


        }

        public string JoiningDate
        {
            get { return strJoiningDate; }
            set { strJoiningDate = value; }


        }


        public string GrossSalary
        {
            get { return strGrossSalary; }
            set { strGrossSalary = value; }


        }

        public string FileName
        {
            get { return strFileName; }
            set { strFileName = value; }


        }
        public string EffectiveDate
        {
            get { return strEffectiveDate; }
            set { strEffectiveDate = value; }


        }

        public string UnitIdFrom
        {
            get { return strUnitIdFrom; }
            set { strUnitIdFrom = value; }


        }

        public string UnitIdTo
        {
            get { return strUnitIdTo; }
            set { strUnitIdTo = value; }


        }

        public string SectionIdFrom
        {
            get { return strSectionIdFrom; }
            set { strSectionIdFrom = value; }


        }

        public string SectionIdTo
        {
            get { return strSectionIdTo; }
            set { strSectionIdTo = value; }


        }


        public string SecondSalary
        {
            get { return strSecondSalary; }
            set { strSecondSalary = value; }


        }

        public string ManualIncrement
        {
            get { return strManualIncrement; }
            set { strManualIncrement = value; }


        }


        public string IncrementAmount
        {
            get { return strIncrementAmount; }
            set { strIncrementAmount = value; }


        }
        public string SecondBonus
        {
            get { return strSecondBonus; }
            set { strSecondBonus = value; }


        }
        public string EidTypeId
        {
            get { return strEidTypeId; }
            set { strEidTypeId = value; }


        }

        public string Bonus
        {
            get { return strBonus; }
            set { strBonus = value; }


        }
        public string FromDate
        {
            get { return strFromDate; }
            set { strFromDate = value; }


        }

        public string ToDate
        {
            get { return strToDate; }
            set { strToDate = value; }


        }

        public string FirstSalary
        {
            get { return strFirstSalary; }
            set { strFirstSalary = value; }


        }

        public string LeaveAmount
        {
            get { return strLeaveAmount; }
            set { strLeaveAmount = value; }


        }


        public string AdjustmentFee
        {
            get { return strAdjustmentFee; }
            set { strAdjustmentFee = value; }


        }

        public string LeaveDay
        {
            get { return strLeaveDay; }
            set { strLeaveDay = value; }


        }


        public string FoodDeductFee
        {
            get { return strFoodDeductFee; }
            set { strFoodDeductFee = value; }

        }

        public string ApprovedById
        {
            get { return strApprovedById; }
            set { strApprovedById = value; }

        }
        public string FoodFeeBank
        {
            get { return strFoodFeeBank; }
            set { strFoodFeeBank = value; }

        }
        public string FromMonth
        {
            get { return strFromMonth; }
            set { strFromMonth = value; }

        }

        public string ArrearFeeCash
        {
            get { return strArrearFeeCash; }
            set { strArrearFeeCash = value; }

        }

        public string FoodFeeCash
        {
            get { return strFoodFeeCash; }
            set { strFoodFeeCash = value; }

        }
        public string AdvanceFeeCash
        {
            get { return strAdvanceFeeCash; }
            set { strAdvanceFeeCash = value; }

        }
        public string ToMonth
        {
            get { return strToMonth; }
            set { strToMonth = value; }

        }


        public string FoodAllowance
        {
            get { return strFoodAllowance; }
            set { strFoodAllowance = value; }

        }

        public string TotalTaxFee
        {
            get { return strTotalTaxFee; }
            set { strTotalTaxFee = value; }

        }

        public string HoldYn
        {
            get { return strHoldYn; }
            set { strHoldYn = value; }

        }

        public string FromYear
        {
            get { return strFromYear; }
            set { strFromYear = value; }

        }
        public string ToYear
        {
            get { return strToYear; }
            set { strToYear = value; }

        }
        public string TaxDeductFee
        {
            get { return strTaxDeductFee; }
            set { strTaxDeductFee = value; }

        }


        public string RecivedDate
        {
            get { return strRecivedDate; }
            set { strRecivedDate = value; }

        }
        public string EmployeeId
        {
            get { return strEmployeeId; }
            set { strEmployeeId = value; }

        }

        public string EmployeeName
        {
            get { return strEmployeeName; }
            set { strEmployeeName = value; }

        }


        public string CardNo
        {
            get { return strCardNo; }
            set { strCardNo = value; }

        }

        public string WorkingDay
        {
            get { return strWorkingDay; }
            set { strWorkingDay = value; }

        }

        public string AllowenceAmount
        {
            get { return strAllowenceAmount; }
            set { strAllowenceAmount = value; }

        }
        public string TaxFee
        {
            get { return strTaxFee; }
            set { strTaxFee = value; }

        }
        public string AdvanceFee
        {
            get { return strAdvanceFee; }
            set { strAdvanceFee = value; }

        }

        public string ArrearFee
        {
            get { return strArrearFee; }
            set { strArrearFee = value; }

        }

        public string OverTimeAmount
        {
            get { return strOverTimeAmount; }
            set { strOverTimeAmount = value; }

        }

        public string AttendenceFee
        {
            get { return strAdvanceFee; }
            set { strAdvanceFee = value; }

        }


        public string DesginationId
        {
            get { return strDesignationId; }
            set { strDesignationId = value; }

        }

        public string DesginationName
        {
            get { return strDesignationName; }
            set { strDesignationName = value; }

        }

        public string SalaryProcessTypeId
        {
            get { return strSalaryProcessTypeId; }
            set { strSalaryProcessTypeId = value; }

        }
        public string ConvenceFee
        {
            get { return strConvenceFee; }
            set { strConvenceFee = value; }

        }

        public string DeductDate
        {
            get { return strDeductDate; }
            set { strDeductDate = value; }

        }

        public string DeductYn
        {
            get { return strDeductYn; }
            set { strDeductYn = value; }

        }

        public string OverTimeHour
        {
            get { return strOverTimeHour; }
            set { strOverTimeHour = value; }

        }

        public string AdvanceDeductFee
        {
            get { return strAdvanceDeductFee; }
            set { strAdvanceDeductFee = value; }

        }


        public string TiffinTypeId
        {
            get { return strTiffinTypeId; }
            set { strTiffinTypeId = value; }

        }


        public string BonusTypeId
        {
            get { return strBonusTypeId; }
            set { strBonusTypeId = value; }

        }

        public string IncrementTypeId
        {
            get { return strIncrementTypeId; }
            set { strIncrementTypeId = value; }

        }





        public string UnitId
        {
            get { return strUnitId; }
            set { strUnitId = value; }

        }
        public string CatagoryId
        {
            get { return strCatagoryId; }
            set { strCatagoryId = value; }

        }

        public string SectionId
        {
            get { return strSectionId; }
            set { strSectionId = value; }

        }

        public string Year
        {
            get { return strYear; }
            set { strYear = value; }

        }

        public string Month
        {
            get { return strMonth; }
            set { strMonth = value; }

        }
        public string Count
        {
            get { return strCount; }
            set { strCount = value; }

        }
        public string HeadOfficeId
        {
            get { return strHeadOfficeId; }
            set { strHeadOfficeId = value; }

        }

        public string BranchOfficeId
        {
            get { return strBranchOfficeId; }
            set { strBranchOfficeId = value; }

        }

        public string UpdateBy
        {
            get { return strUpdateBy; }
            set { strUpdateBy = value; }

        }
      
    }
}
