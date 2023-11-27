using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class LookUpDTO
    {
        
        private string strJobId;
        private string strJobTypeCode;
        private string strJobName;
        private string strBuyerId;
        private string strBuyerType;
        private string strBuyerTypeId;
        private string strBuyerTypeCode;
        private string strBuyerName;
        private string strCGPAId;
        private string strCGPACode;
        private string strCGPACodeName;
        private string strColorId;
        private string strColorTypeCode;
        private string strColorName;
        private string strCountryId;
        private string strCountryCode;
        private string strCountryNameBng;
        private string strCountryNameEng;
        private string strCourseId;
        private string strCourseCode;
        private string strCourseName;
        private string strDesignationId;
        private string strDesignationCode;
        private string strDesignationNameBng;
        private string strDesignationNameEng;
        private string strCatagoryId;
        private string strCatagoryCode;
        private string strCatagoryNameBng;
        private string strCatagoryNameEng;
        private string strGenderId;
        private string strGenderName;
        private string strHolidayId;
        private string strHolidayCode;
        private string strInstituteId;
        private string strInstituteCode;
        private string strInstitueName;
      
        private string strMaritalStatusId;
        private string strMaritalStatusCode;
        private string strMaritalStatusName;
        private string strReligionId;
        private string strReligionCode;
        private string strReligionName;
        private string strSalaryId;
        private string strSalaryTypeCode;
        private string strSalaryTypeName;
        private string strSectionId;
        private string strSectionCode;
        private string strSectionNameEng;
        private string strSectionNameBng;
        private string strShiftId;
        private string strShiftCode;
        private string strShiftName;
        private string strSubjectId;
        private string strSubjectCode;
        private string strSubjectName;
        private string strUnitId;
        private string strUnitCode;
        private string strUnitName;
        private string strUnitNameBangla;
        
        private string strYear;
        private string strMonth;

        private string strBloodGroupId;
        private string strBloodGroupName;

        private string strHeadOfficeId;
        private string strHeadOfficeName;
        private string strHeadOfficeNameBangla;
        private string strHeadOfficeMobileNo;
        private string strHeadOfficePhoneNo;
        private string strHeadOfficeFaxNo;
        private string strFromYear;
        private string strToYear;



        private string strDepartmentId;
        private string strDepartmentNameEng;
        private string strDepartmentNameBng;
        private string strDataUploadDir;

        private string strItemNo;
        private string strShiftNameBng;
        private string strShiftNameEng;
        private string strVersionCode;
        private string strVersionId;
        private string strVersionName;
        
        private string strEidId;
        private string strEidYear;
        private string strEidDate;
        private string strEidName;
       
        private string strBranchOfficeName;
        private string strBranchOfficeAddress;
        private string strHeadOfficeAddress;
        private string strBranchOfficeId;
        private string strUpdateBy;

        private string strFromMonth;
        private string strToMonth;
        private string strAttendenceDate;

        private string strEffectId;
        private string strEffectDate;
        private string strPercentAmount;
        private string strGradeId;
        private string strGradeNo;
        private string strFromDate;
        private string strToDate;
        private string strEidTypeId;
        private string strLeaveId;
      
        private string strMaxAllow;
        private string strLeaveTypeId;
        private string strSalaryDay;

        private string strSupervisorId;
        private string strSupervisorName;
        private string strTransferMsg;
        private string strTaxEntryPermission;
        
        private string strSoftName;
        private string strFebricConstructionId;
        private string strFebricConstructionName;
        private string strFabricId;
        private string strFabricName;

        private string strImportId;
        private string strImportName;
        private string strStoreId;
        private string strStoreName;
        private string strSupplierTypeId;
        private string strSupplierType;

        private string strProcessId;
        private string strProcessName;
        private string strLineId;
        private string strLineName;
        
        private string strTopId;
        private string strTopName;
        private string strBottomId;
        private string strBottomName;

        private string strAuxiliaryProcessId;
        private string strAuxiliaryProcessName;
        private string strProcessTime;
        private string strHolidayStartDate;
        private string strHolidayEndDate;
        private string strHolidayTypeId;
        
        private string strContactNo;
        private string strEmailAddresss;
        private string strAddress;
        private string strActiveYn;

        private string strBrandId;
        private string strBrandName;
        private string strCurrencyId;
        private string strCurrencyName;
        
        private string strThreadId;
        private string strThreadCount;
        private string strWhitePrice;
        private string strColorPrice;
        private string strSupplierId;
        
        private string strFebricName;
        private string strArtNo;
        private string strBlance;
        private string strProgrammeId;
        private string strFrontCategoryId;
        private string strFrontCategoryName;
        private string strTargetValue;
        private string strAttendenceYn;
        private string strSubCatagoryName;
        
        private string strStyleId;
        private string strStyleName;

        private string strHangerId;
        private string strHangerSize;
        private string strHangerRate;
        private string strParticularName;

        private string strPolyBagId;
        private string strPolyBagWidht;
        private string strPolyBagHeight;
        private string strPolyBagLength;
        private string strPolyBagRate;

        private string strStichLength;
        private string strHigestCapactiy;
        private string strEmployeeId;
        private string strEmployeeName;
        private string strCardNo;
        private string strDesignation;

        private string strSparePartId;
        private string strSparePartName;
        private string strSparePartNo;

        private string strSparePartCategoryId;
        private string strSparePartCategoryName;
        private string strSparePartCategoryNo;
        private string strQuantityPerEnginee;

        private string strEquipmetId;
        private string strEquipmentName;
        private string strMachineId;
        private string strMachineName;

        private string strProgrammeName;
        private string strProcessCode;
        private string strArtId;

        private string strItemId;
        private string strItemName;
        private string strCompanyId;
        private string strCompanyName;

        private string strVendorId;
        private string strVendorName;
        private string strVendorAddress;
        private string strPhoneNo;
        
        private string strBankId;
        private string strBankName;
        private string strAccountNo;
        private string strSwiftCode;
        
        private string strManufactureId;
        private string strManufactureName;
        private string strOfficeAddress;
        private string strFactoryAddress;
        
        private string strShipId;
        private string strShipName;
        private string strShipTypeId;
        private string strShipTypeName;

        private string strPaymentTermId;
        private string strPaymentDay;
        private string strMedicalFee;
        private string strConvenceFee;

        private string strFoodFee;
        private string strExtraFoodFee;
        private string strTiffinFee;
        private string strWorkingDay;

        private string strProductId;
        private string strProductName;
        private string strTotalOperator;
        private string strOrderDate;
        
        //Upload files
        private string strFileName;
        private string strFileExtension;
        private string strFilePath;
        private string strDataFile;
        private string strFileSalaryYear;
        private string strFileSalaryMonth;
        private byte[] strFileDocuments;
        
        //Branch Office Info
        private string strHeadOfficeIdNo;
        private string strBranchOfficeIdNo;
        private string strBranchOfficeNameBng;
        private string strBranchOfficeMobileNo;
        private string strBranchOfficePhoneNo;
        private string strBranchOfficeFaxNo;
        
        //Product Info
        private string strProductTranId;
       
        private string strDeviceName;
        private string strDevicePrice;
        public string FloorId;
        public string CashPaymenyYn { set; get; }


        public string ProposedDesignationId { set; get; }
        public string AccountRegistrationFee { set; get; }
        public string OtDeductionHour { set; get; }
        public string OtDeductionMinute { set; get; }
        public string RuleId { set; get; }
        public string ProposalLockYn { set; get; }
        public string ActivityLockYn { set; get; }
        public string SetupId { set; get; }
        public string ProposalDate { set; get; }
        public string LockYn { set; get; }
        public string PhaseId { set; get; }
        public string PromotionMonth { set; get; }
        public string PermissionId { set; get; }
        public string TiffinCrossOverTime { set; get; }
        //TiffinCrossOverTime
        private string strRequisitionDate;
        private string strQuantity;
        private string strDevicesTotalPrice;
        private string strShipAddress;
        private string strEmailAddress;
        private string strRequisitionQuantity;
        private string strFileSize;
        private string strEmployeePass;
        private string strSoftId;
        private string strMenuId;
        private string strMenuName;
        private string strMenuPath;

        public string strSeasonId;
        public string strSeasonName;

        private string strDistrictId;
        private string strDistrictName;

        private string strNationalityId;
        private string strNationalityName;

        private string strJobTypeId;
        private string strJobTypeName;

        private string strJobLocationId;
        private string strJobLocationName;

        private string strEmployeeTypeId;
        private string strEmployeeTypeName;

        private string strTrainingPeriodId;
        private string strTrainingPeriodName;

        private string strOccurenceTypeId;
        private string strOccurenceTypeName;

        private string strPaymentTypeId;
        private string strPaymentTypeName;
        private string strPONo;
        private string strStyleNo;
        private string strBloodGroupCode;

        private string strSupplierName;
        private string strSupplierAddress;
        private string strMobileNo;
        private string strTelephoneNo;
        private string strFaxNo;
        private string strMailAddress;
        private string strIssuedBy;
        private string strOfficeName;
        private string strOfficeId;
        private string strReceivedBy;
        private string strTranShipmentId;
        private string strTranShipmentName;
        private string strPaymentModeId;
        private string strPaymentModeName;
        private string strPartShipmentId;
        private string strPartShipmentName;
        private string strLeaveName;
        private string strHolidayName;
        private string strPoUnitId;
        private string strPoUnitName;


        private string strFromMonthId;
        private string strToMonthId;
        private string strArrearBonusId;
        private string strTotalMonth;
        private string strPaymentDate;
        private string strSalaryMonthId;

        private string strBuyerShortName;
        private string strBuyerFullName;

        private string strColorShortName;
        private string strColorFullName;
        private string strProductionUnitId;
        private string strSalaryUnitId;
        private string strPOTypeName;
        private string strPOTypeId;
        private string strProductionLineId;
        private string strProductionLineName;
        private string strSalaryUnitName;
        private string strStyleDescription;
        private string strToleranceId;
        private string strTolerancePercentage;

        private string strPOId;
        private string strPODate;



        private string strSewingDefectEntryId;
        private string strsewingDefectEntryName;

        private string strAddDirtyStainEntryId;
        private string strAddDirtyStainEntryName;
        private string strAestheticDefectId;
        private string strAestheticDefectName;
        private string strLimitDate;
        private string strMenuPosition;

        private string strMsg;
        private string strTaxDate;
        private string strGrossSalary;
        private string strTreadSupplierId;
        private string strTreadSupplierName;


        private string strInTime;
        private string strOutTime;
        private string strLunchInTime;
        private string strLunchOutTime;
        private string strGeneralOutTime;


        private string strFabricSymbolicName;
        private string strSizeName;


        private string strBarcodeNumber;
        private string strBarcodeNumberCheck;



        private string strPoNo;
        private string strOrderQty;


        private string strShipQty;
        private string strCouttonQry;
        private string strSizeNameId;
        private string strSizeWisePackingQTY;
        private string strCRDDate;
        private string strPackingDate;
        private string strTotalOrderQTY;
        private string strTotalShipQTY;
        private string strTotalCuttonQTY;

        private string strUnitGroupId;

        public string BINNo { set; get; }
        public string SizeId { set; get; }
        public string CartoonId { set; get; }
        public string CartoonSize { set; get; }
        public string CartoonQuantity { set; get; }
        public string ProductQuantityPerCartoon { set; get; }
        public string ProductQuantity { set; get; }

        public string ScheduleId { set; get; }
        public int lock_id { get; set; }

        public decimal ShiftConfigurationId { set; get; }
        //public decimal ShiftId { set; get; }

        public string PunchStartTime { set; get; }
        public string LoginStartTime { set; get; }
        public decimal LoginGraceTime { set; get; }
        public string LoginEndTime { set; get; }

        //public string LunchOutTime { set; get; }
        //public string LunchInTime { set; get; }

        public string LunchOutStartTime { set; get; }
        public string LunchOutEndTime { set; get; }
        public string LunchInStartTime { set; get; }
        public string LunchInEndTime { set; get; }

        public string LogoutStratTime { set; get; }
        public string LogoutTime { set; get; }
        public string PunchEndTime { set; get; }

        public string EffectiveDate { set; get; }
        //public string ActiveYn { set; get; }

        public string CreateBy { set; get; }
        public string CreateDate { set; get; }
        public string EearlyOtStartTime { set; get; }

        public decimal RosterId { get; set; }

        public string ActualHoliday { set; get; }
        public string DeductHoliday { set; get; }
              

        public string UnitGroupId
        {
            get { return strUnitGroupId; }
            set { strUnitGroupId = value; }
        }
        public string TotalOrderQTY
        {
            get { return strTotalOrderQTY; }
            set { strTotalOrderQTY = value; }
        }
        public string TotalShipQTY
        {
            get { return strTotalShipQTY; }
            set { strTotalShipQTY = value; }
        }
        public string TotalCuttonQTY
        {
            get { return strTotalCuttonQTY; }
            set { strTotalCuttonQTY = value; }
        }
        public string CRDDate
        {
            get { return strCRDDate; }
            set { strCRDDate = value; }
        }
        public string PackingDate
        {
            get { return strPackingDate; }
            set { strPackingDate = value; }
        }
        public string SizeWisePackingQTY
        {
            get { return strSizeWisePackingQTY; }
            set { strSizeWisePackingQTY = value; }
        }
        public string SizeNameId
        {
            get { return strSizeNameId; }
            set { strSizeNameId = value; }
        }

        public string PoNo
        {
            get { return strPoNo; }
            set { strPoNo = value; }
        }
        public string OrderQty
        {
            get { return strOrderQty; }
            set { strOrderQty = value; }
        }
        public string ShipQty
        {
            get { return strShipQty; }
            set { strShipQty = value; }
        }
        public string CouttonQry
        {
            get { return strCouttonQry; }
            set { strCouttonQry = value; }
        }
        public string BarcodeNumber
        {
            get { return strBarcodeNumber; }
            set { strBarcodeNumber = value; }
        }
        public string SizeName
        {
            get { return strSizeName; }
            set { strSizeName = value; }
        }
        public string FabricSymbolicName
        {
            get { return strFabricSymbolicName; }
            set { strFabricSymbolicName = value; }
        }
        public string InTime
        {
            get { return strInTime; }
            set { strInTime = value; }
        }
        public string OutTime
        {
            get { return strOutTime; }
            set { strOutTime = value; }
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

        public string GeneralOutTime
        {
            get { return strGeneralOutTime; }
            set { strGeneralOutTime = value; }
        }

        public string TreadSupplierId
        {
            get { return strTreadSupplierId; }
            set { strTreadSupplierId = value; }
        }
        public string TreadSupplierName
        {
            get { return strTreadSupplierName; }
            set { strTreadSupplierName = value; }
        }
        private string strTreadColorId;
        private string strTreadColorName;
        public string TreadColorId
        {
            get { return strTreadColorId; }
            set { strTreadColorId = value; }
        }
        public string TreadColorName
        {
            get { return strTreadColorName; }
            set { strTreadColorName = value; }
        }

        public string GrossSalary
        {
            get { return strGrossSalary; }
            set { strGrossSalary = value; }
        }
        public string TaxDate
        {
            get { return strTaxDate; }
            set { strTaxDate = value; }
        }
        public string Msg
        {
            get { return strMsg; }
            set { strMsg = value; }
        }

        public string MenuPosition
        {
            get { return strMenuPosition; }
            set { strMenuPosition = value; }
        }
        public string LimitDate
        {
            get { return strLimitDate; }
            set { strLimitDate = value; }
        }

        public string AestheticDefectId
        {
            get { return strAestheticDefectId; }
            set { strAestheticDefectId = value; }
        }

        public string AestheticDefectName
        {
            get { return strAestheticDefectName; }
            set { strAestheticDefectName = value; }
        }

        public string AddDirtyStainEntryId
        {
            get { return strAddDirtyStainEntryId; }
            set { strAddDirtyStainEntryId = value; }
        }

        public string AddDirtyStainEntryName
        {
            get { return strAddDirtyStainEntryName; }
            set { strAddDirtyStainEntryName = value; }
        }

        public string SewingDefectEntryId
        {
            get { return strSewingDefectEntryId; }
            set { strSewingDefectEntryId = value; }
        }
        public string SewingDefectEntryName
        {
            get { return strsewingDefectEntryName; }
            set { strsewingDefectEntryName = value; }
        }






        public string PODate
        {
            get { return strPODate; }
            set { strPODate = value; }
        }
        public string POId
        {
            get { return strPOId; }
            set { strPOId = value; }
        }
        public string ToleranceId
        {
            get { return strToleranceId; }
            set { strToleranceId = value; }
        }

        public string TolerancePercentage
        {
            get { return strTolerancePercentage; }
            set { strTolerancePercentage = value; }
        }
        public string StyleDescription
        {
            get { return strStyleDescription; }
            set { strStyleDescription = value; }
        }
        public string SalaryUnitName
        {
            get { return strSalaryUnitName; }
            set { strSalaryUnitName = value; }
        }
        public string ProductionLineId
        {
            get { return strProductionLineId; }
            set { strProductionLineId = value; }
        }

        public string ProductionLineName
        {
            get { return strProductionLineName; }
            set { strProductionLineName = value; }
        }
        public string POTypeName
        {
            get { return strPOTypeName; }
            set { strPOTypeName = value; }
        }

        public string POTypeId
        {
            get { return strPOTypeId; }
            set
            {
                strPOTypeId = value;
            }
        }

        public string SalaryUnitId
        {
            get { return strSalaryUnitId; }
            set { strSalaryUnitId = value; }
        }

        public string ProductionUnitId
        {
            get { return strProductionUnitId; }
            set { strProductionUnitId = value; }

        }

        public string ColorShortName
        {
            get { return strColorShortName; }
            set { strColorShortName = value; }
        }

        public string ColorFullName
        {
            get { return strColorFullName; }
            set { strColorFullName = value; }
        }

        public string BuyerShortName
        {
            get { return strBuyerShortName; }
            set { strBuyerShortName = value; }
        }
        public string BuyerFullName
        {
            get { return strBuyerFullName; }
            set { strBuyerFullName = value; }
        }


        public string SupplierId
        {
            get { return strSupplierId; }
            set { strSupplierId = value; }
        }
        public string SalaryMonthId
        {
            get { return strSalaryMonthId; }
            set { strSalaryMonthId = value; }
        }
        public string PaymentDate
        {
            get { return strPaymentDate; }
            set { strPaymentDate = value; }
        }

        public string TotalMonth
        {
            get { return strTotalMonth; }
            set { strTotalMonth = value; }
        }
        public string ArrearBonusId
        {
            get { return strArrearBonusId; }
            set { strArrearBonusId = value; }
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
        public string PoUnitName
        {
            get { return strPoUnitName; }
            set { strPoUnitName = value; }
        }


        public string PoUnitId
        {
            get { return strPoUnitId; }
            set { strPoUnitId = value; }
        }

        public string HolidayName
        {
            get { return strHolidayName; }
            set { strHolidayName = value; }
        }

        public string LeaveName
        {
            get { return strLeaveName; }
            set { strLeaveName = value; }
        }
        
        public string PartShipmentName
        {
            get { return strPartShipmentName; }
            set { strPartShipmentName = value; }
        }
        public string PartShipmentId
        {
            get { return strPartShipmentId; }
            set { strPartShipmentId = value; }
        }
        public string PaymentModeName
        {
            get { return strPaymentModeName; }
            set { strPaymentModeName = value; }
        }
        public string PaymentModeId
        {
            get { return strPaymentModeId; }
            set { strPaymentModeId = value; }
        }
        public string TranShipmentName
        {
            get { return strTranShipmentName; }
            set { strTranShipmentName = value; }
        }
        public string TranShipmentId
        {
            get { return strTranShipmentId; }
            set { strTranShipmentId = value; }
        }
        public string ReceivedBy
        {
            get { return strReceivedBy; }
            set { strReceivedBy = value; }
        }
        public string OfficeId
        {
            get { return strOfficeId; }
            set { strOfficeId = value; }
        }
        public string OfficeName
        {
            get { return strOfficeName; }
            set { strOfficeName = value; }
        }
        public string IssuedBy
        {
            get { return strIssuedBy; }
            set { strIssuedBy = value; }
        }
        public string MailAddress
        {
            get { return strMailAddress; }
            set { strMailAddress = value; }
        }
        public string FaxNo
        {
            get { return strFaxNo; }
            set { strFaxNo = value; }
        }
        public string TelephoneNo
        {
            get { return strTelephoneNo; }
            set { strTelephoneNo = value; }
        }
        public string MobileNo
        {
            get { return strMobileNo; }
            set { strMobileNo = value; }
        }
        public string SupplierAddress
        {
            get { return strSupplierAddress; }
            set { strSupplierAddress = value; }
        }
        public string SupplierName
        {
            get { return strSupplierName; }
            set { strSupplierName = value; }
        }

        public string BloodGroupCode
        {
            get { return strBloodGroupCode; }
            set { strBloodGroupCode = value; }
        }

        public string StyleNo
        {
            get { return strStyleNo; }
            set { strStyleNo = value; }
        }
        public string PONo
        {
            get { return strPONo; }
            set { strPONo = value; }
        }
        public string PaymentTypeId
        {
            get { return strPaymentTypeId; }
            set { strPaymentTypeId = value; }
        }
        public string PaymentTypeName
        {
            get { return strPaymentTypeName; }
            set { strPaymentTypeName = value; }
        }
        public string OccurenceTypeId
        {
            get { return strOccurenceTypeId; }
            set { strOccurenceTypeId = value; }
        }
        public string OccurenceTypeName
        {
            get { return strOccurenceTypeName; }
            set { strOccurenceTypeName = value; }
        }
        public string TrainingPeriodId
        {
            get { return strTrainingPeriodId; }
            set { strTrainingPeriodId = value; }
        }
        public string TrainingPeriodName
        {
            get { return strTrainingPeriodName; }
            set { strTrainingPeriodName = value; }
        }

        public string EmployeeTypeId
        {
            get { return strEmployeeTypeId; }
            set { strEmployeeTypeId = value; }
        }
        public string EmployeeTypeName
        {
            get { return strEmployeeTypeName; }
            set { strEmployeeTypeName = value; }
        }
        public string JobLocationId
        {
            get { return strJobLocationId; }
            set { strJobLocationId = value; }
        }
        public string JobLocationName
        {
            get { return strJobLocationName; }
            set { strJobLocationName = value; }
        }

        public string JobTypeId
        {
            get { return strJobTypeId; }
            set { strJobTypeId = value; }
        }
        public string JobTypeName
        {
            get { return strJobTypeName; }
            set { strJobTypeName = value; }
        }
        public string NationalityId
        {
            get { return strNationalityId; }
            set { strNationalityId = value; }
        }
        public string NationalityName
        {
            get { return strNationalityName; }
            set { strNationalityName = value; }
        }
        public string DistrictId
        {
            get { return strDistrictId; }
            set { strDistrictId = value; }
        }
        public string DistrictName
        {
            get { return strDistrictName; }
            set { strDistrictName = value; }
        }

        public string SeasonId
        {
            get { return strSeasonId; }
            set { strSeasonId = value; }
        }

        public string SeasonName
        {
            get { return strSeasonName; }
            set { strSeasonName = value; }
        }

        public string MenuId
        {
            get { return strMenuId; }
            set { strMenuId = value; }
        }

        public string MenuName
        {
            get { return strMenuName; }
            set { strMenuName = value; }
        }

        public string MenuPath
        {
            get { return strMenuPath; }
            set { strMenuPath = value; }
        }


        public string SoftId
        {
            get { return strSoftId; }
            set { strSoftId = value; }
        }
        public string EmployeePass
        {
            get { return strEmployeePass; }
            set { strEmployeePass = value; }
        }

        public string FileSize
        {
            get { return strFileSize; }
            set { strFileSize = value; }
        }
        public string RequisitionQuantity
        {
            get { return strRequisitionQuantity; }
            set { strRequisitionQuantity = value; }
        }
        public string ShipAddress
        {
            get { return strShipAddress; }
            set { strShipAddress = value; }
        }
        public string EmailAddress
        {
            get { return strEmailAddress; }
            set { strEmailAddress = value; }
        }
        public string ProductTranId
        {
            get { return strProductTranId; }
            set { strProductTranId = value; }
        }
       
        public string DeviceName
        {
            get { return strDeviceName; }
            set { strDeviceName = value; }
        }
        public string DevicePrice
        {
            get { return strDevicePrice; }
            set { strDevicePrice = value; }
        }

        public string RequisitionDate
        {
            get { return strRequisitionDate; }
            set { strRequisitionDate = value; }
        }
        public string Quantity
        {
            get { return strQuantity; }
            set { strQuantity = value; }
        }
        public string DevicesTotalPrice
        {
            get { return strDevicesTotalPrice; }
            set { strDevicesTotalPrice = value; }
        }

        //



        public string HeadOfficeIdNo
        {
            get { return strHeadOfficeIdNo; }
            set { strHeadOfficeIdNo = value; }
        }

        public string BranchOfficeIdNo
        {
            get { return strBranchOfficeIdNo; }
            set { strBranchOfficeIdNo = value; }
        }
        public string BranchOfficeNameBng
        {
            get { return strBranchOfficeNameBng; }
            set { strBranchOfficeNameBng = value; }
        }
        public string BranchOfficeMobileNo
        {
            get { return strBranchOfficeMobileNo; }
            set { strBranchOfficeMobileNo = value; }
        }
        public string BranchOfficePhoneNo
        {
            get { return strBranchOfficePhoneNo; }
            set { strBranchOfficePhoneNo = value; }
        }
        public string BranchOfficeFaxNo
        {
            get { return strBranchOfficeFaxNo; }
            set { strBranchOfficeFaxNo = value; }
        }


        public byte[] FileDocuments
        {
            get { return strFileDocuments; }
            set { strFileDocuments = value; }


        }

        public string OrderDate
        {
            get { return strOrderDate; }
            set { strOrderDate = value; }


        }
        public string TotalOperator
        {
            get { return strTotalOperator; }
            set { strTotalOperator = value; }


        }

        public string WorkingDay
        {
            get { return strWorkingDay; }
            set { strWorkingDay = value; }


        }

        public string ProductId
        {
            get { return strProductId; }
            set { strProductId = value; }


        }

        public string ProductName
        {
            get { return strProductName; }
            set { strProductName = value; }


        }

        public string TiffinFee
        {
            get { return strTiffinFee; }
            set { strTiffinFee = value; }


        }

        public string MedicalFee
        {
            get { return strMedicalFee; }
            set { strMedicalFee = value; }


        }

        public string ConvenceFee
        {
            get { return strConvenceFee; }
            set { strConvenceFee = value; }


        }

        public string FoodFee
        {
            get { return strFoodFee; }
            set { strFoodFee = value; }


        }

        public string ExtraFoodFee
        {
            get { return strExtraFoodFee; }
            set { strExtraFoodFee = value; }


        }


        public string PaymentTermId
        {
            get { return strPaymentTermId; }
            set { strPaymentTermId = value; }


        }
        public string PaymentDay
        {
            get { return strPaymentDay; }
            set { strPaymentDay = value; }


        }
        public string ShipTypeId
        {
            get { return strShipTypeId; }
            set { strShipTypeId = value; }


        }

        public string ShipTypeName
        {
            get { return strShipTypeName; }
            set { strShipTypeName = value; }


        }

        public string ShipId
        {
            get { return strShipId; }
            set { strShipId = value; }


        }

        public string ShipName
        {
            get { return strShipName; }
            set { strShipName = value; }


        }
        public string ManufactureId
        {
            get { return strManufactureId; }
            set { strManufactureId = value; }


        }

        public string ManufactureName
        {
            get { return strManufactureName; }
            set { strManufactureName = value; }


        }

        public string OfficeAddress
        {
            get { return strOfficeAddress; }
            set { strOfficeAddress = value; }


        }

        public string FactoryAddress
        {
            get { return strFactoryAddress; }
            set { strFactoryAddress = value; }


        }

        public string BankId
        {
            get { return strBankId; }
            set { strBankId = value; }


        }
        public string BankName
        {
            get { return strBankName; }
            set { strBankName = value; }


        }

        public string AccountNo
        {
            get { return strAccountNo; }
            set { strAccountNo = value; }


        }

        public string SwiftCode
        {
            get { return strSwiftCode; }
            set { strSwiftCode = value; }


        }

        public string PhoneNo
        {
            get { return strPhoneNo; }
            set { strPhoneNo = value; }


        }
        public string VendorId
        {
            get { return strVendorId; }
            set { strVendorId = value; }


        }

        public string VendorName
        {
            get { return strVendorName; }
            set { strVendorName = value; }


        }

        public string VendorAddress
        {
            get { return strVendorAddress; }
            set { strVendorAddress = value; }


        }

        public string CompanyId
        {
            get { return strCompanyId; }
            set { strCompanyId = value; }


        }

        public string CompanyName
        {
            get { return strCompanyName; }
            set { strCompanyName = value; }


        }

        public string ItemId
        {
            get { return strItemId; }
            set { strItemId = value; }


        }

        public string ItemName
        {
            get { return strItemName; }
            set { strItemName = value; }


        }

        public string ArtId
        {
            get { return strArtId; }
            set { strArtId = value; }


        }
        public string ItemNo
        {
            get { return strItemNo; }
            set { strItemNo = value; }


        }

        public string ProcessCode
        {
            get { return strProcessCode; }
            set { strProcessCode = value; }


        }

        public string ProgrammeName
        {
            get { return strProgrammeName; }
            set { strProgrammeName = value; }


        }

        public string MachineName
        {
            get { return strMachineName; }
            set { strMachineName = value; }


        }

        public string MachineId
        {
            get { return strMachineId; }
            set { strMachineId = value; }


        }
        public string EquipmetId
        {
            get { return strEquipmetId; }
            set { strEquipmetId = value; }


        }

        public string EquipmentName
        {
            get { return strEquipmentName; }
            set { strEquipmentName = value; }


        }

        public string QuantityPerEnginee
        {
            get { return strQuantityPerEnginee; }
            set { strQuantityPerEnginee = value; }


        }


        public string SparePartCategoryId
        {
            get { return strSparePartCategoryId; }
            set { strSparePartCategoryId = value; }


        }

        public string SparePartCategoryName
        {
            get { return strSparePartCategoryName; }
            set { strSparePartCategoryName = value; }


        }

        public string SparePartCategoryNo
        {
            get { return strSparePartCategoryNo; }
            set { strSparePartCategoryNo = value; }


        }

        public string SparePartId
        {
            get { return strSparePartId; }
            set { strSparePartId = value; }


        }

        public string SparePartName
        {
            get { return strSparePartName; }
            set { strSparePartName = value; }


        }

        public string SparePartNo
        {
            get { return strSparePartNo; }
            set { strSparePartNo = value; }


        }

        public string CardNo
        {
            get { return strCardNo; }
            set { strCardNo = value; }


        }

        public string Designation
        {
            get { return strDesignation; }
            set { strDesignation = value; }


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
        public string StichLength
        {
            get { return strStichLength; }
            set { strStichLength = value; }


        }

        public string HigestCapactiy
        {
            get { return strHigestCapactiy; }
            set { strHigestCapactiy = value; }


        }

        public string PolyBagId
        {
            get { return strPolyBagId; }
            set { strPolyBagId = value; }


        }
        public string PolyBagWidht
        {
            get { return strPolyBagWidht; }
            set { strPolyBagWidht = value; }


        }
        public string PolyBagHeight
        {
            get { return strPolyBagHeight; }
            set { strPolyBagHeight = value; }


        }
        public string PolyBagLength
        {
            get { return strPolyBagLength; }
            set { strPolyBagLength = value; }


        }
        public string PolyBagRate
        {
            get { return strPolyBagRate; }
            set { strPolyBagRate = value; }


        }


        public string HangerId
        {
            get { return strHangerId; }
            set { strHangerId = value; }


        }

        public string HangerSize
        {
            get { return strHangerSize; }
            set { strHangerSize = value; }


        }

        public string HangerRate
        {
            get { return strHangerRate; }
            set { strHangerRate = value; }


        }

        public string ParticularName
        {
            get { return strParticularName; }
            set { strParticularName = value; }


        }



        public string StyleId
        {
            get { return strStyleId; }
            set { strStyleId = value; }


        }

        public string StyleName
        {
            get { return strStyleName; }
            set { strStyleName = value; }


        }


        public string SubCatagoryName
        {
            get { return strSubCatagoryName; }
            set { strSubCatagoryName = value; }


        }

        public string FebricName
        {
            get { return strFebricName; }
            set { strFebricName = value; }


        }

        public string AttendenceYn
        {
            get { return strAttendenceYn; }
            set { strAttendenceYn = value; }


        }

        public string TargetValue
        {
            get { return strTargetValue; }
            set { strTargetValue = value; }


        }
        public string FrontCategoryId
        {
            get { return strFrontCategoryId; }
            set { strFrontCategoryId = value; }


        }
        public string FrontCategoryName
        {
            get { return strFrontCategoryName; }
            set { strFrontCategoryName = value; }


        }

        public string ArtNo
        {
            get { return strArtNo; }
            set { strArtNo = value; }


        }

        public string Blance
        {
            get { return strBlance; }
            set { strBlance = value; }


        }

        public string ProgrammeId
        {
            get { return strProgrammeId; }
            set { strProgrammeId = value; }


        }

       
        public string ThreadId
        {
            get { return strThreadId; }
            set { strThreadId = value; }


        }

        public string WhitePrice
        {
            get { return strWhitePrice; }
            set { strWhitePrice = value; }


        }

        public string ThreadCount
        {
            get { return strThreadCount; }
            set { strThreadCount = value; }


        }

        public string ColorPrice
        {
            get { return strColorPrice; }
            set { strColorPrice = value; }


        }

        public string CurrencyId
        {
            get { return strCurrencyId; }
            set { strCurrencyId = value; }


        }



        public string CurrencyName
        {
            get { return strCurrencyName; }
            set { strCurrencyName = value; }


        }

        public string BrandId
        {
            get { return strBrandId; }
            set { strBrandId = value; }


        }

        public string BrandName
        {
            get { return strBrandName; }
            set { strBrandName = value; }


        }

        public string ActiveYn
        {
            get { return strActiveYn; }
            set { strActiveYn = value; }


        }

        public string ContactNo
        {
            get { return strContactNo; }
            set { strContactNo = value; }


        }

        public string EmailAddresss
        {
            get { return strEmailAddresss; }
            set { strEmailAddresss = value; }


        }


        public string Address
        {
            get { return strAddress; }
            set { strAddress = value; }


        }





        public string HolidayTypeId
        {
            get { return strHolidayTypeId; }
            set { strHolidayTypeId = value; }


        }

        public string HolidayStartDate
        {
            get { return strHolidayStartDate; }
            set { strHolidayStartDate = value; }


        }

        public string HolidayEndDate
        {
            get { return strHolidayEndDate; }
            set { strHolidayEndDate = value; }


        }

        public string ProcessTime
        {
            get { return strProcessTime; }
            set { strProcessTime = value; }


        }
        public string AuxiliaryProcessId
        {
            get { return strAuxiliaryProcessId; }
            set { strAuxiliaryProcessId = value; }


        }

        public string AuxiliaryProcessName
        {
            get { return strAuxiliaryProcessName; }
            set { strAuxiliaryProcessName = value; }


        }

        public string TopId
        {
            get { return strTopId; }
            set { strTopId = value; }


        }

        public string TopName
        {
            get { return strTopName; }
            set { strTopName = value; }


        }

        public string BottomId
        {
            get { return strBottomId; }
            set { strBottomId = value; }


        }


        public string BottomName
        {
            get { return strBottomName; }
            set { strBottomName = value; }


        }


        public string LineId
        {
            get { return strLineId; }
            set { strLineId = value; }


        }

        public string LineName
        {
            get { return strLineName; }
            set { strLineName = value; }


        }

        public string ProcessId
        {
            get { return strProcessId; }
            set { strProcessId = value; }


        }

        public string ProcessName
        {
            get { return strProcessName; }
            set { strProcessName = value; }


        }

        public string SupplierTypeId
        {
            get { return strSupplierTypeId; }
            set { strSupplierTypeId = value; }


        }

        public string SupplierType
        {
            get { return strSupplierType; }
            set { strSupplierType = value; }


        }

        public string StoreId
        {
            get { return strStoreId; }
            set { strStoreId = value; }


        }

        public string StoreName
        {
            get { return strStoreName; }
            set { strStoreName = value; }


        }

        public string ImportId
        {
            get { return strImportId; }
            set { strImportId = value; }


        }

        public string DataUploadDir
        {
            get { return strDataUploadDir; }
            set { strDataUploadDir = value; }


        }

        public string ImportName
        {
            get { return strImportName; }
            set { strImportName = value; }


        }

        public string FabricId
        {
            get { return strFabricId; }
            set { strFabricId = value; }


        }

        public string FabricName
        {
            get { return strFabricName; }
            set { strFabricName = value; }


        }

        public string FebricConstructionId
        {
            get { return strFebricConstructionId; }
            set { strFebricConstructionId = value; }


        }

        public string FebricConstructionName
        {
            get { return strFebricConstructionName; }
            set { strFebricConstructionName = value; }


        }

        public string SoftName
        {
            get { return strSoftName; }
            set { strSoftName = value; }


        }

        public string TaxEntryPermission
        {
            get { return strTaxEntryPermission; }
            set { strTaxEntryPermission = value; }


        }

        public string TransferMsg
        {
            get { return strTransferMsg; }
            set { strTransferMsg = value; }


        }
        public string SupervisorName
        {
            get { return strSupervisorName; }
            set { strSupervisorName = value; }


        }

        public string SupervisorId
        {
            get { return strSupervisorId; }
            set { strSupervisorId = value; }


        }
        public string SalaryDay
        {
            get { return strSalaryDay; }
            set { strSalaryDay = value; }


        }
        public string LeaveTypeId
        {
            get { return strLeaveTypeId; }
            set { strLeaveTypeId = value; }


        }
        public string MaxAllow
        {
            get { return strMaxAllow; }
            set { strMaxAllow = value; }


        }

        public string LeaveId
        {
            get { return strLeaveId; }
            set { strLeaveId = value; }


        }

        public string EidTypeId
        {
            get { return strEidTypeId; }
            set { strEidTypeId = value; }


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


        public string GradeId
        {
            get { return strGradeId; }
            set { strGradeId = value; }


        }

        public string GradeNo
        {
            get { return strGradeNo; }
            set { strGradeNo = value; }


        }

        public string PercentAmount
        {
            get { return strPercentAmount; }
            set { strPercentAmount = value; }


        }


        public string EffectId
        {
            get { return strEffectId; }
            set { strEffectId = value; }


        }


        public string EffectDate
        {
            get { return strEffectDate; }
            set { strEffectDate = value; }


        }

        public string AttendenceDate
        {
            get { return strAttendenceDate; }
            set { strAttendenceDate = value; }


        }



        public string ToMonth
        {
            get { return strToMonth; }
            set { strToMonth = value; }


        }
        public string FromMonth
        {
            get { return strFromMonth; }
            set { strFromMonth = value; }


        }

        public string EidId
        {
            get { return strEidId; }
            set { strEidId = value; }


        }
        public string EidYear
        {
            get { return strEidYear; }
            set { strEidYear = value; }


        }

        public string EidName
        {
            get { return strEidName; }
            set { strEidName = value; }


        }


        public string EidDate
        {
            get { return strEidDate; }
            set { strEidDate = value; }


        }


        public string ShiftNameBng
        {
            get { return strShiftNameBng; }
            set { strShiftNameBng = value; }


        }

        public string ShiftNameEng
        {
            get { return strShiftNameEng; }
            set { strShiftNameEng = value; }


        }


        public string JobId
        {
            get { return strJobId;}
            set { strJobId = value; } 


        }

        public string VersionId
        {
            get { return strVersionId; }
            set { strVersionId = value; }


        }

        public string VersionName
        {
            get { return strVersionName; }
            set { strVersionName = value; }


        }
        public string VersionCode
        {
            get { return strVersionCode; }
            set { strVersionCode = value; }


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



        public string JobTypeCode
        {
            get { return strJobTypeCode; }
            set { strJobTypeCode = value; }


        }

        public string JobName
        {
            get { return strJobName; }
            set { strJobName = value; }


        }
        public string BuyerId
        {
            get { return strBuyerId; }
            set { strBuyerId = value; }


        }
        public string BuyerType
        {
            get { return strBuyerType; }
            set { strBuyerType = value; }


        }

        public string BuyerTypeId
        {
            get { return strBuyerTypeId; }
            set { strBuyerTypeId = value; }


        }

        public string BuyerTypeCode
        {
            get { return strBuyerTypeCode; }
            set { strBuyerTypeCode = value; }


        }
        public string BuyerName
        {
            get { return strBuyerName; }
            set { strBuyerName = value; }


        }

        public string CGPAId
        {
            get { return strCGPAId; }
            set { strCGPAId = value; }


        }

        public string CGPACode
        {
            get { return strCGPACode; }
            set { strCGPACode = value; }


        }
        public string CGPACodeName
        {
            get { return strCGPACodeName; }
            set { strCGPACodeName = value; }


        }

        public string ColorId
        {
            get { return strColorId; }
            set { strColorId = value; }


        }

        public string ColorTypeCode
        {
            get { return strColorTypeCode; }
            set { strColorTypeCode = value; }


        }

        public string ColorName
        {
            get { return strColorName; }
            set { strColorName = value; }


        }

        public string CountryId
        {
            get { return strCountryId; }
            set { strCountryId = value; }


        }
        public string CountryCode
        {
            get { return strCountryCode; }
            set { strCountryCode = value; }


        }

        public string CountryNameBng
        {
            get { return strCountryNameBng; }
            set { strCountryNameBng = value; }


        }
        public string CountryNameEng
        {
            get { return strCountryNameEng; }
            set { strCountryNameEng = value; }


        }

        public string CourseId
        {
            get { return strCourseId; }
            set { strCourseId = value; }


        }
        public string CourseCode
        {
            get { return strCourseCode; }
            set { strCourseCode = value; }


        }

        public string CourseName
        {
            get { return strCourseName; }
            set { strCourseName = value; }


        }

        public string DesignationId
        {
            get { return strDesignationId; }
            set { strDesignationId = value; }


        }

        public string DesignationCode
        {
            get { return strDesignationCode; }
            set { strDesignationCode = value; }


        }


        public string DesignationNameBng
        {
            get { return strDesignationNameBng; }
            set { strDesignationNameBng = value; }


        }

        public string DesignationNameEng
        {
            get { return strDesignationNameEng; }
            set { strDesignationNameEng = value; }


        }

        public string CatagoryId
        {
            get { return strCatagoryId; }
            set { strCatagoryId = value; }


        }

        public string CatagoryCode
        {
            get { return strCatagoryCode; }
            set { strCatagoryCode = value; }


        }

        public string CatagoryNameBng
        {
            get { return strCatagoryNameBng; }
            set { strCatagoryNameBng = value; }


        }

        public string CatagoryNameEng
        {
            get { return strCatagoryNameEng; }
            set { strCatagoryNameEng = value; }


        }

        public string GenderId
        {
            get { return strGenderId; }
            set { strGenderId = value; }


        }
        public string GenderName
        {
            get { return strGenderName; }
            set { strGenderName = value; }


        }
        public string HolidayId
        {
            get { return strHolidayId; }
            set { strHolidayId = value; }


        }

        public string HolidayCode
        {
            get { return strHolidayCode; }
            set { strHolidayCode = value; }


        }

        public string InstituteId
        {
            get { return strInstituteId; }
            set { strInstituteId = value; }


        }

        public string InstituteCode
        {
            get { return strInstituteCode; }
            set { strInstituteCode = value; }


        }
        public string InstitueName
        {
            get { return strInstitueName; }
            set { strInstitueName = value; }


        }

        public string MaritalStatusId
        {
            get { return strMaritalStatusId; }
            set { strMaritalStatusId = value; }


        }

        public string MaritalStatusCode
        {
            get { return strMaritalStatusCode; }
            set { strMaritalStatusCode = value; }


        }
        public string MaritalStatusName
        {
            get { return strMaritalStatusName; }
            set { strMaritalStatusName = value; }


        }

        public string ReligionId
        {
            get { return strReligionId; }
            set { strReligionId = value; }


        }

        public string ReligionCode
        {
            get { return strReligionCode; }
            set { strReligionCode = value; }


        }
        public string ReligionName
        {
            get { return strReligionName; }
            set { strReligionName = value; }


        }
        public string SalaryId
        {
            get { return strSalaryId; }
            set { strSalaryId = value; }


        }


        public string SalaryTypeCode
        {
            get { return strSalaryTypeCode; }
            set { strSalaryTypeCode = value; }


        }

        public string SalaryTypeName
        {
            get { return strSalaryTypeName; }
            set { strSalaryTypeName = value; }


        }

        public string SectionId
        {
            get { return strSectionId; }
            set { strSectionId = value; }


        }

        public string SectionCode
        {
            get { return strSectionCode; }
            set { strSectionCode = value; }


        }

        public string SectionNameEng
        {
            get { return strSectionNameEng; }
            set { strSectionNameEng = value; }


        }
        public string SectionNameBng
        {
            get { return strSectionNameBng; }
            set { strSectionNameBng = value; }


        }
        public string ShiftId
        {
            get { return strShiftId; }
            set { strShiftId = value; }


        }

        public string ShiftCode
        {
            get { return strShiftCode; }
            set { strShiftCode = value; }


        }

        public string ShiftName
        {
            get { return strShiftName; }
            set { strShiftName = value; }


        }

        public string SubjectId
        {
            get { return strSubjectId; }
            set { strSubjectId = value; }


        }

        public string SubjectCode
        {
            get { return strSubjectCode; }
            set { strSubjectCode = value; }


        }

        public string SubjectName
        {
            get { return strSubjectName; }
            set { strSubjectName = value; }


        }
        public string UnitId
        {
            get { return strUnitId; }
            set { strUnitId = value; }


        }

        public string UnitCode
        {
            get { return strUnitCode; }
            set { strUnitCode = value; }


        }
        public string UnitName
        {
            get { return strUnitName; }
            set { strUnitName = value; }


        }

        public string UnitNameBangla
        {
            get { return strUnitNameBangla; }
            set { strUnitNameBangla = value; }


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



        public string BloodGroupId
        {
            get { return strBloodGroupId; }
            set { strBloodGroupId = value; }


        }

        public string BloodGroupName
        {
            get { return strBloodGroupName; }
            set { strBloodGroupName = value; }


        }

        public string HeadOfficeId
        {
            get { return strHeadOfficeId; }
            set { strHeadOfficeId = value; }


        }
        public string HeadOfficeName
        {
            get { return strHeadOfficeName; }
            set { strHeadOfficeName = value; }


        }

        public string HeadOfficeNameBangla
        {
            get { return strHeadOfficeNameBangla; }
            set { strHeadOfficeNameBangla = value; }


        }

        public string HeadOfficeMobileNo
        {
            get { return strHeadOfficeMobileNo; }
            set { strHeadOfficeMobileNo = value; }


        }

        public string HeadOfficePhoneNo
        {
            get { return strHeadOfficePhoneNo; }
            set { strHeadOfficePhoneNo = value; }


        }

        public string HeadOfficeFaxNo
        {
            get { return strHeadOfficeFaxNo; }
            set { strHeadOfficeFaxNo = value; }


        }

        public string HeadOfficeAddress
        {
            get { return strHeadOfficeAddress; }
            set { strHeadOfficeAddress = value; }


        }


        public string DepartmentId
        {
            get { return strDepartmentId; }
            set { strDepartmentId = value; }


        }

        public string DepartmentNameEng
        {
            get { return strDepartmentNameEng; }
            set { strDepartmentNameEng = value; }


        }

        public string DepartmentNameBng
        {
            get { return strDepartmentNameBng; }
            set { strDepartmentNameBng = value; }


        }

        public string BranchOfficeName
        {
            get { return strBranchOfficeName; }
            set { strBranchOfficeName = value; }



        }
        public string BranchOfficeAddress
        {
            get { return strBranchOfficeAddress; }
            set { strBranchOfficeAddress = value; }



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



        //Upload Files
        public string FileName
        {
            get { return strFileName; }
            set { strFileName = value; }
        }
        public string FileExtension
        {
            get { return strFileExtension; }
            set { strFileExtension = value; }
        }
        public string FilePath
        {
            get { return strFilePath; }
            set { strFilePath = value; }
        }
        public string DataFile
        {
            get { return strDataFile; }
            set { strDataFile = value; }
        }
        public string FileSalaryYear
        {
            get { return strFileSalaryYear; }
            set { strFileSalaryYear = value; }
        }
        public string FileSalaryMonth
        {
            get { return strFileSalaryMonth; }
            set { strFileSalaryMonth = value; }
        }


    }
}
