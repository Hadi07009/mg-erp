using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
 public  class MaintenanceDTO
    {
     
        private string strUpdateBy;
        private string strHeadOfficeId;
        private string strBranchOfficeId;

        private string strMachineModelId;
        private string strMachineModelCode;
        private string strMachineModelName;


        private string strMachinelId;
      
        private string strMachineName;
        private string strMachinePartsId;
        private string strMachineParts;

        private string strMachineMRNo;
        private string strMachineBoxNo;
        private string strReceiveQuantity;
        private string strMachinePartsReceiveId;
        private string strReceiveDate;
        private string strPartsReceiveFromDate;
        private string strPartsReceiveToDate;

        private string strPartsIssueFromDate;
        private string strPartsIssueToDate;

        private string strMachineMRNoSearch;

        private string strMachinePartsIssueId;
        private string strIssueDate;
        private string strIssueQuantity;
        private string strRemarks;
  
        private string strSRNo;
     private string strRemainingQuantity;

     private string strDepartmentId;

     private string strDepartmentName;

     public string DepartmentId
     {
         get { return strDepartmentId; }
         set { strDepartmentId = value; }
     }

     public string DepartmentName
     {
         get { return strDepartmentName; }
         set { strDepartmentName = value; }
     }
     public string PartsIssueFromDate
     {
         get { return strPartsIssueFromDate; }
         set { strPartsIssueFromDate = value; }
     }


     public string PartsIssueToDate
     {
         get { return strPartsIssueToDate; }
         set { strPartsIssueToDate = value; }
     }


     public string RemainingQuantity
     {
         get { return strRemainingQuantity; }
         set { strRemainingQuantity = value; }
     }

     
        public string SRNo
        {
            
            get { return strSRNo; }
            set { strSRNo = value; }
        }

        public string Remarks
        {
            get { return strRemarks; }
            set { strRemarks = value; }
        }
        public string IssueQuantity
        {
            get { return strIssueQuantity; }
            set { strIssueQuantity = value; }
        }

        public string MachinePartsIssueId
        {
            get { return strMachinePartsIssueId; }
            set { strMachinePartsIssueId = value; }
        }
        public string IssueDate
        {
            get { return strIssueDate; }
            set { strIssueDate = value; }
        }

        public string MachineMRNoSearch
        {
            get { return strMachineMRNoSearch; }
            set { strMachineMRNoSearch = value; }
        }

        
        public string PartsReceiveFromDate
        {
            get { return strPartsReceiveFromDate; }
            set { strPartsReceiveFromDate = value; }
        }


        public string PartsReceiveToDate
        {
            get { return strPartsReceiveToDate; }
            set { strPartsReceiveToDate = value; }
        }
        public string ReceiveDate
        {
            get { return strReceiveDate; }
            set { strReceiveDate = value; }
        }
        public string MachinePartsReceiveId
        {
            get { return strMachinePartsReceiveId; }
            set { strMachinePartsReceiveId = value; }
        }

        public string ReceiveQuantity
        {
            get { return strReceiveQuantity; }
            set { strReceiveQuantity = value; }
        }
        public string MachineMRNo
        {
            get { return strMachineMRNo; }
            set { strMachineMRNo = value; }
        }

        public string MachineBoxNo
        {
            get { return strMachineBoxNo; }
            set { strMachineBoxNo = value; }
        }
        public string MachinePartsId
        {
            get { return strMachinePartsId; }
            set { strMachinePartsId = value; }
        }

        public string MachineParts
        {
            get { return strMachineParts; }
            set { strMachineParts = value; }
        }
        public string MachinelId
        {
            get { return strMachinelId; }
            set { strMachinelId = value; }
        }

        public string MachineName
        {
            get { return strMachineName; }
            set { strMachineName = value; }
        }
       
        public string MachineModelId
        {
            get { return strMachineModelId; }
            set { strMachineModelId = value; }
        }

        public string MachineModelCode
        {
            get { return strMachineModelCode; }
            set { strMachineModelCode = value; }
        }

        public string MachineModelName
        {
            get { return strMachineModelName; }
            set { strMachineModelName = value; }
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
