using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class PoDocumentsDTO
    {

        public string strUpdateBy;
        public string strHeadOfficeId;
        public string strBranchOfficeId;

        private string strTranId;
        private string strRequisitionNo;
        private string strDocumentName;
        private string strPoNumber;
        public string PoNumber
        {
            get { return strPoNumber; }
            set { strPoNumber = value; }
        }
        public string RequisitionNo
        {
            get { return strRequisitionNo; }
            set { strRequisitionNo = value; }
        }
        public string DocumentName
        {
            get { return strDocumentName; }
            set { strDocumentName = value; }
        }
        public string TranId
        {
            get { return strTranId; }
            set { strTranId = value; }
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
