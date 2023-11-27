using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class PurchaseDTO
    {


        private string strInvoiceNo;
        private string strSLNo;
        private string strRequisitionNo;
        private string strRequisitionDate;
        private string strMRRNo;
        private string strMRRDate;
        private string strPurchaseDate;
        private string strPrice;
        private string strProductionDescription;
        private string strWarrantyPeriod;
        private string strSupplierName;
        private string strRemarks;
        private string strQuantity;
        private string strEmployeeId;
        private string strUnitId;
        private string strSectionId;
        private string strFileExistsYn;
        private string strLedgerNo;
        private string strTranId;
        private string strProductId;
        private string strEmployeeName;
        private string strCardNo;
        private string strDesignationName;

        private string strHeadOfficeId;
        private string strBranchOfficeId;
        private string strUpdateBy;

        private string strFileName;
        private string strFileSize;
        private string strEmpName;



        public string EmpName
        {
            get { return strEmpName; }
            set { strEmpName = value; }
        }

        public string FileName
        {
            get { return strFileName; }
            set { strFileName = value; }
        }

        public string FileSize
        {
            get { return strFileSize; }
            set { strFileSize = value; }
        }

        public string DesignationName
        {
            get { return strDesignationName; }
            set { strDesignationName = value; }
        }
        public string CardNo
        {
            get { return strCardNo; }
            set { strCardNo = value; }
        }

        public string EmployeeName
        {
            get { return strEmployeeName; }
            set { strEmployeeName = value; }
        }
        public string ProductId
        {
            get { return strProductId; }
            set { strProductId = value; }
        }
        public string TranId
        {
            get { return strTranId; }
            set { strTranId = value; }
        }

        public string LedgerNo
        {
            get { return strLedgerNo; }
            set { strLedgerNo = value; }
        }
        public string FileExistsYn
        {
            get { return strFileExistsYn; }
            set { strFileExistsYn = value; }
        }
        public string InvoiceNo
        {
            get { return strInvoiceNo; }
            set { strInvoiceNo = value; } 
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

        public string RequisitionDate
        {
            get { return strRequisitionDate; }
            set { strRequisitionDate = value; }
        }


        public string MRRNo
        {
            get { return strMRRNo; }
            set { strMRRNo = value; }
        }

        public string MRRDate
        {
            get { return strMRRDate; }
            set { strMRRDate = value; }
        }

        public string PurchaseDate
        {
            get { return strPurchaseDate; }
            set { strPurchaseDate = value; }
        }


        public string Price
        {
            get { return strPrice; }
            set { strPrice = value; }
        }


        public string ProductionDescription
        {
            get { return strProductionDescription; }
            set { strProductionDescription = value; }
        }

        public string WarrantyPeriod
        {
            get { return strWarrantyPeriod; }
            set { strWarrantyPeriod = value; }
        }

        public string SupplierName
        {
            get { return strSupplierName; }
            set { strSupplierName = value; }
        }

        public string Remarks
        {
            get { return strRemarks; }
            set { strRemarks = value; }
        }


        public string Quantity
        {
            get { return strQuantity; }
            set { strQuantity = value; }
        }

        public string EmployeeId
        {
            get { return strEmployeeId; }
            set { strEmployeeId = value; }
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
