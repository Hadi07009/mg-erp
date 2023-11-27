using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class POTypeDTO
    {
        private string strPOTypeId;
        private string strPOTypeCode;
        private string strPOTypeName;
        private string strActiveYn;
        private string strUpdateBy;
        private string strHeadOfficeId;
        private string strBranchOfficeId;



        public string POTypeId
        {
            get { return strPOTypeId; }
            set { strPOTypeId = value; } 

        }

        public string POTypeCode
        {
            get { return strPOTypeCode; }
            set { strPOTypeCode = value; }

        }

        public string POTypeName
        {
            get { return strPOTypeName; }
            set { strPOTypeName = value; }

        }

        public string ActiveYn
        {
            get { return strActiveYn; }
            set { strActiveYn = value; }

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
