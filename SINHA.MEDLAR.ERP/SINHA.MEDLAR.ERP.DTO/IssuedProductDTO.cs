using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class IssuedProductDTO
    {
        private string strEmployeeId;     
        private string strHeadOfficeId;
        private string strBranchOfficeId;
        private string strUpdateBy;

        private string strOpeningBlance;
        private string strIssuedQty;
        private string strIssuedDate;
        private string strSectionId;
        private string strIssuedInFavor;
        private string strRemarks;
        private string strTranId;
        private string strPartNo;
        private string strTranDate;
        private string strTranYear;
        private string strTranMonth;
        private string strStockYn;
        private string strYear;
        private string strMonth;

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
        public string StockYn
        {
            get { return strStockYn; }
            set { strStockYn = value; }
        }
        public string TranYear
        {
            get { return strTranYear; }
            set { strTranYear = value; }
        }
        public string TranMonth
        {
            get { return strTranMonth; }
            set { strTranMonth = value; }
        }
        public string TranDate
        {
            get { return strTranDate; }
            set { strTranDate = value; }
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
        public string IssuedQty
        {
            get { return strIssuedQty; }
            set { strIssuedQty = value; }
        }
        public string IssuedDate
        {
            get { return strIssuedDate; }
            set { strIssuedDate = value; }
        }
        public string SectionId
        {
            get { return strSectionId; }
            set { strSectionId = value; }
        }
        public string IssuedInFavor
        {
            get { return strIssuedInFavor; }
            set { strIssuedInFavor = value; }
        }
        public string Remarks
        {
            get { return strRemarks; }
            set { strRemarks = value; }
        }
        public string OpeningBlance
        {
            get { return strOpeningBlance; }
            set { strOpeningBlance = value; }
        }
        public string EmployeeId
        {
            get { return strEmployeeId; }
            set { strEmployeeId = value; }

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
