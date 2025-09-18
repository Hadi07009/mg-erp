using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class EmployeeDTO
    {

        private string strEmployeeId;
        private string strEmployeeName;
        private string strEmployeeNameBangla;
        private string strEmployeeCode;
        private string strCardNo;
        private string strFatherName;
        private string strMotherName;
        private string strDateOfBirth;
        private string strGenderId;
        private string strMaritalStatusId;
        private string strReligionId;
        private string strBloodGroupId;
        private string strDesignationId;
        private string strDesignationLevelId;
        private string strHusbandName;
        private string strHusbandOccupation;
        private string strPresentAddress;
        private string strPermanentAddress;
        //private string strEmployeePicture;

        //Asad Added
        private string _signature;
        private string _signatureImageType;
        private string _signatureImageName;
        //end


        private string strPicturePath;
        private string strMobileNo;
        private string strPhoneNo;
        private string strEmailAddress;
        private string strUpdateBy;
        private string strUpdateDate;
        private string strProjectCode;
        private string strHeadOfficeId;
        private string strBranchOfficeId;
        private string strCourseId;
        private string strInstituteId;
        private string strSubjectId;
        private string strPassingYear;
        private string strCGPAId;
        private string strOrganizationName;
        private string strWorkingExperience;
        private string strLeaveYear; 
        private string strLeaveMonth;
        private string strLeaveDate;
        private string strLeavingReson;
        private string strGrossSalary;
        private string strJobTypeId;
        private string strEffectiveDate;
        private string strOrderDate;
        private string strDepartmentId;
        private string strUnitId;
        private string strSectionId;
        private string strCatagoryId;
        private string strGradeNo;
        private string strOTAllowYn;
        private string strEmployeeActiveYn;
        private string strStatus;
       
        private string strWorkingDuration;
        private string strYearOfExperience;
        
        private string strJoiningSalary;
        private string strVoterIdCardNo;
        private string strNationaLityId;
        private string strTitleId;
        private string strPaymentTypeId;
        private string strOccurenceTypeId;
        private string strReportingTo;
        private string strShiftId;
        private string strApprovedBY;
        private string strTrainingPeriodId;
        private string strJobLocationId;
        private string strEmployeeTypeId;
        private string strReferenceBy;
        private string strTaxAllowYn;
        private string strDistrictId;
        private string strDivisionId;
        private string strJoiningDate;
        private string strAccountNo;
        private string strPreDesignationId;
        private string strPreDepartmentId;
        private string strFirstSalary;
        private string strOfficeId;
        private string strJobOfficeId;

        private string strFileName;
        private string strFilePath;
        private string strLogCount;
        private string strLogDate;
        private string strLogTime;
        private string strFromDate;
        private string strToDate;
        private string strOfficeIdFrom;
        private string strYear;
        private string strMonth;
        private string strInactiveReason;
        private string strPreSalary;
        private string strInstitueName;
        private string strSubjectName;
        private string strDesignationName;
        private string strSectionName;
        private string strCourseName;
        private string strCGPA;
        private string strJoiningDesignationId;
        private string strEmergencyContactNo;


        //private string strLogInTime;
        //private string strLogOutTime;
        //private string strLunchInTime;
        //private string strLunchOutTime;

        private string strLogInTimeId;
        private string strLogOutTimeId;
        private string strLunchInTimeId;
        private string strLunchInTimeOut;
        private string strAllowanceAmount;
        private string strPunchCode;
        
        private string strFromMonthId;
        private string strToMonthId;
        private string strMsg;


        private string strLogInTime;
        private string strLogOutTime;
        private string strLunchInTime;
        private string strLunchOutTime;
        private string strFinalOutTime;
        private string strFinalInTime;
        private string strIdNo;
        private string strEidTypeId;
        private string strMenuPath;
        private string strSoftId;
        private string strEmpId;
        private string strChkeckYn;
        private string strResignDate;
        private string strConfirmDate;
        private string strResignCasuse;


        private string strFromConfirmDate;
        private string strToConfirmDate;
        private string strLineId;
        private string strIdCardNo;
        private string strProcessId;


        private string strLeaveTypeId;
        private string strRemarks;
        private string strProcessCode;
        private string strDHURange;
        private string strVerificationDate;
        private string strNumberOfCounseling;



        private string strSLNo;
        private string strRequisitionNo;
        private string strProductId;
        private string strLockYn;
        private string strPermissionYn;
        private string strImageType;
        private string strFileSize;

        private string strFromMonth;
        private string strToMonth;
        private string strEidYear;
        private string strAllUnitYn;
        private string strRemark;
        private string strSupplierName;
        private string strAprovedDate;
        private string strAttendenceDate;
        private string strLimitDate;

        private string strShiftTypeId;
        private string strGeneralOutTime;
        private string strHolidayYn;
        private string strHolidayDate;
        private string strTinNo;

        public string HiddenSalary { get; set; }
        public string IncrementLimit { get; set; }
        public string CompanyId { get; set; }
        public string FromYear { get; set; }
        public string Date { get; set; }
        public string ToYear { get; set; }
        public string DutyTypeId { get; set; }
        public string ChangeParam { get; set; }
        public string RosterYn { get; set; }
        public string AttendanceDashBoardId { get; set; }
        public string Present { get; set; }
        public string OutDuty { get; set; }
        public string Recruitment { get; set; }
        public string Detection { get; set; }
        public string OtherDetection { get; set; }
        public string DayOff { get; set; }
        
        public string HoldId { get; set; }
        public string EndDate { get; set; }
        public string StartDate { get; set; }
        public string PhaseId { get; set; }
        public string InsideDay { get; set; }
        public string OutSideDay { get; set; }
        public string FloorId { get; set; }
        public string CacheId { get; set; }
        public string FromCreateDate { get; set; }
        public string ToCreateDate { get; set; }
        public string BankId { get; set; }
        public string VirtualOfficeId { get; set; }
        public string VirtualUnitId { get; set; }
        public string VirtualSectionId { get; set; }


        public string AttendanceBonus { get; set; }
        public string WorkingDay { get; set; }
        public string SittingBranchOfficeId { get; set; }

        public string StatusId { get; set; }
        public string UnitGroupId { get; set; }
        public string DisplayOrder { get; set; }
        public byte[] EmployeePic { get; set; }
        public byte[] Thumbnail { get; set; }
        public string BirthRegistrationNo { get; set; }
        public string BKashNo { get; set; }
        public string RocketNo { get; set; }
        public string NIDNo { get; set; }
        public string PresentAddressBangla { get; set; }
        public string PermanentAddressBangla { get; set; }
        public string FatherNameBangla { get; set; }
        public string MotherNameBangla { get; set; }
        public string DayId { get; set; }
        public decimal MappingId { get; set; }
        public string ActiveYn { get; set; }
        public string MigrationYn { get; set; }
        public string RejectYn { get; set; }
        
        public string RecognizeYn { get; set; }
        public string ApproveYn { get; set; }
        //public string CacheId { get; set; }
        public string PaymentYn { get; set; }

        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string PromotionYear { get; set; }
        public string GradeId { get; set; }

        public string GroupOfficeNameEng { get; set; }
        
        //public string HeadOfficeId { get; set; }
        public string HeadOfficeName { get; set; }
        public string HeadOfficeAddress { get; set; }

        //public string BranchOfficeId { get; set; }
        public string BranchOfficeName { get; set; }
        public string BranchOfficeAddress { get; set; }
        public string UnitName { get; set; }
        public string ShiftName { get; set; }
        public string HolidayName { get; set; }

        public string ShiftEffectDate { set; get; }
        public string HolidayEffectDate { set; get; }
        public string IssueDate { set; get; }
        public string FinalOutDate { get; set; }
        public string SkillLevelName { set; get; }
        public string SkillLevelId { get; set; }
        public decimal SkillId { get; set; }
        public string grade_number { get; set; }
        public string TinNo
        {
            get { return strTinNo; }
            set { strTinNo = value; }

        }
        public string HolidayDate
        {
            get { return strHolidayDate; }
            set { strHolidayDate = value; }

        }

        public string HolidayYn
        {
            get { return strHolidayYn; }
            set { strHolidayYn = value; }

        }
        public string GeneralOutTime
        {
            get { return strGeneralOutTime; }
            set { strGeneralOutTime = value; }

        }
        public string ShiftTypeId
        {
            get { return strShiftTypeId; }
            set { strShiftTypeId = value; }

        }

        public string LimitDate
        {
            get { return strLimitDate; }
            set { strLimitDate = value; }

        }

        public string AttendenceDate
        {
            get { return strAttendenceDate; }
            set { strAttendenceDate = value; }

        }

        public string AprovedDate
        {
            get { return strAprovedDate; }
            set { strAprovedDate = value; }

        }
        public string SupplierName
        {
            get { return strSupplierName; }
            set { strSupplierName = value; }

        }

        public string Remark
        {
            get { return strRemark; }
            set { strRemark = value; }

        }
        public string AllUnitYn
        {
            get { return strAllUnitYn; }
            set { strAllUnitYn = value; }

        }

        public string EidYear
        {
            get { return strEidYear; }
            set { strEidYear = value; }

        }


        public string FromMonth
        {
            get { return strFromMonth; }
            set { strFromMonth = value; }

        }


        public string ToMonth
        {
            get { return strToMonth; }
            set { strToMonth = value; }

        }

        public string FileSize
        {
            get { return strFileSize; }
            set { strFileSize = value; }

        }


        public string ImageType
        {
            get { return strImageType; }
            set { strImageType = value; }

        }

        public string PermissionYn
        {
            get { return strPermissionYn; }
            set { strPermissionYn = value; }

        }
        public string LockYn
        {
            get { return strLockYn; }
            set { strLockYn = value; }

        }

        public string ProductId
        {
            get { return strProductId; }
            set { strProductId = value; }

        }
        public string SLNo
        {
            get { return strSLNo; }
            set { strSLNo = value; }

        }

        public string RequisitionNo
        {
            get { return strRequisitionNo; }
            set { strRequisitionNo = value; }

        }


        public string NumberOfCounseling
        {
            get { return strNumberOfCounseling; }
            set { strNumberOfCounseling = value; }

        }

        public string VerificationDate
        {
            get { return strVerificationDate; }
            set { strVerificationDate = value; }

        }
        public string DHURange
        {
            get { return strDHURange; }
            set { strDHURange = value; }

        }
        public string ProcessCode
        {
            get { return strProcessCode; }
            set { strProcessCode = value; }

        }

        public string LeaveTypeId
        {
            get { return strLeaveTypeId; }
            set { strLeaveTypeId = value; }

        }

        public string Remarks
        {
            get { return strRemarks; }
            set { strRemarks = value; }

        }


        public string ProcessId
        {
            get { return strProcessId; }
            set { strProcessId = value; }

        }

        public string IdCardNo
        {
            get { return strIdCardNo; }
            set { strIdCardNo = value; }

        }

        public string LineId
        {
            get { return strLineId; }
            set { strLineId = value; }

        }

        public string FromConfirmDate
        {
            get { return strFromConfirmDate; }
            set { strFromConfirmDate = value; }

        }

        public string ToConfirmDate
        {
            get { return strToConfirmDate; }
            set { strToConfirmDate = value; }

        }

        public string ResignCasuse
        {
            get { return strResignCasuse; }
            set { strResignCasuse = value; }

        }

        public string ConfirmDate
        {
            get { return strConfirmDate; }
            set { strConfirmDate = value; }

        }
        public string ChkeckYn
        {
            get { return strChkeckYn; }
            set { strChkeckYn = value; }

        }

        public string ResignDate
        {
            get { return strResignDate; }
            set { strResignDate = value; }

        }

        public string EmpId
        {
            get { return strEmpId; }
            set { strEmpId = value; }

        }

        public string SoftId
        {
            get { return strSoftId; }
            set { strSoftId = value; }

        }
        public string MenuPath
        {
            get { return strMenuPath; }
            set { strMenuPath = value; }

        }

        public string EidTypeId
        {
            get { return strEidTypeId; }
            set { strEidTypeId = value; }

        }
        public string IdNo
        {
            get { return strIdNo; }
            set { strIdNo = value; }

        }
        public string LogInTime
        {
            get { return strLogInTime; }
            set { strLogInTime = value; }

        }


        public string LogOutTime
        {
            get { return strLogOutTime; }
            set { strLogOutTime = value; }

        }

        public string LunchInTime
        {
            get { return strLunchInTime; }
            set { strLunchInTime = value; }

        }

        public string LunchOutTime
        {
            get { return strLunchOutTime; }
            set { strLunchOutTime = value; }

        }

        public string FinalOutTime
        {
            get { return strFinalOutTime; }
            set { strFinalOutTime = value; }

        }

        public string FinalInTime
        {
            get { return strFinalInTime; }
            set { strFinalInTime = value; }

        }









        public string Msg
        {
            get { return strMsg; }
            set { strMsg = value; }

        }

        public string ToMonthId
        {
            get { return strToMonthId; }
            set { strToMonthId = value; }

        }

        public string FromMonthId
        {
            get { return strFromMonthId; }
            set { strFromMonthId = value; }

        }

        public string CourseName
        {
            get { return strCourseName; }
            set { strCourseName = value; }

        }


        public string PunchCode
        {
            get { return strPunchCode; }
            set { strPunchCode = value; }

        }

        public string AllowanceAmount
        {
            get { return strAllowanceAmount; }
            set { strAllowanceAmount = value; }

        }

        public string EmergencyContactNo
        {
            get { return strEmergencyContactNo; }
            set { strEmergencyContactNo = value; }

        }
        public string JoiningDesignationId
        {
            get { return strJoiningDesignationId; }
            set { strJoiningDesignationId = value; }

        }

        public string CGPA
        {
            get { return strCGPA; }
            set { strCGPA = value; }

        }


        public string DesignationName
        {
            get { return strDesignationName; }
            set { strDesignationName = value; }

        }
        public string SectionName
        {
            get { return strSectionName; }
            set { strSectionName = value; }

        }
        public string SubjectName
        {
            get { return strSubjectName; }
            set { strSubjectName = value; }

        }
        public string InstitueName
        {
            get { return strInstitueName; }
            set { strInstitueName = value; }

        }
        public string PreSalary
        {
            get { return strPreSalary; }
            set { strPreSalary = value; }

        }
        public string Year
        {
            get { return strYear; }
            set { strYear = value; }

        }

        public string InactiveReason
        {
            get { return strInactiveReason; }
            set { strInactiveReason = value; }

        }


        public string Month
        {
            get { return strMonth; }
            set { strMonth = value; }

        }

        public string OfficeIdFrom
        {
            get { return strOfficeIdFrom; }
            set { strOfficeIdFrom = value; }

        }


        public string EmployeeId
        {
            get { return strEmployeeId;}
            set { strEmployeeId = value; } 

        }

        public string OfficeId
        {
            get { return strOfficeId; }
            set { strOfficeId = value; }

        }
        public string JobOfficeId
        {
            get { return strJobOfficeId; }
            set { strJobOfficeId = value; }

        }

        public string JoiningDate
        {
            get { return strJoiningDate; }
            set { strJoiningDate = value; }

        }

        public string FirstSalary
        {
            get { return strFirstSalary; }
            set { strFirstSalary = value; }

        }


        public string AccountNo
        {
            get { return strAccountNo; }
            set { strAccountNo = value; }

        }
        public string EmployeeName
        {
            get { return strEmployeeName; }
            set { strEmployeeName = value ;} 


        }
        public string PreDesignationId
        {
            get { return strPreDesignationId; }
            set { strPreDesignationId = value; }


        }

        public string PreDepartmentId
        {
            get { return strPreDepartmentId; }
            set { strPreDepartmentId = value; }


        }

        public string EmployeeNameBangla
        {
            get { return strEmployeeNameBangla; }
            set { strEmployeeNameBangla = value; } 

        }

        public string EmployeeCode
        {
            get { return strEmployeeCode ;}
            set { strEmployeeCode = value ;} 

        }

        public string CardNo
        {

            get { return strCardNo;}
            set { strCardNo = value ;} 
        
        }

        public string FatherName
        {
            get { return strFatherName;}
            set { strFatherName = value; } 

        }
        public string MotherName
        {

            get { return strMotherName;}
            set { strMotherName = value ;}

        }
        public string DateOfBirth
        {
            get { return strDateOfBirth; }
            set { strDateOfBirth = value; } 

        }


        public string GenderId
        {
            get { return strGenderId;}
            set { strGenderId = value ;} 

        }
        public string MaritalStatusId
        {
            get { return strMaritalStatusId; }
            set{strMaritalStatusId = value ;} 
        }

        public string ReligionId
        {
            get{return strReligionId;}
            set{strReligionId = value ;} 

        }
        public string BloodGroupId
        {
            get{return strBloodGroupId;}
            set{strBloodGroupId = value;} 

        }
        public string DesignationId
        {
            get {return strDesignationId;}
            set{strDesignationId = value ;} 

        }

        public string DesignationLevelId
        {

            get{return strDesignationLevelId;}
            set{strDesignationLevelId = value ;} 
        }

        public string HusbandName
        {
            get {return strHusbandName;}
            set{strHusbandName = value ;} 

        }

        public string HusbandOccupation
        {
            get{return strHusbandOccupation;}
            set{strHusbandOccupation = value;} 

        }

        public string PresentAddress
        {
            get{return strPresentAddress;}
            set{strPresentAddress = value;} 

        }
        public string PermanentAddress
        {
            get{return strPermanentAddress;} 
            set {strPermanentAddress = value; }

        }

        //public string EmployeePicture
        //{
        //    get{return strEmployeePicture;}
        //    set{strEmployeePicture = value ;} 
        //}

        //Asad Added
        public string Signature
        {
            get { return _signature; }
            set { _signature = value; }
        }

        public string SignatureImageType
        {
            get { return _signatureImageType; }
            set { _signatureImageType = value; }
        }

        public string SignatureImageName
        {
            get { return _signatureImageName; }
            set { _signatureImageName = value; }
        }

        //End
        public string PicturePath
        {

            get{return strPicturePath;}
            set{strPicturePath = value ;} 
        }

        
        public string MobileNo
        {
            get{return strMobileNo;} 
            set {strMobileNo = value ;}
        }

        public string PhoneNo
        {
            get{return strPhoneNo;}
            set{strPhoneNo = value ;} 
        }
        public string EmailAddress
        {
            get{return strEmailAddress;} 
            set{strEmailAddress = value;}
        }
        public string UpdateBy
        {
            get{return strUpdateBy;}
            set{strUpdateBy = value;} 

        }
        public string UpdateDate
        {
            get {return strUpdateDate;}
            set {strUpdateDate = value ;}

        }
        public string ProjectCode
        {
            get{return strProjectCode;}
            set{strProjectCode = value ;} 
        }
        public string HeadOfficeId
        {
            get{return strHeadOfficeId;}
            set{strHeadOfficeId = value ;} 

        }
        public string BranchOfficeId
        {
            get{return strBranchOfficeId;}
            set { strBranchOfficeId = value; } 

        }
        public string CourseId
        {
            get {return strCourseId;}
            set{strCourseId = value;} 

        }
        public string InstituteId
        {
            get{return strInstituteId;}
            set{strInstituteId = value ;} 

        }

        public string SubjectId
        {
            get{return strSubjectId;}
            set{strSubjectId = value ;} 

        }
        public string PassingYear
        {
            get{return strPassingYear;}
            set{strPassingYear = value ;} 
           
        }
        public string CGPAId
        {
            get{return strCGPAId;}
            set{strCGPAId = value;} 

        }
        public string OrganizationName
        {
            get{return strOrganizationName;} 
            set{strOrganizationName = value ;}

        }
        public string WorkingExperience
        {
            get {return strWorkingExperience;}
            set{strWorkingExperience = value ;} 

        }
        public string LeaveYear
        {
            get{return strLeaveYear;}
            set{strLeaveYear = value ;} 

        }
        public string LeaveMonth
        {
            get{return strLeaveMonth ;}
            set{strLeaveMonth = value ;} 

        }
        public string LeaveDate
        {
            get{return strLeaveDate;} 
            set{strLeaveDate = value;} 

        }
        public string LeavingReson
        {
            get{return strLeavingReson;}
            set {strLeavingReson = value;}

        }
        public string GrossSalary
        {
            get{return strGrossSalary;}
            set {strGrossSalary = value ;}

        }
        public string JobTypeId
        {
            get {return strJobTypeId;}
            set{strJobTypeId = value ;} 
        }

        public string EffectiveDate
        {
            get{return strEffectiveDate;}
            set{strEffectiveDate = value; } 

        }
        public string OrderDate
        {
            get {return strOrderDate;}
            set{strOrderDate = value; } 
            

        }
        public string DepartmentId
        {
            get{return strDepartmentId;} 
            set {strDepartmentId = value ;}

        }
        public string UnitId
        {
            get{return strUnitId;}
            set{strUnitId = value;} 

        }
        public string SectionId
        {
            get{return strSectionId;} 
            set{strSectionId = value; } 

        }
        public string CatagoryId
        {
            get{return strCatagoryId;}
            set{strCatagoryId = value ;} 

        }
        public string GradeNo
        {
            get{return strGradeNo;}
            set{strGradeNo = value ;} 

        }
        public string OTAllowYn
        {
            get{return strOTAllowYn;} 
            set{strOTAllowYn = value ;} 

        }
        public string EmployeeActiveYn
        {
            get{return strEmployeeActiveYn;}
            set{strEmployeeActiveYn = value ;} 

        }
        public string Status
        {
            get{return strStatus;}
            set{strStatus = value ;} 

        }

        public string WorkingDuration
        {
            get{return strWorkingDuration;}
            set{strWorkingDuration = value ;} 

        }
        public string YearOfExperience
        {
            get {return strYearOfExperience;}
            set{strYearOfExperience = value ;} 

        }

        public string JoiningSalary
        {
            get {return strJoiningSalary;}
            set{strJoiningSalary = value ;} 

        }
        public string VoterIdCardNo
        {
             get {return strVoterIdCardNo;}
            set{strVoterIdCardNo = value ;} 

        }

        public string NationaLityId
        {
            get { return strNationaLityId; }
            set { strNationaLityId = value; }

        }
        public string TitleId
        {
            get { return strTitleId; }
            set { strTitleId = value; }

        }

        public string PaymentTypeId
        {
            get { return strPaymentTypeId; }
            set { strPaymentTypeId = value; }

        }

        public string OccurenceTypeId
        {
            get { return strOccurenceTypeId; }
            set { strOccurenceTypeId = value; }

        }

        public string ReportingTo
        {
            get { return strReportingTo; }
            set { strReportingTo = value; }

        }

        public string ShiftId
        {
            get { return strShiftId; }
            set { strShiftId = value; }

        }

        public string ApprovedBY
        {
            get { return strApprovedBY; }
            set { strApprovedBY = value; }

        }

        public string TrainingPeriodId
        {
            get { return strTrainingPeriodId; }
            set { strTrainingPeriodId = value; }

        }

        public string JobLocationId
        {
            get { return strJobLocationId; }
            set { strJobLocationId = value; }

        }

        public string EmployeeTypeId
        {
            get { return strEmployeeTypeId; }
            set { strEmployeeTypeId = value; }

        }

        public string ReferenceBy
        {
            get { return strReferenceBy; }
            set { strReferenceBy = value; }

        }

        public string TaxAllowYn
        {
            get { return strTaxAllowYn; }
            set { strTaxAllowYn = value; }

        }

        public string DistrictId
        {
            get { return strDistrictId; }
            set { strDistrictId = value; }

        }

        public string DivisionId
        {
            get { return strDivisionId; }
            set { strDivisionId = value; }

        }


        public string FileName
        {
            get { return strFileName; }
            set { strFileName = value; }

        }

        public string FilePath
        {
            get { return strFilePath; }
            set { strFilePath = value; }

        }

        public string LogCount
        {
            get { return strLogCount; }
            set { strLogCount = value; }

        }

        public string LogDate
        {
            get { return strLogDate; }
            set { strLogDate = value; }

        }

        public string LogTime
        {
            get { return strLogTime; }
            set { strLogTime = value; }

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

        public string ScheduleID { get; set; }
        public string BankIdAlternet { get; set; }
        public string AccountNoAlter { get; set; }
        public string NoChildPresent { get; set; }
        public string NoChildJoin { get; set; }
    }
}
