using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SINHA.MEDLAR.ERP.DTO
{
    public class BuyerPODTO
    {


        private string strPONo;
        private string strBuyerId;
        private string strStyleId;
        private string strColorId;
        private string strDeliveryDate;
        private string strOrderDate;
        private string strOrderQuantity;

        private string strFromDate;
        private string strToDate;
        private string strSize;
        private string strQuantity;
        private string strPOsearchNo;





        private string strHeadOfficeId;
        private string strBranchOfficeId;
        private string strUpdateBy;


        public string POSearchNo
        {

            get { return strPOsearchNo; }
            set { strPOsearchNo = value; }

        }

        public string Quantity
        {

            get { return strQuantity; }
            set { strQuantity = value; }

        }
        public string Size
        {

            get { return strSize; }
            set { strSize = value; }

        }

        public string FromDate
        {

            get { return strFromDate; }
            set { strFromDate = value; }

        }

        public string ToDate
        {

            get { return strToDate; }
            set { strToDate = value; }

        }


        public string PONo
        {

            get { return strPONo;}
            set { strPONo = value; } 

        }

        public string BuyerId
        {

            get { return strBuyerId; }
            set { strBuyerId = value; }

        }

        public string StyleId
        {

            get { return strStyleId; }
            set { strStyleId = value; }

        }

        public string ColorId
        {

            get { return strColorId; }
            set { strColorId = value; }

        }


        public string DeliveryDate
        {

            get { return strDeliveryDate; }
            set { strDeliveryDate = value; }

        }

        public string OrderDate
        {

            get { return strOrderDate; }
            set { strOrderDate = value; }

        }

        public string OrderQuantity
        {

            get { return strOrderQuantity; }
            set { strOrderQuantity = value; }

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
