using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class POAssignDTO
    {

        private string strPONo;
        private string strStyleNo;
        private string strLineId;
        private string strTranId;


        private string strUpdateBy;
        private string strUpdateDate;
        private string strHeadOfficeId;
        private string strHeadOfficeName;
        private string strBranchOfficeId;
        private string strBranchOfficeName;
        private string strFactoryId;
        private string strPOId;
        private string strStyleId;

        public string StyleId
        {
            get { return strStyleId; }
            set { strStyleId = value; }
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
        public string TranId
        {
            get { return strTranId; }
            set { strTranId = value; }

        }
        public string PONo
        {
            get { return strPONo; }
            set { strPONo = value; }

        }

        public string StyleNo
        {
            get { return strStyleNo; }
            set { strStyleNo = value; }

        }

        public string LineId
        {
            get { return strLineId; }
            set { strLineId = value; }

        }

        public string UpdateBy
        {
            get { return strUpdateBy; }
            set { strUpdateBy = value; }

        }

        public string UpdateDate
        {
            get { return strUpdateDate; }
            set { strUpdateDate = value; }

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


        public string BranchOfficeId
        {
            get { return strBranchOfficeId; }
            set { strBranchOfficeId = value; }

        }
        public string BranchOfficeName
        {
            get { return strBranchOfficeName; }
            set { strBranchOfficeName = value; }

        }






    }
}
