using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class StyleDTO
    {

        private string strBuyerId;
        private string strBuyerCode;
        private string strStyleId;
        private string strStyleCode;
        private string strStyleNo;
        private string strStyleDes;
        private string strActiveYn;
        private string strUpdateBy;
        private string strHeadOfficeId;
        private string strBranchOfficeId;

        public string BuyerId
        {

            get { return strBuyerId; }
            set { strBuyerId = value; }

        }

        public string BuyerCode
        {

            get { return strBuyerCode; }
            set { strBuyerCode = value; }

        }

        public string styleId
        {

            get { return strStyleId; }
            set { strStyleId = value; }

        }
        public string styleNo
        {

            get { return strStyleNo; }
            set { strStyleNo = value; }

        }

        public string styleCode
        {

            get { return strStyleCode; }
            set { strStyleCode = value; }

        }

        public string StyleDes
        {

            get { return strStyleDes; }
            set { strStyleDes = value; }

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
