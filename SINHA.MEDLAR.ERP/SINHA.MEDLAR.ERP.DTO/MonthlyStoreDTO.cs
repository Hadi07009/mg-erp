using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class MonthlyStoreDTO
    {


        private string strTranId;
        private string strEquipementId;
        private string strPartId;
        private string strOpeningStock;
        private string strReceivedBlance;
        private string strTotalBlance;
        private string strIssuedQuantity;
        private string strClosingBlance;
        private string strUpdateBy;
        private string strHeadOfficeId;
        private string strBranchOfficeId;
        private string strPartNo;
        private string strYear;
        private string strMonth;
        private string strBeginingStock;
        private string strStockYn;
        private string strSupplierId;
        private string strInvoiceNo;
        private string strInvoiceIssueDate;
        private string strIssueDate;
        private string strStockAfterAddition;
        private string strSparePartId;
        private string strStartTranMonth;
        private string strStartTranYear;

        public string StartTranYear
        {
            get { return strStartTranYear; }
            set { strStartTranYear = value; }

        }
        public string StartTranMonth
        {
            get { return strStartTranMonth; }
            set { strStartTranMonth = value; }

        }
        public string SparePartId
        {
            get { return strSparePartId; }
            set { strSparePartId = value; }

        }
        public string StockAfterAddition
        {
            get { return strStockAfterAddition; }
            set { strStockAfterAddition = value; }

        }
        public string IssueDate
        {
            get { return strIssueDate; }
            set { strIssueDate = value; }

        }
        public string InvoiceIssueDate
        {
            get { return strInvoiceIssueDate; }
            set { strInvoiceIssueDate = value; }

        }
        public string InvoiceNo
        {
            get { return strInvoiceNo; }
            set { strInvoiceNo = value; }

        }
        public string SupplierId
        {
            get { return strSupplierId; }
            set { strSupplierId = value; }

        }

        public string StockYn
        {
            get { return strStockYn; }
            set { strStockYn = value; }

        }

        public string BeginingStock
        {
            get { return strBeginingStock; }
            set { strBeginingStock = value; }

        }
        public string PartNo
        {
            get { return strPartNo; }
            set { strPartNo = value; }

        }

        public string TranId
        {
            get { return strTranId; }
            set { strTranId = value; }

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

        public string OpeningStock
        {
            get { return strOpeningStock; }
            set { strOpeningStock = value; }

        }


        public string ReceivedBlance
        {
            get { return strReceivedBlance; }
            set { strReceivedBlance = value; }

        }


        public string TotalBlance
        {
            get { return strTotalBlance; }
            set { strTotalBlance = value; }

        }


        public string IssuedQuantity
        {
            get { return strIssuedQuantity; }
            set { strIssuedQuantity = value; }

        }

        public string ClosingBlance
        {
            get { return strClosingBlance; }
            set { strClosingBlance = value; }

        }

        public string UpdateBy
        {
            get { return strUpdateBy; }
            set { strUpdateBy = value; }

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

    }
}
