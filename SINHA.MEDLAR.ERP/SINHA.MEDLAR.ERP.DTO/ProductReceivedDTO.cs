using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class ProductReceivedDTO
    {
        private string strEmployeeId;     
        private string strHeadOfficeId;
        private string strBranchOfficeId;
        private string strUpdateBy;

        private string strMRRNo;
        private string strPartNo;
        private string strRequiredQty;
        private string strApprovedQty;
        private string strReceivedDate;
        private string strRequisitionNo;
        private string strPartNoSrc;
        private string strReceivedQty;
        private string strTranId;

        public string TranId
        {
            get { return strTranId; }
            set { strTranId = value; }
        }
        public string ReceivedQty
        {
            get { return strReceivedQty; }
            set { strReceivedQty = value; }

        }
        public string PartNoSrc
        {
            get { return strPartNoSrc; }
            set { strPartNoSrc = value; }

        }
        public string RequisitionNo
        {
            get { return strRequisitionNo; }
            set { strRequisitionNo = value; }

        }
        public string MRRNo
        {
            get { return strMRRNo; }
            set { strMRRNo = value; }

        }
        public string PartNo
        {
            get { return strPartNo; }
            set { strPartNo = value; }

        }
        public string RequiredQty
        {
            get { return strRequiredQty; }
            set { strRequiredQty = value; }

        }
        public string ApprovedQty
        {
            get { return strApprovedQty; }
            set { strApprovedQty = value; }

        }
        public string ReceivedDate
        {
            get { return strReceivedDate; }
            set { strReceivedDate = value; }

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
