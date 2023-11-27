using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class ReportDTO
    {


        private string strEmployeeCode;
        private string strFromDate;
        private string strToDate;
        private string strEmployeeId;
        private string strDepartmentId;
        private string strUnitId;
        private string strSectionId;
        private string strCatagoryId;
        private string strDesignationId;
        private string strHeadOfficeId;
        private string strBranchOfficeId;
        private string strUpdateBY;
        private string strYear;
        private string strMonth;
        private string strRequisitionId;
        private string strCardNo;
        private string strFromMonthId;
        private string strToMonthId;
        private string strPONo;
        private string strBuyerId;
        private string strEidTypeId;
        private string strLineId;
        private string strPunchCode;
        private string strSRNo;
        private string strSMV;
        private string strIncrementAmount;
        private string strFromCapacity;
        private string strToCapacity;

        private string strProgrammeId;
        private string strEquipementId;
        private string strPartId;
        private string strInvoiceNo;
        private string strTargetQtyPercent;

        private string strContractNo;
        private string strIssueDate;

        private string strWorkingDay;
        private string strAverageManpower;
        private string strEmployeeTypeId;
        private string strAmendmentId;


        private string strProductSLNo;
        private string strRequisitionNo;
        private string strProductId;
        private string strAmendDate;
        private string strSalaryRange;
        private string strFromMonth;
        private string strToMonth;
        private string strStyleNo;
        private string strDeliveryDate;
        private string strPurchaseId;
        private string strPartNo;
        private string strPoNumber;
      
        private string strMrNo;
        private string strHourNo;
        private string strProposalYear;
        private string strProposalMonth;
        private string strLimitDate;
        private string strSupplierId;


 
       
        private string strFactoryId;
        private string strPOId;
        private string strProductionDate;


        private string strJoiningYear;
        private string strJoiningMonth;
        private string strChkFivePercent;
        private string strMsg;
        private string strStyleId;
        private string strArtNo;
        private string strFabricId;
        private string strConstructionId;
        private string strColorId;
        private string strLcNo;
        private string strMachineId;
        private string strFOBDate;
        private string strSeasonId;
        private string strContractId;
        private string strDate;

        //New
        public string PreIncrementYear { get; set; }
        public string SittingTypeId { get; set; }
        public string WHRangeId { get; set; }
        public string OccurrenceType { get; set; }
        public string StatusId { get; set; }
        public string CreateBy { get; set; }
        public string OTMunite { get; set; }
        public string LateMinute { get; set; }
        public string FloorId { get; set; }
        public string RecognizeYn { get; set; }
        public string ApproveYn { get; set; }
        public string Delete_Yn { get; set; }
        public string FromCreateDate { get; set; }
        public string ToCreateDate { get; set; }
        public string ReportingBranchOfficeId { get; set; }
        public string SittingBranchOfficeId { get; set; }
        public string UnitGroupId { get; set; }
        public string PaymentMode { get; set; }
        public string PhaseId { get; set; }
        public int NVL { get; set; }
        public string PoStatus { get; set; }
        public string EarlyDepurtureTime { get; set; }
        public int EarlyDepurtureLimit { get; set; }
        public string MediaTypeId { get; set; }
        public string IncrementYn { get; set; }
        public string IncrementTypeId { get; set; }
        public string AllowGeneralIncrement { get; set; }
        public int ExtraIncrement { get; set; }
        public string BatchNo { get; set; }
        public string ArrearYear { get; set; }
        public string ArrearMonth { get; set; }
        public string BankYn { get; set; }
        public string BankId { get; set; }
        
        public string ShiftId { get; set; }

        public int SheetType { get; set; }
        public string accountYn { get; set; }
        public int payment_mode { get; set; }
        public int AddressTypeId { get; set; }

        public string FirstSalary { get; set; }
        public string PaymentTypeId { get; set; }
        public int LateLimit { get; set; }
        public string Date
        {
            get { return strDate; }
            set { strDate = value; }
        }

        public string ContractId
        {
            get { return strContractId; }
            set { strContractId = value; }
        }

        public string SeasonId
        {
            get { return strSeasonId; }
            set { strSeasonId = value; }
        }
        public string FOBDate
        {
            get { return strFOBDate; }
            set { strFOBDate = value; }
        }

        public string MachineId
        {
            get { return strMachineId; }
            set { strMachineId = value; }
        }
        public string LcNo
        {
            get { return strLcNo; }
            set { strLcNo = value; }
        }
        public string ColorId
        {
            get { return strColorId; }
            set { strColorId = value; }
        }

        public string FabricId
        {
            get { return strFabricId; }
            set { strFabricId = value; }
        }
        public string ConstructionId
        {
            get { return strConstructionId; }
            set { strConstructionId = value; }
        }


        public string ArtNo
        {
            get { return strArtNo; }
            set { strArtNo = value; }
        }

        public string StyleId
        {
            get { return strStyleId; }
            set { strStyleId = value; }
        }
        public string Msg
        {
            get { return strMsg; }
            set { strMsg = value; }
        }
        public string ChkFivePercent
        {
            get { return strChkFivePercent; }
            set { strChkFivePercent = value; }
        }
        public string JoiningMonth
        {
            get { return strJoiningMonth; }
            set { strJoiningMonth = value; }
        }

        public string JoiningYear
        {
            get { return strJoiningYear; }
            set { strJoiningYear = value; }
        }


        public string ProductionDate
        {
            get { return strProductionDate; }
            set { strProductionDate = value; }
        }
        public string POId
        {
            get { return strPOId; }
            set { strPOId = value; }
        }
        public string FactoryId
        {
            get { return strFactoryId; }
            set { strFactoryId = value; }
        }

        public string SupplierId
        {
            get { return strSupplierId; }
            set { strSupplierId = value; }

        }

        public string LimitDate
        {
            get { return strLimitDate; }
            set { strLimitDate = value; }

        }

        public string ProposalYear
        {
            get { return strProposalYear; }
            set { strProposalYear = value; }

        }

        public string ProposalMonth
        {
            get { return strProposalMonth; }
            set { strProposalMonth = value; }

        }

        public string HourNo
        {
            get { return strHourNo; }
            set { strHourNo = value; }

        }

        public string MrNo
        {
            get { return strMrNo; }
            set { strMrNo = value; }

        }

        public string PoNumber
        {
            get { return strPoNumber; }
            set { strPoNumber = value; }

        }
        public string PartNo
        {
            get { return strPartNo; }
            set { strPartNo = value; }

        }

        public string PurchaseId
        {
            get { return strPurchaseId; }
            set { strPurchaseId = value; }

        }

        public string DeliveryDate
        {
            get { return strDeliveryDate; }
            set { strDeliveryDate = value; }

        }

        public string StyleNo
        {
            get { return strStyleNo; }
            set { strStyleNo = value; }

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

        public string SalaryRange
        {
            get { return strSalaryRange; }
            set { strSalaryRange = value; }

        }

        public string AmendDate
        {
            get { return strAmendDate; }
            set { strAmendDate = value; }

        }

        public string ProductId
        {
            get { return strProductId; }
            set { strProductId = value; }

        }

        public string ProductSLNo
        {
            get { return strProductSLNo; }
            set { strProductSLNo = value; }

        }

        public string RequisitionNo
        {
            get { return strRequisitionNo; }
            set { strRequisitionNo = value; }

        }

        public string AmendmentId
        {
            get { return strAmendmentId; }
            set { strAmendmentId = value; }

        }

        public string EmployeeTypeId
        {
            get { return strEmployeeTypeId; }
            set { strEmployeeTypeId = value; }

        }


        public string ContractNo
        {
            get { return strContractNo; }
            set { strContractNo = value; }

        }


        public string IssueDate
        {
            get { return strIssueDate; }
            set { strIssueDate = value; }

        }


        public string WorkingDay
        {
            get { return strWorkingDay; }
            set { strWorkingDay = value; }

        }

        public string AverageManpower
        {
            get { return strAverageManpower; }
            set { strAverageManpower = value; }

        }

        public string TargetQtyPercent
        {
            get { return strTargetQtyPercent; }
            set { strTargetQtyPercent = value; }

        }

        public string InvoiceNo
        {
            get { return strInvoiceNo; }
            set { strInvoiceNo = value; }

        }
        public string ProgrammeId
        {
            get { return strProgrammeId; }
            set { strProgrammeId = value; }

        }

        public string EquipementId
        {
            get { return strEquipementId; }
            set { strEquipementId = value; }

        }

        public string PartId
        {
            get { return strPartId; }
            set { strPartId = value; }

        }

        public string FromCapacity
        {
            get { return strFromCapacity; }
            set { strFromCapacity = value; }

        }

        public string ToCapacity
        {
            get { return strToCapacity; }
            set { strToCapacity = value; }

        }

        public string IncrementAmount
        {
            get { return strIncrementAmount; }
            set { strIncrementAmount = value; }

        }

        public string SMV
        {
            get { return strSMV; }
            set { strSMV = value; }

        }

        public string SRNo
        {
            get { return strSRNo; }
            set { strSRNo = value; }

        }

        public string PunchCode
        {
            get { return strPunchCode; }
            set { strPunchCode = value; }

        }
        public string LineId
        {
            get { return strLineId; }
            set { strLineId = value; }

        }

        public string FromDate
        {
            get { return strFromDate; }
            set { strFromDate = value; }

        }



        public string EidTypeId
        {
            get { return strEidTypeId; }
            set { strEidTypeId = value; }

        }
        public string FromMonthId
        {
            get { return strFromMonthId; }
            set { strFromMonthId = value; }

        }
        public string ToMonthId
        {
            get { return strToMonthId; }
            set { strToMonthId = value; }

        }
        public string EmployeeCode
        {
            get { return strEmployeeCode; }
            set { strEmployeeCode = value; }
            
        }


        public string CardNo
        {
            get { return strCardNo; }
            set { strCardNo = value; }

        }




        public string ToDate
        {
            get { return strToDate; }
            set { strToDate = value; }

        }

        public string EmployeeId
        {
            get { return strEmployeeId; }
            set { strEmployeeId = value; }

        }

        public string DepartmentId
        {
            get { return strDepartmentId; }
            set { strDepartmentId = value; }

        }

        public string UnitId
        {
            get { return strUnitId; }
            set { strUnitId = value; }

        }

        public string SectionId
        {
            get { return strSectionId; }
            set { strSectionId = value; }

        }

        public string CatagoryId
        {
            get { return strCatagoryId; }
            set { strCatagoryId = value; }

        }

        public string DesignationId
        {
            get { return strDesignationId; }
            set { strDesignationId = value; }

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
            get { return strUpdateBY; }
            set { strUpdateBY = value; }

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


        public string RequisitionId
        {
            get { return strRequisitionId; }
            set { strRequisitionId = value; }

        }

       

        public string PONo
        {
            get { return strPONo; }
            set { strPONo = value; }

        }
        public string BuyerId
        {
            get { return strBuyerId; }
            set { strBuyerId = value; }

        }
    }
}
