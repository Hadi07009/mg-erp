using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class ColorDTO
    {


        private string strColorId;
        private string strColorCode;
        private string strBuyerId;
        private string strBuyerCode;
        private string strColorShortName;
        private string strColorFullName;
        private string strActiveYn;
        private string strUpdateBy;
        private string strUpdateDate;
        private string strHeadOfficeId;
        private string strBranchOfficeId;
        private string strColorName;

        public string ColorName
        {

            get { return strColorName; }
            set { strColorName = value; }
        }
        public string ColorId
        {

            get { return strColorId; }
            set { strColorId = value;} 
        }
        public string ColorCode
        {

            get { return strColorCode; }
            set { strColorCode = value; }
        }
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


        public string ColorShortName
        {

            get { return strColorShortName; }
            set { strColorShortName = value; }
        }

        public string ColorFullName
        {

            get { return strColorFullName; }
            set { strColorFullName = value; }
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

        public string BranchOfficeId
        {

            get { return strBranchOfficeId; }
            set { strBranchOfficeId = value; }
        }

    }
}
